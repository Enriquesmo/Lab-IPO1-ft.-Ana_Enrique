using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para Participantes.xaml
    /// </summary>
    public partial class Participantes : Window
    {
        ObservableCollection<Excursionista> lista;
        /************************************************************************************************/

        /*Inicializacion de la ventana Participantes*/

        public Participantes(Ruta ruta, ObservableCollection<Excursionista> listadoParticipantes)
        {
            InitializeComponent();
            lista = ruta.participantes;
            foreach (Excursionista ex in lista)
            {
                ListaParticipantes.Items.Add(ex);
            }
            Foto.Visibility = Visibility.Hidden;

        }

        /************************************************************************************************/

        /*Botones de la propia ventana Participantes*/

        private void ListaParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            ListaParticipantes.Items.Refresh();
            selec = ListaParticipantes.SelectedItem as Excursionista;
            if (selec != null)
            {
                txbNombre.Text = selec.Nombre;
                txbApp.Text = selec.Apellidos;
                txbEdad.Text = selec.Edad.ToString();
                txbTelef.Text = selec.Telefono.ToString();
                txbDni.Text = selec.DNI;
            }
            */
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" ·Para consultar los detalles de un Participante, seleccione uno de la lista de la izquierda.\n \n ·A su vez, para añadir un participante nuevo, rellene todos sus campos. \n\n ·Por ultimo, tenga en cuenta que si la ruta ha sido finalizada, no se podrán modificar sus participantes.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
           /*
            ListaParticipantes.Items.Remove(ListaParticipantes.SelectedItem);
            txbNombre.Text = "";
            txbApp.Text = "";
            txbEdad.Text = "";
            txbTelef.Text = "";
            txbDni.Text = "";
            */


        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            /*
            Excursionista nuevo = new Excursionista(txbNombre.Text, txbApp.Text, int.Parse(txbEdad.Text), int.Parse(txbTelef.Text), txbDni.Text);
            ListaParticipantes.Items.Add(nuevo);
            */
        }
        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            /*
            Excursionista nuevo = new Excursionista(txbNombre.Text, txbApp.Text, int.Parse(txbEdad.Text), int.Parse(txbTelef.Text), txbDni.Text);
            selec = ListaParticipantes.SelectedItem as Excursionista;
            selec.Edad = int.Parse(txbEdad.Text);
            selec.DNI = txbDni.Text;
            selec.Apellidos= txbApp.Text;
            selec.Nombre= txbNombre.Text;
            selec.Telefono = int.Parse(txbTelef.Text);
            MessageBox.Show("Participante modificado");
            */
        }
        private void btnActualizarFoto_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnX_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAlLadoDeLaPersona(object sender, RoutedEventArgs e)
        {

        }

        // Esta variable se usa para guardar la imagen tras pulsar el boton de actualizar foto, para luego implementarla cuando se cree o modifique un guia
        public Uri Imagen { get; set; }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/

        private void introducirEnLaListBox(ListBox listbox, List<string> listaAIntroducir)
        {
            if (listaAIntroducir != null)
            {
                for (int i = 0; i < listaAIntroducir.Count; i++)
                {
                    listbox.Items.Add(listaAIntroducir[i]);
                }
            }
        }
        private void estadoBotones(int opcion) 
        {
            if (opcion == 1)
            {
                btnAnadir.IsEnabled = true;
                btnMod.IsEnabled = false;
                btnBorrar.IsEnabled = false;
            }
            else if (opcion == 2)
            {
                btnAnadir.IsEnabled = false;
                btnMod.IsEnabled = true;
                btnBorrar.IsEnabled = true;
            }
            btnLimpiar.IsEnabled = true;
        }
        private bool esNumero(TextBox textbox, string mensaje) 
        {
            int aDevolver;
            bool esNumero = true;
            if (textbox.Text != "")
            { /*Hemos puesto esta condicion para que si el espacio esta en blanco, tambien pueda crearse la ruta*/
                esNumero = int.TryParse(textbox.Text, out aDevolver);
                if (esNumero != true)
                {
                    MessageBox.Show("Error al Introducir " + mensaje + ".\nDebe introducir un número.", "Error", MessageBoxButton.OK);
                    esNumero = false;
                }
            }
            return esNumero;
        }
        private int introducirNumero(TextBox textbox) 
        {
            int numero = 0;
            bool siMaxPart = int.TryParse(textbox.Text, out numero);
            if (siMaxPart)
            {
                numero = int.Parse(textbox.Text);
            }
            return numero;
        }
        private string introducirString(string emisor) 
        {
            string contenidoAMeter;
            if (emisor.Equals(null))
            {
                contenidoAMeter = "";
            }
            else
            {
                contenidoAMeter = emisor;
            }
            return contenidoAMeter;
        }
        private List<string> extraerElementosListBox(ListBox listbox) 
        {
            List<string> listaADevolver = new List<string> { };
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                string aux = (string)listbox.Items[i];
                listaADevolver.Add(aux);
            }
            return listaADevolver;
        }
    }
}
