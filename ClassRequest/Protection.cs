using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ClassRequest
{
    public static class Protection
    {

        ////КРИПТОГРАФИЯ АЛГОРИТМ AES
        
        //// HashAlgorithm может быть SHA1 или MD5. 
        //// InitialVector должен быть строкой размерностью 16 ASCII символов.
        //// KeySize может быть 128, 192, или 256.
        //// The Salt выступает в роли второго ключа.
        //// PasswordIterations сколько раз алгоритм выполнится над текстом.

        //шифрование
        public static string Encrypt(string plainText, string password,
            string salt = "Addmin", string hashAlgorithm = "SHA1",
            int passwordIterations = 2, string initialVector = "r2oCxdEGBlBjfigK",
            int keySize = 256)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = derivedPassword.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;
            using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }
            symmetricKey.Clear();

            return Convert.ToBase64String(cipherTextBytes);
        }



        //дешифрование
        public static string Decrypt(string cipherText, string password,
            string salt = "Addmin", string hashAlgorithm = "SHA1",
            int passwordIterations = 2, string initialVector = "r2oCxdEGBlBjfigK",
            int keySize = 256)
        {
            if (string.IsNullOrEmpty(cipherText))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = derivedPassword.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int byteCount = 0;
            using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                    {
                        byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }
            symmetricKey.Clear();

            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
        }


        public static string EncryptMD5(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum1 = md5.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return (BitConverter.ToString(checkSum1).Replace("-", string.Empty));
        }
    }
}
