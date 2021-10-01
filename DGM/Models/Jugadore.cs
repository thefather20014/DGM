using System;
using System.Collections.Generic;

#nullable disable

namespace DGM.Models
{
    public partial class Jugadore
    {
        public int IdJugadores { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Pasaporte { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public int IdEquipo { get; set; }
        public int IdEstado { get; set; }

        public virtual Equipo IdEquipoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
    }
}
