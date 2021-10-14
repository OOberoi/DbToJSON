using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbToJSON.Repositories;
using DbToJSON.Shared;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace UnitTests
{
    [TestClass]
    public class DbToJSONUnitTests
    {
        private readonly JsonDbContext _jsonDbContext;
        private IEnumerable<RepaperingInfo> RepaperingInfo { get; set; }

        public DbToJSONUnitTests(JsonDbContext jsonDbContext)
        {
            _jsonDbContext = jsonDbContext;
        }

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
            using var ctx = new JsonDbContext();


        }

        [TestMethod]
        public void GetWriteToFile()
        { 
        }
    }
}
 