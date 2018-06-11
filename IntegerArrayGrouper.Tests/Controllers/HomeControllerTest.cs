using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegerArrayGrouper;
using IntegerArrayGrouper.Controllers;
using IntegerArrayGrouper.Models;

namespace IntegerArrayGrouper.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestCorrectInput1()
        {
            HomeController controller = new HomeController();
            var input = new ViewModel()
            {
                Input = "[1,2,3,4,5,1,1]"
            };
            ViewResult result = controller.Index(input) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as ViewModel;
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsError);
            Assert.AreEqual("[1,2,3,4,5,1,1]", model.Input);
            Assert.AreEqual("[1]", model.Output);
        }

        [TestMethod]
        public void TestCorrectInput2()
        {
            HomeController controller = new HomeController();
            var input = new ViewModel()
            {
                Input = "[1,1,1,1,3,3,3,3,2,1,2,9,9,9]"
            };
            ViewResult result = controller.Index(input) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as ViewModel;
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsError);
            Assert.AreEqual("[1,1,1,1,3,3,3,3,2,1,2,9,9,9]", model.Input);
            Assert.AreEqual("[9,3,1]", model.Output);
        }

        [TestMethod]
        public void TestCorrectInput3()
        {
            HomeController controller = new HomeController();
            var input = new ViewModel()
            {
                Input = "[1,2,3,2,1,9,9,8]"
            };
            ViewResult result = controller.Index(input) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as ViewModel;
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsError);
            Assert.AreEqual("[1,2,3,2,1,9,9,8]", model.Input);
            Assert.AreEqual("[]", model.Output);
        }

        [TestMethod]
        public void TestInvalidInput()
        {
            HomeController controller = new HomeController();
            var input = new ViewModel()
            {
                Input = "[112,he3,2,1,9,9,8]"
            };
            ViewResult result = controller.Index(input) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as ViewModel;
            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsError);
            Assert.AreEqual("[112,he3,2,1,9,9,8]", model.Input);
            Assert.AreEqual("Invalid input format.", model.Output);
        }
    }
}
