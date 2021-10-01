using System;
using System.Collections.Generic;

#nullable disable

namespace DGM.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Jugadores = new HashSet<Jugadore>();
        }

        public int IdEstado { get; set; }
        public string Descripion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Jugadore> Jugadores { get; set; }
    }
}
