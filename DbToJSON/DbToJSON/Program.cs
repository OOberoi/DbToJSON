using DbToJSON.Repositories;
using System;

namespace DbToJSON
{
    public class Program
    {
        private readonly IRepaperingInfo _repaperingInfo;


        public Program(IRepaperingInfo repaperingInfo)
        {
            _repaperingInfo = repaperingInfo;
        }

        public static void Main()
        {
           
            Console.WriteLine("Hello World!");
            //_repaperingInfo.GetRepaperingInfo();
        }
    }
}
