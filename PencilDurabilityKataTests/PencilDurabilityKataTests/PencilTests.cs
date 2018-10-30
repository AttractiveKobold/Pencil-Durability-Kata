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

            pencil.write("  a b \n ");

            Assert.AreEqual(98, pencil.getDurability());

            pencil.write("  c   ");

            Assert.AreEqual(97, pencil.getDurability());
        }

        [TestMethod]
        public void PencilDurabilityDegradesByTwoWhenWritingUppercaseLetter()
        {

            pencil.write("A \nB");

            Assert.AreEqual(96, pencil.getDurability());

            pencil.write(" C   ");

            Assert.AreEqual(94, pencil.getDurability());

        }

        [TestMethod]
        public void PencilDurabilityResetsWhenSharpened()
        {
            pencil.write("fubdfniebibnasdA");

            pencil.sharpen();

            Assert.AreEqual(100, pencil.getMaxDurability());
            Assert.AreEqual(100, pencil.getDurability());
        }
    }
}
