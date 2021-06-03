using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class AppdbContext : DbContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        public AppdbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dbLabbbb5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasSequence<int>("Docid").IncrementsBy(1);
            modelBuilder.HasSequence<int>("Labid").IncrementsBy(1);
            modelBuilder.HasSequence<int>("Hosid").IncrementsBy(1);
            modelBuilder.HasSequence<int>("Patid").IncrementsBy(1);

            modelBuilder.Entity<Doctor>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Docid");

            modelBuilder.Entity<Hospital>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Hosid");

            modelBuilder.Entity<Lab>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Labid");

            modelBuilder.Entity<Patient>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Patid");


        }
    }
}
