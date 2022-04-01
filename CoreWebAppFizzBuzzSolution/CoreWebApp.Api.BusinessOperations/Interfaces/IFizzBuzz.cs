using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Api.BusinessOperations.Interfaces
{
    public interface IFizzBuzz
    {
        List<string> GetFzzBuzz(string[] fizzBuzzOperation);
    }
}
