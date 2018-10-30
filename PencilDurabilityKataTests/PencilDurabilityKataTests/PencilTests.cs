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
            pencil = new Pencil(100, 100, 100);
        }

        [TestMethod]
        public void whenPencilIsPassedTwoStringsItAppendsTheFirstStringOntoTheSecondString()
        {
            Assert.AreEqual("aaaSome Test Words", pencil.write("Some Test Words", "aaa"));
        }

        [TestMethod]
        public void whenALowercaseLetterIsWrittenDurabilityDegradesByOne()
        {

            pencil.write("  a b \n ");

            Assert.AreEqual(98, pencil.getPointDurability());

            pencil.write("  c   ");

            Assert.AreEqual(97, pencil.getPointDurability());
        }

        [TestMethod]
        public void whenAnUppercaseLetterIsWrittenDurabilityDegradesByTwo()
        {

            pencil.write("A \nB");

            Assert.AreEqual(96, pencil.getPointDurability());

            pencil.write(" C   ");

            Assert.AreEqual(94, pencil.getPointDurability());

        }

        [TestMethod]
        public void whenSharpenedDurabilityIsReset()
        {
            pencil.write("fubdfniebibnasdA");

            pencil.sharpen();

            Assert.AreEqual(100, pencil.getMaxDurability());
            Assert.AreEqual(100, pencil.getPointDurability());
        }

        [TestMethod]
        public void whenThereIsNotEnoughDurabilityABlankIsWritten()
        {
            pencil = new Pencil(5, 0, 0);

            Assert.AreEqual("abcd f  ", pencil.write("abcdEfgh"));

            
        }

        [TestMethod]
        public void whenPencilIsSharpenedLengthIsReducedByOne()
        {
            pencil = new Pencil(5, 1, 0);

            pencil.write("aaaaa");
            pencil.sharpen();
            
            Assert.AreEqual(0, pencil.getLength());

        }

        [TestMethod]
        public void whenPencilLengthIsZeroPencilCannotBeSharpened()
        {
            pencil = new Pencil(5, 0, 0);

            pencil.write("aaaaa");
            pencil.sharpen();
            
            Assert.AreEqual("     ", pencil.write("aaaaa"));

        }

        [TestMethod]
        public void whenGivenTwoStringsReplaceTheLastInstanceOfTheFirstStringInTheSecondStringWithBlankSpaces()
        {
            Assert.AreEqual("Erase last instance of word          in this string", pencil.erase("instance", "Erase last instance of word instance in this string"));
        }

        [TestMethod]
        public void whenGivenAStringToEraseThatIsNotInTheStartingStringReturnTheStartingString()
        {
            Assert.AreEqual("Nothing should erase", pencil.erase("bacon", "Nothing should erase"));
        }

        [TestMethod]
        public void whenEraserIsUsedDegradeEraserDurabilityByOnePerCharacter()
        {
            pencil = new Pencil(5, 1, 10);

            pencil.erase(" Durability", "Reduce Durability");

            Assert.AreEqual(0, pencil.getEraserDurability());
        }

        [TestMethod]
        public void whenEraserDurabilityIsZeroErasingStops()
        {
            pencil = new Pencil(5, 1, 8);

            Assert.AreEqual("Reduce Du        ", pencil.erase(" Durability", "Reduce Durability"));
        }
    }
}
