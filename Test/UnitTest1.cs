using Concecionaria.Controllers;
using Concecionaria.Entity;
using Concecionaria.UnitOfWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
             
        [Fact]
        public void Test1()
        {
            var dbfake = A.Fake<IUnitOfWork>();
            A.CallTo(() => dbfake.ClienteRepo.GetAll());

            var controller = new ClienteController(dbfake);

            var test = controller.Get();
            Assert.NotNull(test);
        }

        [Fact]
        public void Test2()
        {
            var dbfake = A.Fake<IUnitOfWork>();
            A.CallTo(() => dbfake.ClienteRepo.GetAll());
            var controller = new ClienteController(dbfake);
            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nombre = "Nicolas",
                Apellido = "Francolino",
                Dni = "35830046",

            };
            var test = controller.Post(cliente);
            Assert.NotNull(test);
            

        }

    }
}