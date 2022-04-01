using CoreWebApp.Api.BusinessOperations.Interfaces;
using CoreWebAppFizzBuzz.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoreWebAppFizzBuzz.UnitTests
{
    [TestClass]
    public class FizzBuzzControllerTests
    {
        private FizzBuzzController _sut;
        private Mock<IFizzBuzz> _fizzBuzz;


        [TestInitialize]
        public void Initialize()
        {
            _fizzBuzz = new Mock<IFizzBuzz>();
            //_fizzBuzz.Setup(x => x.GetFzzBuzz(new string[] { "1", "3", "5", "15" })).Returns(new List<string>() { "Valid!" });

            // Subject Under Test
            _sut = new FizzBuzzController(_fizzBuzz.Object);
        }

        [TestMethod]
        public async void Verify_Result_Of_Controller_Method()
        {
            var fizzBuzz = _sut.Get(new string[] { "1", "3", "5", "15" });
            Assert.IsNotNull(fizzBuzz);
        }
    }
}
