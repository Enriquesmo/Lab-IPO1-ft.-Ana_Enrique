using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_IPO1_ft.Ana_Enrique.Datos
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
        public Uri Imagenlista { set; get; }
        public string Origen { set; get; }
        public string Destino { set; get; }
        public DateTime FechayHora { get; set; }
        public bool Finalizada { set; get; }
        public Uri mapa { set; get; }
        public Ruta(string titulo, string prvin, Uri caratula, string
        argumento, int duracion)
        {
            Nombre = titulo;
            Provincia = prvin;
            Imagenlista = caratula;
            Descripcion = argumento;
            Duracion = duracion;
            dificultad.Add("Baja");
            dificultad.Add("Media");
            dificultad.Add("Alta");

        }
    }
}
