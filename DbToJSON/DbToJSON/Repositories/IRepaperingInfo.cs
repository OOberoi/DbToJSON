using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbToJSON.Shared;
namespace DbToJSON.Repositories
{
    public interface IRepaperingInfo
    {
        //IEnumerable<client>
        string GetJSON();
        string GetJSON(string[] instanceArr);
        IList<string> GetJSONList(string[] instanceArr);
        void GetRepaperingInfo();
    }
}
