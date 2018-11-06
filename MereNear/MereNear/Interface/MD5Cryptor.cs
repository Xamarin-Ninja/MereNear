using System;
using System.Security.Cryptography;
using System.Text;

namespace MereNear.Interface
{
    public class MD5Cryptor : IMD5Cryptor
    {
        //public String Encrypt(String inputString)
        //{
        //    String Key = "ANKAA";
        //    byte[] IVector = new byte[8] {27, 9, 45, 27, 0, 72, 171, 54};

        //    byte[] buffer = Encoding.ASCII.GetBytes(inputString);
        //    TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();
        //    MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        //    tripleDes.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(Key));
        //    tripleDes.IV = IVector;
        //    ICryptoTransform ITransform = tripleDes.CreateEncryptor();
        //    return Convert.ToBase64String(ITransform.TransformFinalBlock(buffer, 0, buffer.Length));
        //}

        public String Encrypt(String inputString)
        {
            try
            {
                String Key = "ANKAA";
                byte[] IVector = new byte[8] { 27, 9, 45, 27, 0, 72, 171, 54 };

                byte[] buffer = Encoding.ASCII.GetBytes(inputString);
                TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                tripleDes.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                tripleDes.IV = IVector;
                ICryptoTransform ITransform = tripleDes.CreateEncryptor();
                return Convert.ToBase64String(ITransform.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            { return "Error : " + ex.Message.ToString(); }

        }

        public String Decrypt(String inputString)
        {
            try
            {
                String Key = "ANKAA";
                byte[] IVector = new byte[8] { 27, 9, 45, 27, 0, 72, 171, 54 };

                byte[] buffer = Convert.FromBase64String(inputString);
                TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                tripleDes.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                tripleDes.IV = IVector;
                ICryptoTransform ITransform = tripleDes.CreateDecryptor();
                return Encoding.ASCII.GetString(ITransform.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            { return "Error : " + ex.Message.ToString(); }

        }
    }
}
