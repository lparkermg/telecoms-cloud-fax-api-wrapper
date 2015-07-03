namespace TcFaxApi.Entities
{
    public class ClientGrantResponse
    {
        public string AccessToken { get { return _accessToken; } }
        private string _accessToken;

        public int ExpiresIn { get { return _expiresIn; } }
        private int _expiresIn;

        public string TokenType { get { return _tokenType; } }
        private string _tokenType;

        public string Scope { get { return _scope; } }
        private string _scope;

        public ClientGrantResponse(string accessToken, int expiresIn, string tokenType, string scope)
        {
            _accessToken = accessToken;
            _expiresIn = expiresIn;
            _tokenType = tokenType;
            _scope = scope;
        }

    }
}
