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
            var fichero = Application.GetResourceStream(new Uri("ListaDeRutas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaRuta = new Ruta("", "", null, "", 0);
                nuevaRuta.Nombre = node.Attributes["Titulo"].Value;
                nuevaRuta.Provincia= node.Attributes["Provincia"].Value.ToString();
                nuevaRuta.Duracion = Convert.ToInt32(node.Attributes["Duracion"].Value);
                
                nuevaRuta.dificultad = Convert.ToInt32(node.Attributes["dificultad"].Value);
                nuevaRuta.participantes.Add(node.Attributes["participante"].Value);
                nuevaRuta.puntosInteres.Add(node.Attributes["puntoInteres"].Value);
                nuevaRuta.formaLlegada = node.Attributes["formallegada"].Value.ToString();
                nuevaRuta.formaVuelta = node.Attributes["formavuelta"].Value.ToString();
                nuevaRuta.material.Add(node.Attributes["material"].Value);
                nuevaRuta.seCome = Convert.ToBoolean(node.Attributes["seCome"].Value);
                nuevaRuta.guia = node.Attributes["Guia"];
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
        }
    }
}
