using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void TestSound()
        {
            Chip testChip = new Chip("doritos", 1.50M);
            Assert.AreEqual("Crunch, Crunch, Yum!", testChip.MakeSound(), "Didn't make correct sound.");

            Candy testCandy = new Candy("hersheys", 2.00M);
            Assert.AreEqual("Munch, Munch, Yum!", testCandy.MakeSound(), "Didn't make correct sound.");

            Drink testDrink = new Drink("whiskey", 0.50M);
            Assert.AreEqual("Glug, Glug, Yum!", testDrink.MakeSound(), "Didn't make correct sound.");

            Gum testGum= new Gum("five", 3.00M);
            Assert.AreEqual("Chew, Chew, Yum!", testGum.MakeSound(), "Didn't make correct sound.");
        }

        [TestMethod]
        public void 
    }
}
