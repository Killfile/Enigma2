using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.Factories;
using EnigmaEmulator.Rotors;

namespace EnigmaTests.EnigmaFactoryTests
{
    [TestClass]
    public class RotorFactoryTests
    {
        [TestMethod]
        public void CanConstructRotorFactory()
        {
            RotorFactory factory = new RotorFactory();
        }

        [TestMethod]
        public void CanConstructRotor()
        {
            RotorFactory factory = new RotorFactory();
            factory.GetRotor(Rotor.I);
        }

        [TestMethod]
        public void CanConstructReflector()
        {
            RotorFactory factory = new RotorFactory();
            factory.GetReflector(Reflector.A);
        }

        [TestMethod]
        public void ConstructTest_RotorI()
        {
            string expectedMapping = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
            char expectedTurnover = 'Q';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.I);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(expectedTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_RotorII()
        {
            string expectedMapping = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
            char expectedTurnover = 'E';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.II);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(expectedTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_RotorIII()
        {
            string expectedMapping = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
            char expectedTurnover = 'V';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.III);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(expectedTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_RotorIV()
        {
            string expectedMapping = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
            char expectedTurnover = 'J';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.IV);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(expectedTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_RotorV()
        {
            string expectedMapping = "VZBRGITYUPSDNHLXAWMJQOFECK";
            char expectedTurnover = 'Z';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.V);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(expectedTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_RotorVI()
        {
            string expectedMapping = "JPGVOUMFYQBENHZRDKASXLICTW";
            char firstTurnover = 'Z';
            char secondTurnover = 'M';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.VI);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(firstTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
            result.SetOffset(secondTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_RotorVII()
        {
            string expectedMapping = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
            char firstTurnover = 'Z';
            char secondTurnover = 'M';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.VII);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(firstTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
            result.SetOffset(secondTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_RotorVIII()
        {
            string expectedMapping = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
            char firstTurnover = 'Z';
            char secondTurnover = 'M';
            RotorFactory factory = new RotorFactory();
            EnigmaRotor result = factory.GetRotor(Rotor.VIII);
            Assert.AreEqual(expectedMapping, result.Mapping);
            result.SetOffset(firstTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
            result.SetOffset(secondTurnover);
            Assert.IsTrue(result.IsInTurnoverPosition);
        }

        [TestMethod]
        public void ConstructTest_ReflectorA()
        {
            string expectedMapping = "EJMZALYXVBWFCRQUONTSPIKHGD";
            RotorFactory factory = new RotorFactory();
            EnigmaRotor reflector = factory.GetReflector(Reflector.A);
            Assert.AreEqual(expectedMapping, reflector.Mapping);
        }

        [TestMethod]
        public void ConstructTest_ReflectorB()
        {
            string expectedMapping = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
            RotorFactory factory = new RotorFactory();
            EnigmaRotor reflector = factory.GetReflector(Reflector.B);
            Assert.AreEqual(expectedMapping, reflector.Mapping);
        }

        [TestMethod]
        public void ConstructTest_ReflectorC()
        {
            string expectedMapping = "FVPJIAOYEDRZXWGCTKUQSBNMHL";
            RotorFactory factory = new RotorFactory();
            EnigmaRotor reflector = factory.GetReflector(Reflector.C);
            Assert.AreEqual(expectedMapping, reflector.Mapping);
        }

        [TestMethod]
        public void ConstructTest_ReflectorBThin()
        {
            string expectedMapping = "ENKQAUYWJICOPBLMDXZVFTHRGS";
            RotorFactory factory = new RotorFactory();
            EnigmaRotor reflector = factory.GetReflector(Reflector.BThin);
            Assert.AreEqual(expectedMapping, reflector.Mapping);
        }

        [TestMethod]
        public void ConstructTest_ReflectorCThin()
        {
            string expectedMapping = "RDOBJNTKVEHMLFCWZAXGYIPSUQ";
            RotorFactory factory = new RotorFactory();
            EnigmaRotor reflector = factory.GetReflector(Reflector.CThin);
            Assert.AreEqual(expectedMapping, reflector.Mapping);
        }
    }
}
