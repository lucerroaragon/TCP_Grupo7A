using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reportes
    {
        public int IdReporte { get; set; }
        public int IdUsuario { get; set; }
        public int IdPuntoReciclaje { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaReporte { get; set; }

        public PuntosReciclaje PuntosReciclaje { get; set; }
        public Ususario Ususario { get; set; }
    }
}
