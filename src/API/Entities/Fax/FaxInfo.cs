namespace TcFaxApi.Entities.Fax
{
    public class FaxInfo
    {
        public string Id { get { return _id; } }
        private string _id;

        public string FromNumber { get { return _fromNumber; } }
        private string _fromNumber;

        public string ServiceNumber { get {  return _serviceNumber; } }
        private string _serviceNumber;

        public int PageCount { get { return _pageCount; } }
        private int _pageCount;

        public string ReceivedDate { get { return _receivedDate; } }
        private string _receivedDate;

        public int TiffBytes { get { return _tiffBytes; } }
        private int _tiffBytes;

        public int Pointer { get { return _pointer; } }
        private int _pointer;

        public FaxInfo(string id, string fromNumber, string serviceNumber, int pageCount, string receivedDate, int tiffBytes, int pointer)
        {
            _id = id;
            _fromNumber = fromNumber;
            _serviceNumber = serviceNumber;
            _pageCount = pageCount;
            _receivedDate = receivedDate;
            _tiffBytes = tiffBytes;
            _pointer = pointer;
        }
    }
}
