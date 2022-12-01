using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_IPO1_ft.Ana_Enrique
{
    public class Ruta
    {
        public string Nombre { set; get; }
        public string Provincia { set; get; }
        public int Duracion { set; get; }
        public List<string> dificultad { get; }
        public List<Excursionista> participantes { get; set; }
        public List<PuntoDeInteres> puntosInteres { get; set; }
        public string formaLlegada { get; set; }
        public string formaVuelta { get; set; }
        public List<string> material { get; set; }
        public bool seCome { set; get; }
        public Guia guia { get; set; }
        public string Descripcion { set; get; }
        public string Origen { set; get; }
        public string Destino { set; get; }
        public DateTime FechayHora { get; set; }
        public bool Finalizada { set; get; }
        public Uri Mapa { set; get; }
        public List<string> incidencias { get; set; }
        public Ruta(string nombre, string provincia, Uri mapa, string descripcion, int duracion) {
            Nombre = nombre;
            Provincia = provincia;
            Mapa = mapa;
            Descripcion = descripcion;
            Duracion = duracion;
            dificultad.Add("Baja");
            dificultad.Add("Media");
            dificultad.Add("Alta");

        }
    }
}
