using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Likes
    {
        public int IdLike { get; set; }
        public int IdUsuario { get; set; }
        public int IdPuntoReciclaje { get; set; }


        public PuntosReciclaje PuntosReciclaje { get; set; }
        public Usuario Ususario { get; set; }  
    }
}
