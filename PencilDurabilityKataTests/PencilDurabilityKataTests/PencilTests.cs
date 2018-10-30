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
        public void whenPencilIsPassedTwoStringsItAppendsTheFirstStringOntoTheSecondString()
        {
            Assert.AreEqual("Some Test Words", pencil.write("Some Test Words", ""));
        }

        [TestMethod]
        public void whenALowercaseLetterIsWrittenDurabilityDegradesByOne()
        {

            pencil.write("  a b \n ");

            Assert.AreEqual(98, pencil.getDurability());

            pencil.write("  c   ");

            Assert.AreEqual(97, pencil.getDurability());
        }

        [TestMethod]
        public void whenAnUppercaseLetterIsWrittenDurabilityDegradesByTwo()
        {

            pencil.write("A \nB");

            Assert.AreEqual(96, pencil.getDurability());

            pencil.write(" C   ");

            Assert.AreEqual(94, pencil.getDurability());

        }

        [TestMethod]
        public void whenSharpenedDurabilityIsReset()
        {
            pencil.write("fubdfniebibnasdA");

            pencil.sharpen();

            Assert.AreEqual(100, pencil.getMaxDurability());
            Assert.AreEqual(100, pencil.getDurability());
        }

        [TestMethod]
        public void whenThereIsNotEnoughDurabilityABlankIsWritten()
        {
            pencil = new Pencil(5);

            Assert.AreEqual("abcd f  ", pencil.write("abcdEfgh"));

            
        }
    }
}
