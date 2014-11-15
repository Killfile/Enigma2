using System;
using EnigmaEmulator.Machines;
using EnigmaEmulator.Rotors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1.EnigmaMachineTests.Support;

namespace UnitTestProject1.EnigmaMachineTests
{
    [TestClass]
    public class NestedEnigmaMachineTests
    {
        
        
            

        [TestMethod]
        public void CanCreateEnigmaMachine()
        {
            NestedEnigmaMachine enigma = new NestedEnigmaMachine();
        }

        [TestMethod]
        public void EnigmaTakesRotorsAndReflector()
        {
            BuildEnigma();
        }

        private static NestedEnigmaMachine BuildEnigma(char[] ringSettings = null)
        {
            if (ringSettings == null)
            {
                ringSettings = new char[] { 'A', 'A', 'A' };
            }
            NestedRotor rotorI = NestedEnigmaMachineTestSupport.CreateRotorI();
            rotorI.SetRingSetting(ringSettings[0]);
            NestedRotor rotorII = NestedEnigmaMachineTestSupport.CreateRotorII();
            rotorII.SetRingSetting(ringSettings[1]);
            NestedRotor rotorIII = NestedEnigmaMachineTestSupport.CreateRotorIII();
            rotorIII.SetRingSetting(ringSettings[2]);
            EnigmaReflector reflectorB = NestedEnigmaMachineTestSupport.CreateBReflector();
            NestedEnigmaMachine enigma = new NestedEnigmaMachine();

            EnigmaRotor[] rotors = new EnigmaRotor[4];
            rotors[0] = reflectorB;
            rotors[1] = rotorI;
            rotors[2] = rotorII;
            rotors[3] = rotorIII;

            enigma.SetRotors(rotors);
            return enigma;
        }

        [TestMethod]
        public void EnigmaTakesOffsetKey()
        {

            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.SetRingSetting("AAA");
        }

        [TestMethod]
        public void RotorsAdvanceBeforeCrypting()
        {
            String expected = "B";
            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.SetRingSetting("AAA");
            String actual = enigma.Crypt("A");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SteckersAlterInput()
        {
            String expected = "B";
            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.SetRingSetting("AAA");
            enigma.Setcker('Y', 'A');
            String actual = enigma.Crypt("Y");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SteckersAlterOutput()
        {
            String expected = "Y";
            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.SetRingSetting("AAA");
            enigma.Setcker('B', 'Y');
            String actual = enigma.Crypt("A");
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void RotorsAdvanceAlongCryptString()
        {
            String expected = "BDZGO";
            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.SetRingSetting("AAA");
            String actual = enigma.Crypt("AAAAA");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RotorsAdvanceAlongCryptString_WithRingSetting()
        {
            String expected = "EWTYX";
            //NestedRotor I = CreateRotorI();
            //I.SetRingSetting('B');
            //NestedRotor II = CreateRotorII();
            //II.SetRingSetting('B');
            //NestedRotor III = CreateRotorIII();
            //III.SetRingSetting('B');
            //Reflector rB = CreateBReflector();
            //EnigmaMachine enigma = new EnigmaMachine(I, II, III, rB);
            NestedEnigmaMachine enigma = BuildEnigma(new char[]{'B','B','B'});
            enigma.SetRingSetting("AAA");
            String actual = enigma.Crypt("AAAAA");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RotorsAdvanceAlongCryptString_2()
        {
            String expected = "DDWCRLRHLZBMHDGCMYOKMIZWNHUACPCYYGWQSN";
            //NestedRotor rotorI = CreateRotorI();
            //NestedRotor rotorII = CreateRotorII();
            //NestedRotor rotorIII = CreateRotorIII();
            //Reflector reflectorB = CreateBReflector();
            //EnigmaMachine enigma = new EnigmaMachine(rotorI, rotorII, rotorIII, reflectorB);
            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.SetRingSetting("AAA");
            String actual = enigma.Crypt("MAYBEINVADINGFRANCEWASNTSUCHAGREATIDEA");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanGetRotorSettings()
        {
            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.GetRotorSettings();
        }

        [TestMethod]
        public void GetSetRotorSettings()
        {
            string expected = "ABC";
            NestedEnigmaMachine enigma = BuildEnigma();
            enigma.SetRotorOffset(expected);
            string actual = enigma.GetRotorSettings();
            Assert.AreEqual(expected, actual);
        }

    }
}
