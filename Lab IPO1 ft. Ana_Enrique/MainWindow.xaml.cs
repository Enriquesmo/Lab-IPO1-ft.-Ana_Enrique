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

      

       
        private void pnlDisenoPrincipal_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntrada(passContrasena.Password, password,
            passContrasena, ImgCheckPassword))
                btnLogin.Focus();
        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Gracias por usar la aplicación", "Despedida1");
        }

        private void VentanaPrincipal_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Aun despues de cerrarnos, Muchas Gracias por usar la aplicación", "Despedida2");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // La comprobación ya lleva implícita que las entradas
            // estén vacías
            VentanaInicio.Visibility=Visibility.Hidden;
            VentanaOlvidaste.Visibility = Visibility.Visible;
            if (ComprobarEntrada(txtUsuario.Text, usuario,
            txtUsuario, ImgCheckUsuario)
            &&
            ComprobarEntrada(passContrasena.Password, password,
            passContrasena, ImgCheckPassword))
            {
                Application.Current.Shutdown();
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

        private void lblRecordarContrasena_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VentanaInicio.Visibility = Visibility.Hidden;
            VentanaOlvidaste.Visibility = Visibility.Visible;
        }
    }
}
