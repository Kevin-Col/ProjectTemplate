using Model.Emun;
using System.ComponentModel;
using System.Text;
using XSystem.Security.Cryptography;

namespace Common
{
    public static class CommonExten
    {
        public static string GetDesc(this ApiCode code)
        {
            var field = code.GetType().GetField(code.ToString());
            var objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs.Length == 0)
                return code.ToString();
            else
                return ((DescriptionAttribute)objs[0]).Description;
        }
        /// <summary>
        /// 用MD5加密字符串，可选择生成16位或者32位的加密字符串
        /// </summary>
        /// <param name="password">待加密的字符串</param>
        /// <param name="bit">位数，一般取值16 或 32</param>
        /// <returns>返回的加密后的字符串</returns>
        public static string MD5Encrypt(this string password, int bit = 32)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder tmp = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            if (bit == 16)
                return tmp.ToString().Substring(8, 16);
            else
            if (bit == 32) return tmp.ToString();//默认情况
            else return string.Empty;
        }
    }
}