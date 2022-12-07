﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HECHA

namespace Lab_IPO1_ft.Ana_Enrique
{
    public class Ruta
    {
        public string Nombre { set; get; }
        public string Provincia { set; get; }
        public int Duracion { set; get; }
        public int dificultad { get; set; }
        public List<int> participantes { get; set; } //id es telefono
        public List<string> puntosInteres { get; set; }//id es nombre
        public string formaLlegada { get; set; }
        public string formaVuelta { get; set; }
        public List<string> material { get; set; }
        public bool seCome { set; get; }
        public int guia { get; set; } //id es telefono
        public string Descripcion { set; get; }
        public string Origen { set; get; }
        public string Destino { set; get; }
        public DateTime FechayHora { get; set; }
        public bool Finalizada { set; get; }
        public Uri Mapa { set; get; }
        public Uri Imagenlista { set; get; }
        public List<string> incidencias { get; set; }
        public List<string> dificultades { get;set; }
        public Ruta(string nombre, string provincia, Uri mapa, string descripcion, int duracion) {
            dificultades.Add("Baja");
            dificultades.Add("Media");
            dificultades.Add("Alta");
            Nombre = nombre;
            Provincia = provincia;
            Mapa = mapa;
            Descripcion = descripcion;
            Duracion = duracion;
           

        }
    }
}
