using Gesbanc.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gesbanc.Infrastructure.Context
{
    public class GesbancContext : DbContext
    {
        public GesbancContext(DbContextOptions<GesbancContext> options) : base(options) { }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<GrupoEntidadEntity> GrupoEntidad { get; set; }
        public DbSet<EntidadEntity> Entidad { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configure relations
            builder.Entity<UserEntity>()
                .HasIndex(u => u.Id)
                .IsUnique(true);

            builder.Entity<UserEntity>()
                .Property(x => x.Active)
                .IsRequired(true)
                .HasDefaultValue(true);

            builder.Entity<GrupoEntidadEntity>()
                .HasMany(x => x.Entidad)
                .WithOne(x => x.GrupoEntidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.GrupoEntidadId);

            builder.Entity<EntidadEntity>()
                .HasOne(x => x.GrupoEntidad)
                .WithMany(x => x.Entidad)
                .OnDelete(DeleteBehavior.Cascade);


            //Add some data
            AddData(builder);
        }

        /// <summary>
        /// seed data
        /// </summary>
        /// <param name="builder"></param>
        private void AddData(ModelBuilder builder)
        {
            //users
            builder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 1,
                    Username = "test",
                    Password = "098f6bcd4621d373cade4e832627b4f6",
                    Active = true
                },
                new UserEntity
                {
                    Id = 2,
                    Username = "test2",
                    Password = "098f6bcd4621d373cade4e832627b4f6",
                    Active = false
                }
            );

            builder.Entity<GrupoEntidadEntity>().HasData(
               new GrupoEntidadEntity
               {
                   Id = 1,
                   Nombre = "Sabadell",
                   Color = "Azul"
               },
               new GrupoEntidadEntity
               {
                   Id = 2,
                   Nombre = "Bankia",
                   Color = "Verde"
               }
           );

            builder.Entity<EntidadEntity>().HasData(
               new EntidadEntity
               {
                   Id = 1,
                   GrupoEntidadId = 1,
                   Nombre = "Sabadell",
                   CodPostal = "01234",
                   Estado_Activo = true,
                   Logo = "logo1.png",
                   Mail = "sabadell@test.com",
                   Pais = "España",
                   Provincia = "Alicante",
                   Poblacion = "Elche",
                   Telefono = "12486196"

               },
              new EntidadEntity
              {
                  Id = 1,
                  GrupoEntidadId = 1,
                  Nombre = "Sabadell 2",
                  CodPostal = "43432",
                  Estado_Activo = true,
                  Logo = "logo1.png",
                  Mail = "sabadell2@test2.com",
                  Pais = "España",
                  Provincia = "Alicante",
                  Poblacion = "Alicante",
                  Telefono = "454634"

              },
              new EntidadEntity
              {
                  Id = 1,
                  GrupoEntidadId = 2,
                  Nombre = "Bankia",
                  CodPostal = "01234",
                  Estado_Activo = true,
                  Logo = "logo2.png",
                  Mail = "Bankia@test.com",
                  Pais = "España",
                  Provincia = "Madrid",
                  Poblacion = "Madrid",
                  Telefono = "12486196"
              }
           );

            
        }
    }
}
