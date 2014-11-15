using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("EnigmaTests")]
namespace EnigmaEmulator.Factories
{
    public enum Rotor { IC,IIC,IIIC,I,II,III,IV,V,VI,VII,VIII, Beta, Gamma };
    public enum Reflector { A, B, C, BThin, CThin};
    public class RotorFactory
    {
        public EnigmaRotor GetRotor(Rotor rotorKey)
        {
            EnigmaRotor returnValue;
            switch (rotorKey)
            {
                case Rotor.I:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
                        Turnover = new char[] {'Q'}
                    };
                    break;
                case Rotor.II:
                     returnValue = new EnigmaRotor()
                    {
                        Mapping = "AJDKSIRUXBLHWTMCQGZNPYFVOE",
                        Turnover = new char[] {'E'}
                    };
                    break;
                case Rotor.III:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "BDFHJLCPRTXVZNYEIWGAKMUSQO",
                        Turnover = new char[] { 'V' }
                    };
                    break;
                case Rotor.IV:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "ESOVPZJAYQUIRHXLNFTGKDCMWB",
                        Turnover = new char[] { 'J' }
                    };
                    break;
                case Rotor.V:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "VZBRGITYUPSDNHLXAWMJQOFECK",
                        Turnover = new char[] { 'Z' }
                    };
                    break;
                case Rotor.VI:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "JPGVOUMFYQBENHZRDKASXLICTW",
                        Turnover = new char[] { 'Z','M' }
                    };
                    break;
                case Rotor.VII:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "NZJHGRCXMYSWBOUFAIVLPEKQDT",
                        Turnover = new char[] { 'Z', 'M' }
                    };
                    break;
                case Rotor.VIII:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "FKQHTLXOCBJSPDZRAMEWNIUYGV",
                        Turnover = new char[] { 'Z', 'M' }
                    };
                    break;
               
                default:
                    returnValue = new EnigmaRotor()
                    {
                        Mapping = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                        Turnover = new char[] { '!' }
                    };
                    break;
            }
            return returnValue;
        }

        public EnigmaRotor GetReflector(Reflector reflectorKey)
        {
            EnigmaRotor returnValue;
            switch(reflectorKey) {
                case Reflector.A:
                    returnValue = new EnigmaReflector()
                    {
                        Mapping = "EJMZALYXVBWFCRQUONTSPIKHGD"
                    };
                    break;
                case Reflector.B:
                    returnValue = new EnigmaReflector()
                    {
                        Mapping = "YRUHQSLDPXNGOKMIEBFZCWVJAT"
                    };
                    break;
                case Reflector.C:
                    returnValue = new EnigmaReflector()
                    {
                        Mapping = "FVPJIAOYEDRZXWGCTKUQSBNMHL"
                    };
                    break;
                case Reflector.BThin:
                    returnValue = new EnigmaReflector()
                    {
                        Mapping = "ENKQAUYWJICOPBLMDXZVFTHRGS"
                    };
                    break;
                case Reflector.CThin:
                    returnValue = new EnigmaReflector()
                    {
                        Mapping = "RDOBJNTKVEHMLFCWZAXGYIPSUQ"
                    };
                    break;
                default:
                    returnValue = new EnigmaReflector()
                    {
                        Mapping = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                    };
                    break;
            }
            return returnValue;
        }
    }
}
