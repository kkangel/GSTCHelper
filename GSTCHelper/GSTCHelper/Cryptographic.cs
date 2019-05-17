using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTCHelper
{
    class Cryptographic
    {
        private static char[] legalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".ToCharArray();

        public static String encode(byte[] data)
        {
            int d;
            int len = data.Length;
            
            StringBuilder buf = new StringBuilder((data.Length * 3) / 2);
            int end = len - 3;
            int i = 0;
            int n = 0;
            while (i <= end)
            {
                d = (((data[i] & 255) << 16) | ((data[i + 1] & 255) << 8)) | (data[i + 2] & 255);
                buf.Append(legalChars[(d >> 18) & 63]);
                buf.Append(legalChars[(d >> 12) & 63]);
                buf.Append(legalChars[(d >> 6) & 63]);
                buf.Append(legalChars[d & 63]);
                i += 3;
                int n2 = n + 1;
                if (n >= 14)
                {
                    n2 = 0;
                    buf.Append(" ");
                }
                n = n2;
            }
            if (i == (0 + len) - 2)
            {
                d = ((data[i] & 255) << 16) | ((data[i + 1] & 255) << 8);
                buf.Append(legalChars[(d >> 18) & 63]);
                buf.Append(legalChars[(d >> 12) & 63]);
                buf.Append(legalChars[(d >> 6) & 63]);
                buf.Append("=");
            }
            else if (i == (0 + len) - 1)
            {
                d = (data[i] & 255) << 16;
                buf.Append(legalChars[(d >> 18) & 63]);
                buf.Append(legalChars[(d >> 12) & 63]);
                buf.Append("==");
            }
            return buf.ToString();
           // return Convert.ToBase64String(buf);
        }

        private static int decode(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return c - 65;
            }
            if (c >= 'a' && c <= 'z')
            {
                return (c - 97) + 26;
            }
            if (c >= '0' && c <= '9')
            {
                return ((c - 48) + 26) + 26;
            }
            switch (c)
            {
                case '+':
                    return 62;
                case '/':
                    return 63;
                case '=':
                    return 0;
                default:
                    throw new Exception("unexpected code: " + c);
            }
        }

        public static byte[] decode(String s)
        {

            MemoryStream bos = new MemoryStream();
            
                //try
                //{
                    decode(s,ref bos);
                    byte[] decodedBytes = bos.ToArray();
                    try
                    {
                        bos.Close();
                    bos.Dispose();
                    }
                    catch (IOException ex)
                    {
                       
                    }
                    return decodedBytes;
            //}
            //catch (IOException e)
            //{

            //}


        }

        private static void decode(String s,ref MemoryStream os) 
        {
            
            int i = 0;
        int len = s.Length;
        while (true) {
            if (i<len && s[i] <= ' ') {
                i++;
            } else if (i != len) {
                    int tri = (((decode(s[i]) << 18) + (decode(s[i+1]) << 12)) + (decode(s[i+2]) << 6)) + decode(s[i+3]);
                    
                    os.WriteByte((byte)((tri >> 16) & 255));
                if (s[i+2] != '=') {
                    os.WriteByte((byte)((tri >> 8) & 255));
                    if (s[i+3] != '=') {
                        os.WriteByte((byte)(tri & 255));
                        i += 4;
                    } else {
                        return;
                    }
                }
                return;
            } else {
                return;
            }
        }
    }

    }
}
