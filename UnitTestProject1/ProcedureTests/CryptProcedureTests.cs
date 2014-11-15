using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.Procedure;

namespace EnigmaTests.ProcedureTests
{
    [TestClass]
    public class CryptProcedureTests
    {
        [TestMethod]
        public void CanConstructCryptProcedure()
        {
            CryptProcedure procedure = new CryptProcedure();
        }

        [TestMethod]
        public void CanTransform()
        {
            CryptProcedure procedure = new CryptProcedure();
            procedure.Transform("abcdefg");
        }

        [TestMethod]
        public void TransformEnforcesCase()
        {
            string expected = "ABCDEFG";
            CryptProcedure procedure = new CryptProcedure();
            string actual = procedure.Transform("abcdefg");
            Assert.AreEqual(expected, actual);
        }
    }
}
