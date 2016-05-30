using System;
using ClassRequest.DAL;
using Npgsql;

namespace ClassRequest.Login
{
    public class LoginReposFactory : IDisposable
    {
        RepositoryLogin RepositoryLogin { set; get; }

        private NpgsqlConnection npgsql;
        private SqlConnect sqlConnect;

        public LoginReposFactory(string server, string port, string userId, string password, string database)
        {
            npgsql = new NpgsqlConnection("Server=" + server +
                                                           "; Port=" + port +
                                                           "; User Id=" + userId +
                                                           "; Password=" + password +
                                                           "; Database=" + database + ";");
            sqlConnect = new SqlConnect(npgsql);
            OpenConnection();

            RepositoryLogin = new RepositoryLogin(sqlConnect);
        }

        public void OpenConnection()
        {
            sqlConnect.GetInstance().OpenConn();
        }

        public void Dispose()
        {
            sqlConnect.GetInstance().CloseConn();
        }

        public RepositoryLogin GetLogin()
        {
            return RepositoryLogin;
        }
    }
}
