using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbToJSON.Repositories;

namespace UnitTests
{
    [TestClass]
    public class DbToJSONUnitTests
    {
        [TestMethod]
        public void AddTest()
        {
            int val = 10;
            Assert.IsTrue(val > 5);
        }

        [TestMethod]
        public void GetArrayList()
        {
            int[] arr = new int[5] {10, 5, 2, 1, 6 };
            int expected = 5;
            Assert.AreEqual(expected, arr.Length);
        }

        [TestMethod]
        public void GetRepaperingInfo()
        { 
            //using var context = new Json
        }

        [TestMethod]
        public void GetWriteToFile()
        { 
        }
    }
}
 