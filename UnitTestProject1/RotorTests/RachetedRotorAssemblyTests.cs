using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.RotorAssembly;
using EnigmaEmulator.Rotors;
using UnitTestProject1.EnigmaMachineTests.Support;

namespace EnigmaTests.RotorTests
{
    [TestClass]
    public class RachetedRotorAssemblyTests
    {


        [TestMethod]
        public void CanConstructThreeRotorAssembly()
        {
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
        }

        [TestMethod]
        public void CanSetRotors()
        {
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(new EnigmaRotor[3]);
        }

        [TestMethod]
        public void CanCrypt()
        {
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            assembly.Crypt('A');
        }

        [TestMethod]
        public void CryptsCorrectly()
        {
            char expectedCryptText = 'U';
            char plainText = 'A';
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            char actual = assembly.Crypt(plainText);
            Assert.AreEqual(expectedCryptText, actual);
        }

        [TestMethod]
        public void CanGetRotorSettings()
        {
            string expected = "AAA";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(new EnigmaRotor[3]);
            string actual = assembly.RotorSettings;
        }

        [TestMethod]
        public void RotorSettingsReturnInitialValue()
        {
            string expected = "AAA";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            string actual = assembly.RotorSettings;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdvanceChangesRotorSettings()
        {
            string expected = "AAB";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            assembly.Advance();
            string actual = assembly.RotorSettings;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondRotorAdvancesAtTurnover()
        {
            string expected = "ABW";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            assembly.SetRotorOffset("AAV");
            Assert.AreEqual("AAV", assembly.RotorSettings,"Failed to reach starting position");
            assembly.Advance();
            Assert.AreEqual(expected, assembly.RotorSettings);
        }

        [TestMethod]
        public void SecondRotorAdvancesAtBothTurnover()
        {
            string firstExpected = "ABW";
            string secondExpected = "ACX";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();

            var rotors = BuildRotorArray();
            rotors[3].SetTurnover(new char[] {'V','W'});

            assembly.SetRotors(rotors);
            assembly.SetRotorOffset("AAV");
            Assert.AreEqual("AAV", assembly.RotorSettings, "Failed to reach starting position");
            assembly.Advance();
            Assert.AreEqual(firstExpected, assembly.RotorSettings);
            assembly.Advance();
            Assert.AreEqual(secondExpected, assembly.RotorSettings);
        }

        [TestMethod]
        public void PredoublestepTest()
        {
            string startingOffset = "ADV";
            string expected = "AEW";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            assembly.SetRotorOffset(startingOffset);
            Assert.AreEqual(startingOffset, assembly.RotorSettings, "Failed to reach starting position");
            assembly.Advance();
            Assert.AreEqual(expected, assembly.RotorSettings);
        }

        [TestMethod]
        public void ThirdRotorAdvancesAtTurnover()
        {
            string startingOffset = "AEW";
            string expected = "BFX";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            assembly.SetRotorOffset(startingOffset);
            Assert.AreEqual(startingOffset, assembly.RotorSettings, "Failed to reach starting position");
            assembly.Advance();
            Assert.AreEqual(expected, assembly.RotorSettings);
        }

        [TestMethod]
        public void CanSetRingSettings()
        {
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            assembly.SetRingSettings("AAA");
        }

        [TestMethod]
        public void CanGetRingSettings()
        {
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            Assert.IsNotNull(assembly.RingSettings);
        }

        [TestMethod]
        public void RingSettingsPersist()
        {
            string expected = "QWE";
            RachetedRotorAssembly assembly = new RachetedRotorAssembly();
            assembly.SetRotors(BuildRotorArray());
            assembly.SetRingSettings(expected);
            Assert.AreEqual(expected, assembly.RingSettings);
        }

        private static EnigmaRotor[] BuildRotorArray()
        {
            
            EnigmaRotor rotorI = EnigmaIMachineTestSupport.CreateRotorI();
            EnigmaRotor rotorII = EnigmaIMachineTestSupport.CreateRotorII();
            EnigmaRotor rotorIII = EnigmaIMachineTestSupport.CreateRotorIII();
            
            EnigmaReflector reflectorB = EnigmaIMachineTestSupport.CreateBReflector();
            
            EnigmaRotor[] rotors = new EnigmaRotor[4];
            rotors[0] = reflectorB;
            rotors[1] = rotorI;
            rotors[2] = rotorII;
            rotors[3] = rotorIII;

            return rotors;
        }
    }
}
