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

        DataTable dictionarylocalidades;
        DataTable dictionaryProvincias;


        List<Usuario> _listaUsuarios;
        DataTable dt = new DataTable();
      

        public string usuarioId { get; set; }

        // ErrorProvider
        private ErrorProvider errorProvider;
      
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
            dictionarylocalidades = negLocalidad.TablaLocalidades();
            comboPueblo.DataSource = new BindingSource(dictionarylocalidades, null);
            comboPueblo.ValueMember = "localidadID";
            comboPueblo.DisplayMember = "nombre";

            dictionaryProvincias = negProvincia.TablaProvincias();
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
            bool bValidarEmail = ValidarEmail();
            bool bValidarPass =ValidarPass();
            bool bValidarRepPass = ValidarRePass();
            bool bValidarNombre = ValidarNombre();
            bool bValidarApellidos= ValidarApellidos();
            bool bValidarDni =ValidarDni();
            bool bValidarCodPOs = ValidarCodpos(); ;
            bool bValidarComboPueblo = ValidarComboPueblo();
            bool bValidarComboProvincia =ValidarComboProvincia();
            bool bValidarDateTimePickerNacido = ValidarDateTimePickerNacido();

          

            if (bValidarEmail && bValidarPass && bValidarRepPass && bValidarNombre && bValidarApellidos && bValidarDni && bValidarCodPOs && bValidarComboPueblo
                && bValidarComboProvincia && bValidarDateTimePickerNacido)
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
            btnBuscar.Enabled = true;
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
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

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
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

        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"apellidos like'{txtApellido.Text.Trim()}%'";
        }

        private void DataGridViewUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void TxtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            ValidarEmail();
        }

        private void Txtpass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarPass();
        }

        private void TxtRepPass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarRePass();
        }

        private void TxtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarNombre();
        }

        private void TxtApellidos_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarApellidos();
        }

        private void TxtDni_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarDni();
        }

        private void TxtCalle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarCalle();
        }

        private void TxtCalle2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarCalle2();
        }

        private void TxtCodPOs_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarCodpos();
        }

        private void ComboPueblo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarComboPueblo();
        }

        private void ComboProvincia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarComboProvincia();
        }

        private void dateTimePickerNacido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidarDateTimePickerNacido();
        }

        private bool ValidarEmail()
        {
            bool bStatus = true;

            string mensajesErrores = Utilidades.ValidaCadena("Correo electrónico", txtEmail.Text, 50, true);
            string patronMailValido = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";

            if (!Regex.IsMatch(txtEmail.Text, patronMailValido))
            {
                mensajesErrores += "El formato del Correo electrónico no es correcto" + Environment.NewLine;
                errorProvider.SetError(txtEmail, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorProvider.SetError(txtEmail, "");
                bStatus = true;
            }

            return bStatus;
        }

        private bool ValidarPass()
        {

            bool bStatus = true;
            string mensajesErrores = Utilidades.ValidaCadena("Contraseña", txtpass.Text, 32, true);

            if (string.IsNullOrEmpty(txtpass.Text))
            {
                errorProvider.SetError(txtpass, "");
                bStatus = true;
            }
            else if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtpass, mensajesErrores);
                bStatus = false;
            }
            else
            {

                //La	 contraseñ a	 deberá	 tener	 una	 complejidad	 de	 al	 menos	 1	 número, una	
                // mayúscula y   un carácter   no alfanumérico
              

               
                string patronContrasenyaValido =(@"[A-Z0-9!@#\$%\^&\*\?_~\/]{8,}$");



                if (!Regex.IsMatch(txtpass.Text, patronContrasenyaValido))
                {
                    mensajesErrores = "El formato de la contraseña no es correcto" +
                        ", deberá tener una complejidad de al menos 1 número, una mayúscula y un carácter no alfanumérico" + Environment.NewLine;
                    errorProvider.SetError(txtpass, mensajesErrores);
                    bStatus = false;
                }


                else
                {
                    errorProvider.SetError(txtpass, "");
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private bool ValidarRePass()
        {
            bool bStatus = true;

            string mensajesErrores = Utilidades.ValidaCadena("Confirmar contraseña", txtRepPass.Text, 32, true);
            if (!txtpass.Text.Equals(txtRepPass.Text))
            {
                errorProvider.SetError(txtRepPass, "Ambas constraseñas deben ser iguales");
                bStatus = false;
            }
            else if (string.IsNullOrEmpty(txtRepPass.Text))
            {
                errorProvider.SetError(txtRepPass, "");
                bStatus = true;
            }
            else if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtRepPass, mensajesErrores);
                bStatus = false;
            }

            else
            {
                {
                    errorProvider.SetError(txtRepPass, "");
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private bool ValidarNombre()
        {
            bool bStatus = true;

            string mensajesErrores = Utilidades.ValidaCadena("Nombre", txtNombre.Text, 35, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtNombre, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorProvider.SetError(txtNombre, "");
                bStatus = true;
            }

            return bStatus;
        }

        private bool ValidarApellidos()
        {
            bool bStatus = true;
            string mensajesErrores = Utilidades.ValidaCadena("Apellidos", txtApellidos.Text, 55, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(txtApellidos, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorProvider.SetError(txtApellidos, "");
                bStatus = true;

            }
            return bStatus;
        }

        private bool ValidarDni()
        {
            bool bStatus = true;

            string mensajesErrores = Utilidades.ValidaCadena("DNI", txtDni.Text, 9, true);
            string patronNIFValido = "^([0-9]{8}[A-Z]{1})|[XYZ][0-9]{7}[A-Z]{1}$";
            if (!"".Equals(mensajesErrores) || !Regex.IsMatch(txtDni.Text, patronNIFValido))
            {
                mensajesErrores += "El formato del DNI no es correcto" + Environment.NewLine;
                errorProvider.SetError(txtDni, mensajesErrores);
                bStatus = false;
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
                    bStatus = false;
                }
                else
                {
                    errorProvider.SetError(txtDni, "");
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private void maskedTextTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if(maskedTextTelefono.Text.Length==0)
            {
                maskedTextTelefono.Text = null;
            }
            errorProvider.SetError(maskedTextTelefono, "Error al introducir los datos del telefono");
        }

        private bool ValidarCalle()
        {
            bool bStatus = true;
            if (!string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                string mensajesErrores = Utilidades.ValidaCadena("Calle", txtCalle.Text, 45, true);

                if (!"".Equals(mensajesErrores))
                {
                    errorProvider.SetError(txtCalle, mensajesErrores);
                    bStatus = false;
                }
                else
                {
                    errorProvider.SetError(txtCalle, "");
                    bStatus = true;
                }
            }
            else
            {
                errorProvider.SetError(txtCalle, "");
                bStatus = true;
            }


            return bStatus;
        }

        private bool ValidarCalle2()
        {
            bool bStatus = true;
            if (!string.IsNullOrWhiteSpace(txtCalle2.Text))
            {
                string mensajesErrores = Utilidades.ValidaCadena("Calle", txtCalle2.Text, 45, true);

                if (!"".Equals(mensajesErrores))
                {
                    errorProvider.SetError(txtCalle2, mensajesErrores);
                    bStatus = false;
                }
                else
                {
                    errorProvider.SetError(txtCalle2, "");
                    bStatus = true;
                }
            }
            else
            {
                errorProvider.SetError(txtCalle2, "");
                bStatus = true;
            }


            return bStatus;
        }

        private bool ValidarCodpos()
        {
            bool bStatus = true;
            if (!string.IsNullOrWhiteSpace(txtCodPOs.Text))
            {
                string mensajesErrores = Utilidades.ValidaCadena("codpos", txtCodPOs.Text, 5, true);

                if (mensajesErrores.Equals(""))
                {
                    errorProvider.SetError(txtCodPOs, "");
                    bStatus = true;

                 /*  DataTable dt= dictionarylocalidades.Select("localidadId ='"+txtCodPOs.Text+"'").CopyToDataTable();

                    DataTable tblFiltered = dictionarylocalidades.AsEnumerable()
                                             .Where(row => row.Field<String>("localidadId") == txtCodPOs.Text)                                                
                                                .OrderBy(row => row.Field<String>("nombre"))
                                             .CopyToDataTable();
                    comboPueblo.DataSource = new BindingSource(dt, null);
                    comboPueblo.ValueMember = "localidadID";
                    comboPueblo.DisplayMember = "nombre";*/

                }
                else if (!"".Equals(mensajesErrores))
                {
                    errorProvider.SetError(txtCodPOs, mensajesErrores);
                    bStatus = false;
                }
            }
           
            else
            {
                errorProvider.SetError(txtCodPOs, "");
                bStatus = true;
            }

            return bStatus;

        }

        private bool ValidarComboPueblo()
        {
            bool bStatus = true;
            string mensajesErrores = Utilidades.ValidaCadena("Pueblo", comboPueblo.Text, 100, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(comboPueblo, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorProvider.SetError(comboPueblo, "");
                bStatus = true;

               
            }

            return bStatus;
        }

        private bool ValidarComboProvincia()
        {
            bool bStatus = true;
            string mensajesErrores = Utilidades.ValidaCadena("Provincia", comboProvincia.Text, 100, true);

            if (!"".Equals(mensajesErrores))
            {
                errorProvider.SetError(comboProvincia, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorProvider.SetError(comboProvincia, "");
                bStatus = true;
            }

            return bStatus;
        }

        private bool ValidarDateTimePickerNacido()
        {
            bool bStatus = true;
            string mensajesErrores = "La fecha de alta no puede ser mayor que la actual" + Environment.NewLine;
            try
            {
                if (dateTimePickerNacido.Value.Date > DateTime.Now.Date)
                {
                    errorProvider.SetError(dateTimePickerNacido, mensajesErrores);
                    bStatus = false;
                }
                else
                {
                    errorProvider.SetError(dateTimePickerNacido, "");
                    bStatus = true;
                }
            }
            catch (FormatException)
            {
                errorProvider.SetError(dateTimePickerNacido, "La fecha seleccionada no es válida" + Environment.NewLine);
                bStatus = false;
            }

            return bStatus;
        }


    }
}
