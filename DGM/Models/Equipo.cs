using System;
using System.Collections.Generic;

#nullable disable

namespace DGM.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            Jugadores = new HashSet<Jugadore>();
        }

        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Jugadore> Jugadores { get; set; }
    }
}
