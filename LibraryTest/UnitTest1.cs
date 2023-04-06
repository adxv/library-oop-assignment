namespace LibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PriceCheckTest()
        {
            ManageFile reader = new ManageFile();
            reader.ReadFromFile();

            Assert.AreEqual(Library.PriceCheck(0), 100);
            Assert.AreEqual(Library.PriceCheck(1), 10);
            Assert.AreEqual(Library.PriceCheck(2), 10);
            Assert.AreEqual(Library.PriceCheck(3), 10);
            Assert.AreEqual(Library.PriceCheck(4), 100);
            Assert.AreEqual(Library.PriceCheck(5), 50);

        }
        public void CalculatePriceTest()
        {
            ManageFile reader = new ManageFile();
            reader.ReadFromFile();

            Assert.AreEqual(Library.CalculatePrice(3, 1), 10);
            Assert.AreEqual(Library.CalculatePrice(0, 43), 400);
            Assert.AreEqual(Library.CalculatePrice(2, 54), 60);
            Assert.AreEqual(Library.CalculatePrice(1, 0), 10);

        }
    }
}