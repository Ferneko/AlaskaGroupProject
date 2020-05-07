using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Exceptions
{
    public class RegistroRepetidoException : Exception
    {
        public RegistroRepetidoException(string message)
       : base(message)
        {
        }

        public RegistroRepetidoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
