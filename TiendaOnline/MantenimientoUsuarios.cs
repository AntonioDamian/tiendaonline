using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_entidades;
using Capa_negocio;
using MiLibreria;

namespace TiendaOnline
{
    public partial class MantenimientoUsuarios : Form
    {

        Negocio neg;
        NegocioLocalidad negLocalidad;
        NegocioProvincia negProvincia;
        List<Usuario> _listaUsuarios;
        DataTable dt = new DataTable();
        DataTable dictionarylocalidades;
        DataTable dictionaryProvincias;

        public static Usuario usuario;

        private bool IsNuevo = false;

        private bool IsEditar = false;


        public MantenimientoUsuarios()
        {
            InitializeComponent();
            neg = new Negocio();
            negLocalidad = new NegocioLocalidad();
            negProvincia = new NegocioProvincia();


            usuario = new Usuario();

            this.ttMensaje.SetToolTip(this.txtEmail, "Ingrese un email");
        }

        //Mostrar mensaje de confirmación

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Apitienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Apitienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //limpiar controles

        private void Limpiar()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {

                    c.Text = string.Empty;
                    //Enfoco en el primer TextBox
                    this.txtEmail.Focus();
                }
            }

            comboPueblo.SelectedIndex = -1;
            comboProvincia.SelectedIndex = -1;
            maskedTextTelefono.Text = "";
        }

        //Habilitar los controles

        private void Habilitar(bool valor)
        {
            this.txtApellidos.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;          
            txtpass.ReadOnly = !valor;
            txtRepPass.ReadOnly = !valor;
            txtDni.ReadOnly = !valor;
            maskedTextTelefono.ReadOnly = !valor;
            txtCalle.ReadOnly = !valor;
            txtCalle2.ReadOnly = !valor;
            txtCodPOs.ReadOnly = !valor;
            comboPueblo.SelectedIndex = -1;
            comboProvincia.SelectedIndex = -1;

        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Metodo para ocultar columnas
        private void OcultarColumna()
        {
            this.dataGridViewUsuarios.Columns[0].Visible = false;
            this.dataGridViewUsuarios.Columns[1].Visible = false;
        }

        //Metodo para mostrar columnas

        private void Mostrar()
        {
            //  this.dataGridViewUsuarios.DataSource = neg.ObtenerUsuarios();

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

            this.OcultarColumna();

            lbTotal.Text = "Total de registros: " + Convert.ToString(dataGridViewUsuarios.Rows.Count);

            dictionarylocalidades = negLocalidad.TablaLocalidades();
            comboPueblo.DataSource = new BindingSource(dictionarylocalidades, null);
            comboPueblo.ValueMember = "localidadID";
            comboPueblo.DisplayMember = "nombre";

            dictionaryProvincias = negProvincia.TablaProvincias();
            comboProvincia.DataSource = new BindingSource(dictionaryProvincias, null);
            comboProvincia.ValueMember = "ProvinciaID";
            comboProvincia.DisplayMember = "nombre";
        }

        private void MantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        //controles y metodos de la pestaña listado

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNombre.Checked)
            {
                this.txtBusqueda.Enabled = true;
                this.txtBusqueda.Visible = true;
            }
            else
            {
                this.txtBusqueda.Enabled = false;
                this.txtBusqueda.Visible = false;
            }
        }

        private void rbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDni.Checked)
            {
                this.txtBusqueda.Enabled = true;
                this.txtBusqueda.Visible = true;
            }
            else
            {
                this.txtBusqueda.Enabled = false;
                this.txtBusqueda.Visible = false;
            }
        }

        private void rbemail_CheckedChanged(object sender, EventArgs e)
        {
            if (rbemail.Checked)
            {
                this.txtBusqueda.Enabled = true;
                this.txtBusqueda.Visible = true;
            }
            else
            {
                this.txtBusqueda.Enabled = false;
                this.txtBusqueda.Visible = false;
            }
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
                    lbTotal.Text = "Total de registros: " + Convert.ToString(dataGridViewUsuarios.Rows.Count);
                    if (rbDni.Checked == true)
                    {
                       
                        dt.DefaultView.RowFilter = $"Dni like'{txtBusqueda.Text}%'";
                        lbTotal.Text = "Total de registros: " + Convert.ToString(dataGridViewUsuarios.Rows.Count);
                    }

                    if (rbemail.Checked == true)
                    {
                       
                        dt.DefaultView.RowFilter = $"Email like'{txtBusqueda.Text}%'";
                        lbTotal.Text = "Total de registros: " + Convert.ToString(dataGridViewUsuarios.Rows.Count);
                    }

                }
                else
                {
                    dataGridViewUsuarios.DataSource = dt;
                    txtBusqueda.Text = "";

                }


            }
            else
            {
                txtBusqueda.Visible =false;
                txtBusqueda.Enabled =false;
                lbApellido.Visible = false;
                txtApellido.Enabled =false;
                txtApellido.Visible =false;
            }
        }

        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"apellidos like'{txtApellido.Text.Trim()}%'";
        }
        private void dataGridViewUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DevolverUsuario();
            tabControl1.SelectedIndex = 1;
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataGridViewUsuarios.Columns[0].Visible = true;
            }
            else
            {
                this.dataGridViewUsuarios.Columns[0].Visible = false;
            }
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewUsuarios.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridViewUsuarios.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente desea eliminar los registros", "Apiventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    bool valido = true;

                    foreach (DataGridViewRow row in dataGridViewUsuarios.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            valido = neg.Borrar(Convert.ToInt32(codigo));

                            if (valido)
                            {
                                this.MensajeOK("Se eliminó correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError("No se pudo eliminar el registro");
                            }
                        }
                    }
                }

                    this.Mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }




        //controles y metodos de la pestaña mantenimiento
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtEmail.Focus();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(!this.lbUsuarioID.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
          

            try
            {
                bool bValidarEmail = ValidarEmail();
                bool bValidarPass = ValidarPass();
                bool bValidarRepPass = ValidarRePass();
                bool bValidarNombre = ValidarNombre();
                bool bValidarApellidos = ValidarApellidos();
                bool bValidarDni = ValidarDni();
                bool bValidarCodPOs = ValidarCodpos(); ;
                bool bValidarComboPueblo = ValidarComboPueblo();
                bool bValidarComboProvincia = ValidarComboProvincia();
                bool bValidarDateTimePickerNacido = ValidarDateTimePickerNacido();


                if (bValidarEmail && bValidarPass && bValidarRepPass && bValidarNombre && bValidarApellidos && bValidarDni && bValidarCodPOs && bValidarComboPueblo
                         && bValidarComboProvincia && bValidarDateTimePickerNacido)
                {
                    bool añadido = false;
                    string passMD5 = NegocioUsuario.ConvertirContrasenyaMD5(txtpass.Text);

                    string codigoLocalidad = comboPueblo.SelectedValue.ToString();
                    string codigoProvincia = comboProvincia.SelectedValue.ToString();

                    if (this.IsNuevo)
                    {
                       

                        añadido = neg.Nuevo(txtEmail.Text, passMD5, txtNombre.Text, txtApellidos.Text, txtDni.Text, maskedTextTelefono.Text, txtCalle.Text, txtCalle2.Text, txtCodPOs.Text, codigoLocalidad, codigoProvincia, dateTimePickerNacido.Value);

                    }
                    else
                    {
                        añadido = neg.Actualizar(new Usuario(usuario.UsuarioID, txtEmail.Text, passMD5, txtNombre.Text, txtApellidos.Text, txtDni.Text, maskedTextTelefono.Text, txtCalle.Text, txtCalle2.Text, txtCodPOs.Text, codigoLocalidad, codigoProvincia, dateTimePickerNacido.Value));

                    }                   
                  

                    if (añadido)
                    {
                        if(this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro");
                        }

                       
                    }
                    else
                    {
                        this.MensajeError("ERROR,no se han podido introducir los datos");

                       
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
                else
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
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
                errorIcono.SetError(txtEmail,mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorIcono.SetError(txtEmail, "");
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
                

                errorIcono.SetError(txtpass, "");
                bStatus = true;
            }
            else if (!"".Equals(mensajesErrores))
            {
                errorIcono.SetError(txtpass, mensajesErrores);
                bStatus = false;
            }
            else
            {

                //La	 contraseñ a	 deberá	 tener	 una	 complejidad	 de	 al	 menos	 1	 número, una	
                // mayúscula y   un carácter   no alfanumérico



                string patronContrasenyaValido = (@"[A-Z0-9!@#\$%\^&\*\?_~\/]{8,}$");



                if (!Regex.IsMatch(txtpass.Text, patronContrasenyaValido))
                {
                    mensajesErrores = "El formato de la contraseña no es correcto" +
                        ", deberá tener una complejidad de al menos 1 número, una mayúscula y un carácter no alfanumérico" + Environment.NewLine;
                    errorIcono.SetError(txtpass, mensajesErrores);
                    bStatus = false;
                }


                else
                {
                    errorIcono.SetError(txtpass, "");
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
                errorIcono.SetError(txtRepPass, "Ambas constraseñas deben ser iguales");
                bStatus = false;
            }
            else if (string.IsNullOrEmpty(txtRepPass.Text))
            {
                errorIcono.SetError(txtRepPass, "");
                bStatus = true;
            }
            else if (!"".Equals(mensajesErrores))
            {
                errorIcono.SetError(txtRepPass, mensajesErrores);
                bStatus = false;
            }

            else
            {
                {
                    errorIcono.SetError(txtRepPass, "");
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
                errorIcono.SetError(txtNombre, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorIcono.SetError(txtNombre, "");
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
                errorIcono.SetError(txtApellidos, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorIcono.SetError(txtApellidos, "");
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
                errorIcono.SetError(txtDni, mensajesErrores);
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
                    errorIcono.SetError(txtDni, "Introduce un DNI o un DNI válido");
                    bStatus = false;
                }
                else
                {
                    errorIcono.SetError(txtDni, "");
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private void maskedTextTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextTelefono.Text.Length == 0)
            {
                maskedTextTelefono.Text = null;
            }
            errorIcono.SetError(maskedTextTelefono, "Error al introducir los datos del telefono");
        }

        private bool ValidarCalle()
        {
            bool bStatus = true;
            if (!string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                string mensajesErrores = Utilidades.ValidaCadena("Calle", txtCalle.Text, 45, true);

                if (!"".Equals(mensajesErrores))
                {
                    errorIcono.SetError(txtCalle, mensajesErrores);
                    bStatus = false;
                }
                else
                {
                    errorIcono.SetError(txtCalle, "");
                    bStatus = true;
                }
            }
            else
            {
                errorIcono.SetError(txtCalle, "");
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
                    errorIcono.SetError(txtCalle2, mensajesErrores);
                    bStatus = false;
                }
                else
                {
                    errorIcono.SetError(txtCalle2, "");
                    bStatus = true;
                }
            }
            else
            {
                errorIcono.SetError(txtCalle2, "");
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
                    errorIcono.SetError(txtCodPOs, "");
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
                    errorIcono.SetError(txtCodPOs, mensajesErrores);
                    bStatus = false;
                }
            }

            else
            {
                errorIcono.SetError(txtCodPOs, "");
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
                errorIcono.SetError(comboPueblo, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorIcono.SetError(comboPueblo, "");
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
                errorIcono.SetError(comboProvincia, mensajesErrores);
                bStatus = false;
            }
            else
            {
                errorIcono.SetError(comboProvincia, "");
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
                    errorIcono.SetError(dateTimePickerNacido, mensajesErrores);
                    bStatus = false;
                }
                else
                {
                    errorIcono.SetError(dateTimePickerNacido, "");
                    bStatus = true;
                }
            }
            catch (FormatException)
            {
                errorIcono.SetError(dateTimePickerNacido, "La fecha seleccionada no es válida" + Environment.NewLine);
                bStatus = false;
            }

            return bStatus;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}

