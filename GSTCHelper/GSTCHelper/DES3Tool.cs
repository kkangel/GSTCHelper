using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GSTCHelper
{
    /// <summary>
    /// 3DES 加密解密
    /// -----------------------------------------------------------
    /// 说明:
    ///     转载自网上http://bbs.csdn.net/topics/350158619
    ///     并加以扩展
    /// 修正:
    ///     1. 修改正解密后出现 '\0'
    /// 注: 1. Key必须为24位
    ///     2. 向量不能小于8位
    ///     3. 明文末尾如果是带'\0'字符,则会一起去掉
    /// -----------------------------------------------------------
    /// 扩展人:Wuyf 11222337#qq.com
    /// 日  期:2014-11-29
    /// </summary>
    public class Des3Tool
    {
        #region CBC模式**

        #region 扩展方法

        /// <summary>
        /// 3DES 加密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <param name="isRetBase64">true:返回base64,false:返回Utf8</param>
        /// <returns></returns>
        public static string Des3EncodeCBC(string key, string iv, string data)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Encoding.UTF8.GetBytes(data);

            rtnValue = Des3EncodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Convert.ToBase64String(rtnValue);

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeCBC(string key, string iv, string dataEnBase64)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Convert.FromBase64String(dataEnBase64);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeCBC(string key, string iv, byte[] dataArr)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        #endregion

        #region 原加解密方法


        /// <summary>
        /// DES3 CBC模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            //复制于MSDN

            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
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

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// DES3 CBC模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        #endregion

        #endregion

        #region ECB模式

        #region 不提供Iv(扩展方法)

        private static string ivDefault = "12345678";

        /// <summary>
        /// 3DES 加密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <param name="isRetBase64">true:返回base64,false:返回Utf8</param>
        /// <returns></returns>
        public static string Des3EncodeECB(string key, string data)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(ivDefault);
            byte[] dataArr = Encoding.UTF8.GetBytes(data);

            rtnValue = Des3EncodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Convert.ToBase64String(rtnValue);

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, string dataEnBase64)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(ivDefault);
            byte[] dataArr = Convert.FromBase64String(dataEnBase64);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, byte[] dataArr)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(ivDefault);

            rtnValue = Des3DecodeECB(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }
        #endregion

        #region 提供Iv(扩展方法)


        /// <summary>
        /// 3DES 加密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <param name="isRetBase64">true:返回base64,false:返回Utf8</param>
        /// <returns></returns>
        public static string Des3EncodeECB(string key, string iv, string data)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Encoding.UTF8.GetBytes(data);

            rtnValue = Des3EncodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Convert.ToBase64String(rtnValue);

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, string iv, string dataEnBase64)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Convert.FromBase64String(dataEnBase64);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, string iv, byte[] dataArr)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);

            rtnValue = Des3DecodeECB(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        #endregion

        #region 原加解密方法


        /// <summary>
        /// DES3 ECB模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
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

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        /// <summary>
        /// DES3 ECB模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// 类测试
        /// </summary>
        public static void Test()
        {
            System.Text.Encoding utf8 = System.Text.Encoding.UTF8;

            // 扩展方法测试
            string keyExt = "abcdefghijklmnopqrstuvwx";
            string ivExt = "12345678";
            string dataExt = "吴@#@\0\n";

            // CBC 模式
            string tmpEnCBC = Des3Tool.Des3EncodeCBC(keyExt, ivExt, dataExt);       // 返回 base64
            string tmpDeCBC = Des3Tool.Des3DecodeCBC(keyExt, ivExt, tmpEnCBC);       // 返回 utf8格式字符串

            System.Console.WriteLine(tmpEnCBC);
            System.Console.WriteLine(tmpDeCBC);

            System.Console.WriteLine();

            // ECB 带 iv
            string tmpEnECB = Des3Tool.Des3EncodeECB(keyExt, ivExt, dataExt);       // 返回 base64
            string tmpDeECB = Des3Tool.Des3DecodeECB(keyExt, ivExt, tmpEnECB);       // 返回 utf8格式字符串

            System.Console.WriteLine(tmpEnECB);
            System.Console.WriteLine(tmpDeECB);

            System.Console.WriteLine();

            // ECB 不带 iv
            string tmpEnECBNoIv = Des3Tool.Des3EncodeECB(keyExt, dataExt);       // 返回 base64
            string tmpDeECBNoIv = Des3Tool.Des3DecodeECB(keyExt, tmpEnECBNoIv);       // 返回 utf8格式字符串

            System.Console.WriteLine(tmpEnECBNoIv);
            System.Console.WriteLine(tmpDeECBNoIv);

            System.Console.WriteLine();



            //key为abcdefghijklmnopqrstuvwx的Base64编码
            byte[] key = Convert.FromBase64String("YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4");
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用
            byte[] data = utf8.GetBytes("中国ABCabc123");

            System.Console.WriteLine("ECB模式:");
            byte[] str1 = Des3Tool.Des3EncodeECB(key, iv, data);
            byte[] str2 = Des3Tool.Des3DecodeECB(key, iv, str1);
            System.Console.WriteLine(Convert.ToBase64String(str1));
            System.Console.WriteLine(System.Text.Encoding.UTF8.GetString(str2));

            System.Console.WriteLine();

            System.Console.WriteLine("CBC模式:");
            byte[] str3 = Des3Tool.Des3EncodeCBC(key, iv, data);
            byte[] str4 = Des3Tool.Des3DecodeCBC(key, iv, str3);
            System.Console.WriteLine(Convert.ToBase64String(str3));
            System.Console.WriteLine(utf8.GetString(str4));

            System.Console.WriteLine();

        }

    }
}
