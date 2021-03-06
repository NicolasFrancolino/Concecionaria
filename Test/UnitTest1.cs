
using Concecionaria.Controllers;
using Concecionaria.Entity;
using Concecionaria.UnitOfWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
             
        //[TestMethod]
        //public void Test1()
        //{
        //    var dbfake = A.Fake<IUnitOfWork>();
        //    A.CallTo(() => dbfake.ClienteRepo.GetAll());

        //    var controller = new ClienteController(dbfake);

        //    var test = controller.Get();
        //    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(test, typeof(NotFoundResult));
        //}

        [TestMethod]
        public void Test2()
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