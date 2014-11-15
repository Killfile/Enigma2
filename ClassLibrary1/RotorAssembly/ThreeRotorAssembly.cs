using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("EnigmaTests")]
namespace EnigmaEmulator.RotorAssembly
{
    
    internal class RachetedRotorAssembly : ARotorAssembly
    {

              
        public override void SetRotors(Rotors.EnigmaRotor[] rotors)
        {
            _reflector = rotors[0] as EnigmaReflector;
            rotors = rotors.Skip(1).ToArray();
            _rotors = rotors;
        }

        public override void Advance(int positions = 1)
        {
            while (positions > 1)
            {
                Advance();
                positions--;
            }
            bool rotor1IsInTurnoverPosition = _rotors[1].IsInTurnoverPosition;
            bool rotor2IsInTurnoverPosition = _rotors[2].IsInTurnoverPosition;
            if (rotor1IsInTurnoverPosition)
            {
                _rotors[0].Advance();
                _rotors[1].Advance();
            }
            if (rotor2IsInTurnoverPosition)
                _rotors[1].Advance();
            _rotors[2].Advance();
            
        }

        public override char Crypt(char clearText)
        {
            char crypt = clearText;
            for (int i = _rotors.Length-1; i >= 0; i--)
                crypt = _rotors[i].Convert(crypt);

            crypt = _reflector.Convert(crypt);

            for (int i = 0; i < _rotors.Length; i++)
                crypt = _rotors[i].ReverseConvert(crypt);

            return crypt;
        }


        public override void SetRotorOffset(string offset)
        {
            if (_rotors == null || _rotors.Length != offset.Length)
                throw new RotorAssemblyConfigurationException();

            for (int i = 0; i < _rotors.Length; i++)
            {
                _rotors[i].SetOffset(offset[i]);
            }
        }


        public override void SetRingSettings(string ringsetting)
        {
            if (_rotors == null || _rotors.Length != ringsetting.Length)
                throw new RotorAssemblyConfigurationException();

            for (int i = 0; i < _rotors.Length; i++)
            {
                _rotors[i].SetRingSetting(ringsetting[i]);
            }
        }
    }
}
