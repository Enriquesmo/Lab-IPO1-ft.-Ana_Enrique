using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_IPO1_ft.Ana_Enrique
{
    public class PuntoDeInteres
    {

        public string Nombre { set; get; }
        public List<string> tipologia { set; get; }
        public string Descripcion { set; get; }
        public Uri mapa { set; get; }
        public List<Uri> galeria { set; get; }
        public PuntoDeInteres(string titulo, string prvin, Uri caratula, string argumento, int duracion)
            {
                Nombre = titulo;
                Provincia = prvin;
                Imagenlista = caratula;
                Descripcion = argumento;
            Duracion = duracion;
            tipologia.Add("");
            tipologia.Add("");
            tipologia.Add("");


        }
    }
}
