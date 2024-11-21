using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Administrador { get; set; }
        public bool Estado { get; set; }


        public List<Comentarios> Comentarios { get; set; }
        public List<Likes> Likes { get; set; }

        
    }
}
