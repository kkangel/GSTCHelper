using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTCHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (rtbOriginalBox.Text != null && rtbOriginalBox.Text != "")
            {
                byte[] bytEncode = Encoding.UTF8.GetBytes(rtbOriginalBox.Text);
                rtbFinallBox.Text = Cryptographic.encode(bytEncode);

            }
        }
        private static  String encoding = "utf-8";
        private static  String iv = "01234567";
        private static  String secretKey = "chinalife13nde3i!sfac43#";




        private string strTest = "%2FXP8SIaFmotAtC8wxdh7F%2FCSxNVTa8k7GhyOb7fS42YbySe%2FidGvC4%2Bi%2F0qH+mbQdJBqvgCgu3J8%2BhrmknullZkx8lTty%2FSDhHTRk9XVGGQCHgvzJnnljJJjT+GgriYQiXfj2PwMLvRwf0XFAEBozc7%2Bnteq5at9Uv8FdSMMN3oqlYJCrbn25L+6AZM1%2BgYbAi7TegKq22rPtStLFFlxRxg3kmCpsb9Vf9s5m2CuH3ZSpLGJYsN+4Cur2OOIZmu1Qk71ORDvucEzwTfB8aFnc7xOs3IFu02ERf%2F43o%2BA8d4p1Fso+wCBGgbWhpcy6kYEyA7CAqwfyGgnbhmPyA3cwrYfxXsgsSSSV%2FlLHkrE8mlqL+eJUExeCVpx%2FNlSyH2%2BjHopn0AbB%2F2pQsD9gSYKHL240tpkGnndpkuzvLlt%2Fe+yQ7DKi7xoD0CCCnQX7QZ960%2F0hXPqN5CwACqtPLEQ7113XnD%2FO4la4Nr%2F%2Fkb+ZO1PTB5kTWbE427WWKBuJ0CJ%2BQTKnoHhU%2BfTwtAmmQAcLy9%2BlDIg4P%2Fpun%2Bt+DGYSbp8nwIwkYGGcS0HmYjRXHlu3UIvWPQSXz%2FLBQ3eNtv4iAXJ7OiPvlFCn+xV3ak2sNJYkZ6WT8jyE6rjTb0uVf1YDfMzCh8zOIZZtl1gEikEeev8COanxM+cDfGzhHGjRiUAE2sV9ZE1%2FPAyaRAEtD1FF4RQ4%2B%2B4fODrFouiO79MrBHbgQ2+d2VqaUYonIRB0xJb5LOSg8Qq5hamO29kbcypLp%2B1AusgPv0l%2BPtnahQRYjmk+b8o6GGwOtb7ahg2gGHgHNjj7Hu0V8%2Fb8ot6rOmEJxTQ8bu8Q89Z1SybrbPSe+XqrKu%2Bnt6SdsWb1COaoKOhHafQcYMh3wLVwmvjWLfRVsNuP8StSpXz2405NE+6r94z8mFbZ1X3kSw1aDWnR%2BTOZaup84kgTf%2BeBMPQYFsVchwiNLD2w1qsacV+lnP6bdnEWBoMI9hnsuCxCHup%2B00ma%2BP5VJ5EsldgLjakfX1y%2FM9AXedL%2FKrF+Sg%2FTl%2BxaMEq58Tv%2BRj4KJWo%2Fw6Q5gXBStMswI%2BLrx1QqRBULa5qniKjCPPcU+GmZxI0GyJ928%2FsJu70meTpAbAAWECw11LCpgse1pp7A3cYfBW9bgnTozgDd%2F+bIkUDpNJv1ZlKOdPKYQy55KncdT%2B1KwV0newUVIKHJaplfXwboSEFhsEXHHm+fBEv8rwORCQW0VFhF2SGju2ACv%2Fv3bCtcTc1IVX9mTC7mg7B1MgHjb7frp1Z+9%2B%2BGxUdCMETVPmVOHgQheSF1TPC%2FCwoHLF3SfGA%2Br07ANEzGDkQJ91qWW7%2Bt+yM774IThme7qS%2BY6BTIac7G8Z6%2FD32qNtTirOuU9k7NWnY8%2FjY3OyqUECj51+uSGDlzwJ2EFTpu4%2Fbm4n%2FoHFDNi%2BKjXPmbrLbiWh4I6WZuRFVwMxoZE%2Foour+rQGkRsFDtzrEmrDHVIe4uIwOr5vdkRH1J%2BRmn6UHTft%2Bm%2FmwdRkXzeTg7xRw+DEPUxm0F0kL3yiLtgGwKMFNfFmXVpj1hZwaj32cx6K8tkieH26e8JT8WwKqJ+Xd70OcLX7rwYJMRtXjkzXTkwH1fbE6vzHg358MVW25pazFRKdWo3zSUr3PK9+yGcyGQb90fSEzoYLsQw07lo%2BBuQ1JUUCQP%2Bc%2F%2FqU9eQDzEhobMG3lcUB20fw+nq9IdOmUeQ24HVL6R%2FdZS9FtLTTdoSe1pdNY9Z40%2Bc5e83x3zc%2FdMWyMHe16+PL068N4DsSaM8XrK%2FRd7TLdYXz5JeuuK8mz2W9tdPHREqqqb3Lx5Y7EsKCSf+UmdZyVY%2B7GibvWVSb6o7jxUTqpPFvIj%2BEtoSpPz0MQGuiwMTEMlm8TzUx9tY+tL2ca%2BR8iLv2MwBQjcj80%2BXALUGhMQUSNvBTjCSWvUrvQFB%2FUCgNbQs2MEVq+GG4qRfEY0cxgwphskhTc%2Fx%2Fj60y1RXktk1HU1fFUdtWQvGq38aOa%2F2A9ViTc+KWMqC2V1Ph4ztkNSuIZ4ri7OZHLMtkyQxXtVO1ntcdCDHr2aJyxR74QUGMFh+E7GqyLMMToe83RrtxeNJYBoTgAJdfoO4EruZ1fD37nt66LC6wcjT%2BUxVmmF3+TWZebPBusLQTFWxM6u6B5f3xBbXbPfIGmaGdF3voAkVDspwqBiSZrOKIiHKY+zUzNHZhA3VASjW4BpnQ3bkbuJJl1h%2BVmj8gxirFEulwStpoZd6rYDKuTqdl4+ygqUALhZ%2FdhxZCEPj4sHaTTC%2Fz9gUoAcjk2RaZvtcfMk3H7SMnSTv16KN2NB+iXe%2FZK73Lyqh69eddqnx2b1hkuyZJe333STQuiC7uiQ190HHDWImoZCgq0m4+mU4RZCOPXk%2FUSGzigZJ84yRWQeoDCf%2FqrLOzj6v0TZhrqL%2FgcPodSg7Flab%2B+vIhDVvugrk8RB%2Fh6InTuWfFZrImvKEaW";

        private string strTest2 = "YWJjZGFiY2RhYmNkYWJjZGFiY2RhYmNkYWJjZGFiY2RhYmNkYWJjZA==";
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //if (rtbOriginalBox.Text != null && rtbOriginalBox.Text != "")
            // {
            string strEncode = System.Web.HttpUtility.UrlDecode(rtbOriginalBox.Text, Encoding.UTF8);
            //string strEncode = System.Web.HttpUtility.UrlDecode(strTest, Encoding.UTF8);
            byte[] bytFinalBytes = Cryptographic.decode(strEncode);
            //byte[] bytFinalBytes = Cryptographic.decode(rtbOriginalBox.Text);
            //rtbFinallBox.Text = Encoding.UTF8.GetString(bytFinalBytes);
            rtbFinallBox.Text = Convert.ToBase64String(bytFinalBytes);
            //rtbFinallBox.Text = System.Text.Encoding.ASCII.GetString(bytFinalBytes);
            // }
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
           //rtbFinallBox.Text= Encoding.UTF8.GetBytes(rtbOriginalBox.Text).ToString() ;
           string strExchange= System.Web.HttpUtility.UrlDecode(rtbOriginalBox.Text, Encoding.UTF8);
           byte[] bytFinalBytes = Cryptographic.decode(strExchange);
           string strDecodeMid= Encoding.UTF8.GetString(bytFinalBytes);
           string strDecode = Des3Tool.Des3DecodeCBC(secretKey, iv, strDecodeMid);
           rtbFinallBox.Text = strDecode;
        }

        private void btnDESEncode_Click(object sender, EventArgs e)
        {
            string strEncode = Des3Tool.Des3EncodeCBC(secretKey, iv, rtbOriginalBox.Text);
            rtbFinallBox.Text = strEncode;

        }

        private void btnDESDecode_Click(object sender, EventArgs e)
        {
            string strDecode = Des3Tool.Des3DecodeCBC(secretKey, iv, rtbOriginalBox.Text);
            rtbFinallBox.Text = strDecode;
        }
    }
}
