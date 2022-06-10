using System.Collections.Generic;
using Concecionaria.Controllers;
using Concecionaria.Entity;
using Concecionaria.UnitOfWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Test2
{
    public class UnitTest1
    {
        private readonly IUnitOfWork _context = A.Fake<IUnitOfWork>();

        [Fact]
        public void Test1()
        {

            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nombre = "Nicolas",
                Apellido = "Francolino",
                Direccion = "Tucuman 2619",
                Dni = "35830045",
            };
            
            var controler = new ClienteController(_context);
            var result = controler.Post(cliente);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Test2()
        {
            var controler = new ClienteController(_context);

            var test = controler.Get();
            Assert.NotNull(test);
        }

        [Fact]
        public void Test2_1()
        {
            var controler = new ClienteController(_context);

            var test = controler.Get();
            Assert.IsType<ActionResult<IEnumerable<Cliente>>>(test);
        }

        [Fact]
        public void Test3()
        {
            var controler = new ClienteController(_context);

            var result = controler.Delete(1);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Test4()
        {
            A.CallTo(() => _context.ClienteRepo.GetById(1)).Returns(null);
            var controler = new ClienteController(_context);
            var result = controler.Delete(1);
            Assert.IsType<NotFoundResult>(result);
        }

        //[Fact]
        //public void Test5()
        //{

        //    Cliente cliente = new Cliente()
        //    {
        //        Id = 1,
        //        Nombre = "Nicolas",
        //        Apellido = "Francolino",
        //        Direccion = "Tucuman 2619",
        //        Dni = "35830045",
        //    };

        //    A.CallTo(() => _context.ClienteRepo.Update(cliente)).Returns();
        //    var controler = new ClienteController(_context);
        //    var result = controler.Put;
        //    Assert.IsType<NotFoundResult>(result);
        //}
    }
}