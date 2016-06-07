using System;
using System.Windows.Forms;
using System.Configuration;
using ClassRequest;
using ClassRequest.Login;

namespace LogIn
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Тестирование защиты

            // зашифрованное подключение к базе
            //ConfigurationManager.AppSettings.Set("ip", Protection.DESEncrypt("127.0.0.1"));
            //ConfigurationManager.AppSettings.Set("port", Protection.DESEncrypt("5432"));
            //ConfigurationManager.AppSettings.Set("userIdAdmin", Protection.DESEncrypt("admin"));
            //ConfigurationManager.AppSettings.Set("passwdAdmin", Protection.DESEncrypt("0000"));
            //ConfigurationManager.AppSettings.Set("userIdStaff", Protection.DESEncrypt("staff"));
            //ConfigurationManager.AppSettings.Set("passwdStaff", Protection.DESEncrypt("1111"));
            //ConfigurationManager.AppSettings.Set("userIdUser", Protection.DESEncrypt("users"));
            //ConfigurationManager.AppSettings.Set("passwdUser", Protection.DESEncrypt("2222"));
            //ConfigurationManager.AppSettings.Set("userIdLogin", Protection.DESEncrypt("login"));
            //ConfigurationManager.AppSettings.Set("passwdLogin", Protection.DESEncrypt("0001"));
            //ConfigurationManager.AppSettings.Set("dataBase", Protection.DESEncrypt("malakhov"));

            //string ip = ConfigurationManager.AppSettings.Get("ip");
            //string port = ConfigurationManager.AppSettings.Get("port");

            //string userIdAdmin = ConfigurationManager.AppSettings.Get("userIdAdmin");
            //string passwdAdmin = ConfigurationManager.AppSettings.Get("passwdAdmin");
            //string userIdStaff = ConfigurationManager.AppSettings.Get("userIdStaff");
            //string passwdStaff = ConfigurationManager.AppSettings.Get("passwdStaff");
            //string userIdUser = ConfigurationManager.AppSettings.Get("userIdUser");
            //string passwdUser = ConfigurationManager.AppSettings.Get("passwdUser");
            //string userIdLogin = ConfigurationManager.AppSettings.Get("userIdLogin");
            //string passwdLogin = ConfigurationManager.AppSettings.Get("passwdLogin");

            //string dataBase = ConfigurationManager.AppSettings.Get("dataBase");

            #endregion

            ConnectConfig cc = new ConnectConfig(Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("ip")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("port")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("userIdLogin")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("passwdLogin")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("dataBase")));

            LoginReposFactory loginReposFactory = new LoginReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);

            //Application.Run(new WfLogin(loginReposFactory));
            Application.Run(new NewLogInForm(loginReposFactory));
        }
    }
}