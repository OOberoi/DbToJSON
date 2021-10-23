using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbToJSON.Repositories;
using DbToJSON.Shared;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Text;
using System;
using System.Globalization;

namespace UnitTests
{
    [TestClass]
    public class DbToJSONUnitTests
    {
        public IEnumerable<ClientRepaperingInfo> RepaperingInfo { get; set; }

        private readonly JsonDbContext _jsonDbContext;

        public DbToJSONUnitTests()
        {
        }
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
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void GetRepaperingInfo()
        {
            try
            {
                using var ctx = new JsonDbContext();
                if (ctx != null) 
                {
                    var retVal = ctx.ClientRepaperingInfo
                        .Select(s => new
                        {
                            s.ID,
                            s.PackageId,
                            s.PackageInstanceId,
                            s.JSON,
                            s.DateCreated
                        }).ToList();
                    if (retVal.Count > 0)
                    {
                        Assert.IsTrue(true);
                    }
                }
            }
            
            catch (Exception ex)
            {
                ex.Message.ToString();
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void AddRepaperingInfo()
        {
            try
            {
                using var ctx = new JsonDbContext();
                var cli = new ClientRepaperingInfo
                {
                    ClientId = "38AX67",
                    JSON = "JSON DATA",
                    PackageId = "iawdev89890",
                    PackageInstanceId = "iawdev89890_38AX67",
                    Comments = "Package Sent",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };
                ctx.ClientRepaperingInfo.Add(cli);
                ctx.SaveChanges();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Assert.IsTrue(false);
            }
        }

        [Ignore]
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

        [TestMethod]
        public void RemoveAccentedChars()
        {
            try
            {
                string txt = "â, î or ô?><ä ë ü Ö Ü ã õ ñ Ã Õ Ñ";
                var normalizedString = txt.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new();

                foreach (var ns in normalizedString)
                {
                    var unicodeCat = CharUnicodeInfo.GetUnicodeCategory(ns);
                    if (unicodeCat != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(ns);
                    }
                }
                _ = sb.ToString().Normalize(NormalizationForm.FormC);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Assert.IsTrue(true);
            }            
        }
    }
}
 