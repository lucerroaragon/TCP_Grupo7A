using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentarios
    {
        public int IdComentario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPuntoReciclaje { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaCometario { get; set; }

        public PuntosReciclaje PuntosReciclaje { get; set; }
        public Usuario Ususario { get; set; }
    }
}
