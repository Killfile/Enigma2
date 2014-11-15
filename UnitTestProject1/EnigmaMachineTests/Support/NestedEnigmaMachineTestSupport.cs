using EnigmaEmulator;
using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.EnigmaMachineTests.Support
{
    public static class NestedEnigmaMachineTestSupport
    {
        public static NestedRotor CreateAlphabeticalRotor()
        {
            NestedRotor rotor = new NestedRotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            rotor.SetOffset('A');
            rotor.SetTurnover('Y');
            return rotor;
        }

        public static EnigmaReflector CreateAlphabeticalReflector()
        {
            return new EnigmaReflector()
            {
                Mapping = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            };
        }

        public static NestedRotor CreateRotorI()
        {
            NestedRotor rotor = new NestedRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotor.SetOffset('A');
            rotor.SetTurnover('Q');
            return rotor;
        }

        public static NestedRotor CreateRotorII()
        {
            NestedRotor rotor = new NestedRotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
            rotor.SetOffset('A');
            rotor.SetTurnover('E');
            return rotor;
        }

        public static NestedRotor CreateRotorIII()
        {
            NestedRotor rotor = new NestedRotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");
            rotor.SetOffset('A');
            rotor.SetTurnover('V');
            return rotor;
        }

        public static EnigmaReflector CreateBReflector()
        {
            return new EnigmaReflector()
            {
                Mapping = "YRUHQSLDPXNGOKMIEBFZCWVJAT"
            };
        }  
    }
}
