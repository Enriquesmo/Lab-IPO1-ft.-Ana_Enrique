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
    /// Lógica de interacción para ListaDeGuias.xaml
    /// </summary>
    public partial class ListaDeGuias : Window
    {
        ObservableCollection<Guia> listadoGuiasAux;
        /************************************************************************************************/

        /*Inicializacion de la ventana ListaDeGuias*/

        // falta: añadir la foto, boton de ayuda
        public ListaDeGuias(ObservableCollection<Guia> listadoGuias)
        {
            InitializeComponent();
            listadoGuiasAux = listadoGuias;
            for (int i = 0; i < listadoGuias.Count; i++)
            {
                ListaParticipantes.Items.Add(listadoGuias[i]);
            }
            estadoBotones(1);
            Foto.Visibility = Visibility.Hidden;
        }

        /************************************************************************************************/

        /*Botones de la propia ventana ListaDeGuias*/
        private void ListaParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Guia guiaAux = ListaParticipantes.SelectedItem as Guia;
            if (guiaAux != null)
            {
                txbNombre.Text = guiaAux.Nombre;
                txbApellidos.Text = guiaAux.Apellidos;
                txbTelefono.Text = guiaAux.Telefono.ToString();
                txbCorreo.Text = guiaAux.Correo;
                txbPuntuacion.Text = guiaAux.Puntuacion.ToString();
                txbIdiomas.Text = "";
                ListBoxRutas.Items.Clear();
                ListBoxIdiomas.Items.Clear();
                introducirEnLaListBox(ListBoxRutas, guiaAux.Rutas);
                introducirEnLaListBox(ListBoxIdiomas, guiaAux.Idiomas);
                Foto.Visibility = Visibility.Visible;
                // añadir que se ponga la imagen del guia
                estadoBotones(2);
            }
        }
        private void btnX_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ListaParticipantes.SelectedItem = null;
            Foto.Visibility = Visibility.Hidden;
            txbNombre.Text = "";
            txbApellidos.Text = "";
            txbTelefono.Text = "";
            txbCorreo.Text = "";
            txbPuntuacion.Text = "";
            txbIdiomas.Text = "";
            ListBoxRutas.Items.Clear();
            ListBoxIdiomas.Items.Clear();
            estadoBotones(1);
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí hay que introducir la ayuda que se facilitará al usuario para esta ventana.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnBorrar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Guia seleccionada = ListaParticipantes.SelectedItem as Guia;
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Está seguro que quiere borrar el guia?.", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ListaParticipantes.Items.Remove(seleccionada);
                Foto.Visibility = Visibility.Hidden;
                txbNombre.Text = "";
                txbApellidos.Text = "";
                txbTelefono.Text = "";
                txbCorreo.Text = "";
                txbPuntuacion.Text = "";
                txbIdiomas.Text = "";
                ListBoxRutas.Items.Clear();
                ListBoxIdiomas.Items.Clear();
                estadoBotones(1);
                // Lo eliminamos de la lista de guias principal
                listadoGuiasAux.Remove(seleccionada);
            }
        }
        private void btnMod_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Guia guiaAModificar = ListaParticipantes.SelectedItem as Guia;
            bool esNumeroTelefono = esNumero(txbTelefono, "el Telefono");
            bool esNumeroPuntuacion = esNumero(txbPuntuacion, "la Puntuacion");
            String nombreAux = introducirString(txbNombre.Text);

            if (nombreAux.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre del guia.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
            }
            else
            {
                if (esNumeroTelefono == true && esNumeroPuntuacion == true)
                {
                    System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres modificar al guia?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {

                        guiaAModificar.Nombre = introducirString(txbNombre.Text);
                        guiaAModificar.Apellidos = introducirString(txbApellidos.Text);
                        guiaAModificar.Correo = introducirString(txbCorreo.Text);
                        guiaAModificar.Telefono = introducirNumero(txbTelefono);
                        guiaAModificar.Puntuacion = introducirNumero(txbPuntuacion);
                        guiaAModificar.Idiomas = extraerElementosListBox(ListBoxIdiomas);
                        ListaParticipantes.Items.Refresh();
                        // Lo eliminamos de la lista de guias principal y lo añadimos de nuevo
                        listadoGuiasAux.Remove(guiaAModificar);
                        listadoGuiasAux.Add(guiaAModificar);
                    }
                }
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres limpiar todos los campos?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                txbNombre.Text = "";
                txbApellidos.Text = "";
                txbTelefono.Text = "";
                txbCorreo.Text = "";
                txbPuntuacion.Text = "";
                txbIdiomas.Text = "";
                ListBoxIdiomas.Items.Clear();
                ListBoxRutas.Items.Clear();
            }
        }
        private void btnAnadir_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Guia guiaAAnadir = new Guia("","",null,0,"",0);
            bool esNumeroTelefono = esNumero(txbTelefono, "el Telefono");
            bool esNumeroPuntuacion = esNumero(txbPuntuacion, "la Puntuacion");
            String nombreAux = introducirString(txbNombre.Text);

            if (nombreAux.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre del guia.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
            }
            else
            {
                if (esNumeroTelefono == true && esNumeroPuntuacion == true)
                {
                    System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres añadir al guia?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        guiaAAnadir.Nombre = introducirString(txbNombre.Text);
                        guiaAAnadir.Apellidos = introducirString(txbApellidos.Text);
                        guiaAAnadir.Correo = introducirString(txbCorreo.Text);
                        guiaAAnadir.Telefono = introducirNumero(txbTelefono);
                        guiaAAnadir.Puntuacion = introducirNumero(txbPuntuacion);
                        guiaAAnadir.Idiomas = extraerElementosListBox(ListBoxIdiomas);
                        ListaParticipantes.Items.Add(guiaAAnadir);
                        // Lo añadimos de la lista de guias principal
                        listadoGuiasAux.Add(guiaAAnadir);
                    }
                }
            }
        }
        private void btnBorrarIdioma_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ListBoxIdiomas.Items.Remove(ListBoxIdiomas.SelectedItem);
        }
        private void btnAnadirIdioma_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ListBoxIdiomas.Items.Add(txbIdiomas.Text);
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/

        private void introducirEnLaListBox(ListBox listbox, List<string> listaAIntroducir) // Terminado
        {
            if (listaAIntroducir != null)
            {
                for (int i = 0; i < listaAIntroducir.Count; i++)
                {
                    listbox.Items.Add(listaAIntroducir[i]);
                }
            }
        }
        private void estadoBotones( int opcion) // Terminado
        {
            if(opcion == 1)
            {
                btnAnadir.IsEnabled = true;
                btnMod.IsEnabled = false;
                btnBorrar.IsEnabled = false;
            }
            else if(opcion == 2)
            {
                btnAnadir.IsEnabled = false;
                btnMod.IsEnabled = true;
                btnBorrar.IsEnabled = true;
            }
            btnLimpiar.IsEnabled = true;
        }
        private bool esNumero(TextBox textbox, string mensaje) // Terminado
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
        private int introducirNumero(TextBox textbox) // Terminado
        {
            int numero = 0;
            bool siMaxPart = int.TryParse(textbox.Text, out numero);
            if (siMaxPart)
            {
                numero = int.Parse(textbox.Text);
            }
            return numero;
        }
        private string introducirString(string emisor) // Terminado
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
        private List<string> extraerElementosListBox(ListBox listbox) // Terminado
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
