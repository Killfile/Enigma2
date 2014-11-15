using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.Rotors
{
    class StationaryRotor : NestedRotor
    {
        public override void Advance(int count = 1)
        {
            //Nothing to see here.  The whole point of a stationary rotor is that it doesn't advance.
        }
    }
}
