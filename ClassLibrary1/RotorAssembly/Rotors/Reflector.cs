using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaEmulator.Rotors
{
    public class EnigmaReflector : NestedRotor
    {
        public override string Mapping
        {
            get
            {
                return base.Mapping;
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    char crypt = value[i];
                    char clear = Alphabet[i];
                    int indexOfCryptInClear = Alphabet.IndexOf(crypt);
                    int indexOfClearInCrypt = value.IndexOf(clear);
                    if (indexOfClearInCrypt != indexOfCryptInClear)
                        throw new ReflectorMappingException(
                            string.Format("Invalid reflector mapping; {0} ({1}) and {2} ({3}) do not reflect", crypt,
                                          indexOfCryptInClear, clear, indexOfClearInCrypt));
                }
                base.Mapping = value;
            }
        }

        public EnigmaReflector()
        {
        }

        public override char Crypt(char clearText)
        {
            return Convert(clearText);
        }

        public override string CurrentConfiguration
        {
            get { return string.Empty; }
        }
    }

    public class ReflectorMappingException : Exception
    {
        public ReflectorMappingException(string message) : base(message)
        {
            }
    }
}
