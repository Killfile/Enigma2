using EnigmaEmulator.Rotors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.RotorTests
{
    [TestClass]
    public class SingleRotorEncryptionTest
    {
        private static NestedRotor CreateSingleRotorEnigmaMachine()
        {
            NestedRotor rotorI = new NestedRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
                rotorI.SetOffset('A');
                rotorI.SetTurnover('Q');
            rotorI.Drives = new EnigmaReflector()
                {
                    Mapping = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                };
            return rotorI;
        }

        [TestMethod]
        public void TestMethod1()
        {
            char expected = 'A';
            NestedRotor enigma = CreateSingleRotorEnigmaMachine();
            char actual = enigma.Crypt('A');
            Assert.AreEqual(expected,actual);

        }
    }
}
