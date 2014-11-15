using EnigmaEmulator.Rotors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.RotorTests.NestedRotorTests
{
    [TestClass]
    public class NestedRotorEncryptionTests
    {
        private static NestedRotor CreateMultiRotorEnigmaMachine(string key)
        {
            NestedRotor rotorI = new NestedRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetOffset(key[0]);
            rotorI.SetTurnover('Q');
            NestedRotor rotorII = new NestedRotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
            rotorII.SetOffset(key[1]);
            rotorII.SetTurnover('E');
            NestedRotor rotorIII = new NestedRotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");
            rotorIII.SetOffset(key[2]);
            rotorIII.SetTurnover('V');

            EnigmaReflector BReflector = new EnigmaReflector()
            {
                Mapping = "YRUHQSLDPXNGOKMIEBFZCWVJAT"
            };

            rotorIII.Drives = rotorII;
            rotorII.Drives = rotorI;
            rotorI.Drives = BReflector;
            return rotorIII;
        }

        [TestMethod]
        public void SingleCharacterCrypt()
        {
            char expected = 'P';
            NestedRotor enigma = CreateMultiRotorEnigmaMachine("AAA");
            char actual = enigma.Crypt('G');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleCharacterDeCrypt()
        {
            char expected = 'G';
            NestedRotor enigma = CreateMultiRotorEnigmaMachine("AAA");
            char actual = enigma.Crypt('P');
            Assert.AreEqual(expected, actual);
        }

        
    }
}
