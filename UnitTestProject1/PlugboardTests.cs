using System;
using EnigmaEmulator.Plugboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PlugboardTests
    {
        [TestMethod]
        public void CanInitPlugboard()
        {
            Steckerbrett board = new Steckerbrett();
        }

        [TestMethod]
        public void CanWirePairs()
        {
            Steckerbrett board = new Steckerbrett();
            board.Stecker('A', 'B');
        }

        [TestMethod]
        public void UnsteckeredPairsNotTranslated()
        {
            char expected = 'A';
            Steckerbrett board = new Steckerbrett();
            char actual = board.Translate('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SteckeredPairsTranslate()
        {
            char expected = 'B';
            Steckerbrett board = new Steckerbrett();
            board.Stecker('A', expected);
            char actual = board.Translate('A');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SteckeredPairsReverseTranslate()
        {
            char expected = 'A';
            Steckerbrett board = new Steckerbrett();
            board.Stecker('A', 'B');
            char actual = board.Translate('B');
            Assert.AreEqual(expected, actual);
        }
    }
}
