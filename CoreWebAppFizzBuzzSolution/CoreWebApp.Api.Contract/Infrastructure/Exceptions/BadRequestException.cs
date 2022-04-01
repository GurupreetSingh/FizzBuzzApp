using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Api.Contract.Infrastructure.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base()
        { }

        /// <summary>
        /// Initialize a new instance of a class with a message
        /// </summary>
        /// <param name="message">Message that describe the Error.</param>
        public BadRequestException(string message)
            : base(message)
        {

        }
    }
}
