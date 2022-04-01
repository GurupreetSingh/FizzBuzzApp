using CoreWebApp.Api.BusinessOperations.Interfaces;
using CoreWebApp.Api.Contract.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAppFizzBuzz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController
    {
        private readonly IFizzBuzz _fizzBuzz;
        public FizzBuzzController(IFizzBuzz fizzBuzz)
        {
            _fizzBuzz = fizzBuzz;
        }

        [HttpPost(Name = "GetFizzBuzz")]
        public ActionResult<List<string>> Get(string[] fizzBuzzOperation)
        {
            return _fizzBuzz.GetFzzBuzz(fizzBuzzOperation);
        }
    }
}
