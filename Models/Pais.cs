using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CiudadesTiempoAPI.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombrePais { get; set; }
        [Required]
        public int CiudadId { get; set; }
        [ForeignKey("CiudadId")]
        public Ciudad Ciudad { get; set; }

    }
}
