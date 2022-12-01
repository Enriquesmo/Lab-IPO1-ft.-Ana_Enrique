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
using System.Xml;

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para ListaDeRutas.xaml
    /// </summary>
    public partial class ListaDeRutas : Window
    {
        List<Ruta> listadorutas;
        public ListaDeRutas()
        {
            InitializeComponent();
            listadorutas= new List<Ruta>();
            listadorutas = CargarContenidoXML();
            Listarutas.ItemsSource = listadorutas;
        }
        private List<Ruta> CargarContenidoXML()
        {
            List<Ruta> listado = new List<Ruta>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/peliculas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaRuta = new Ruta("", 0, null, "", 0);
                nuevaRuta.Nombre = node.Attributes["Titulo"].Value;
                nuevaRuta.Origen = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevaRuta.Duracion = Convert.ToInt32(node.Attributes["Duracion"].Value);
                nuevaRuta.Descripcion = node.Attributes["Argumento"].Value;
                nuevaRuta.Imagenlista = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative);
                nuevaRuta.guia = node.Attributes["Director"].Value;
                nuevaRuta.material = node.Attributes["Genero"].Value;
                nuevaRuta.FechayHora = Convert.ToDateTime(node.Attributes["AltaEnVideoteca"].Value);
                nuevaRuta.Finalizada = Convert.ToBoolean(node.Attributes["Visualizada"].Value);
                nuevaRuta.mapa = new Uri(node.Attributes["URL_IMDB"].Value, UriKind.Absolute);
                listado.Add(nuevaRuta);
            }

            //hay que terminarlo
            return listado;
        }
    }
}
