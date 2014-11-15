using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.Rotors
{
    public class RotorWiring
    {
        protected const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string Mapping;

        public RotorWiring(String mapping)
        {
            Mapping = mapping;
        }

        public char Convert(char c) {
            int alphabeticalIndexOfCharacter = Alphabet.IndexOf(c);
            char targetCharacter = Mapping[alphabeticalIndexOfCharacter];
            return targetCharacter;
        }

        public char Reverse(char c) {
            int mapingIndexOfCharacter = Mapping.IndexOf(c);
            char targetCharacter = Alphabet[mapingIndexOfCharacter];
            return targetCharacter;
        }
    }
}
