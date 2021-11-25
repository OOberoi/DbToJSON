using DbToJSON.Shared;
using System.Collections.Generic;

namespace DbToJSON.Repositories
{
    public interface IRepaperingInfo
    {
        IEnumerable<ClientRepaperingInfo> GetAllRepaperingInfo();
        string GetJSON();
        string GetJSON(string[] instanceArr);
        IList<string> GetJSONList(string[] instanceArr);
        void GetRepaperingInfo();
    }
}
