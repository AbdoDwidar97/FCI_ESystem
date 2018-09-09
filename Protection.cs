using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FCI_Com
{
    class Protection
    {

        MD5CryptoServiceProvider HashedKey = new MD5CryptoServiceProvider();
        TripleDESCryptoServiceProvider Encryptor = new TripleDESCryptoServiceProvider();


        public string Encrypt(string Pwd, string Key)
        {

            byte[] PwdBytes = Encoding.UTF8.GetBytes(Pwd);
            byte[] KeyBytes = Encoding.UTF8.GetBytes(Key);


            byte[] HashKey = HashedKey.ComputeHash(KeyBytes);


            Encryptor.Key = HashKey;


            Encryptor.Mode = CipherMode.ECB;
            Encryptor.Padding = PaddingMode.PKCS7;


            try
            {

                ICryptoTransform Encr = Encryptor.CreateEncryptor();

                byte[] EncryptedPwd = Encr.TransformFinalBlock(PwdBytes, 0, Pwd.Length);

                string EncryptedPwdText = Convert.ToBase64String(EncryptedPwd);

                return EncryptedPwdText;

            }

            catch { Encryptor.Clear(); HashedKey.Clear(); return null; }
            finally { Encryptor.Clear(); HashedKey.Clear(); }

                        
        }



        public string Decrypt(string Pwd64, string Key)
        {

            HashedKey = new MD5CryptoServiceProvider();
            Encryptor = new TripleDESCryptoServiceProvider();



            byte[] KeyBytes = Encoding.UTF8.GetBytes(Key);


            byte[] HashKey = HashedKey.ComputeHash(KeyBytes);


            Encryptor.Key = HashKey;


            Encryptor.Mode = CipherMode.ECB;
            Encryptor.Padding = PaddingMode.PKCS7;


            try
            {

                ICryptoTransform Decr = Encryptor.CreateDecryptor();

                byte[] PwdBytes = Convert.FromBase64String(Pwd64);

                byte[] DecryptedPwd =  Decr.TransformFinalBlock(PwdBytes, 0, PwdBytes.Length);

                string DecryptedPwdText = Encoding.UTF8.GetString(DecryptedPwd);

                return DecryptedPwdText;

            }

            catch { Encryptor.Clear(); HashedKey.Clear(); return null; }
            finally { Encryptor.Clear(); HashedKey.Clear(); }



        }
        


    }
}
