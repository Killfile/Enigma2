using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("EnigmaTests")]
namespace EnigmaEmulator.RotorAssembly
{
    internal class NestedRotorAssembly : ARotorAssembly
    {
        public override void SetRotors(Rotors.EnigmaRotor[] rotors)
        {
            throw new NotImplementedException();
        }

        public override void Advance(int positions = 1)
        {
            throw new NotImplementedException();
        }

        public override char Crypt(char clearText)
        {
            throw new NotImplementedException();
        }

        public override void SetRotorOffset(string offset)
        {
            throw new NotImplementedException();
        }

        public override void SetRingSettings(string ringsetting)
        {
            throw new NotImplementedException();
        }
    }
}
