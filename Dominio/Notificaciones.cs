using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Notificaciones
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaNotificacion { get; set; }
        public bool EsLeida { get; set; }

    

        public Ususario Usuario { get; set; }

    }
}
