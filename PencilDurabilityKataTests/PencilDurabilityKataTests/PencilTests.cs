using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilLibrary;

namespace PencilDurabilityKataTests
{
    [TestClass]
    public class PencilTests
    {
        [TestMethod]
        public void PencilAppendsTextToTheEndOfTheGivenString()
        {
            Pencil pencil = new Pencil(1000);

            Assert.AreEqual("Some Test Words", pencil.write("Some Test Words", ""));
        }

        [TestMethod]
        public void PencilDurabilityDegradesByOneWhenWritingALowercaseLetter()
        {
            Pencil pencil = new Pencil(5);

            pencil.write("ab");

            Assert.AreEqual(3, pencil.getDurability());

            pencil.write("c");

            Assert.AreEqual(2, pencil.getDurability());
        }
    }
}
