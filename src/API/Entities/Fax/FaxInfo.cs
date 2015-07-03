namespace TcFaxApi.Entities.Fax
{
    public class FaxInfo
    {
        /// <summary>
        /// ID of the Fax.
        /// </summary>
        public string Id { get { return _id; } }
        private string _id;

        /// <summary>
        /// Number the fax was from.
        /// </summary>
        public string FromNumber { get { return _fromNumber; } }
        private string _fromNumber;

        /// <summary>
        /// Number that the fax is to.
        /// </summary>
        public string ServiceNumber { get {  return _serviceNumber; } }
        private string _serviceNumber;

        /// <summary>
        /// Amount of pages that are in the fax.
        /// </summary>
        public int PageCount { get { return _pageCount; } }
        private int _pageCount;

        /// <summary>
        /// Date the fax was receieved.
        /// </summary>
        public string ReceivedDate { get { return _receivedDate; } }
        private string _receivedDate;

        /// <summary>
        /// File size of the tiff file (in bytes).
        /// </summary>
        public int TiffBytes { get { return _tiffBytes; } }
        private int _tiffBytes;

        /// <summary>
        /// Pointer of the fax. (Most like received date in Epoch.
        /// </summary>
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
