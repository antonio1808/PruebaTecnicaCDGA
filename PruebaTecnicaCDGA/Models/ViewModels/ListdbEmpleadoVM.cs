using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnicaCDGA.Models.ViewModels
{
    public class ListdbEmpleadoVM
    {
        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int idPuesto { get; set; } 
        public string DPI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngresoRegistro { get; set; }

    }
}