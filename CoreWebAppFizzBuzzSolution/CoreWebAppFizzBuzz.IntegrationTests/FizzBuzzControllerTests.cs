using CoreWebApp.Api.BusinessOperations.Interfaces;
using CoreWebApp.Api.BusinessOperations.Repository;
using CoreWebAppFizzBuzz.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoreWebAppFizzBuzz.IntegrationTests
{
    [TestClass]
    public class FizzBuzzControllerTests: BaseTestController
    {
        
        [TestInitialize]
        public void Initialize()
        {
           
        }

        [TestMethod]
        public async void Verify_Result_Of_EndPoint()
        {
            var fizzBuzz = await GetFizzBuzzAsync(new string[] { "1", "3", "5", "15" });
            Assert.IsNotNull(fizzBuzz);
        }

    }
}