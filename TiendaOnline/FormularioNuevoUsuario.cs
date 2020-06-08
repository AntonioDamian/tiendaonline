using Capa_entidades;
using Capa_negocio;
using MiLibreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TiendaOnline
{
    public partial class FormularioNuevoUsuario : Form
    {
        Negocio neg;
        NegocioLocalidad negLocalidad;
        NegocioProvincia negProvincia;
        public static Usuario usuario;

        int usuID;

      
        List<Usuario> _listaUsuarios;
        DataTable dt = new DataTable();
        private int indice;

        public string usuarioId { get; set; }

        // ErrorProvider
        private ErrorProvider errorProvider;


        private bool emailValido = false;
        private bool pasvalido = false;
        private bool repasvalido = false;
        private bool nombreValido = false;
        private bool apellidosValidos = false;
        private bool dniValido = false;
        private bool codigoPos = false;
        private bool puebloIdValido = false;
        private bool provinciaidValido = false;
        private bool fechaNacimientoValido = false;

        public FormularioNuevoUsuario()
        {
            InitializeComponent();
            neg = new Negocio();
            negLocalidad = new NegocioLocalidad();
            negProvincia = new NegocioProvincia();

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            usuario = new Usuario();        


        }

      


        private void FormularioNuevoUsuario_Load(object sender, EventArgs e)
        {
            DataTable dictionarylocalidades = negLocalidad.TablaLocalidades();
            comboPueblo.DataSource = new BindingSource(dictionarylocalidades, null);
            comboPueblo.ValueMember = "localidadID";
            comboPueblo.DisplayMember = "nombre";

            DataTable dictionaryProvincias = negProvincia.TablaProvincias();
            comboProvincia.DataSource = new BindingSource(dictionaryProvincias, null);
            comboProvincia.ValueMember = "ProvinciaID";
            comboProvincia.DisplayMember = "nombre";

            if (Text == "formularioNuevoUsuario")
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnRegistrar.Text = "Registrar";
                lbusuario.Enabled = false;
                lbUsuarioID.Enabled = false;
            }

            txtBusqueda.Enabled = false;
            txtBusqueda.Visible = false;

            btnBuscar.Enabled = false;


            errorProvider.ContainerControl = this;

        }

        




        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("Correo electrónico", txtEmail.Text, 50, true);
            string patronMailValido = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            if (!Regex.IsMatch(txtEmail.Text, patronMailValido))
            {
                mensajesErrores += "El formato del Correo electrónico no es correcto" + Environment.NewLine;
                errorProvider.SetError(txtEmail, mensajesErrores);
                emailValido = false;
            }
            else
            {
                errorProvider.SetError(txtEmail, "");
                emailValido = true;
            }
        }

        private void Txtpass_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("Contraseña", txtpass.Text, 32, true);

            if (string.IsNullOrEmpty(txtpass.Text))
            {
                errorProvider.SetError(txtpass, "");
                pasvalido = true;
            }
            else if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtpass, mensajesErrores);
                pasvalido = false;
            }
            else
            {
                // Mínimo de 8 caracteres al menos 1 alfabeto en mayúsculas, 1 alfabeto en minúsculas, 1 número y 1 carácter especial:

                //"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"

                // string patronContrasenyaValido = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{3,})$$";
                // string patronContrasenyaValido = "^(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[$@$!%*?&])[A-Za-z[0-9]$@$!%*?&]{3,32}";
                // "La contraseña debe tener al menos una letra minúscula, una mayúscula y un número";
                Regex expresion = new Regex(@"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])");
                string patronContrasenyaValido = @"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])";

                if (!Regex.IsMatch(txtpass.Text, patronContrasenyaValido))
                {
                    mensajesErrores = "El formato de la contraseña no es correcto" + Environment.NewLine;
                    errorProvider.SetError(txtpass, mensajesErrores);
                    pasvalido = false;
                }


                else
                {
                    errorProvider.SetError(txtpass, "");
                    pasvalido = true;
                }
            }
        }

        private void TxtRepPass_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("Confirmar contraseña", txtRepPass.Text, 32, true);
            if (!txtpass.Text.Equals(txtRepPass.Text))
            {
                errorProvider.SetError(txtRepPass, "Ambas constraseñas deben ser iguales");
                repasvalido = false;
            }
            else if (string.IsNullOrEmpty(txtRepPass.Text))
            {
                errorProvider.SetError(txtRepPass, "");
                repasvalido = true;
            }
            else if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtRepPass, mensajesErrores);
                repasvalido = false;
            }

            else
            {


                {
                    errorProvider.SetError(txtRepPass, "");
                    repasvalido = true;
                }
            }
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("Nombre", txtNombre.Text, 35, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtNombre, mensajesErrores);
                nombreValido = false;
            }
            else
            {
                errorProvider.SetError(txtNombre, "");
                nombreValido = true;
            }
        }

        private void TxtApellidos_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("Apellidos", txtApellidos.Text, 55, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtApellidos, mensajesErrores);
                apellidosValidos = false;
            }
            else
            {
                errorProvider.SetError(txtApellidos, "");
                apellidosValidos = true;
            }
        }

        private void TxtDni_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("DNI", txtDni.Text, 9, true);
            string patronNIFValido = "^([0-9]{8}[A-Z]{1})|[XYZ][0-9]{7}[A-Z]{1}$";
            if (!"".Equals(mensajesErrores) || !Regex.IsMatch(txtDni.Text, patronNIFValido))
            {
                mensajesErrores += "El formato del DNI no es correcto" + Environment.NewLine;
                errorProvider.SetError(txtDni, mensajesErrores);
                dniValido = false;
            }
            else
            {
                // Calculamos la letra del documento
                string numeroDNI = "";
                if (txtDni.Text.StartsWith("X"))
                    numeroDNI = 0 + txtDni.Text.Substring(1, 7);
                else if (txtDni.Text.StartsWith("Y"))
                    numeroDNI = 1 + txtDni.Text.Substring(1, 7);
                else if (txtDni.Text.StartsWith("Z"))
                    numeroDNI = 2 + txtDni.Text.Substring(1, 7);
                else
                    numeroDNI = txtDni.Text.Substring(0, 8);

                string letraNIF = "TRWAGMYFPDXBNJZSQVHLCKE";
                int posicionLetra = Int32.Parse(numeroDNI) % 23;

                if (!letraNIF[posicionLetra].Equals(txtDni.Text[8]))
                {
                    errorProvider.SetError(txtDni, "Introduce un DNI o un DNI válido");
                    dniValido = false;
                }
                else
                {
                    errorProvider.SetError(txtDni, "");
                    dniValido = true;
                }
            }
        }


        private void TxtCodPOs_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("codpos", txtCodPOs.Text, 5, true);

            if (mensajesErrores.Equals(""))
            {
                errorProvider.SetError(txtCodPOs, "");
                codigoPos = true;
            }
            else if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtCodPOs, mensajesErrores);
                codigoPos = false;
            }
            else if (txtCodPOs.Text == string.Empty)
            {
                errorProvider.SetError(txtCodPOs, "");
                codigoPos = true;
            }

        }

        private void ComboPueblo_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("Pueblo", comboPueblo.Text, 100, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(comboPueblo, mensajesErrores);
                puebloIdValido = false;
            }
            else
            {
                errorProvider.SetError(comboPueblo, "");
                puebloIdValido = true;
            }
        }

        private void ComboProvincia_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = Utilidades.ValidaCadena("Provincia", comboProvincia.Text, 100, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(comboProvincia, mensajesErrores);
                provinciaidValido = false;
            }
            else
            {
                errorProvider.SetError(comboProvincia, "");
                provinciaidValido = true;
            }
        }

        private void DateTimePickerNacido_Leave(object sender, EventArgs e)
        {
            string mensajesErrores = "La fecha de alta no puede ser mayor que la actual" + Environment.NewLine;
            try
            {
                if (dateTimePickerNacido.Value.Date > DateTime.Now.Date)
                {
                    errorProvider.SetError(dateTimePickerNacido, mensajesErrores);
                    fechaNacimientoValido = false;
                }
                else
                {
                    errorProvider.SetError(dateTimePickerNacido, "");
                    fechaNacimientoValido = true;
                }
            }
            catch (FormatException)
            {
                errorProvider.SetError(dateTimePickerNacido, "La fecha seleccionada no es válida" + Environment.NewLine);
                fechaNacimientoValido = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)

            {

                if (c is TextBox)

                {

                    c.Text = "";

                    //Enfoco en el primer TextBox

                    this.txtEmail.Focus();

                }

            }

            comboPueblo.SelectedIndex = -1;
            comboProvincia.SelectedIndex = -1;
            maskedTextTelefono.Text = "";

        }


        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            TxtEmail_Leave(null, null);
            Txtpass_Leave(null, null);
            TxtRepPass_Leave(null, null);
            TxtNombre_Leave(null, null);
            TxtApellidos_Leave(null, null);
            TxtDni_Leave(null, null);
            TxtCodPOs_Leave(null, null);
            ComboPueblo_Leave(null, null);
            ComboProvincia_Leave(null, null);
            DateTimePickerNacido_Leave(null, null);

            // string codigoLocalidad = comboPueblo.SelectedValue.ToString();
            //  string codigoProvincia = comboProvincia.SelectedValue.ToString();

            if (emailValido && pasvalido && repasvalido && nombreValido && apellidosValidos && dniValido &&
                 puebloIdValido && provinciaidValido && fechaNacimientoValido && codigoPos)
            {
                bool añadido = false;

                string passMD5 = NegocioUsuario.ConvertirContrasenyaMD5(txtpass.Text);

                string codigoLocalidad = comboPueblo.SelectedValue.ToString();
                string codigoProvincia = comboProvincia.SelectedValue.ToString();

                if (btnRegistrar.Text == "Registrar")
                {
                    añadido = neg.Nuevo(txtEmail.Text, passMD5, txtNombre.Text, txtApellidos.Text, txtDni.Text, maskedTextTelefono.Text, txtCalle.Text, txtCalle2.Text, txtCodPOs.Text, codigoLocalidad, codigoProvincia, dateTimePickerNacido.Value);

                }
                else if (btnRegistrar.Text == "Actualizar")
                {
                    añadido = neg.Actualizar(new Usuario(usuario.UsuarioID, txtEmail.Text, passMD5, txtNombre.Text, txtApellidos.Text, txtDni.Text, maskedTextTelefono.Text, txtCalle.Text, txtCalle2.Text, txtCodPOs.Text, codigoLocalidad, codigoProvincia, dateTimePickerNacido.Value));


                }

                if (añadido)
                {
                    MessageBox.Show("Todos los datos introducidos son correctos");
                }
                else
                {
                    MessageBox.Show("ERROR,no se han podido introducir los datos");

                    txtEmail.Text = "";
                    txtpass.Text = "";
                    txtRepPass.Text = "";
                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtDni.Text = "";
                    maskedTextTelefono.Text = "";
                    txtCalle.Text = "";
                    txtCalle2.Text = "";
                    txtCodPOs.Text = "";
                    comboPueblo.SelectedIndex = -1;
                    comboProvincia.SelectedIndex = -1;
                }
            }


        }

      

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _listaUsuarios = new List<Usuario>();
            _listaUsuarios = neg.ObtenerUsuarios();

            /*  DataColumn nomApellido = dt.Columns.Add("NomApellido", typeof(string));

              foreach (DataRow data in dt.Rows)
              {

                  data["NomApellido"] = data["nombre"].ToString() + " " + data["apellidos"].ToString();
              }*/


            dt = Utilidades.ConvertToDataTable(_listaUsuarios);
            dt.DefaultView.Sort = "UsuarioID";

            dataGridViewUsuarios.DataSource = dt;
            // dataGridViewUsuarios.Columns["NomApellido"].Visible = false;

            txtBusqueda.Enabled = false;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusqueda.Text.Trim()) == false)
            {


                if (rbNombre.Checked == true)
                {
                    lbApellido.Visible = true;
                    txtApellido.Enabled = true;
                    txtApellido.Visible = true;

                    dt.DefaultView.RowFilter = $"nombre like'{txtBusqueda.Text.Trim()}%'";

                    //dt.DefaultView.RowFilter = $"nomApellido like'{txtBusqueda.Text}%'";
                }
                if (rbDni.Checked == true)
                {
                    dt.DefaultView.RowFilter = $"Dni like'{txtBusqueda.Text}%'";
                }

                if (rbemail.Checked == true)
                {
                    dt.DefaultView.RowFilter = $"Email like'{txtBusqueda.Text}%'";
                }

            }
            else
            {
                dataGridViewUsuarios.DataSource = dt;
                txtBusqueda.Text = "";
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"apellidos like'{txtApellido.Text.Trim()}%'";
        }

        private void dataGridViewUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DevolverUsuario();
        }

        private void DevolverUsuario()
        {
           

            DateTime? Fecha = dataGridViewUsuarios.SelectedRows[0].Cells[12].Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataGridViewUsuarios.SelectedRows[0].Cells[12].Value);


            Usuario usuario = new Usuario(int.Parse(dataGridViewUsuarios.SelectedRows[0].Cells[0].Value.ToString()),
                dataGridViewUsuarios.SelectedRows[0].Cells[1].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[2].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[3].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[4].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[5].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[6].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[7].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[8].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[9].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[10].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[11].Value.ToString(),
                Fecha);


            lbusuario.Enabled = true;
            lbUsuarioID.Enabled = true;
            btnRegistrar.Enabled = false;
            btnRegistrar.Text = "Actualizar";
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;


            lbUsuarioID.Text = usuario.UsuarioID.ToString();
            txtEmail.Text = usuario.Email;
            txtpass.Text = usuario.Password;
            txtRepPass.Text = usuario.Password;
            txtNombre.Text = usuario.Nombre;
            txtApellidos.Text = usuario.Apellidos;
            txtDni.Text = usuario.Dni;
            if (usuario.Telefono.Length == 9)
            {

                maskedTextTelefono.Text = usuario.Telefono;

                maskedTextTelefono.Text =
                    maskedTextTelefono.Text.PadLeft(12, '0');
                // maskedTextTelefono.PromptChar = '0';

            }
            else
            {
                maskedTextTelefono.Text = usuario.Telefono;
            }

            txtCalle.Text = usuario.Calle;
            txtCalle2.Text = usuario.Calle2;
            txtCodPOs.Text = usuario.Codpos;
            comboPueblo.SelectedValue = usuario.PuebloID;
            comboProvincia.SelectedValue = usuario.ProvinciaID;
            if (usuario.Nacido == null)
            {

                dateTimePickerNacido.Format = DateTimePickerFormat.Custom;
                dateTimePickerNacido.CustomFormat = " ";
            }
            else
            {
                dateTimePickerNacido.Value = Convert.ToDateTime(usuario.Nacido);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
