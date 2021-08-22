using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiudadesTiempoAPI.Models
{
    public class Ciudad
    {   [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCiudad { get; set; }
        [Required]
        public string HoraActual { get; set; }
        [Required]
        public string TemperaturaActual { get; set; }

    }
}
