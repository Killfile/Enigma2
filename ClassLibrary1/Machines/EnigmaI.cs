using EnigmaEmulator.Plugboard;
using EnigmaEmulator.Procedure;
using EnigmaEmulator.RotorAssembly;
using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.Machines
{
    public class EnigmaI : ISteckeredEnigma
    {
        public virtual int numberOfRotorsIncludingReflector { get { return 4; } }
        private RachetedRotorAssembly _rotorAssembly;
        private CryptProcedure _procedure;
        private Steckerbrett _plugboard;

        public EnigmaI()
        {
            _rotorAssembly = new RachetedRotorAssembly();
            _procedure = new CryptProcedure();
            _plugboard = new Steckerbrett();
        }

        public void SetRotorOffset(string offset)
        {
            //char[] reversedOffset = offset.Reverse().ToArray();
            _rotorAssembly.SetRotorOffset(offset);
            
        }

        public void SetRingSetting(string key)
        {
            _rotorAssembly.SetRotorOffset(key);
        }

        public string Crypt(string clearText)
        {
            clearText = _procedure.Transform(clearText);
            StringBuilder output = new StringBuilder();
            
            foreach (char character in clearText)
            {
                char cryptCharacter =  _plugboard.Translate(character);
                _rotorAssembly.Advance();
                cryptCharacter = _rotorAssembly.Crypt(cryptCharacter);
                cryptCharacter = _plugboard.Translate(cryptCharacter);
                output.Append(cryptCharacter);
            }
            return output.ToString();
        }


        public void SetRotors(Rotors.EnigmaRotor[] rotors)
        {
            if (rotors != null && rotors.Length == numberOfRotorsIncludingReflector && rotors[0] is EnigmaReflector)
                _rotorAssembly.SetRotors(rotors);
            else
                throw new RotorAssemblyConfigurationException();
        }


        public void Advance(int positions = 1)
        {
            _rotorAssembly.Advance();
        }


        public string GetRotorSettings()
        {
            return _rotorAssembly.RotorSettings;
        }

        public void Stecker(char a, char b)
        {
            _plugboard.Stecker(a, b);
        }
    }

    public class EnigmaIConfigurationException : Exception
    {
    }
}
