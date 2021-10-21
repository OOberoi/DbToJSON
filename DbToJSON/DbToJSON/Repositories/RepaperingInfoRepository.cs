using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DbToJSON.Repositories
{
    class RepaperingInfoRepository : IRepaperingInfo
    {
        public RepaperingInfoRepository(JsonDbContext jsonDbContext)
        {
            _jsonDbContext = jsonDbContext;
        }
        private readonly JsonDbContext _jsonDbContext;
        string IRepaperingInfo.GetJSON(string[] instanceArr) =>
            // get the payload
            // read the payload and format it to well formed JSON string
            // Send it as an email to a recipient
            throw new NotImplementedException();

        public string GetJSON()
        {
            throw new NotImplementedException();
        }

        IList<string> IRepaperingInfo.GetJSONList(string[] instanceArr)
        {
            throw new NotImplementedException();
        }

        void IRepaperingInfo.GetRepaperingInfo()
        {
            try
            {
                using var ctx = new JsonDbContext();
                var retVal = ctx.RepaperingInfo
                    .Select(s => new
                    {
                        s.PackageId,
                        s.PackageInstanceId,
                        s.JSON
                    });
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
