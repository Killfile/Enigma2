using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnigmaEmulator.Machines
{
    public class EnigmaM4 : EnigmaI
    {
        public override int numberOfRotorsIncludingReflector
        {
            get
            {
                return 5;
            }
        }
    }
}
