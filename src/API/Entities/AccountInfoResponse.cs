namespace TcFaxApi.Entities
{
    public class AccountInfoResponse
    {
        /// <summary>
        /// The Username gathered with the account info.
        /// </summary>
        public string Username { get { return _username; } }
        private string _username;

        /// <summary>
        /// The current status of the account.
        /// </summary>
        public string Status { get { return _status; } }
        private string _status;

        /// <summary>
        /// Services on the Account.
        /// </summary>
        public int AccountServices { get { return _accountServices; } }
        private int _accountServices;

        /// <summary>
        /// Current Balance on the account.
        /// </summary>
        public float CreditBalance { get { return _creditBalance; } }
        private float _creditBalance;

        /// <summary>
        /// Primary email attached to the account.
        /// </summary>
        public string PrimaryEmail { get { return _primaryEmail; } }
        private string _primaryEmail;

        public AccountInfoResponse(string username, string status, int accountServices, float creditBalance, string primaryEmail)
        {
            _username = username;
            _status = status;
            _accountServices = accountServices;
            _creditBalance = creditBalance;
            _primaryEmail = primaryEmail;
        }
    }
}
