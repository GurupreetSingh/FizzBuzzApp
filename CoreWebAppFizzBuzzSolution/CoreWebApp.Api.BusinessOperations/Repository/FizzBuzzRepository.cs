using CoreWebApp.Api.BusinessOperations.Interfaces;
using CoreWebApp.Api.Contract.Enumerations;
using CoreWebApp.Api.Contract.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Api.BusinessOperations.Repository
{
    public class FizzBuzzRepository : IFizzBuzz
    {
        private readonly ILogger<FizzBuzzRepository> _logger;
        public FizzBuzzRepository(ILogger<FizzBuzzRepository> logger)
        {
            _logger = logger;
        }

        public List<string> GetFzzBuzz(string[] fizzBuzzOperation)
        {
            List<string> list = new List<string>();
            if (fizzBuzzOperation == null || fizzBuzzOperation.Length == 0)
            {
                _logger.LogError(new BadRequestException("Invalid Parameter!"), "Bad Request Exception from GetFzzBuzz()", fizzBuzzOperation);
                throw new BadRequestException("Invalid Parameter!");
            }

            foreach (string str in fizzBuzzOperation)
            {
                string result = GenerateWord(str);
                if (string.IsNullOrEmpty(result))
                {
                    list.Add(string.Format("Divided {0} by 3", str));
                    list.Add(string.Format("Divided {0} by 5", str));
                }
                else
                {
                    list.Add(result);
                }
            }
            return list;
        }

        #region Private members
        private string GenerateWord(string? param)
        {
            if (!IsValidInteger(param)) { return ValueTypeName.Invalid; }
            else if ((Convert.ToInt16(param) % 5 == 0) && (Convert.ToInt16(param) % 3 == 0)) { return ValueTypeName.FizzBuzz; }
            else if (Convert.ToInt16(param) % 3 == 0) { return ValueTypeName.Fizz; }
            else if (Convert.ToInt16(param) % 5 == 0) { return ValueTypeName.Buzz; }
            else { return String.Empty; }
        }

        private bool IsValidInteger(string? param)
        {
            try
            {
                Convert.ToInt32(param);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}

