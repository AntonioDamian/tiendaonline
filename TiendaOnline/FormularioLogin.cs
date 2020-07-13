using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;



namespace TiendaOnline
{
    public partial class FormularioLogin : Form
    {
        private int numerointentosLogin;
        private bool aplicacionClose = false;
       
        private Negocio _neg;
        private NegocioUsuario negUsuario = new NegocioUsuario();

        public FormularioLogin()
        {
            InitializeComponent();

            numerointentosLogin = 3;
            _neg = new Negocio();

            negUsuario.CrearUsuarioCliente();

        }
     /*   private void FormularioLogin_Load(object sender, EventArgs e)
        {
            numerointentosLogin = 3;
            _neg = new Negocio();

            negUsuario.CrearUsuarioCliente();
        }*/




        private void Login(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string password = txtPass.Text;
            Usuario usuario = new Usuario();



            // Si se han usado todos los intentos de login, sólo se podrá cerrar la aplicación
            if (aplicacionClose)
                Application.Exit();

            // Primero validamos que se han rellenado ambos campos, sino mostraremos un error
            if (!"".Equals(nombre) && !"".Equals(password))
            {
                // Si aún quedan intentos de login por realizar, intentamos acceder a la aplicación con los datos introducidos
                // por el usuario
                if (numerointentosLogin > 1)
                {                  

                    bool usuarioLogueado = _neg.Validar2(txtNombre.Text, txtPass.Text,out usuario);
                    // Si se puede loguear al usuario, se comprueba si es el primer login (para que establezca una nueva contraseña)
                    // o se redirige al usuario al formulario principal
                    if (usuarioLogueado)
                    {
                        if (txtPass.Text.Equals(usuario.Email) )
                        {
                            DialogResult result = MessageBox.Show("¿Desea entrar a de la aplicación?,debe crear una contraseña valida",
                               "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                FormularioCambioContrasenya formularioCambioContrasenya = new FormularioCambioContrasenya(usuario);
                                formularioCambioContrasenya.ShowDialog();
                            }
                        }
                        else
                        {
                            FormularioPrincipal formularioPrincipal = new FormularioPrincipal(nombre);  
                            
                            formularioPrincipal.Show();
                            this.Hide();                           
                           
                        }                  
                       
                    }
                    // Si no se puede loguear al usuario mostramos el error y quitamos un intento de los disponibles
                    else
                    {
                        numerointentosLogin--;
                        labelinfoLogin.ForeColor = System.Drawing.Color.Red;
                        labelinfoLogin.Text = "Usuario o contraseña inválido. Inténtalo de nuevo.\nTe quedan " + numerointentosLogin + " intentos";
                    }
                }
                // Cuando se exceden los intentos disponibles, sólo se mostrará un botón para cerrar la aplicación y el mensaje correspondiente
                else
                {
                    labelinfoLogin.ForeColor = System.Drawing.Color.Red;
                    labelinfoLogin.Text = "Se han excedido el número de intentos.\nLa aplicacion se cerrará.";
                    aplicacionClose = true;
                    btnLogin.Text = "Cerrar";
                    btnSalir.Visible = false;
                }
            }


            else if("".Equals(password) && !"".Equals(nombre))
            {
               bool usuarioLogueado = _neg.Validar2(txtNombre.Text, txtPass.Text, out usuario);

                DialogResult result = MessageBox.Show("¿Desea entrar a de la aplicación?,debe crear una contraseña valida",
               "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FormularioCambioContrasenya formularioCambioContrasenya = new FormularioCambioContrasenya(usuario);
                    formularioCambioContrasenya.ShowDialog();
                }

            }
            else
            {
                labelinfoLogin.ForeColor = System.Drawing.Color.Red;
                labelinfoLogin.Text = "Introduce el usuario y la contraseña para acceder a la aplicación.";
            }
        }

     

        private void RecordarContraseña(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DialogResult result = MessageBox.Show("Debe crear una contraseña nueva valida,no se puede recuperar la antigua contraseña",
             "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                FormularioRecordarPass recPass = new FormularioRecordarPass();
                recPass.ShowDialog();
            }         

        }

      

        private void Salir(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Deseas salir de la aplicacion?", "Confirmación",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

     

     
    }
}
