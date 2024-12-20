﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PuntosReciclaje
    {
        public int IdPuntoReciclaje { get; set; }
        public Usuario Usuario { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public TipoReciclaje NombreTipo { get; set; }
        public List<string> TipoReciclaje { get; set; }
        public string Descripcion { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Estado { get; set; }
        public Imagenes NombreImagen { get; set; }
        public List<string> Imagenes { get; set; }
        public string MaterialesReciclables { get; set; }





        public List<Comentarios> Comentarios { get; set; }
        public List<Likes> Likes { get; set; }


    }
}
