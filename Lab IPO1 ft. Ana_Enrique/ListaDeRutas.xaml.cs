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
            List<Pelicula> listado = new List<Pelicula>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/peliculas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaPelicula = new Pelicula("", 0, null, "", 0);
                nuevaPelicula.Titulo = node.Attributes["Titulo"].Value;
                nuevaPelicula.Anio = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevaPelicula.Duracion = Convert.ToInt32(node.Attributes["Duracion"].Value);
                nuevaPelicula.Argumento = node.Attributes["Argumento"].Value;
                nuevaPelicula.Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative);
                nuevaPelicula.Director = node.Attributes["Director"].Value;
                nuevaPelicula.GeneroPelicula = node.Attributes["Genero"].Value;
                nuevaPelicula.AltaEnVideoteca = Convert.ToDateTime(node.Attributes["AltaEnVideoteca"].Value);
                nuevaPelicula.Visualizada = Convert.ToBoolean(node.Attributes["Visualizada"].Value);
                nuevaPelicula.URL_IMDB = new Uri(node.Attributes["URL_IMDB"].Value, UriKind.Absolute);
                listado.Add(nuevaPelicula);
            }
            return listado;
        }
    }
}
