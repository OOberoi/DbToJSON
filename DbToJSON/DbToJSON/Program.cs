using DbToJSON.Repositories;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using DbToJSON.Shared;

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
        }
    }
   
}

