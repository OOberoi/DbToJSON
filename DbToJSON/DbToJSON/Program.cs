using DbToJSON.Repositories;
using System;

namespace DbToJSON
{
    public class Program
    {       
        public static void Main()
        {
            RepaperingInfoRepository _repaperingInfo = new();
            Console.WriteLine("Hello World!");
            string json = _repaperingInfo.GetJSON();
        }
    }
}
