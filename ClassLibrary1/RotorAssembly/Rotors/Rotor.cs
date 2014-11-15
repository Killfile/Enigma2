using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.Rotors
{
    public class EnigmaRotor
    {
        protected RotorWiring _wiring;

        protected int _ringSetting;
        protected int[] _turnoverPosition;
        protected const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        protected int _rotorOffset;
        public char[] Turnover {
            get { return _turnoverPosition.Select(p => Alphabet[p]).ToArray(); }
            set { SetTurnover(value); } 
        }

        public char Offset
        {
            get { return Alphabet[_rotorOffset]; }
            set { SetOffset(value); }
        }

        public virtual string Mapping
        {
            get { return _wiring.Mapping; }
            set { _wiring.Mapping = value; }
        }

        private int EffectiveOffset
        {
            get { return (26 + _rotorOffset - _ringSetting) % 26; }
        }

        public EnigmaRotor()
        {
            _wiring = new RotorWiring(Alphabet);

            _rotorOffset = 0;
            _ringSetting = 0;
            _turnoverPosition = new int[] {25};
        }

        public EnigmaRotor(string mapping) : this()
        {
            _wiring = new RotorWiring(mapping);
        }


        public void SetRingSetting(char c)
        {
            _ringSetting = Alphabet.IndexOf(c);
        }

        public void SetTurnover(char c)
        {
            _turnoverPosition = new int[] {Alphabet.IndexOf(c)};
        }

        public void SetTurnover(char[] array)
        {
            _turnoverPosition = array.Select(c=>Alphabet.IndexOf(c)).ToArray();
        }

        public bool IsInTurnoverPosition
        {
            get
            {
                return _turnoverPosition.Contains(_rotorOffset);
            }
        }

        public void SetOffset(char c)
        {
            _rotorOffset = Alphabet.IndexOf(c);
        }

        public char Convert(char p)
        {

            char preMapped = MapIncomingCharacterThroughRotorOffset(p);
            char transformed = _wiring.Convert(preMapped); 
            char postMapped = MapOutgoingCharacterThroughRotorOffset(transformed);
            return postMapped;
        }

        private char MapIncomingCharacterThroughRotorOffset(char unmapped)
        {

            int alphabeticalIndexOfCharacter = Alphabet.IndexOf(unmapped);
            int mappedIndex = (alphabeticalIndexOfCharacter + EffectiveOffset) % 26;
            return Alphabet[mappedIndex];
        }

        private char MapOutgoingCharacterThroughRotorOffset(char unmapped)
        {

            int alphabeticalIndexOfCharacter = Alphabet.IndexOf(unmapped);

            while (alphabeticalIndexOfCharacter - EffectiveOffset < 0)
                alphabeticalIndexOfCharacter += 26;

            int mappedIndex = (alphabeticalIndexOfCharacter - EffectiveOffset) % 26;
            return Alphabet[mappedIndex];
        }

        public char ReverseConvert(char c)
        {
            char preMapped = MapIncomingCharacterThroughRotorOffset(c);
            char reverseMapped = _wiring.Reverse(preMapped);
            char postMapped = MapOutgoingCharacterThroughRotorOffset(reverseMapped);
            return postMapped;
        }

        public virtual void Advance(int count = 1)
        {
            while (count > 1)
            {
                Advance();
                count--;
            }

            int newOffset = (_rotorOffset + count) % 26;
            _rotorOffset = newOffset;
        }


        public char RingSetting { get { return Alphabet[_ringSetting]; } }
    }
}
