using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilLibrary;

namespace PencilDurabilityKataTests
{
    [TestClass]
    public class PencilTests
    {
        Pencil pencil;

        [TestInitialize]
        public void testInit()
        {
            pencil = new Pencil(100);
        }

        [TestMethod]
        public void PencilAppendsTextToTheEndOfTheGivenString()
        {
            Assert.AreEqual("Some Test Words", pencil.write("Some Test Words", ""));
        }

        [TestMethod]
        public void PencilDurabilityDegradesByOneWhenWritingALowercaseLetter()
        {

            pencil.write("ab");

            Assert.AreEqual(98, pencil.getDurability());

            pencil.write("c");

            Assert.AreEqual(97, pencil.getDurability());
        }

        [TestMethod]
        public void PencilDurabilityDegradesByTwoWhenWritingUppercaseLetter()
        {
            

            
        }
    }
}
