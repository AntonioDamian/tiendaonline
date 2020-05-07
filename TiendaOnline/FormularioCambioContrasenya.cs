using Capa_entidades;
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

namespace TiendaOnline
{
    public partial class FormularioCambioContrasenya : Form
    {

        private Usuario usuario;
        private Negocio neg;


        public FormularioCambioContrasenya(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            neg = new Negocio();

            this.usuario = new Usuario(usuario);

        }

        private void ConfirmarPass(object sender, EventArgs e)
        {
                       
            string pass1 = cambioPass.Text;
            string pass2 = cambioRePass.Text;



            if ("".Equals(pass1) || "".Equals(pass2))
            {
                labelInfo.ForeColor = System.Drawing.Color.Red;
                labelInfo.Text = "Para cambiar la contraseña debes rellenar ambos campos.";
            }
            else if (!pass1.Equals(pass2))
            {
                labelInfo.ForeColor = System.Drawing.Color.Red;
                labelInfo.Text = "Las dos contraseñas no son iguales, por favor, corrige el error y vuelve a intentarlo.";
            }
            else
            {

                usuario.Password = neg.ConvertirContrasenyaMD5(pass1);



                // Una vez cambiada la contraseña, cerramos el formulario para que el usuario acceda a la aplicación
                bool contrasenyaCambiada = neg.Actualizar(usuario);

                if (contrasenyaCambiada)
                    this.Close();
                else
                {
                    labelInfo.ForeColor = System.Drawing.Color.Red;
                    labelInfo.Text = "Se ha producido un error actualizando la contraseña. Inténtalo de nuevo.";
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
