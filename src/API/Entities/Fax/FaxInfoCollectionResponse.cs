using System.Collections.Generic;

namespace TcFaxApi.Entities.Fax
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
