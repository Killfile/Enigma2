using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.Rotors;

namespace EnigmaTests.RotorTests
{
    [TestClass]
    public class BasicRotorTests
    {
        [TestMethod]
        public void CanCreateRotor()
        {
            EnigmaRotor temp = new EnigmaRotor();
        }

        [TestMethod]
        public void Rotor_HasMapping()
        {
            EnigmaRotor temp = new EnigmaRotor();
            temp.Mapping = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }


        [TestMethod]
        public void Rotor_ConstructsWithMapping()
        {
            CreateRotorI();
        }

        private static EnigmaRotor CreateRotorI()
        {
            EnigmaRotor rotorI = new EnigmaRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetOffset('A');
            rotorI.SetTurnover('Q');
            return rotorI;
        }

        [TestMethod]
        public void Rotor_CanSetOffset()
        {
            EnigmaRotor rotorI = new EnigmaRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetOffset('A');
        }

        [TestMethod]
        public void Rotor_CanSetTurnover()
        {
            EnigmaRotor rotorI = new EnigmaRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetTurnover('Q');
        }

        [TestMethod]
        public void Rotor_CanSetTurnoverArray()
        {
            EnigmaRotor rotorI = new EnigmaRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetTurnover(new char[] {'Q','S'});
        }

        [TestMethod]
        public void MultiTurnoversTriggerOnARotor()
        {
            EnigmaRotor rotorI = new EnigmaRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            rotorI.SetTurnover(new char[] { 'Q', 'S' });
            rotorI.SetOffset('Q');
            bool firstTurnoverWorks = rotorI.IsInTurnoverPosition;
            rotorI.SetOffset('S');
            bool secondTurnoverWorks = rotorI.IsInTurnoverPosition;
            Assert.IsTrue(firstTurnoverWorks && secondTurnoverWorks);
        }



        [TestMethod]
        public void Rotor_MapsLettersWithOffsetZero()
        {
            char expected = 'E';

            EnigmaRotor Rotor_I = CreateRotorI();
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_MapsLettersWithOffsetOne()
        {
            char expected = 'J';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance();
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_MappslettersWithRingSetting()
        {
            char expected = 'K';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('B');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_MappslettersWithRingSettingAndOffset()
        {
            char expected = 'W';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('F');
            Rotor_I.SetOffset('Y');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }




        [TestMethod]
        public void Rotor_MapsLettersWithOffset27()
        {
            char expected = 'J';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance(27);
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_ReverseMappslettersWithOffsetZero()
        {
            char expected = 'A';
            EnigmaRotor Rotor_I = CreateRotorI();
            char actual = Rotor_I.ReverseConvert('E');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_ReverseMapsLettersWithOffsetOne()
        {
            char expected = 'D';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance();
            char actual = Rotor_I.ReverseConvert('K');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_ReverseMapsLettersWithOffset27()
        {
            char expected = 'D';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.Advance(27);
            char actual = Rotor_I.ReverseConvert('K');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_SetOffset()
        {
            char expected = 'J';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.SetOffset('B');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_SetRingSetting()
        {
            char expected = 'K';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('B');
            char actual = Rotor_I.Convert('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_ReverseMappslettersWithRingSetting()
        {
            char expected = 'A';
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.SetRingSetting('B');
            char actual = Rotor_I.ReverseConvert('K');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rotor_IsInTurnoverPosition_False()
        {
            EnigmaRotor Rotor_I = CreateRotorI();
            Assert.IsFalse(Rotor_I.IsInTurnoverPosition);
        }

        [TestMethod]
        public void Rotor_IsInTurnoverPosition_True()
        {
            EnigmaRotor Rotor_I = CreateRotorI();
            Rotor_I.SetOffset('Q');
            Assert.IsTrue(Rotor_I.IsInTurnoverPosition);
        }
    }
}
