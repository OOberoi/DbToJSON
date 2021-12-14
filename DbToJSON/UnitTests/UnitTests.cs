using DbToJSON.Repositories;
using DbToJSON.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace UnitTests
{
    [TestClass]
    public class DbToJSONUnitTests
    {
        #region "Private Static Vars"
        private static readonly string hyphen = "_";
        private static readonly string backSlashes = "\\";
        private static readonly string year = DateTime.Now.Year.ToString();
        private static readonly string month = DateTime.Now.Date.Month.ToString();
        private static readonly string day = DateTime.Now.Date.Day.ToString();
        private static readonly string extn = ".txt";
        private static readonly string jsonFN = "MyDbJson";
        private static readonly string accentedFN = "MyAccented";
        private static readonly string fileName = hyphen + year + month + day + extn;
        private static readonly string path = Directory.GetCurrentDirectory();
        #endregion

        public IEnumerable<ClientRepaperingInfo> RepaperingInfo { get; set; }

        private readonly JsonDbContext _jsonDbContext;

        public DbToJSONUnitTests()
        {
        }
        public DbToJSONUnitTests(JsonDbContext jsonDbContext)
        {
            _jsonDbContext = jsonDbContext;
        }
        #region Test Methods
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
                Assert.IsTrue(false);
            }
        }

        public void GetProcessInstancesArr()
        { 
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
                        Assert.IsTrue(retVal.Count > 0);
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
                    ClientId = "38AX69",
                    JSON = "JSON DATA New",
                    PackageId = "rbcdev89891",
                    PackageInstanceId = "rbcdev89891_38AX69",
                    Comments = "Package Sent to BMO",
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

        [TestMethod]
        public void UpdateRepaperingInfo()
        {
            try
            {
                using var ctx = new JsonDbContext();
                var cli = ctx.ClientRepaperingInfo.First(c => c.ID == 3);
                cli.Comments = "regression testing";
                cli.JSON = "Json update";
                cli.DateUpdated = DateTime.Now;
                ctx.SaveChanges();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void DeleteRepaperingInfo()
        {
            try
            {
                using var ctx = new JsonDbContext();
                var cli = ctx.ClientRepaperingInfo.First(c => c.ID == 2);
                ctx.Remove(cli);
                ctx.SaveChanges();
                Assert.IsTrue(true);
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
                var ctx = new JsonDbContext();
                if (ctx != null)
                {
                    var retVal = ctx.ClientRepaperingInfo
                        .Select(s => new
                        {
                            s.ID,
                            s.PackageId,
                            s.PackageInstanceId,
                            s.JSON,
                            s.Comments,
                            s.DateCreated
                        }).ToList();
                    if (retVal.Count > 0)
                    {
                        string json = JsonSerializer.Serialize(retVal);
                        File.WriteAllText(path + backSlashes + jsonFN + fileName, json);
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
                File.WriteAllText(path + backSlashes + accentedFN + fileName, sb.ToString());
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Assert.IsTrue(false);
            }
        }
        #endregion
    }



}
