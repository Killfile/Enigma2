using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.Factory;
using EnigmaEmulator.Factories;
using EnigmaEmulator.Machines;

namespace EnigmaTests.EnigmaFactoryTests
{
    [TestClass]
    public class MachineFactoryTests
    {
        [TestMethod]
        public void CanConstructEnigmaFactory()
        {
            EnigmaFactory factory = new EnigmaFactory();
        }

        [TestMethod]
        public void CanConstructEnigmaI()
        {
            EnigmaFactory factory = new EnigmaFactory();
            factory.GetEnigmaI(Reflector.A, new Rotor[] { Rotor.I, Rotor.II, Rotor.III });
        }

        [TestMethod]
        public void EnigmaI_RotorOrderIsCorrect_ConfirmByDoublestepping()
        {
            string startingOffset = "AEW";
            string expected = "BFX";
            EnigmaFactory factory = new EnigmaFactory();
            var enigmaI = factory.GetEnigmaI(Reflector.A, new Rotor[] { Rotor.I, Rotor.II, Rotor.III });
            enigmaI.SetRotorOffset(startingOffset);
            enigmaI.Crypt("A");
            string actual = enigmaI.GetRotorSettings();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRotorException))]
        public void EnigmaI_RejectsInvalidRotors()
        {
            EnigmaFactory factory = new EnigmaFactory();
            var enigmaI = factory.GetEnigmaI(Reflector.A, new Rotor[] { Rotor.VIII, Rotor.II, Rotor.III });
        }

        [TestMethod]
        [ExpectedException(typeof(NonUniqueRotorException))]
        public void EnigmaI_RejectsDuplicateRotors()
        {
            EnigmaFactory factory = new EnigmaFactory();
            var enigmaI = factory.GetEnigmaI(Reflector.A, new Rotor[] { Rotor.I, Rotor.I, Rotor.III });
        }

        [TestMethod]
        public void CanConstructEnigmaM4()
        {
            EnigmaFactory factory = new EnigmaFactory();
            IEnigmaMachine enigma = factory.GetEnigmaM4(Reflector.BThin, new Rotor[] { Rotor.I, Rotor.I, Rotor.III, Rotor.Beta });
        }
    }
}
