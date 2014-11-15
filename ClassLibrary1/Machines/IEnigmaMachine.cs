using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.Machines
{
    public interface IEnigmaMachine
    {
        void SetRotorOffset(string offset);
        void SetRingSetting(string key);
        string Crypt(string clearText);
        void SetRotors(EnigmaRotor[] rotors);
        string GetRotorSettings();
    }
}
