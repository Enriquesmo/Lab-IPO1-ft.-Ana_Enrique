﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HECHO

namespace Lab_IPO1_ft.Ana_Enrique
{
    public class PuntoDeInteres
    {
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Tipo { set; get; }
        public ObservableCollection<Uri> galeria { set; get; }
        public PuntoDeInteres(string nombre, string descripcion){
            Nombre = nombre;
            Descripcion = descripcion;
            galeria = new ObservableCollection<Uri>();
        }
        public PuntoDeInteres(string nombre, string descripcion, string tipo)
        {
            Nombre= nombre;
            Descripcion= descripcion;
            Tipo = tipo;
            galeria= new ObservableCollection<Uri>();
        }
    }
}
