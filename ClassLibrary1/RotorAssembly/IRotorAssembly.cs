using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.RotorAssembly
{
    public abstract class ARotorAssembly
    {
        
        public virtual string RotorSettings
        {
            get
            {
                StringBuilder b = new StringBuilder();

                if (_rotors == null)
                    throw new RotorAssemblyConfigurationException();

                foreach (EnigmaRotor rotor in _rotors)
                {
                    if(rotor != null)
                        b.Append(rotor.Offset);
                }
                return b.ToString();
            }
        }

        public virtual String RingSettings
        {
            get
            {
                StringBuilder b = new StringBuilder();

                if (_rotors == null)
                    throw new RotorAssemblyConfigurationException();

                foreach (EnigmaRotor rotor in _rotors)
                {
                    if (rotor != null)
                        b.Append(rotor.RingSetting);
                }
                return b.ToString();
            }
        }
        protected EnigmaReflector _reflector;
        protected EnigmaRotor[] _rotors;

        public abstract void SetRotors(EnigmaRotor[] rotors);
        public abstract void Advance(int positions = 1);
        public abstract char Crypt(char clearText);
        public abstract void SetRotorOffset(string offset);
        public abstract void SetRingSettings(string ringsetting);
    }
}
