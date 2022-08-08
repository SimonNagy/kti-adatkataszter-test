using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ktiAdatkataszt.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<testframe> testframe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<testframe>(entity =>
            {
                // .net frontenden lévő áttekintő adatok tipizálása
                entity.Property(x => x.Dátum).HasColumnType("datetime");
                entity.Property(x => x.Név).HasColumnType("string");
                entity.Property(x => x.Kategória).HasColumnType("string");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
