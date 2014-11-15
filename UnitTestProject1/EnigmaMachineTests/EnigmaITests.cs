using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.Machines;
using EnigmaEmulator.Rotors;
using UnitTestProject1.EnigmaMachineTests.Support;
using EnigmaEmulator.RotorAssembly;
using EnigmaEmulator.Factory;
using EnigmaEmulator.Factories;

namespace UnitTestProject1.EnigmaMachineTests
{
    [TestClass]
    public class EnigmaITests
    {
        private static ISteckeredEnigma BuildEnigma(char[] ringSettings = null)
        {
            if (ringSettings == null)
            {
                ringSettings = new char[] { 'A', 'A', 'A' };
            }

            EnigmaFactory factory = new EnigmaFactory();
            ISteckeredEnigma enigma = factory.GetEnigmaI(Reflector.B, new Rotor[] { Rotor.I, Rotor.II, Rotor.III });
            enigma.SetRingSetting("AAA");
            //EnigmaRotor rotorI = EnigmaIMachineTestSupport.CreateRotorI();
            //rotorI.SetRingSetting(ringSettings[0]);
            //EnigmaRotor rotorII = EnigmaIMachineTestSupport.CreateRotorII();
            //rotorII.SetRingSetting(ringSettings[1]);
            //EnigmaRotor rotorIII = EnigmaIMachineTestSupport.CreateRotorIII();
            //rotorIII.SetRingSetting(ringSettings[2]);
            //EnigmaReflector reflectorB = EnigmaIMachineTestSupport.CreateBReflector();
            //EnigmaI enigma = new EnigmaI();

            //EnigmaRotor[] rotors = new EnigmaRotor[4];
            //rotors[0] = reflectorB;
            //rotors[1] = rotorI;
            //rotors[2] = rotorII;
            //rotors[3] = rotorIII;

            //enigma.SetRotors(rotors);
            return enigma;
        }

        [TestMethod]
        public void CanConstructEnigmaI()
        {
            EnigmaI enigma = new EnigmaI();
        }

        [TestMethod]
        [ExpectedException(typeof(RotorAssemblyConfigurationException))]
        public void SetRotorsEnforcesRotorCount()
        {
            EnigmaI enigma = new EnigmaI();

            EnigmaRotor[] rotors = new EnigmaRotor[3];
            rotors[0] = new EnigmaReflector();
            enigma.SetRotors(rotors);
        }

        [TestMethod]
        [ExpectedException(typeof(RotorAssemblyConfigurationException))]
        public void SetRotorsEnforcesReflector()
        {
            EnigmaI enigma = new EnigmaI();

            EnigmaRotor[] rotors = new EnigmaRotor[4];
            enigma.SetRotors(rotors);
        }

        [TestMethod]
        public void CanSetRotors()
        {
            EnigmaI enigma = new EnigmaI();

            EnigmaRotor[] rotors = new EnigmaRotor[4];
            rotors[0] = new EnigmaReflector();
            enigma.SetRotors(rotors);
        }

        [TestMethod]
        [ExpectedException(typeof(RotorAssemblyConfigurationException))]
        public void CanNotSetRotorOffsetIfRotorsAreUninitialized()
        {
            EnigmaI enigma = new EnigmaI();
            enigma.SetRotorOffset("AAA");
        }

        [TestMethod]
        public void CanSetRotorOffset()
        {
            IEnigmaMachine enigma = BuildEnigma();
            enigma.SetRotorOffset("AAA");

        }

        
        [TestMethod]
        public void CanCrypt()
        {
            IEnigmaMachine enigma = BuildEnigma();
            enigma.Crypt("Test");
        }

        [TestMethod]
        public void LongCryptOverDoubleStep()
        {
            string expectedCryptText = "LNTOXWXEPYMHXCTALPRBBRGRAWKQJGKHLXLATLFQPCHEESJTBCKEUKKXCUCPIUTUZZBECEOSVIOVQCWTOACQRNAJKBBESCWPMHAPZKVUDZGBWTUGDUEQCTWFXSOBLTEDEOESBXIJYBPJSRXELEAFUPEFPBOFAPIIUZXLGABEZNHTPFNTMLSQTTYGUSFIODXFIESMAALYHJBDPXFPGVZTTAQJGZPIWNOKHBJXLZXZ";
            string plaintext = "vonvonjlooksjhffttteinseinsdreizwoyyqnnsneuninhaltxxbeiangriffunterwassergedruecktywabosxletztergegnerstandnulachtdreinuluhrmarquantonjotaneunachtseyhsdreiyzwozwonulgradyachtsmystossenachxeknsviermbfaelltynnnnnnooovierysichteinsnull";
            IEnigmaMachine enigma = BuildEnigma();
            enigma.SetRotorOffset("ADU");
            string actualCryptText = enigma.Crypt(plaintext);
            Assert.AreEqual(expectedCryptText, actualCryptText);
        }

        [TestMethod]
        public void SimpleCryptNotOverDoubleStep()
        {
            string plainText = "RBMLWDESXRUEPIWEDYLDZUKTTXGGKHLTFHKXLXFDJDMMI";
            string cryptText = "MAYBEINVADINGRUSSIAINTHEWINTERWASNOTAGOODIDEA";
            IEnigmaMachine enigma = BuildEnigma();
            enigma.SetRotorOffset("AAZ");
            string actual = enigma.Crypt(plainText);
            Assert.AreEqual(cryptText, actual);
        }

        [TestMethod]
        public void SimpleCryptOverDoubleStep()
        {
            string plainText = "IHEARTHEWEATHERINARGENTINAISNICETHISTIMEOFYEAR";
            string cryptText = "UFSMHLYCAOFPCYDSBBVHLMNAWBXTSKANKGLZGBHIHAXIRU";
            IEnigmaMachine enigma = BuildEnigma();
            enigma.SetRotorOffset("ADV");
            string actual = enigma.Crypt(plainText);
            Assert.AreEqual(cryptText, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(RotorAssemblyConfigurationException))]
        public void CanNotGetRotorSettingsIfRotorsAreUninitialized()
        {
            EnigmaI enigma = new EnigmaI();
            enigma.GetRotorSettings();
        }

        [TestMethod]
        public void CanGetRotorSettings()
        {
            IEnigmaMachine enigma = BuildEnigma();
            enigma.GetRotorSettings();
        }


        [TestMethod]
        public void GetSetRotorSettings()
        {
            string expected = "ABC";
            IEnigmaMachine enigma = BuildEnigma();
            enigma.SetRotorOffset(expected);
            string actual = enigma.GetRotorSettings();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanStecker()
        {
            ISteckeredEnigma enigma = BuildEnigma();
            enigma.Stecker('A', 'Z');
        }

        [TestMethod]
        public void SteckerWorks()
        {
            ISteckeredEnigma enigma = BuildEnigma();
            enigma.SetRotorOffset("AAA");
            string expectedPreSteckeredResult = "B";
            string preSteckeredResult = enigma.Crypt("A");
            Assert.AreEqual(expectedPreSteckeredResult, preSteckeredResult);
            enigma.Stecker('A', 'Z');
            enigma.SetRotorOffset("AAA");
            string expectedPostSteckeredResult = "U";
            string postSteckeredResult = enigma.Crypt("A");
            Assert.AreEqual(expectedPostSteckeredResult, postSteckeredResult);
        }
        
    }
}
