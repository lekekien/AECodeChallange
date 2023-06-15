using AE.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AE.Data
{
    public  class AECCodeChallangeContext : DbContext
    {
        public AECCodeChallangeContext()
        {

        }
        public AECCodeChallangeContext(DbContextOptions<AECCodeChallangeContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public virtual DbSet<Ship> Ship { get; set; }
        public virtual DbSet<Port> Port { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Port>().HasData(
                 new Port
                 {
                     Id = Guid.NewGuid(),
                     Name = "Port1",
                     Longtitude = new Random().NextDouble(),
                     Lattitude = new Random().NextDouble(),
                 },
                new Port
                {
                    Id = Guid.NewGuid(),
                    Name = "Port2",
                    Longtitude = new Random().NextDouble(),
                    Lattitude = new Random().NextDouble(),
                },
                 new Port
                 {
                     Id = Guid.NewGuid(),
                     Name = "Port3",
                     Longtitude = new Random().NextDouble(),
                     Lattitude = new Random().NextDouble(),
                 },
                 new Port
                 {
                     Id = Guid.NewGuid(),
                     Name = "Port4",
                     Longtitude = new Random().NextDouble(),
                     Lattitude = new Random().NextDouble(),
                 },
                 new Port
                 {
                     Id = Guid.NewGuid(),
                     Name = "Port5",
                     Longtitude = new Random().NextDouble(),
                     Lattitude = new Random().NextDouble(),
                 }
            ) ;

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
