using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Configuration;
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Npgsql;
using ClassRequest;
using ClassRequest.DAL;
using ClassRequest.Login;
using Staff.Sided_Form;
using Configuration = System.Configuration.Configuration;

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

            //< add key = "ip" value = "127.0.0.1" />
            //< add key = "port" value = "5432" />
            //< add key = "userId" value = "postgres" />
            //< add key = "passwd" value = "1507" />
            //< add key = "dataBase" value = "malakhov" />

            //Encrypt(text, password); //где text — текст который необходимо зашифровать,password — пароль для шифровки
            //Decrypt(text, password); //аналогично
            // UPD1: можно воспользоваться и более сложной схемой включая размер ключа и байт
            //Encrypt(text, password1, password2, "SHA1", 2,"16CHARSLONG12345", 256);
            //Decrypt(text, password1, password2, "SHA1", 2,"16CHARSLONG12345", 256);

            //ConfigurationManager.AppSettings.Set("ip", Protection.Encrypt("127.0.0.1", "VEM"));
            //ConfigurationManager.AppSettings.Set("port", Protection.Encrypt("5432", "VEM"));
            //ConfigurationManager.AppSettings.Set("userIdAdmin", Protection.Encrypt("admin", "VEM"));
            //ConfigurationManager.AppSettings.Set("passwdAdmin", Protection.Encrypt("1507", "VEM"));
            //ConfigurationManager.AppSettings.Set("userIdStaff", Protection.Encrypt("staff", "VEM"));
            //ConfigurationManager.AppSettings.Set("passwdStaff", Protection.Encrypt("1111", "VEM"));
            //ConfigurationManager.AppSettings.Set("userIdUser", Protection.Encrypt("users", "VEM"));
            //ConfigurationManager.AppSettings.Set("passwdUser", Protection.Encrypt("2222", "VEM"));
            //ConfigurationManager.AppSettings.Set("userIdLogin", Protection.Encrypt("login", "VEM"));
            //ConfigurationManager.AppSettings.Set("passwdLogin", Protection.Encrypt("1507", "VEM"));
            //ConfigurationManager.AppSettings.Set("dataBase", Protection.Encrypt("malakhov", "VEM"));

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

            ConnectConfig cc = new ConnectConfig(Protection.Decrypt(ConfigurationManager.AppSettings.Get("ip"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("port"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("userIdLogin"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("passwdLogin"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("dataBase"), "VEM"));

            LoginReposFactory loginReposFactory = new LoginReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);

            Application.Run(new WfLogin(loginReposFactory));
        }

        #region Защита old

        //// HashAlgorithm может быть SHA1 или MD5. 
        //// InitialVector должен быть строкой размерностью 16 ASCII символов.
        //// KeySize может быть 128, 192, или 256.
        //// The Salt выступает в роли второго ключа.
        //// PasswordIterations сколько раз алгоритм выполнится над текстом.

        //шифрование
        //public static string Encrypt(string plainText, string password,
        //    string salt = "Addmin", string hashAlgorithm = "SHA1",
        //    int passwordIterations = 2, string initialVector = "r2oCxdEGBlBjfigK",
        //    int keySize = 256)
        //{
        //    if (string.IsNullOrEmpty(plainText))
        //        return "";

        //    byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
        //    byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
        //    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        //    PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm,
        //        passwordIterations);
        //    byte[] keyBytes = derivedPassword.GetBytes(keySize/8);
        //    RijndaelManaged symmetricKey = new RijndaelManaged();
        //    symmetricKey.Mode = CipherMode.CBC;

        //    byte[] cipherTextBytes = null;

        //    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initialVectorBytes))
        //    {
        //        using (MemoryStream memStream = new MemoryStream())
        //        {
        //            using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
        //            {
        //                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        //                cryptoStream.FlushFinalBlock();
        //                cipherTextBytes = memStream.ToArray();
        //                memStream.Close();
        //                cryptoStream.Close();
        //            }
        //        }
        //    }

        //    symmetricKey.Clear();
        //    return Convert.ToBase64String(cipherTextBytes);
        //}



        ////дешифрование
        //public static string Decrypt(string cipherText, string password,
        //    string salt = "Addmin", string hashAlgorithm = "SHA1",
        //    int passwordIterations = 2, string initialVector = "r2oCxdEGBlBjfigK",
        //    int keySize = 256)
        //{
        //    if (string.IsNullOrEmpty(cipherText))
        //        return "";

        //    byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
        //    byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
        //    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

        //    PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm,
        //        passwordIterations);
        //    byte[] keyBytes = derivedPassword.GetBytes(keySize/8);

        //    RijndaelManaged symmetricKey = new RijndaelManaged();
        //    symmetricKey.Mode = CipherMode.CBC;

        //    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        //    int byteCount = 0;

        //    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initialVectorBytes))
        //    {
        //        using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
        //        {
        //            using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
        //            {
        //                byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //                memStream.Close();
        //                cryptoStream.Close();
        //            }
        //        }
        //    }

        //    symmetricKey.Clear();
        //    return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
        //}

        #endregion
    }
}