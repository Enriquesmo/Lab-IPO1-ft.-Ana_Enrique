using Lab_IPO1_ft.Ana_Enrique;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage imagOriginal = new BitmapImage(new Uri("/imagenes/avatar1.png", UriKind.Relative));
        private BitmapImage imagRollOver = new BitmapImage(new Uri("/imagenes/avatar2.png", UriKind.Relative));
        private string usuario = "admin";
        private string password = "ipo1";
        private BitmapImage imagCheck = new BitmapImage(new Uri("/imagenes/check.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("/imagenes/cross.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();
            VentanaOlvidaste.Visibility = Visibility.Hidden;
            VentanaContNueva.Visibility = Visibility.Hidden;

        }

        private void txtUsuario_PreviewKeyDown(object sender, KeyEventArgs e)
        // el primer parametro de entrada es una referencia al objeto en si
        // el segundo parametro son los argumentos de entrada que se introducen
        {
            if (e.Key == Key.Enter)
            {
             
                passContrasena.IsEnabled = true;
                passContrasena.Focus(); // Esto hace que cuando se habilite, pase
                // directamente a ese campo
            }
        }

        private void btnEnviarCod_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show( "Correo enviado\n El codigo es 123", "Correo enviado", MessageBoxButton.OK);
            pssCodigo1.IsEnabled=true;
        }

        private void btnComprobar_Click(object sender, RoutedEventArgs e)
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
        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntrada(passContrasena.Password, password,
            passContrasena, ImgCheckPassword))
                btnLogin.Focus();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {



            // La comprobación ya lleva implícita que las entradas
            // estén vacías
            passContrasena.IsEnabled = true;
            if (ComprobarEntrada(txtUsuario.Text, usuario,
            txtUsuario, ImgCheckUsuario)
            &&
            ComprobarEntrada(passContrasena.Password, password,
            passContrasena, ImgCheckPassword))
            {
                
                ListaDeRutas lista = new ListaDeRutas();
                lista.Show();
                this.Close();


            }
            
        }

        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido, Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightCoral;
                // imagen al lado de la entrada de usuario --> cross
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {
                
                if (ComprobarEntrada(txtUsuario.Text, usuario,
                txtUsuario, ImgCheckUsuario))
                {
                    // habilitar entrada de contraseña y pasarle el foco
                    passContrasena.IsEnabled = true;
                    passContrasena.Focus();
                    // deshabilitar entrada de login
                    txtUsuario.IsEnabled = false;
                }
            }
        }


        private void btnOlvidoPss_Click(object sender, RoutedEventArgs e)
        {
            VentanaInicio.Visibility = Visibility.Hidden;
            VentanaOlvidaste.Visibility = Visibility.Visible;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            VentanaOlvidaste.Visibility = Visibility.Hidden;
            VentanaInicio.Visibility = Visibility.Visible;
            
        }

        private void btnCerrar2_Click(object sender, RoutedEventArgs e)
        {
            VentanaContNueva.Visibility = Visibility.Hidden;
            VentanaInicio.Visibility = Visibility.Visible;

        }

       

        private void btnCambiarPss_Click(object sender, RoutedEventArgs e)
        {
            if (txtContrasena1.Text == txtContrasena2.Text)
            {
               
                VentanaContNueva.Visibility = Visibility.Hidden;
                VentanaInicio.Visibility = Visibility.Visible;
                password = txtContrasena1.Text;

            }
            else
            {
                txtContrasena1.Background= Brushes.Red;
                txtContrasena2.Background= Brushes.Red;
                MessageBox.Show("Las contraseñas no coinciden","Contraseñas",MessageBoxButton.OK);
            }
        }
        /*Botones reservados para suministrar ayuda al usuario*/
        private void btnAyuda1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En el campo USUARIO\nDebera introducir el nombre de su cuenta.\nPor defecto es:\n - admin", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En el campo CONTRASEÑA\nPrimero deberá introducir el usuario válido y a continuación se le desbloqueará dicho campo\nSegundo, deberá introducir una contraseña valida, por defecto es:\n - ipo1", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En el campo EMAIL\nSe debería introducir un email valido, sin embargo, con introducir cualquier combinacion de caracteres es suficiente debido a que esto es una simulación.\nTras haber hecho esto, se deberá hacer click en el botón llamado:\n - ENVIAR CÓDIGO", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En el campo INTRODUCIR EL CODIGO\nTras haber obtenido dicho codigo en el boton de arriba llamado:\n - ENVIAR CODIGO\nDeberá introducir el codigo obtenido, el cual es:\n - 123", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En el campo NUEVA CONTRASÑA\nDeberá introducir la nueva contraseña deseada.\nCualquier combinación de caracteres es admitida.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnAyuda6_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En el campo REPITA SU NUEVA CONTRASEÑA\nDeberá introducir la misma combinacion de caracteres que en el anterior campo.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
