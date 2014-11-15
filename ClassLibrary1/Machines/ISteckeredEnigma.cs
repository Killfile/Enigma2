using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.Machines
{
    public interface ISteckeredEnigma : IEnigmaMachine
    {
        void Stecker(char a, char b);
    }
}
