using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities.Fax
{
    public class FaxInfoCollectionResponse
    {
        public readonly List<FaxInfo> Records;

        public FaxInfoCollectionResponse(List<FaxInfo> records)
        {
            Records = records;
        }
    }
}
