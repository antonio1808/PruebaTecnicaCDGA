using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaCDGA.Models.ViewModels
{
    public class dbEmpleadoVM
    {
        public int idEmpleado { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [Required]
        [Display(Name ="Puesto")]
        public int idPuesto { get; set; }
        [Required]
        public string DPI { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha NAC")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime FechaIngresoRegistro { get; set; }
    }
}