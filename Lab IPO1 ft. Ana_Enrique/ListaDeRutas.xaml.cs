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
using System.Xml;

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para ListaDeRutas.xaml
    /// </summary>
    public partial class ListaDeRutas : Window
    {
        ObservableCollection<Ruta> listadorutas;
        ObservableCollection<Excursionista> particip;
        public ListaDeRutas()
        {
            InitializeComponent();
            particip= new ObservableCollection<Excursionista>();
            listadorutas = new ObservableCollection<Ruta>();
            Ruta ruta1 = new Ruta("Ruta A", "Ciudad Real", null, "Descripcion de prueba 1, ruta en ciudad real", 10, 1, 20, particip);
            Ruta ruta2 = new Ruta("Ruta B", "Madrid", null, "Descripcion de prueba 2, ruta en Madrid", 10, 1, 20, particip);
            listadorutas.Add(ruta1);
            listadorutas.Add(ruta2);
            Listarutas.ItemsSource = listadorutas;
           
        }
       /* private List<Ruta> CargarContenidoXML()
        {
            List<Ruta> listado = new List<Ruta>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("ListaDeRutas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaRuta = new Ruta("", "", null, "", 0);
                nuevaRuta.Nombre = node.Attributes["Titulo"].Value;
                nuevaRuta.Provincia= node.Attributes["Provincia"].Value.ToString();
                nuevaRuta.Duracion = Convert.ToInt32(node.Attributes["Duracion"].Value);
                
                nuevaRuta.dificultad = Convert.ToInt32(node.Attributes["dificultad"].Value);
                nuevaRuta.participantes.Add(Convert.ToInt32(node.Attributes["participante"].Value));
                nuevaRuta.puntosInteres.Add((node.Attributes["puntoInteres"].Value).ToString());
                nuevaRuta.formaLlegada = node.Attributes["formallegada"].Value.ToString();
                nuevaRuta.formaVuelta = node.Attributes["formavuelta"].Value.ToString();
                nuevaRuta.material.Add(node.Attributes["material"].Value);
                nuevaRuta.seCome = Convert.ToBoolean(node.Attributes["seCome"].Value);
                nuevaRuta.guia = Convert.ToInt32(node.Attributes["Guia"]);
                nuevaRuta.Descripcion = node.Attributes["Argumento"].Value;
                nuevaRuta.Origen = node.Attributes["Origen"].Value.ToString();
                nuevaRuta.Destino = node.Attributes["Destino"].Value.ToString();
                nuevaRuta.FechayHora = Convert.ToDateTime(node.Attributes["FechayHora"].Value);
                nuevaRuta.Finalizada = Convert.ToBoolean(node.Attributes["Finalizada"].Value);
                nuevaRuta.Imagenlista = new Uri(node.Attributes["Imagenlista"].Value, UriKind.Relative);
                nuevaRuta.Mapa = new Uri(node.Attributes["URL_IMDB"].Value, UriKind.Absolute);
                nuevaRuta.incidencias.Add(node.Attributes["incidencia"].Value);
                listado.Add(nuevaRuta);
            } 

            //hay que terminarlo
            return listado;
        }*/


        private void txbBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            //implementar buscador
        }

        private void Listarutas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            if (seleccionada != null)
            {
                mapa.Visibility = Visibility.Visible;
                lblNombreruta2.Content = seleccionada.Nombre;
                lblDescripcion2.Content = seleccionada.Descripcion;
                lblpartic2.Content = seleccionada.participantes.Count() + " / " + seleccionada.maxParticipantes;
                if (seleccionada.Finalizada == true)
                {
                    lblFinalizar.Visibility = Visibility.Visible;
                    btnFinalizar.IsEnabled = false;
                }
                else
                {
                    lblFinalizar.Visibility = Visibility.Hidden;
                    btnFinalizar.IsEnabled = true;
                }
            }
        }

        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            mapa.Visibility=Visibility.Hidden;
            lblNombreruta2.Content = "";
            lblDescripcion2.Content = "";
            lblpartic2.Content = "";
        }
        
        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            lblFinalizar.Visibility=Visibility.Visible;
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            seleccionada.Finalizada = true;
            btnFinalizar.IsEnabled = false;
        }

        private void Btn_BorrarRuta_Click(object sender, RoutedEventArgs e)
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            listadorutas.Remove(seleccionada);
        }

        /*Boton reservado para la Ventana Participantes*/
        private void btnParticipantes_Click(object sender, RoutedEventArgs e)
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            Participantes partic = new Participantes();
            partic.Show();
            partic.ListaParticipantes.ItemsSource = seleccionada.participantes;
            particip = seleccionada.participantes;
        }

        /*Botones reservados para la Ventana DetallesRuta*/
        private void Btn_AñadirRuta_Click(object sender, RoutedEventArgs e)
        {
            DetallesRuta ventanaDetallesRuta = new DetallesRuta(null);
            ventanaDetallesRuta.Show();

        }
        private void btnRuta_Click(object sender, RoutedEventArgs e)
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            DetallesRuta ventanaDetallesRuta = new DetallesRuta(seleccionada);
            ventanaDetallesRuta.Show();
        }
    }
}
