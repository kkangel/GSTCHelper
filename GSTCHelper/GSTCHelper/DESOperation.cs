using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GSTCHelper
{
    class DESOperation
    {
        private static  string encoding = "utf-8";
    private static  string iv = "01234567";
    private static  string secretKey = "chinalife13nde3i!sfac43#a4";

        #region 3DES加密

        public static string EncryptDES(string plainText)
        {
            MemoryStream mStream = new MemoryStream();
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.CBC;
            tdsp.Padding = PaddingMode.PKCS7;
            tdsp.IV = Encoding.UTF8.GetBytes(iv);
            tdsp.Key = Encoding.UTF8.GetBytes(secretKey);
            //tdsp.IV = ASCIIEncoding.ASCII.GetBytes(iv);
            //tdsp.Key = ASCIIEncoding.ASCII.GetBytes(secretKey);
            // byte[] data = ASCIIEncoding.ASCII.GetBytes(plainText);
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            CryptoStream cStream = new CryptoStream(mStream,
                   tdsp.CreateEncryptor(),
                   CryptoStreamMode.Write);
            // Write the byte array to the crypto stream and flush it.
            cStream.Write(data, 0, data.Length);
            cStream.FlushFinalBlock();
            // Get an array of bytes from the 
            // MemoryStream that holds the 
            // encrypted data.
            byte[] ret = mStream.ToArray();
            // Close the streams.
            cStream.Close();
            mStream.Close();
            string rtData = Cryptographic.encode(ret);
            //DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            //byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey);
            //byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            //MemoryStream mStream = new MemoryStream();
            //CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, new byte[8]), CryptoStreamMode.Write);
            //cStream.Write(inputByteArray, 0, inputByteArray.Length);
            //cStream.FlushFinalBlock();

            //return Convert.ToBase64String(mStream.ToArray());

            //java代码段
            //Key deskey = SecretKeyFactory.getInstance("desede").generateSecret(new DESedeKeySpec(secretKey.getBytes()));
            //Cipher cipher = Cipher.getInstance("desede/CBC/PKCS5Padding");
            //cipher.init(1, deskey, new IvParameterSpec(iv.getBytes()));
            //return Base64.encode(cipher.doFinal(plainText.getBytes(encoding)));
        }

        #endregion

        #region 3DES解密

        public static string DecryptDES(string encryptText)
        {
            byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, new byte[8]), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());

            //java代码段
            //Key deskey = SecretKeyFactory.getInstance("desede").generateSecret(new DESedeKeySpec(secretKey.getBytes()));
            //Cipher cipher = Cipher.getInstance("desede/CBC/PKCS5Padding");
            //cipher.init(2, deskey, new IvParameterSpec(iv.getBytes()));
            //return new String(cipher.doFinal(Base64.decode(encryptText)), encoding);
        }

        #endregion




    }
}
