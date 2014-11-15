using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.Factory;
using EnigmaEmulator.Factories;
using EnigmaEmulator.Machines;

namespace EnigmaTests.EnigmaMachineTests
{
    [TestClass]
    public class EnigmaM4Tests
    {

        private static ISteckeredEnigma BuildEnigma()
        {
            EnigmaFactory factory = new EnigmaFactory();
            ISteckeredEnigma enigma = factory.GetEnigmaM4(Reflector.BThin, new Rotor[] { Rotor.I, Rotor.I, Rotor.III, Rotor.Beta });
            return enigma;
        }


        [TestMethod]
        public void M4_SetRotorOffset()
        {
            ISteckeredEnigma enigma = BuildEnigma();
            enigma.SetRotorOffset("ABCD");
        }

       
    }
}
