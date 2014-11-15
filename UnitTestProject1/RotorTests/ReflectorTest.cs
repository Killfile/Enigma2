using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaEmulator.Rotors;

namespace UnitTestProject1.RotorTests
{
    [TestClass]
    public class ReflectorTest
    {
        [TestMethod]
        public void CanCreateReflector()
        {
            EnigmaReflector reflector = new EnigmaReflector();
        }

        [TestMethod]
        [ExpectedException(typeof (ReflectorMappingException))]
        public void ReflectorValidatesOnWiring()
        {
            EnigmaReflector reflector = new EnigmaReflector();
            reflector.Mapping = "JEMZALYXVBWFCRQUONTSPIKHGD";
        }

        [TestMethod]
        public void ReflectorAllowsKnownValidWiring()
        {
            EnigmaReflector reflector = new EnigmaReflector();
            reflector.Mapping = "EJMZALYXVBWFCRQUONTSPIKHGD";
        }
    }
}
