using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ktiAdatkataszt.Models
{
    public partial class DatabaseContext : DbContext
    {
        // adatbázis kontextus kijelölése; call <= Program.cs
        // public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) <= ez volt
        public DatabaseContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public virtual DbSet<Testframe> Testframe { get; set; }

        // https://www.findandsolve.com/articles/unable-create-an-object-of-type-datacontext-for-the-different-patterns
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)

            {

                options.UseSqlServer("A FALLBACK CONNECTION STRING");

            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Testframe>(entity =>
            {
                // .net frontenden lévő áttekintő adatok tipizálása
               
                entity.Property(x => x.Dátum).HasColumnType("datetime");
                entity.Property(x => x.Név).HasColumnType("string");
                entity.Property(x => x.Kategória).HasColumnType("string");
                entity.Property(x => x.Melléklet).HasColumnType("byte");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
