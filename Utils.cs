using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotepadSharp
{
    class Utils
    {
        /// <summary>
        /// Base64 编码
        /// </summary>
        /// <param name="encode">编码方式</param>
        /// <param name="source">要编码的字符串</param>
        /// <returns>返回编码后的字符串</returns>
        public static string EncodeBase64(string source, Encoding encode)
        {
            string result = "";
            byte[] bytes  = encode.GetBytes(source);
            try
            {
                result = Convert.ToBase64String(bytes);
            }
            catch
            {
                result = source;
            }

            return result;
        }


        /// <summary>
        /// Base64 解码
        /// </summary>
        /// <param name="encode">解码方式</param>
        /// <param name="source">要解码的字符串</param>
        /// <returns>返回解码后的字符串</returns>
        public static string DecodeBase64(string source, Encoding encode)
        {
            string result = "";
            try
            {
                byte[] bytes = Convert.FromBase64String(source);

                result = encode.GetString(bytes);
            }
            catch
            {
                result = source;
            }

            return result;
        }

        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="isLongType">是否为长格式</param>
        /// <returns>Unicode编码后的字符串</returns>
        internal static string String2Unicode(string source, Boolean isLongType)
        {
            var bytes         = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            if (isLongType)
            {
                stringBuilder.Append("\\u");
            }

            for (var i = 0; i < bytes.Length; i += 2)
            {
                if (isLongType)
                {
                    stringBuilder.AppendFormat("{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'),
                                               bytes[i].ToString("x").PadLeft(2, '0'));
                }
                else
                {
                    stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'),
                                               bytes[i].ToString("x").PadLeft(2, '0'));
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <param name="source">经过Unicode编码的字符串</param>
        /// <returns>正常字符串</returns>
        internal static string Unicode2String(string source)
        {
            try
            {
                if (source.StartsWith("\\u"))
                {
                    source = source.Replace("\\u", "");
                    return new Regex(@"([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(source,
                                                                                                                x =>
                                                                                                                    Convert
                                                                                                                        .ToChar(Convert
                                                                                                                                    .ToUInt16(x.Result("$1"),
                                                                                                                                              16))
                                                                                                                        .ToString());
                }
                else
                {
                    return source;
                }
            }
            catch
            {
                return source;
            }
        }
    }
}