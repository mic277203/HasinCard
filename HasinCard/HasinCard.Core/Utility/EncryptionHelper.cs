using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HasinCard.Core.Utility
{
    public class EncryptionMd5Helper
    {
        /// <summary>
        /// 获得一个字符串的加密密文
        /// 此密文为单向加密，即不可逆(解密)密文
        /// </summary>
        /// <param name="plainText">待加密明文</param>
        /// <returns>已加密密文</returns>
        public static string EncryptStringMD5(string plainText)
        {
            string encryptText = "";

            if (string.IsNullOrEmpty(plainText))
            {
                return encryptText;
            }

            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                return BitConverter.ToString(result).Replace("-", ""); ;
            }
        }
        /// <summary>
        /// 判断明文与密文是否相符
        /// </summary>
        /// <param name="plainText">待检查的明文</param>
        /// <param name="encryptText">待检查的密文</param>
        /// <returns>bool</returns>
        public static bool EqualEncryptString(string plainText, string encryptText)
        {
            return EqualEncryptStringMD5(plainText, encryptText);
        }

        /// <summary>
        /// 判断明文与密文是否相符
        /// </summary>
        /// <param name="plainText">待检查的明文</param>
        /// <param name="encryptText">待检查的密文</param>
        /// <returns>bool</returns>
        public static bool EqualEncryptStringMD5(string plainText, string encryptText)
        {
            bool result = false;
            if (string.IsNullOrEmpty(plainText) || string.IsNullOrEmpty(encryptText))
                return result;

            result = EncryptStringMD5(plainText).Equals(encryptText);
            return result;
        }
    }

    /// <summary>
    /// SHA1
    /// 单向加密
    /// </summary>
    public class EncryptionSHA1Helper
    {
        /// <summary>
        /// 获得一个字符串的加密密文
        /// 此密文为单向加密，即不可逆(解密)密文
        /// </summary>
        /// <param name="plainText">待加密明文</param>
        /// <returns>已加密密文</returns>
        public static string EncryptString(string plainText)
        {
            return EncryptStringSHA1(plainText);
        }
        /// <summary>
        /// 获得一个字符串的加密密文
        /// 此密文为单向加密，即不可逆(解密)密文
        /// </summary>
        /// <param name="plainText">待加密明文</param>
        /// <returns>已加密密文</returns>
        public static string EncryptStringSHA1(string plainText)
        {
            string encryptText = "";
            if (string.IsNullOrEmpty(plainText))
            {
                return encryptText;
            }

            using (var sha1 = SHA1.Create())
            {
                var result = sha1.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                return Encoding.UTF8.GetString(result);
            }
        }
        /// <summary>
        /// 判断明文与密文是否相符
        /// </summary>
        /// <param name="plainText">待检查的明文</param>
        /// <param name="encryptText">待检查的密文</param>
        /// <returns>bool</returns>
        public static bool EqualEncryptString(string plainText, string encryptText)
        {
            return EqualEncryptStringSHA1(plainText, encryptText);
        }
        /// <summary>
        /// 判断明文与密文是否相符
        /// </summary>
        /// <param name="plainText">待检查的明文</param>
        /// <param name="encryptText">待检查的密文</param>
        /// <returns>bool</returns>
        public static bool EqualEncryptStringSHA1(string plainText, string encryptText)
        {
            bool result = false;

            if (string.IsNullOrEmpty(plainText) || string.IsNullOrEmpty(encryptText))
            {
                return result;
            }

            result = EncryptStringSHA1(plainText).Equals(encryptText);

            return result;
        }
    }
    /// <summary>
    /// DES
    /// 双向，可解密
    /// </summary>
    public class EncryptionDESHelper
    {
        /// <summary>
        /// 获得一个字符串的加密密文        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <returns>密文字符串</returns>
        public static string EncryptStringReverse(string plainText)
        {
            return EncryptStringReverse(plainText, HasinCardConsts.EncryptKey);
        }

        /// <summary>
        /// 获得一个字符串的加密密文        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="key">加密/解密密钥</param>
        /// <returns>密文字符串</returns>
        public static string EncryptStringReverse(string plainText, string keyString)
        {
            string encryptText = "";

            if (string.IsNullOrEmpty(plainText))
            {
                return encryptText;
            }

            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        /// <summary>
        /// 对加密密文进行解密
        /// </summary>
        /// <param name="encryptText">待解密的密文</param>
        /// <returns>明文字符串</returns>
        public static string DecryptStringReverse(string encryptText)
        {
            return DecryptStringReverse(encryptText, HasinCardConsts.EncryptKey);
        }

        /// <summary>
        /// 对加密密文进行解密
        /// </summary>
        /// <param name="encryptText">待解密的密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文字符串</returns>
        public static string DecryptStringReverse(string encryptText, string keyString)
        {
            string result = "";

            if (string.IsNullOrEmpty(encryptText))
            {
                return result;
            }

            var fullCipher = Convert.FromBase64String(encryptText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }

        }
    }
}
