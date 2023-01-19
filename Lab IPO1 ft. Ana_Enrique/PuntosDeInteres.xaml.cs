using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

// FALTA: poner colores bonitos

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para PuntosDeInteres.xaml
    /// </summary>
    public partial class PuntosDeInteres : Window
    {
        /************************************************************************************************/

        /*Inicializacion de la ventana PuntosDeInteres*/

        public int indi = 1;
        Ruta rutaElegida;
        public ObservableCollection<Uri> galeriaAux;
        public PuntosDeInteres(Ruta ruta) // Terminado
        {
            InitializeComponent();
            rutaElegida = ruta;
            galeriaAux = new ObservableCollection<Uri>();
            cbTipo.Items.Add("Mirador");
            cbTipo.Items.Add("Área de avistamiento de aves");
            cbTipo.Items.Add("Existencia de plantas autóctonas");
            cbTipo.Items.Add("Masa de agua");
            cbTipo.Items.Add("Margen de un río");
            cbTipo.Items.Add("Puentes");
            cbTipo.Items.Add("Pinturas rupestres");
            cbTipo.Items.Add("Edificación de interés histórico");
            foreach (PuntoDeInteres x in ruta.puntosInteres){
                ListaPuntos.Items.Add(x);
            }
            if (ruta.Finalizada)
            {
                btnBorrarP.IsEnabled = false;
                btnAnadirP.IsEnabled = false;
                btnModP.IsEnabled = false;
                btnAnadirImg.IsEnabled = false;
            }
            lblImagenes.Content = "0/0";
            btnDcha.IsEnabled = false;
            btnIzq.IsEnabled = false;  
        }

        /************************************************************************************************/

        /*Botones de la propia pagina PuntosDeInteres*/

        private void ListaPuntos_SelectionChanged(object sender, SelectionChangedEventArgs e) // Terminado
        {
            ListaPuntos.Items.Refresh();
            PuntoDeInteres puntosel = ListaPuntos.SelectedItem as PuntoDeInteres;
            btnIzq.IsEnabled = false;
            btnDcha.IsEnabled=false;
            if (puntosel != null)
            {
                galeriaAux = puntosel.galeria;
                txbDescripcion.Text = puntosel.Descripcion;
                txbNombreP.Text = puntosel.Nombre;
                if (puntosel.galeria != null  && puntosel.galeria.Count != 0)
                {
                    var bitmap = new BitmapImage(puntosel.galeria.ElementAt(0));
                    Img.Source = bitmap;
                    indi = 1;
                    lblImagenes.Content = indi + "/" + puntosel.galeria.Count;
                    if (puntosel.galeria.Count > 1)
                    {
                        btnDcha.IsEnabled = true;
                    }
                }
                foreach (String s in cbTipo.Items)
                {
                    if (puntosel.Tipo != null)
                    {
                        if (puntosel.Tipo.Equals(s))
                        {
                            cbTipo.SelectedItem = s;
                        }
                    }
                }
            }
        }
        private void btnAnadirP_Click(object sender, RoutedEventArgs e) // Terminado
        {
            PuntoDeInteres nuevoPunto = new PuntoDeInteres("", "");
            String nombreAux = introducirString(txbNombreP.Text);
            if (nombreAux.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre del Punto de Interés.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
            }
            else
            {
                System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres añadir este Punto de Interés?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    nuevoPunto.Nombre = introducirString(txbNombreP.Text);
                    nuevoPunto.Descripcion = introducirString(txbDescripcion.Text);
                    if (cbTipo.SelectedItem != null)
                    {
                        nuevoPunto.Tipo = cbTipo.SelectedItem.ToString();
                    }
                    if (galeriaAux != null)
                    {
                        nuevoPunto.galeria = galeriaAux;
                    }
                    rutaElegida.puntosInteres.Add(nuevoPunto);
                    ListaPuntos.Items.Add(nuevoPunto);
                }
            }
        }
        private void btnBorrarP_Click(object sender, RoutedEventArgs e) // Terminado
        {
            PuntoDeInteres seleccionada = ListaPuntos.SelectedItem as PuntoDeInteres;
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Está seguro que quiere borrar el participante?.", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ListaPuntos.Items.Remove(seleccionada);
                txbNombreP.Text = "";
                txbDescripcion.Text = "";
                cbTipo.SelectedIndex = -1;
                rutaElegida.puntosInteres.Remove(seleccionada);
            }
        }
        private void btnModP_Click(object sender, RoutedEventArgs e) // Terminado
        {
            PuntoDeInteres seleccionada = ListaPuntos.SelectedItem as PuntoDeInteres;
            String nombreAux = introducirString(txbNombreP.Text);
            if (nombreAux.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre del Punto de Interés.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
            }
            else
            {
                System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres añadir este Punto de Interés?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    seleccionada.Nombre = introducirString(txbNombreP.Text);
                    seleccionada.Descripcion = introducirString(txbDescripcion.Text);
                    if (cbTipo.SelectedItem != null)
                    {
                        seleccionada.Tipo = cbTipo.SelectedItem.ToString();
                    }
                    seleccionada.galeria = galeriaAux;
                    rutaElegida.puntosInteres.Remove(seleccionada);
                    rutaElegida.puntosInteres.Add(seleccionada);
                }
            }
        }
        private void btnAnadirImg_Click(object sender, RoutedEventArgs e) // Terminado
        {
            PuntoDeInteres seleccionada = ListaPuntos.SelectedItem as PuntoDeInteres ;
            if (seleccionada != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    Uri NuevaFoto = new Uri(openFileDialog.FileName);
                    BitmapImage nuevaImagen = new BitmapImage(new Uri(openFileDialog.FileName));
                    Img.Source = nuevaImagen;
                    galeriaAux.Add(NuevaFoto);
                    if (seleccionada.galeria.Count > 1)
                    {
                        btnDcha.IsEnabled = true;
                    }
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    Uri NuevaFoto = new Uri(openFileDialog.FileName);
                    galeriaAux.Add(NuevaFoto);
                    BitmapImage nuevaImagen = new BitmapImage(new Uri(openFileDialog.FileName));
                    Img.Source = nuevaImagen;
                }
            }
            Img.Visibility = Visibility.Visible;
        }
        private void btnDcha_Click(object sender, RoutedEventArgs e) // Terminado
        {
            PuntoDeInteres selecci = ListaPuntos.SelectedItem as PuntoDeInteres;
            indi++;
            var bitmap = new BitmapImage(selecci.galeria.ElementAt(indi-1));
            Img.Source = bitmap;
            btnIzq.IsEnabled = true;
            
            lblImagenes.Content = indi + "/" + selecci.galeria.Count;
            if (indi == selecci.galeria.Count)
            {
                btnDcha.IsEnabled = false;
            }
        }
        private void btnIzq_Click(object sender, RoutedEventArgs e) // Terminado
        {
            PuntoDeInteres selecci = ListaPuntos.SelectedItem as PuntoDeInteres;
            indi--;
            var bitmap = new BitmapImage(selecci.galeria.ElementAt(indi - 1));
            Img.Source = bitmap;
            btnDcha.IsEnabled=true;

            lblImagenes.Content = indi + "/" + selecci.galeria.Count;
            if (indi == 1)
            {
                btnIzq.IsEnabled = false;
            }
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show(" ·Para consultar los detalles de un Punto de Interés, seleccione uno de la lista de la izquierda.\n \n ·A su vez, para añadir un punto nuevo, rellene todos sus campos. \n\n ·Por ultimo, tenga en cuenta que si la ruta ha sido finalizada, no se podrán modificar sus Puntos de interés.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void btnX_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ListaPuntos.SelectedItem = null;
            Img.Source=null;
            txbNombreP.Text = "";
            txbDescripcion.Text = "";
            cbTipo.SelectedItem = null;
            btnDcha.IsEnabled = false;
            btnIzq.IsEnabled=false;
            galeriaAux = new ObservableCollection<Uri>();
            lblImagenes.Content = "0/0";
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/
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
    }
}
