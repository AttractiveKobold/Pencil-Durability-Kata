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
            Assert.AreEqual("aaaSome Test Words", pencil.Write("Some Test Words", "aaa"));
        }

        [TestMethod]
        public void whenALowercaseLetterIsWrittenDurabilityDegradesByOne()
        {

            pencil.Write("  a b \n ");

            Assert.AreEqual(98, pencil.getPointDurability());

            pencil.Write("  c   ");

            Assert.AreEqual(97, pencil.getPointDurability());
        }

        [TestMethod]
        public void whenAnUppercaseLetterIsWrittenDurabilityDegradesByTwo()
        {

            pencil.Write("A \nB");

            Assert.AreEqual(96, pencil.getPointDurability());

            pencil.Write(" C   ");

            Assert.AreEqual(94, pencil.getPointDurability());

        }

        [TestMethod]
        public void whenSharpenedDurabilityIsReset()
        {
            pencil.Write("fubdfniebibnasdA");

            pencil.Sharpen();

            Assert.AreEqual(100, pencil.getMaxDurability());
            Assert.AreEqual(100, pencil.getPointDurability());
        }

        [TestMethod]
        public void whenThereIsNotEnoughDurabilityABlankIsWritten()
        {
            pencil = new Pencil(5, 0, 0);

            Assert.AreEqual("abcd f  ", pencil.Write("abcdEfgh"));

            
        }

        [TestMethod]
        public void whenPencilIsSharpenedLengthIsReducedByOne()
        {
            pencil = new Pencil(5, 1, 0);

            pencil.Write("aaaaa");
            pencil.Sharpen();
            
            Assert.AreEqual(0, pencil.getLength());

        }

        [TestMethod]
        public void whenPencilLengthIsZeroPencilCannotBeSharpened()
        {
            pencil = new Pencil(5, 0, 0);

            pencil.Write("aaaaa");
            pencil.Sharpen();
            
            Assert.AreEqual("     ", pencil.Write("aaaaa"));

        }

        [TestMethod]
        public void whenGivenTwoStringsReplaceTheLastInstanceOfTheFirstStringInTheSecondStringWithBlankSpaces()
        {
            Assert.AreEqual("Erase last instance of word          in this string", pencil.Erase("instance", "Erase last instance of word instance in this string"));
        }

        [TestMethod]
        public void whenGivenAStringToEraseThatIsNotInTheStartingStringReturnTheStartingString()
        {
            Assert.AreEqual("Nothing should erase", pencil.Erase("bacon", "Nothing should erase"));
        }

        [TestMethod]
        public void whenEraserIsUsedDegradeEraserDurabilityByOnePerCharacter()
        {
            pencil = new Pencil(5, 1, 10);

            pencil.Erase(" Durability", "Reduce Durability");

            Assert.AreEqual(0, pencil.getEraserDurability());
        }

        [TestMethod]
        public void whenEraserDurabilityIsZeroErasingStops()
        {
            pencil = new Pencil(5, 1, 8);

            Assert.AreEqual("Reduce Du        ", pencil.Erase(" Durability", "Reduce Durability"));
        }

        [TestMethod]
        public void whenGivenAStringEditWritesThatStringInTheFirstBlankSpace()
        {
            Assert.AreEqual("Edit Test Complete", pencil.Edit("Test", "Edit      Complete"));
        }

        [TestMethod]
        public void whenEditingASpaceWithAStringThatIsTooLongUseTheAtSymbolInstead()
        {
            Assert.AreEqual("This is no@ight", pencil.Edit("not", "This is   right"));
        }

        [TestMethod]
        public void whenNonLetterCharactersAreWrittenPointDurabilityDegradesByOne()
        {
            pencil.Write("!1,./'-_=0");
            Assert.AreEqual(90, pencil.getPointDurability());
        }

        [TestMethod]
        public void whenEditingAPaperPointStillDegrades()
        {
            pencil.Edit("Test", "Edit      Complete");
            Assert.AreEqual(96, pencil.getPointDurability());
        }

        [TestMethod]
        public void whenPointDurabilityIsAtZeroEditingStops()
        {
            pencil = new Pencil(3, 0, 0);

            Assert.AreEqual("Edit Tes  Complete", pencil.Edit("Test", "Edit      Complete"));
        }

        [TestMethod]
        public void whenPassedIntegerNEditWillEditTheNthBlankSpace()
        {
            Assert.AreEqual("Edit      Complete Test Again", pencil.Edit("Test", "Edit      Complete      Again", 2));
        }
    }
}
