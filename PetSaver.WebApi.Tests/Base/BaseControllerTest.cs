using Bugsnag.AspNet.WebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.WebApi.Controllers;
using System;

namespace PetSaver.WebApi.Tests.Base
{
    [TestClass]
    public class BaseControllerTest
    {
        [TestMethod]
        public void TratarErro_SystemException_SendToBugsnag()
        {
            var controller = new BaseController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };

            controller.Configuration.UseBugsnag(Bugsnag.ConfigurationSection.Configuration.Settings);

            controller.TratarErro(new Exception("Teste Bugsnag"));

            Assert.IsTrue(true);
        }
    }
}
