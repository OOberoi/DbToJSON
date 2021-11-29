using DbToJSON.Repositories;
using System;
using System.Linq;
using System.IO;
using System.Text;
using DbToJSON.Shared;

namespace DbToJSON
{
    public class Program
    {
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
                    ClientId = "38AX69",
                    JSON = "JSON DATA New",
                    PackageId = "iawdev89891",
                    PackageInstanceId = "iawdev89891_38AX69",
                    Comments = "Package Sent to BMO",
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

            #region "GetJSON"
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

            #region "GetRepaperingInfo"
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
        }
    }
   
}
