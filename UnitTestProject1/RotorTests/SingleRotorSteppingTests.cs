using EnigmaEmulator.Rotors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.RotorTests
{
    [TestClass]
    public class SingleRotorSteppingTests
    {

        private static NestedRotor CreateSingleRotorEnigmaMachine()
        {
            NestedRotor rotorI = new NestedRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetOffset('A');
            rotorI.SetTurnover('Q');
            rotorI.Drives = new EnigmaReflector();
            return rotorI;
        }

        [TestMethod]
        public void GetSingleRotorConfigurationTest()
        {
            NestedRotor Rotor_I = CreateSingleRotorEnigmaMachine();
            string expected = "A";
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSingleRotorConfigurationTest_Advanced()
        {
            string expected = "B";
            NestedRotor Rotor_I = CreateSingleRotorEnigmaMachine();
            Rotor_I.Advance();
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }
    }
}
