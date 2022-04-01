using CoreWebApp.Api.BusinessOperations.Interfaces;
using CoreWebApp.Api.BusinessOperations.Repository;
using CoreWebApp.Api.Contract.Enumerations;
using CoreWebApp.Api.Contract.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CoreWebAppFizzBuzz.UnitTests
{
    [TestClass]
    public class FizzBuzzRepositoryTests
    {
        private IFizzBuzz _sut;
        private Mock<ILogger<FizzBuzzRepository>> _logger;

        [TestInitialize]
        public void Initialize() {
            _logger = new Mock<ILogger<FizzBuzzRepository>>();

            // Subject Under Test
            _sut = new FizzBuzzRepository(_logger.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void It_Should_Return_Expected_Exception_BadRequestException_Value_Of_Input_As_Null()
        {
            string[] fizzBuzzOperation = new string[] { };
            List<string> result = _sut.GetFzzBuzz(fizzBuzzOperation);
        }

        [TestMethod]
        public void It_Should_Return_List_Of_Word_Per_Value_Of_Input()
        {
            string[] fizzBuzzOperation = new string[] { "", "3", "5", "15" };
            List<string> result = _sut.GetFzzBuzz(fizzBuzzOperation);
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void It_Should_Return_List_Of_Word_Per_Value_Of_Valid_Input()
        {
            string[] fizzBuzzOperation = new string[] { "3", "5", "15" };
            List<string> result = _sut.GetFzzBuzz(fizzBuzzOperation);
            Assert.AreEqual(ValueTypeName.Fizz, result[0]);
            Assert.AreEqual(ValueTypeName.Buzz, result[1]);
            Assert.AreEqual(ValueTypeName.FizzBuzz, result[2]);
        }

        [TestMethod]
        public void It_Should_Return_List_Of_Word_Per_Value_Of_Valid_Input_As_Per_Result()
        {
            string[] fizzBuzzOperation = new string[] { "1", "3", "5", "", "15", "A", "23" };
            List<string> result = _sut.GetFzzBuzz(fizzBuzzOperation);
            Assert.AreEqual(9, result.Count);
            Assert.AreEqual(string.Format("Divided {0} by 3", fizzBuzzOperation[0]), result[0]);
            Assert.AreEqual(string.Format("Divided {0} by 5", fizzBuzzOperation[0]), result[1]);
            Assert.AreEqual(ValueTypeName.Fizz, result[2]);
            Assert.AreEqual(ValueTypeName.Buzz, result[3]);
            Assert.AreEqual(ValueTypeName.Invalid, result[4]);
            Assert.AreEqual(ValueTypeName.FizzBuzz, result[5]);
            Assert.AreEqual(ValueTypeName.Invalid, result[6]);
            Assert.AreEqual(string.Format("Divided {0} by 3", fizzBuzzOperation[6]), result[7]);
            Assert.AreEqual(string.Format("Divided {0} by 5", fizzBuzzOperation[6]), result[8]);
        }
    }
}