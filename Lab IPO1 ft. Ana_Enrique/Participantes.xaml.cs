using Microsoft.Win32;
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
        ObservableCollection<Excursionista> listadoParticipantesAux;
        Ruta rutaElegida;
        /************************************************************************************************/

        /*Inicializacion de la ventana Participantes*/

        public Participantes(Ruta ruta, ObservableCollection<Excursionista> listadoParticipantes)
        {
            InitializeComponent();
            listadoParticipantesAux = listadoParticipantes;
            rutaElegida = ruta;
            for (int i = 0; i < listadoParticipantesAux.Count; i++)
            {
                ListaParticipantes.Items.Add(listadoParticipantesAux[i]);
            }

            // FALTA HACER QUE SE PONGA EN TICK TODOS LOS QUE ESTEN AÑADIDOS

            /*
            for(int i = 0; i < ListaParticipantes.Items.Count; i++)
            {
                if (ruta.participantes.Contains(listadoParticipantesAux[i]))
                    {
                       var button = (Button)FindName("BtnAlLadoDeLaPersona");
                       cambiarImagenDelBoton(button,1);
                    }
            }*/
            /*Aqui comprobamos los excursionistas que se encuntran ya en la ruta para poder marcarlos con un check*/
            /*
            foreach (var item in ListaParticipantes.Items)
            {
                ListBoxItem itemContainer = (ListBoxItem)ListaParticipantes.ItemContainerGenerator.ContainerFromItem(item);
                if (itemContainer != null)
                {
                    Button button = (Button)itemContainer.FindName("BtnAlLadoDeLaPersona");
                    if (ruta.participantes.Contains(item))
                    {
                        cambiarImagenDelBoton(button, 1);
                    }
                }

            }*/

            Foto.Visibility = Visibility.Hidden;
            estadoBotones(1);

        }

        /************************************************************************************************/

        /*Botones de la propia ventana Participantes*/

        private void ListaParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e) // Terminado
        {
            
            ListaParticipantes.Items.Refresh();
            Excursionista seleccionado = ListaParticipantes.SelectedItem as Excursionista;
            if (seleccionado != null)
            {
                txbNombre.Text = seleccionado.Nombre;
                txbApellidos.Text = seleccionado.Apellidos;
                txbEdad.Text = seleccionado.Edad.ToString();
                txbTelefono.Text = seleccionado.Telefono.ToString();
                txbDni.Text = seleccionado.DNI;
                Foto.Visibility = Visibility.Visible;
                if (seleccionado.Foto != null)
                {
                    BitmapImage imagen = new BitmapImage(seleccionado.Foto);
                    Foto.Source = imagen;
                }
                else
                {
                    Foto.Source = null;
                }
                estadoBotones(2);
            }
            
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" ·Para consultar los detalles de un Participante, seleccione uno de la lista de la izquierda.\n \n ·A su vez, para añadir un participante nuevo, rellene todos sus campos. \n\n ·Por ultimo, tenga en cuenta que si la ruta ha sido finalizada, no se podrán modificar sus participantes.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Excursionista excursionista = ListaParticipantes.SelectedItem as Excursionista;
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Está seguro que quiere borrar el guia?.", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ListaParticipantes.Items.Remove(excursionista);
                txbNombre.Text = "";
                txbApellidos.Text = "";
                txbEdad.Text = "";
                txbTelefono.Text = "";
                txbDni.Text = "";
                Foto.Source = null;
                LtbRutasExcursionista.Items.Clear();
            }
                /*
                 ListaParticipantes.Items.Remove(ListaParticipantes.SelectedItem);
                 txbNombre.Text = "";
                 txbApp.Text = "";
                 txbEdad.Text = "";
                 txbTelef.Text = "";
                 txbDni.Text = "";
                 */


            }
        private void btnAnadir_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Excursionista excursionita = new Excursionista("", "", 0, 0, "");
            bool esNumeroTelefono = esNumero(txbTelefono, "el Telefono");
            bool esNumeroEdad = esNumero(txbEdad, "la Edad");
            String nombreAux = introducirString(txbNombre.Text);

            if (nombreAux.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre del excursionista.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
            }
            else
            {
                if (esNumeroTelefono == true && esNumeroEdad == true)
                {
                    System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres añadir al excursionista?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        excursionita.Nombre = introducirString(txbNombre.Text);
                        excursionita.Apellidos = introducirString(txbApellidos.Text);
                        excursionita.Edad = introducirNumero(txbEdad);
                        excursionita.Telefono = introducirNumero(txbTelefono);
                        excursionita.Foto = Imagen;
                        excursionita.DNI = introducirString(txbDni.Text);
                        ListaParticipantes.Items.Add(excursionita);
                        ListaParticipantes.Items.Refresh();
                        // Lo añadimos de la lista de guias principal
                        listadoParticipantesAux.Add(excursionita);
                    }
                }
            }
            /*
            Excursionista nuevo = new Excursionista(txbNombre.Text, txbApp.Text, int.Parse(txbEdad.Text), int.Parse(txbTelef.Text), txbDni.Text);
            ListaParticipantes.Items.Add(nuevo);
            */
        }
        private void btnMod_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Excursionista excursionistaAModificar = ListaParticipantes.SelectedItem as Excursionista;
            bool esNumeroTelefono = esNumero(txbTelefono, "el Telefono");
            bool esNumeroEdad = esNumero(txbEdad, "la Edad");
            String nombreAux = introducirString(txbNombre.Text);

            if (nombreAux.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre del excursionista.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
            }
            else
            {
                if (esNumeroTelefono == true && esNumeroEdad == true)
                {
                    System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres modificar al excursionista?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {

                        excursionistaAModificar.Nombre = introducirString(txbNombre.Text);
                        excursionistaAModificar.Apellidos = introducirString(txbApellidos.Text);
                        excursionistaAModificar.Edad = introducirNumero(txbEdad);
                        excursionistaAModificar.Telefono = introducirNumero(txbTelefono);
                        excursionistaAModificar.Foto = Imagen;
                        excursionistaAModificar.DNI = introducirString(txbDni.Text);
                        ListaParticipantes.Items.Refresh();
                        // Lo eliminamos de la lista de guias principal y lo añadimos de nuevo
                        listadoParticipantesAux.Remove(excursionistaAModificar);
                        listadoParticipantesAux.Add(excursionistaAModificar);
                    }
                }
            }
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
        private void btnX_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ListaParticipantes.SelectedItem = null;
            Foto.Source = null;
            txbNombre.Text = "";
            txbApellidos.Text = "";
            txbEdad.Text = ""; ;
            txbTelefono.Text = "";
            txbDni.Text = "";
            LtbRutasExcursionista.Items.Clear();
            estadoBotones(1);
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres limpiar todos los campos?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Foto.Source = null;
                txbNombre.Text = "";
                txbApellidos.Text = "";
                txbEdad.Text = ""; ;
                txbTelefono.Text = "";
                txbDni.Text = "";
                LtbRutasExcursionista.Items.Clear();
            }
        }
        private void ButtonAlLadoDeLaPersona(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int valor = 0;
            Excursionista excursionista = ListaParticipantes.SelectedItem as Excursionista;
            if(excursionista != null)
            {
                if (button.Content == null)
                {
                    valor = 2;
                    rutaElegida.participantes.Remove(excursionista);
                }
                else if (button.Content.Equals("check"))
                {
                    valor = 2;
                    rutaElegida.participantes.Remove(excursionista);
                }
                else
                {
                    valor = 1;
                    rutaElegida.participantes.Add(excursionista);
                }
                cambiarImagenDelBoton(button, valor);
            }
            else
            {
                MessageBox.Show("Debe seleccionar el excursionista primero y luego darle su respectivo boton.", "Error", MessageBoxButton.OK);
            }
            
        }
        private void btnActualizarFoto_Click(object sender, RoutedEventArgs e) // Terminado
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                Uri NuevaFoto = new Uri(openFileDialog.FileName);
                BitmapImage nuevaImagen = new BitmapImage(new Uri(openFileDialog.FileName));
                Foto.Source = nuevaImagen;
                Imagen = NuevaFoto;
            }
        }
        // Esta variable se usa para guardar la imagen tras pulsar el boton de actualizar foto, para luego implementarla cuando se cree o modifique un guia
        public Uri Imagen { get; set; }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/

        private void cambiarImagenDelBoton(Button button, int opcion) // Terminado
        {
            if (opcion == 1)
            {
                System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres añadir este participante a la ruta?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    ImageBrush imagenCheck = new ImageBrush();
                    imagenCheck.ImageSource = new BitmapImage(new Uri("check.png", UriKind.RelativeOrAbsolute));
                    button.Background = imagenCheck;
                    button.Content = "check";
                }
               
            }
            else if(opcion == 2)
            {
                System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este participante a la ruta?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    ImageBrush imagenCross = new ImageBrush();
                    imagenCross.ImageSource = new BitmapImage(new Uri("cross.png", UriKind.RelativeOrAbsolute));
                    button.Background = imagenCross;
                    button.Content = "cross";
                }
            }
        }
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
        private void estadoBotones(int opcion) // Terminado
        {
            if (rutaElegida.Finalizada == false)
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
            }
            else
            {
                btnAnadir.IsEnabled=false;
                btnMod.IsEnabled=false;
                btnBorrar.IsEnabled=false;
                btnActualizarFoto.IsEnabled=false;
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
