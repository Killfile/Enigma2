using EnigmaEmulator.Rotors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.RotorTests.NestedRotorTests
{
    [TestClass]
    public class NestedRotorBasicTests
    {
        [TestMethod]
        public void CanCreateNestedRotor()
        {
            NestedRotor temp = new NestedRotor();
        }

        [TestMethod]
        public void NestedRotor_HasMapping()
        {
            NestedRotor temp = new NestedRotor();
            temp.Mapping = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }


        [TestMethod]
        public void NestedRotor_ConstructsWithMapping()
        {
            CreateRotorI();
        }

        private static NestedRotor CreateRotorI()
        {
            NestedRotor rotorI = new NestedRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetOffset('A');
            rotorI.SetTurnover('Q');
            return rotorI;
        }

        [TestMethod]
        public void NestedRotor_MapsLettersWithOffsetZero()
        {
            char expected = 'E';

            NestedRotor Rotor_I = CreateRotorI();
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_MapsLettersWithOffsetOne()
        {
            char expected = 'J';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance();
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_MappslettersWithRingSetting()
        {
            char expected = 'K';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('B');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_MappslettersWithRingSettingAndOffset()
        {
            char expected = 'W';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('F');
            Rotor_I.SetOffset('Y');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }




        [TestMethod]
        public void NestedRotor_MapsLettersWithOffset27()
        {
            char expected = 'J';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance(27);
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_ReverseMappslettersWithOffsetZero()
        {
            char expected = 'A';
            NestedRotor Rotor_I = CreateRotorI();
            char actual = Rotor_I.ReverseConvert('E');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_ReverseMapsLettersWithOffsetOne()
        {
            char expected = 'D';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance();
            char actual = Rotor_I.ReverseConvert('K');
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
        public void NestedRotor_ReverseMapsLettersWithOffset27()
        {
            char expected = 'D';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance(27);
            char actual = Rotor_I.ReverseConvert('K');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_SetOffset()
        {
            char expected = 'J';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.SetOffset('B');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_SetRingSetting()
        {
            char expected = 'K';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('B');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedRotor_ReverseMappslettersWithRingSetting()
        {
            char expected = 'A';
            NestedRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('B');
            char actual = Rotor_I.ReverseConvert('K');
            Assert.AreEqual(expected, actual);
        }

        
    }
}
