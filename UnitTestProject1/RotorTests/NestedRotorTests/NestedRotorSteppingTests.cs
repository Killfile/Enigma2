using EnigmaEmulator.Rotors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.RotorTests.NestedRotorTests
{
    [TestClass]
    public class NestedRotorSteppingTests
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static NestedRotor CreateMultiRotorEnigmaMachine(string key, string turnovers = "QEV")
        {
            NestedRotor rotorI = new NestedRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetOffset(key[0]);
            rotorI.SetTurnover(turnovers[0]);
            NestedRotor rotorII = new NestedRotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
            rotorII.SetOffset(key[1]);
            rotorII.SetTurnover(turnovers[1]);
            NestedRotor rotorIII = new NestedRotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");
            rotorIII.SetOffset(key[2]);
            rotorIII.SetTurnover(turnovers[2]);

            EnigmaReflector BReflector = new EnigmaReflector()
            {
                Mapping = "YRUHQSLDPXNGOKMIEBFZCWVJAT"
            };

            rotorIII.Drives = rotorII;
            rotorII.Drives = rotorI;
            rotorI.Drives = BReflector;
            return rotorIII;
        }

        private static NestedRotor CreateDoublestepEnigmaMachine(string key, string turnovers = "QEV")
        {
            NestedRotor rotorI = new NestedRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetOffset(key[0]);
            rotorI.SetTurnover(turnovers[0]);
            NestedRotor rotorII = new NestedRotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
            rotorII.SetOffset(key[1]);
            rotorII.SetTurnover(turnovers[1]);
            NestedRotor rotorIII = new NestedRotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");
            rotorIII.SetOffset(key[2]);
            rotorIII.SetTurnover(turnovers[2]);

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
        public void GetMultiRotorConfigurationTest()
        {
            NestedRotor Rotor_I = CreateMultiRotorEnigmaMachine("AAA");
            string expected = "AAA";
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMultiRotorConfigurationTest_Stepped()
        {
            NestedRotor Rotor_I = CreateMultiRotorEnigmaMachine("AAA");
            string expected = "AAB";
            Rotor_I.Advance();
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMultiRotorConfigurationTest_MultiStepped_RightNormal()
        {
            NestedRotor Rotor_I = CreateMultiRotorEnigmaMachine("AAU");
            string expected = "AAU";
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMultiRotorConfigurationTest_MultiStepped_RightNotch()
        {
            NestedRotor Rotor_I = CreateMultiRotorEnigmaMachine("AAU");
            string expected = "AAV";
            Rotor_I.Advance();
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMultiRotorConfigurationTest_MultiStepped_MiddleStep()
        {
            NestedRotor Rotor_I = CreateMultiRotorEnigmaMachine("AAV");
            string expected = "ABW";
            Rotor_I.Advance();
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMultiRotorConfigurationTest_MultiStepped_SecondRightNormal()
        {
            NestedRotor Rotor_I = CreateMultiRotorEnigmaMachine("ABW");
            string expected = "ABX";
            Rotor_I.Advance();
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMultiRotorConfigurationTest_MultiStepped_ThirdRotorAdvances()
        {
            NestedRotor Rotor_I = CreateMultiRotorEnigmaMachine("AEV");
            string expected = "BFW";
            Rotor_I.Advance();
            string actual = Rotor_I.CurrentConfiguration;
            Assert.AreEqual(expected, actual);
        }


       


    }
}
