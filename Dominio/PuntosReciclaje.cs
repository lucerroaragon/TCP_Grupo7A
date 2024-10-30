﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PuntosReciclaje
    {
        public int IdPuntoReciclaje { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Horario { get; set; }
        public string Telefono { get; set; }
        public string Imagen { get; set; }
        public List<string> Imagenes { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public List<Comentarios> Comentarios { get; set; }
        public List<Likes> Likes { get; set; }


    }
}