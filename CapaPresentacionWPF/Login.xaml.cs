﻿using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapaEntidades;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {

       // Variables que utilizaremos en esta clase

        private int numeroIntentos;
        private Negocio neg;
        private NegocioUsuario negUsu;

        Usuario usuario;


        /// <summary>
        /// 
        /// </summary>
        public Login()
        {
            InitializeComponent();
            numeroIntentos = 3;
            neg = new Negocio();
            negUsu = new NegocioUsuario();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            /*   numeroIntentos = 3;
               neg = new Negocio();
               negUsu = new NegocioUsuario();*/


        }

        /// <summary>
        /// Metodo que nos permite acceder a la aplicacion si son correctas nuestras credenciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnAcceder_Click(object sender, RoutedEventArgs e)
        {
            string nombre = Usuario.Text.Trim();
            string pass = Contrasenya.Password;

            usuario = new Usuario();


            if (numeroIntentos > 0)
            {
                if (!"".Equals(nombre) && !"".Equals(pass))
                {
                    bool usuarioLogueado = neg.Validar2(nombre, pass, out usuario);
                  
                    if (usuarioLogueado)
                    {
                        if (pass.Equals(usuario.Email))
                        {
                            MessageBoxResult result = MessageBox.Show("¿Desea entrar a de la aplicación?,debe crear una contraseña valida",
                               "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                CambioContrasenya formularioCambioContrasenya = new CambioContrasenya(usuario);
                                formularioCambioContrasenya.ShowDialog();
                            }
                        }
                        else
                        {
                            MainWindow formularioPrincipal = new MainWindow(usuario);
                            formularioPrincipal.Show();
                            this.Hide();
                        }
                    }
                    // Si no se puede loguear al usuario mostramos el error y quitamos un intento de los disponibles
                    else
                    {
                        numeroIntentos--;

                        InfoLogin.Foreground = Brushes.Red;
                        InfoLogin.Text = "Usuario o contraseña inválido. Inténtalo de nuevo.\nTe quedan " + numeroIntentos + " intentos";
                    }
                }
                // Cuando se exceden los intentos disponibles, sólo se mostrará un botón para cerrar la aplicación y el mensaje correspondiente

                else if ("".Equals(pass) && !"".Equals(nombre))
                {
                    bool usuarioLogueado = neg.Validar2(nombre, pass, out usuario);

                    MessageBoxResult result = MessageBox.Show("¿Desea entrar a de la aplicación?,debe crear una contraseña valida",
                   "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        CambioContrasenya formularioCambioContrasenya = new CambioContrasenya(usuario);
                        formularioCambioContrasenya.ShowDialog();
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }

                }
                else
                {
                    InfoLogin.Foreground = Brushes.Red;
                    InfoLogin.Text = "Introduce el usuario y la contraseña para acceder a la aplicación.";
                    numeroIntentos--;
                }
            }
            else if (numeroIntentos == 0)
            {
                InfoLogin.Foreground = Brushes.Red;
                InfoLogin.Text = "Se han excedido el número de intentos.\nLa aplicacion se cerrará.";

                Application.Current.Shutdown();

            }

        }

        /// <summary>
        /// Metodo para recuperar la contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Run run1 = new Run("¿Has olvidado la contraseña?");
            MessageBoxResult result = MessageBox.Show("Debe crear una contraseña nueva valida,no se puede recuperar la antigua contraseña",
             "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                CambioContrasenya formularioCambioContrasenya = new CambioContrasenya(usuario);
                formularioCambioContrasenya.ShowDialog();
            }


        }


        /// <summary>
        /// Metodo para salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea cerrar la aplicación?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Metodo que minimizara la ventana login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void ButtonMinimizar_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}

