using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbToJSON.Application.Contracts.Infrastructure
{
    public interface ICsvExport
    {
        //todo: to pass a List<EventExportDto>
        byte[] ExportEventsToCsv(string path);
    }
}
