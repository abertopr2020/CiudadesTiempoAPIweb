using CiudadesTiempoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiudadesTiempoAPI.Data
{
    public class Basecontext : DbContext
    {
        public Basecontext(DbContextOptions<Basecontext> option) : base(option)
        {

        }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Pais> Paises { get; set; }
    }
}
