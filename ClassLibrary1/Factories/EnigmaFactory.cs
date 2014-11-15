using EnigmaEmulator.Factories;
using EnigmaEmulator.Machines;
using EnigmaEmulator.Rotors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("EnigmaTests")]
namespace EnigmaEmulator.Factory
{
    public class EnigmaFactory
    {
        RotorFactory _rotorFactory;
        
        public EnigmaFactory()
        {
            _rotorFactory = new RotorFactory();
        }

        public ISteckeredEnigma GetEnigmaI(Reflector reflector, Rotor[] rotors)
        {
            EnforceEnigmaIRotorConstraints(rotors);
            EnforceEnigmaIReflectorConstraints(reflector);

            EnigmaRotor[] allRotors = MergeReflectorIntoRotorArray(reflector, rotors);
            //allRotors[1] = _rotorFactory.GetRotor(rotors[0]);
            //allRotors[2] = _rotorFactory.GetRotor(rotors[1]);
            //allRotors[3] = _rotorFactory.GetRotor(rotors[2]);
            EnigmaI returnValue = new EnigmaI();
            returnValue.SetRotors(allRotors);
            return returnValue;
        }

        private EnigmaRotor[] MergeReflectorIntoRotorArray(Reflector reflector, Rotor[] rotors)
        {
            EnigmaRotor[] allRotors = new EnigmaRotor[rotors.Length + 1];
            allRotors[0] = _rotorFactory.GetReflector(reflector);
            for (int i = 0; i < rotors.Length; i++)
            {
                allRotors[i + 1] = _rotorFactory.GetRotor(rotors[i]);
            }
            return allRotors;
        }

        private static void EnforceEnigmaIReflectorConstraints(Reflector reflector)
        {
            List<Reflector> validReflectors = new List<Reflector> { Reflector.A, Reflector.B, Reflector.C };
            bool containsInvalidReflectors = validReflectors.Contains(reflector) == false;
            if (containsInvalidReflectors)
                throw new InvalidReflectorException();
        }

        private static void EnforceEnigmaIRotorConstraints(Rotor[] rotors)
        {
            List<Rotor> validRotors = new List<Rotor>
            {
                Rotor.I,Rotor.II,Rotor.III,Rotor.IV,Rotor.V
            };

            bool containsInvalidRotors = rotors.Any(r => validRotors.Contains(r) == false);
            if (containsInvalidRotors)
                throw new InvalidRotorException("The specified rotor is not valid in this device");

            if (rotors.Distinct().Count() != rotors.Count())
                throw new NonUniqueRotorException();
        }


        internal ISteckeredEnigma GetEnigmaM4(Reflector reflector, Rotor[] rotors)
        {
            EnigmaRotor[] allRotors = MergeReflectorIntoRotorArray(reflector, rotors);
            EnigmaM4 returnValue = new EnigmaM4();
            returnValue.SetRotors(allRotors);
            return returnValue;
        }
    }
}
