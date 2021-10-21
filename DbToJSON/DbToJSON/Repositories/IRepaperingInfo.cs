using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbToJSON.Repositories
{
    interface IRepaperingInfo
    {
        string GetJSON();
        string GetJSON(string[] instanceArr);
        IList<string> GetJSONList(string[] instanceArr);
        void GetRepaperingInfo();
    }
}
