using DbToJSON.Repositories;
using System;
using System.Linq;
using System.IO;
using System.Text;

namespace DbToJSON
{
    public class Program
    {       
        public static void Main()
        {
            RepaperingInfoRepository _repaperingInfo = new();
            StringBuilder sb = new();

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
                            Console.WriteLine($"The values are: {item.ID + ", " + item.PackageInstanceId + ", " + item.PackageId + ", " + item.JSON + ", " + item.DateCreated.ToString("YYYYmmdd")}");
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
                            s.DateCreated
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
