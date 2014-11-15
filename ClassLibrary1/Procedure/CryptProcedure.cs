using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("EnigmaTests")]
namespace EnigmaEmulator.Procedure
{
    internal class CryptProcedure
    {
        public string Transform(string input)
        {
            return input.ToUpper();
        }
    }
}
