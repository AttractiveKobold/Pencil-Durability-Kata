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
            Pencil pencil = new Pencil();

            Assert.AreEqual("Some Test Words", pencil.write("", "Some Test Words"));
        }
    }
}
