using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_negocio;
using Capa_entidades;
using System.Security.Cryptography;

namespace TiendaOnline
{
    public partial class FormularioRecordarPass : Form
    {

        Negocio _neg;
        List<Usuario> listaUsuarios;

        public FormularioRecordarPass()
        {
            InitializeComponent();
            _neg = new Negocio();

        }

        private void FormularioRecordarPass_Load(object sender, EventArgs e)
        {
            listaUsuarios = _neg.ObtenerUsuarios();

        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {


            List<Usuario> usuario;

            usuario = listaUsuarios.Where(x => x.Nombre.ToUpper().Equals(textNomUsuario.Text.ToUpper()) && x.Dni.Equals(textDniUsuario.Text)).ToList();

            var result = (from usuarios in listaUsuarios
                          where usuarios.Nombre.ToUpper().Equals(textNomUsuario.Text.ToUpper())
                          && usuarios.Dni.Equals(textDniUsuario.Text)
                          select usuarios);

            if (result != null)
            {

                foreach(Usuario item in result)
                {
                    FormularioCambioContrasenya formularioCambio = new FormularioCambioContrasenya(item);
                    formularioCambio.ShowDialog();
                    this.Close();
                }
               

            }
            else
            {
                lbError.ForeColor = System.Drawing.Color.Red;
                lbError.Text = "No existe ese usuario.";
            }




        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textNomUsuario_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textNomUsuario, "");
        }

        private void textNomUsuario_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidNombre(textNomUsuario.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textNomUsuario.Select(0, textNomUsuario.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textNomUsuario, errorMsg);
                textNomUsuario.Focus();
            }
        }





        public bool ValidNombre(string nombre, out string errorMessage)
        {
            // Confirm that the email address string is not empty.
            if (nombre.Length == 0)
            {
                errorMessage = "El nombre es requerido";
                return false;
            }

            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            else
            {

                errorMessage = "";
                return true;

            }
           
        }
       
    }
}
   
