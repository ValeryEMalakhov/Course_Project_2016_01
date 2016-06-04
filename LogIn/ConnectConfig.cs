namespace LogIn
{
    public class ConnectConfig
    {
        public string Server { private set; get; }
        public string Port { private set; get; }
        public string UserId { private set; get; }
        public string Password { private set; get; }
        public string Database { private set; get; }

        public ConnectConfig()
        { }

        public ConnectConfig(string server, string port, string userId, string password, string database)
        {
            Server = server;
            Port = port;
            UserId = userId;
            Password = password;
            Database = database;
        }
    }
}
