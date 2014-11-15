using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnigmaEmulator.Factories
{
    class InvalidRotorException : Exception
    {
        public InvalidRotorException(string message) : base(message) { }
    }
}
