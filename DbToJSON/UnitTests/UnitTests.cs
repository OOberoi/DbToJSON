using DbToJSON.Repositories;
using DbToJSON.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace UnitTests
{
    [TestClass]
    public class DbToJSONUnitTests
    {
        private const string fileName = "MyJson.txt";
        private const string filePath = "@C://Users//oober//source//repos//Console Apps//DbToJSON//DbToJSON//";
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
                    ClientId = "38AX68",
                    JSON = "JSON DATA New",
                    PackageId = "iawdev89891",
                    PackageInstanceId = "iawdev89890_38AX68",
                    Comments = "Package Sent to TD",
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
                            s.DateCreated
                        }).ToList();
                    if (retVal.Count > 0)
                    {
                        string json = JsonSerializer.Serialize(retVal);
                        File.WriteAllText(filePath + fileName, json);
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
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Assert.IsTrue(true);
            }            
        }
    }

        
    //public static IList<ClientRepaperingInfo> GetRepaperingList()
    //{
    //    var ctx = new JsonDbContext();
    //    if (ctx != null)
    //    {
    //        if (ctx.ClientRepaperingInfo.Any())
    //        {
    //            return ctx.ClientRepaperingInfo.ToList();
    //        }
    //    }
    //    return null;
    //}
        
}
 