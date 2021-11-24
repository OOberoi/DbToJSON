using DbToJSON.Repositories;
using System;

namespace DbToJSON
{
    public class Program
    {       
        public static void Main()
        {
            RepaperingInfoRepository _repaperingInfo = new();

            #region "GetJSON"
            string json = _repaperingInfo.GetJSON();
            Console.WriteLine(json);
            Console.ReadLine();
            #endregion
        }
    }
}
