using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbToJSON.Repositories;
using DbToJSON.Shared;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;

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
            try
            {
                int[] arr = new int[5] { 10, 5, 2, 1, 6 };
                int expected = 5;
                Assert.AreEqual(expected, arr.Length);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void GetRepaperingInfo()
        {
            try
            {
                var retVal = _jsonDbContext.RepaperingInfo.ToList();
                if (retVal.Count > 0)
                {
                    Assert.IsTrue(true);
                }
            }
            
            catch (Exception ex)
            {
                ex.Message.ToString();
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void WriteToFile()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
 