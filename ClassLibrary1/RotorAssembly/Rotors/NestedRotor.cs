using System;
using System.Collections.Generic;
using System.Linq;

namespace EnigmaEmulator.Rotors
{
    public class NestedRotor : EnigmaRotor
    {
        private RotorWiring _wiring;

        private NestedRotor _drives;

        public virtual String CurrentConfiguration
        {
            get { return Drives.CurrentConfiguration + Alphabet[_rotorOffset]; }
        }

        public NestedRotor Drives
        {
            private get { return _drives; }
            set { _drives = value; }
        }

        public NestedRotor() : base()
        {
           
        }

        public void SetOffset(string sequence)
        {
            char c = sequence[sequence.Length-1];
            SetOffset(c);
            if (sequence.Length > 1)
            {
                sequence = sequence.Substring(0,sequence.Length-1);
                Drives.SetOffset(sequence);
            }
        }

        public override void Advance(int count = 1)
        {
            while (count > 1)
            {
                Advance();
                count --;
            }

           
            if (_turnoverPosition.Contains(_rotorOffset) && Drives != null)
            {
                Drives.Advance();
            }

            base.Advance();
            
        }

        public NestedRotor(string mapping) : base(mapping)
        {
           
        }

        public virtual char Crypt(char clearText)
        {
            char incomingResult = Convert(clearText);
            char downstreamResult = Drives.Crypt(incomingResult);
            char outgoingResult = ReverseConvert(downstreamResult);
            return outgoingResult;
        }
    }
}


        //public char Convert(char p)
        //{
        //    int alphaIndex = Alphabet.IndexOf(p);
        //    alphaIndex = (alphaIndex + CombinedOffset) % 26;
