﻿using Lab_IPO1_ft.Ana_Enrique;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

// TERMINADA

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string usuario = "admin";
        private string password = "ipo1";

        /************************************************************************************************/

        /*Inicializacion de la ventana MainWindow*/
        public MainWindow() // Terminado
        {
            InitializeComponent();
            VentanaOlvidaste.Visibility = Visibility.Hidden;
            VentanaContNueva.Visibility = Visibility.Hidden;
        }

        /************************************************************************************************/

        /*Botones de la propia ventana ListaDeRutas*/

        /**************************************************************/

        /*Botones de la SubVentana Inicio*/

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e) // Terminado
        {
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {

                if (ComprobarEntrada(txtUsuario.Text, usuario,
                txtUsuario))
                {
                    // habilitar entrada de contraseña y pasarle el foco
                    passContrasena.IsEnabled = true;
                    passContrasena.Focus();
                    // deshabilitar entrada de login
                    txtUsuario.IsEnabled = false;
                }
            }
        }
        private void passContrasena_KeyDown(object sender, KeyEventArgs e) // Terminado
        {
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {
                btnLogin.Focusable= true;
                btnLogin.Focus();
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // La comprobación ya lleva implícita que las entradas estén vacías
            passContrasena.IsEnabled = true;
            if (ComprobarEntrada(txtUsuario.Text, usuario,
            txtUsuario)
            &&
            ComprobarEntrada(passContrasena.Password, password,
            passContrasena))
            {
                ListaDeRutas lista = new ListaDeRutas();
                lista.Show();
                this.Close();
            }
        }
        private void btnOlvidoPss_Click(object sender, RoutedEventArgs e) // Terminado
        {
            VentanaInicio.Visibility = Visibility.Hidden;
            VentanaOlvidaste.Visibility = Visibility.Visible;
        }
        private void btnAyuda1_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("En el campo USUARIO\nDebera introducir el nombre de su cuenta.\nPor defecto es:\n - admin", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda2_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("En el campo CONTRASEÑA\nPrimero deberá introducir el usuario válido y a continuación se le desbloqueará dicho campo\nSegundo, deberá introducir una contraseña valida, por defecto es:\n - ipo1", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnLogin_GotFocus(object sender, RoutedEventArgs e) // Terminado
        {
            btnLogin.Background = Brushes.DarkBlue;
        }
        private void btnLogin_LostFocus(object sender, RoutedEventArgs e) // Terminado
        {
            btnLogin.Background = Brushes.CornflowerBlue;
        }

        /**************************************************************/

        /*Botones de la SubVentana Olvidaste*/

        private void btnEnviarCod_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("Correo enviado\n El codigo es 123", "Correo enviado", MessageBoxButton.OK);
            pssCodigo1.IsEnabled = true;
        }
        private void btnComprobar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            if (pssCodigo1.Password == "123")
            {
                VentanaOlvidaste.Visibility = Visibility.Hidden;
                VentanaContNueva.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("El codigo introducido no es correcto", "Incorrecto", MessageBoxButton.OK);
            }
        }
        private void btnCerrar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            VentanaOlvidaste.Visibility = Visibility.Hidden;
            VentanaInicio.Visibility = Visibility.Visible;

        }
        private void btnAyuda3_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("En el campo EMAIL\nSe debería introducir un email valido, sin embargo, con introducir cualquier combinacion de caracteres es suficiente debido a que esto es una simulación.\nTras haber hecho esto, se deberá hacer click en el botón llamado:\n - ENVIAR CÓDIGO", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda4_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("En el campo INTRODUCIR EL CODIGO\nTras haber obtenido dicho codigo en el boton de arriba llamado:\n - ENVIAR CODIGO\nDeberá introducir el codigo obtenido, el cual es:\n - 123", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /**************************************************************/

        /*Botones de la SubVentana ContNueva*/

        private void btnCambiarPss_Click(object sender, RoutedEventArgs e) // Terminado
        {
            if (txtContrasena1.Text == txtContrasena2.Text)
            {
                VentanaContNueva.Visibility = Visibility.Hidden;
                VentanaInicio.Visibility = Visibility.Visible;
                password = txtContrasena1.Text;
            }
            else
            {
                txtContrasena1.Background = Brushes.Red;
                txtContrasena2.Background = Brushes.Red;
                MessageBox.Show("Las contraseñas no coinciden", "Contraseñas", MessageBoxButton.OK);
            }
        }
        private void btnCerrar2_Click(object sender, RoutedEventArgs e) // Terminado
        {
            VentanaContNueva.Visibility = Visibility.Hidden;
            VentanaInicio.Visibility = Visibility.Visible;
        }
        private void btnAyuda5_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("En el campo NUEVA CONTRASÑA\nDeberá introducir la nueva contraseña deseada.\nCualquier combinación de caracteres es admitida.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda6_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("En el campo REPITA SU NUEVA CONTRASEÑA\nDeberá introducir la misma combinacion de caracteres que en el anterior campo.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /**************************************************************/

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/
        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido, Control componenteEntrada) // Terminado
        {
            Boolean valido = false;
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightCoral;
                // imagen al lado de la entrada de usuario --> cross
                valido = false;
            }
            return valido;
        }

        private void btnCreditos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aplicación desarrollada por: \n Enrique Sánchez-Migallón Ochoa\n Ana Toledano Franco\n\n Acabado el 20/01/23 \n v.1.6.3 \n" , "Créditos", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
