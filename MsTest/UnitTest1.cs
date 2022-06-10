using Concecionaria.Controllers;
using Concecionaria.Entity;
using Concecionaria.UnitOfWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace MsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cliente cliente = new Cliente();
            //{
            //    Id = 1,
            //    Nombre = "Nicolas",
            //    Apellido = "Francolino",
            //    Dni = "35830046",

            //};
            var dbfake = A.Fake<IUnitOfWork>();
            A.CallTo(() => dbfake.ClienteRepo.Insert(cliente));
            var controller = new ClienteController(dbfake);
            var test = controller.Post(cliente);
            Assert.IsInstanceOfType(test, typeof(OkResult));
        }
    }
}