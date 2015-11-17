using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Web.Security;
namespace ZXL.Common
{
    /// <summary>
    /// 哈希算法
    /// </summary>
    public class HashAlgorithm
    {
        /// <summary>
        /// 计算 <paramref name="text"/> 的 MD5 值
        /// </summary>
        /// <param name="text">待计算文本</param>
        /// <returns><paramref name="text"/> 的 MD5 值</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="text"/> 为 null</exception>
        public static string MD5(string text)
        {
            return MD5(text, false);
        }

        /// <summary>
        /// 计算 <paramref name="text"/> 的 MD5 值
        /// </summary>
        /// <param name="text">待计算文本</param>
        /// <param name="isUpperCase">是否要输出为大写字母</param>
        /// <returns><paramref name="text"/> 的 MD5 值</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="text"/> 为 null</exception>
        public static string MD5(string text, bool isUpperCase)
        {
            return Hash(text, isUpperCase, FormsAuthPasswordFormat.MD5.ToString());
        }

        /// <summary>
        /// 计算 <paramref name="text"/> 的 SHA1 值
        /// </summary>
        /// <param name="text">待计算文本</param>
        /// <returns><paramref name="text"/> 的 SHA1 值</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="text"/> 为 null</exception>
        public static string SHA1(string text)
        {
            return SHA1(text, false);
        }

        /// <summary>
        /// 计算 <paramref name="text"/> 的 SHA1 值
        /// </summary>
        /// <param name="text">待计算文本</param>
        /// <param name="isUpperCase">是否要输出为大写字母</param>
        /// <returns><paramref name="text"/> 的 SHA1 值</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="text"/> 为 null</exception>
        public static string SHA1(string text, bool isUpperCase)
        {
            return Hash(text, isUpperCase, FormsAuthPasswordFormat.SHA1.ToString());
        }

        /// <summary>
        /// 计算 <paramref name="text"/> 的哈希值
        /// </summary>
        /// <param name="text">待计算文本</param>
        /// <param name="isUpperCase">是否要输出为大写字母</param>
        /// <param name="passwordFormat">计算使用的哈希算法</param>
        /// <returns><paramref name="text"/> 的哈希值</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="text"/> 为 null</exception>
        private static string Hash(string text, bool isUpperCase, string passwordFormat)
        {
            var hashString = FormsAuthentication.HashPasswordForStoringInConfigFile(text, passwordFormat);
            return isUpperCase ? hashString : hashString.ToLower();
        }
    }
}
