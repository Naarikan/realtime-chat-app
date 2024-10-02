using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using RealTimeChatApp.Application.Model;

namespace RealTimeChatApp.Application.Encryption
{
    public class InviteCodeManager
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("FB4631CA-7C82-4EC5-8875-0CE06BFB"); // 32 byte key
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("CDCAF198-513D-41"); // 16 byte IV

        public string CreateInviteCode(Guid groupId)
        {
            var plainCode = $"{groupId}:{DateTime.UtcNow.Ticks}";
            var encryptedCode = Encrypt(plainCode);

            return encryptedCode;
        }

        public DecryptedInviteCode DecryptInviteCode(string encryptedCode)
        {
            var plainText = Decrypt(encryptedCode);
            var parts = plainText.Split(':');
            if (parts.Length != 2)
                throw new InvalidOperationException("Decrypted invite code is in an invalid format.");

            var groupId = parts[0];
            if (!Guid.TryParse(groupId, out var parsedGroupId))
                throw new InvalidOperationException("GroupId is not in the correct format.");

            return new DecryptedInviteCode
            {
                GroupId = parsedGroupId
            };
        }

        private string Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] cipherTextBytes;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cs.FlushFinalBlock();
                        cipherTextBytes = ms.ToArray();
                    }
                }

                return Convert.ToBase64String(cipherTextBytes);
            }
        }

        private string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);

            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(cipherTextBytes))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
