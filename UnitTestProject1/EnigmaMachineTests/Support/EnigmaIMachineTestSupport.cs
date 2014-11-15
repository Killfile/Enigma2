using EnigmaEmulator.Factories;
using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.EnigmaMachineTests.Support
{
    public static class EnigmaIMachineTestSupport
    {
        public static EnigmaRotor CreateAlphabeticalRotor()
        {
            EnigmaRotor rotor = new EnigmaRotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
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

        public static EnigmaRotor CreateRotorI()
        {
            RotorFactory factory = new RotorFactory();
            return factory.GetRotor(Rotor.I);
        }

        public static EnigmaRotor CreateRotorII()
        {
            RotorFactory factory = new RotorFactory();
            return factory.GetRotor(Rotor.II);
        }

        public static EnigmaRotor CreateRotorIII()
        {
            RotorFactory factory = new RotorFactory();
            return factory.GetRotor(Rotor.III);
        }

        public static EnigmaReflector CreateBReflector()
        {
            RotorFactory factory = new RotorFactory();
            return factory.GetReflector(Reflector.B) as EnigmaReflector;
        }  
    }
}
