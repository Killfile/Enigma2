using System;
using System.Linq;
using System.Text;
using EnigmaEmulator.Plugboard;
using EnigmaEmulator.Rotors;

namespace EnigmaEmulator.Machines
{
    public class NestedEnigmaMachine : IEnigmaMachine 
    {
        private NestedRotor _rotors;
        private Steckerbrett _plugboard;

        public NestedEnigmaMachine()
        {
            _plugboard = new Steckerbrett();
        }

        //public EnigmaMachine(NestedRotor rotorI, NestedRotor rotorII, NestedRotor rotorIII, Reflector reflectorB) : this()
        //{
        //    rotorI.Drives = reflectorB;
        //    rotorII.Drives = rotorI;
        //    rotorIII.Drives = rotorII;
        //    _rotors = rotorIII;
        //}

        public void SetRotors(EnigmaRotor[] rotors)
        {
            EnigmaReflector reflector = rotors[0] as EnigmaReflector;
            var temp = rotors.Skip(1).ToArray();
            var nestedRotors = Array.ConvertAll(temp, item => (NestedRotor)item);
            
            
            for (int i = nestedRotors.Length - 1; i > 0; i--)
            {
                nestedRotors[i].Drives = nestedRotors[i - 1];
            }

            nestedRotors[0].Drives = reflector;
            _rotors = nestedRotors[nestedRotors.Length-1];
            
        }

        public void SetRotorOffset(string offset)
        {
            _rotors.SetOffset(offset);
        }

        public void SetRingSetting(string key)
        {
            _rotors.SetOffset(key);
        }

       

        public string Crypt(string p)
        {
            StringBuilder result = new StringBuilder();
            foreach (char character in p)
            {
                Advance();
                char preSteckeredCharacter = _plugboard.Translate(character);
                char cryptedCharacter = _rotors.Crypt(preSteckeredCharacter);
                char postSteckeredCharacter = _plugboard.Translate(cryptedCharacter);
                result.Append(postSteckeredCharacter);
            }
            return result.ToString();
        }

        public void Setcker(char a, char b)
        {
            _plugboard.Stecker(a, b);
        }





        public void Advance(int positions = 1)
        {
            _rotors.Advance(positions);
        }


        public string GetRotorSettings()
        {
            return _rotors.CurrentConfiguration;
        }
    }
}
