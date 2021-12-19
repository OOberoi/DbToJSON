using DbToJSON.Repositories;
using DbToJSON.Shared;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DbToJSON
{

    public class Program
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
        public static void Main()
        {
            RepaperingInfoRepository _repaperingInfo = new();
            StringBuilder sb = new();

            //test the getProcessInstance function
            string myArr = Utils.GetProcessInstance();
            string jsonSerialize = JsonSerializer.Serialize(myArr);
            File.WriteAllText(path + backSlashes + jsonFN + fileName, jsonSerialize);

            Console.WriteLine(myArr);

            #region AddRepaperingInfo
            try
            {
                using var ctx = new JsonDbContext();
                var cli = new ClientRepaperingInfo()
                {
                    ClientId = "38AX70",
                    JSON = "JSON DATA New",
                    PackageId = "iawdev89892",
                    PackageInstanceId = "iawdev89892_38AX70",
                    Comments = "Package Sent to BNS",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };
                ctx.ClientRepaperingInfo.Add(cli);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            #endregion

            #region GetJSON
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
                        foreach (var item in retVal)
                        {
                            Console.WriteLine($"The values are: {item.ID + ", " + item.PackageInstanceId + ", " + item.PackageId + ", " + item.JSON + ", " + item.DateCreated.ToString("M/d/yyyy")}");
                        }
                    }
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            #endregion

            #region GetRepaperingInfo
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
                                V = s.DateCreated.ToString("M/d/yyyy")
                            }).ToList();
                        if (retVal.Count > 0)
                        {
                            Console.WriteLine($"The value is {retVal.Count}");
                        }
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            #endregion

            #region AddRepaperingInfo
            try
            {
                using var ctx = new JsonDbContext();
                var cli = ctx.ClientRepaperingInfo.First(c => c.ID == 3);
                cli.Comments = "regression testing";
                cli.JSON = "Json update";
                cli.DateUpdated = DateTime.Now;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            #endregion

            #region UpdateRepaperingInfo
            try
            {
                using var ctx = new JsonDbContext();
                var cli = ctx.ClientRepaperingInfo.First(c => c.ID == 3);
                cli.Comments = "regression testing";
                cli.JSON = "Json update";
                cli.DateUpdated = DateTime.Now;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            #endregion

            #region DeleteRepaperingInfo
            try
            {
                using var ctx = new JsonDbContext();
                var cli = ctx.ClientRepaperingInfo.First(c => c.ID == 2);
                ctx.Remove(cli);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            #endregion

            #region WriteToFile
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
            }
            #endregion

            #region RemoveAccentedCharacters
                try
                {
                    string txt = "â, î or ô?><ä ë ü Ö Ü ã õ ñ Ã Õ Ñ";
                    var normalizedString = txt.Normalize(NormalizationForm.FormD);
                    StringBuilder sBuilder = new();

                    foreach (var ns in normalizedString)
                    {
                        var unicodeCat = CharUnicodeInfo.GetUnicodeCategory(ns);
                        if (unicodeCat != UnicodeCategory.NonSpacingMark)
                        {
                            sb.Append(ns);
                        }
                    }
                    _ = sBuilder.ToString().Normalize(NormalizationForm.FormC);
                    File.WriteAllText(path + backSlashes + accentedFN + fileName, sBuilder.ToString());
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            #endregion

           
        }
    }

    public static class Utils
    {
        #region GetProcessInstanceArray
        public static string GetProcessInstance()
        {
            try
            {
                var procInstances = new string[] { "rbcdev000001", "rbcdev000002", "rbcdev000003", "rbcdev000004", "rbcdev000005" };
                StringBuilder sbArr = new();
                if (procInstances.Length > 0)
                {
                    foreach (var item in procInstances)
                    {
                        sbArr.Append(item);
                        sbArr.Append(';');
                    }
                }
                return sbArr.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        
    }
}

