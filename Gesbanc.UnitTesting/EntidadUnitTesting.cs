using Gesbanc.Business.Contracts;
using Gesbanc.Business.Services;
using Gesbanc.Infrastructure.Context;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Infrastructure.Repositories;
using Gesbanc.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesbanc.UnitTesting
{
    [TestClass]
    public class EntidadUnitTesting
    {

        [TestMethod]
        public async Task PostAsyncTest()
        {
            var options = new DbContextOptionsBuilder<GesbancContext>()
                .UseInMemoryDatabase(databaseName: "gesbancFake")
                .Options;

            // Run the test against one instance of the context
            using (var context = new GesbancContext(options))
            {
                var repo = new EntidadRepository(context);

                var service = new EntidadService(repo);

                var entities = generateFakeEntidades();

                foreach(var entity in entities)
                {
                    await service.PostAsync(entity);
                }
            }

            // separated instance to verify.
            using (var context = new GesbancContext(options))
            {
                Assert.AreEqual(2, context.Entidad.Count());
                Assert.AreEqual("Sabadell", context.Entidad.FirstOrDefault().Nombre);
            }
        }

        [TestMethod]
        public async Task PutAsyncTest()
        {
            var options = new DbContextOptionsBuilder<GesbancContext>()
                .UseInMemoryDatabase(databaseName: "gesbancFake")
                .Options;

            // Run the test against one instance of the context
            using (var context = new GesbancContext(options))
            {
                var repo = new EntidadRepository(context);

                var entity = new EntidadEntity();

                var service = new EntidadService(repo);

                if (context.Entidad.Count() == 0)
                {
                    var ent = generateFakeEntidades().Where(x => x.Id == 1).FirstOrDefault();

                    entity = await service.PostAsync(ent);
                }
                else
                {
                    entity = context.Entidad.Where(x => x.Id == 1).FirstOrDefault();
                }

                entity.Nombre = "Sabadell3";

                await service.PutAsync(entity);


            }

            // separated instance to verify.
            using (var context = new GesbancContext(options))
            {
                Assert.AreEqual(2, context.Entidad.Count());
                Assert.AreEqual("Sabadell3", context.Entidad.Where(x => x.Id == 1).FirstOrDefault().Nombre);
            }
        }

        [TestMethod]
        public async Task DeleteAsyncTest()
        {
            var options = new DbContextOptionsBuilder<GesbancContext>()
                .UseInMemoryDatabase(databaseName: "gesbancFake")
                .Options;

            // Run the test against one instance of the context
            using (var context = new GesbancContext(options))
            {
                var repo = new EntidadRepository(context);

                var service = new EntidadService(repo);

                var entities = generateFakeEntidades();

                if (context.Entidad.Count() == 0)
                {
                    foreach (var entity in entities)
                    {
                        await service.PostAsync(entity);
                    }
                }

                await service.DeleteAsync(entities[0].Id);
            }

            // separated instance to verify.
            using (var context = new GesbancContext(options))
            {
                Assert.AreEqual(1, context.Entidad.Count());
                Assert.AreEqual("Bankia", context.Entidad.Single().Nombre);
            }
        }

        [TestMethod]
        public async Task GetAllAsync()
        {
            var options = new DbContextOptionsBuilder<GesbancContext>()
                .UseInMemoryDatabase(databaseName: "gesbancFake")
                .Options;

            // Run the test against one instance of the context
            using (var context = new GesbancContext(options))
            {
                var repo = new EntidadRepository(context);

                var service = new EntidadService(repo);

                var entities = generateFakeEntidades();

                foreach (var entity in entities)
                {
                    await service.PostAsync(entity);
                }
            }

            // separated instance to verify.
            using (var context = new GesbancContext(options))
            {
                Assert.AreEqual(2, context.Entidad.Count());
            }
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            var options = new DbContextOptionsBuilder<GesbancContext>()
                .UseInMemoryDatabase(databaseName: "gesbancFake")
                .Options;

            // Run the test against one instance of the context
            using (var context = new GesbancContext(options))
            {
                var repo = new EntidadRepository(context);

                var service = new EntidadService(repo);

                var entities = generateFakeEntidades();

                foreach (var entity in entities)
                {
                    await service.PostAsync(entity);
                }
            }

            // separated instance to verify.
            using (var context = new GesbancContext(options))
            {
                Assert.AreEqual("123123", context.Entidad.Where(x => x.Id == 1).FirstOrDefault().CodPostal);
            }
        }

        private List<EntidadEntity> generateFakeEntidades()
        {
            List<EntidadEntity> entities = new List<EntidadEntity>();

            entities.Add(
            new EntidadEntity
            {
                Id = 1,
                CodPostal = "123123",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Estado_Activo = true,
                GrupoEntidadId = 1,
                Logo = "logo1.png",
                Pais = "España",
                Mail = "email@test.com",
                Nombre = "Sabadell",
                Poblacion = "Elche",
                Provincia = "Alicante",
                Telefono = "112312312"
            });

            entities.Add(
            new EntidadEntity
            {
                Id = 2,
                CodPostal = "1231343423",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Estado_Activo = true,
                GrupoEntidadId = 1,
                Logo = "logo2.png",
                Pais = "España",
                Mail = "email2@test.com",
                Nombre = "Bankia",
                Poblacion = "Madrid",
                Provincia = "Madrid",
                Telefono = "34451231"
            });

            return entities;
        }
    }
}
