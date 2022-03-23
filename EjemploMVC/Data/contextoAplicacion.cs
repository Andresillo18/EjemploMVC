using EjemploMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVC.Data
{
    public class contextoAplicacion: DbContext
    {

        // CONSTRUCTOR
        public contextoAplicacion(DbContextOptions<contextoAplicacion> options) : base(options) { 

        }

        // PROPIEDADES (se crea una propiedad por cada tabla)
        public DbSet<Libro> Libro { get; set; }


        // Si uno requiriera modificar características de la tabla, 
        // Se debe SOBRESCRIBIR el método OnModelCreating

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    base.OnModelCreating(modelBuilder);
        //}

    }

    
}
