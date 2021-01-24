using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VigenereEncryptor
{
#nullable enable
    public sealed class VigenereEncryptor
    {
        /// <summary>
        /// <para>Returns <seealso cref="IEnumerable{T}"/> iterator 
        /// of encrypted <see cref="string"/>s from <paramref name="source"/> iterator</para>
        /// <para>For Encryption/Decryption uses <paramref name="key"></paramref></para>
        /// </summary>
        public IEnumerable<string> Encrypt(IEnumerable<string>? source, string? key)
        {
            return ModifyCollection(source, key, EncryptionModificationMethod.Encrypt);
        }


        /// <summary>
        /// <para>Returns <seealso cref="IEnumerable{T}"/> iterator
        /// of decrypted <see cref="string"/>s from <paramref name="source"/> iterator</para>
        /// <para>For Encryption/Decryption uses <paramref name="key"></paramref></para>
        /// </summary>
        public IEnumerable<string> Decrypt(IEnumerable<string>? source, string? key)
        {
            return ModifyCollection(source, key, EncryptionModificationMethod.Decrypt);
        }


        /// <summary>
        /// Returns encrypted <see cref="string"/> <paramref name="source"/>
        /// </summary>
        public string EncryptString(string? source, string? key)
        {
            return ModifyString(source, key, EncryptionModificationMethod.Encrypt);
        }


        /// <summary>
        /// Returns decrypted <see cref="string"/> <paramref name="source"/>
        /// </summary>
        public string DecryptString(string? encrypted, string? key)
        {
            return ModifyString(encrypted, key, EncryptionModificationMethod.Decrypt);
        }


        /// <summary>
        /// <para>Modifies <paramref name="source"/> iterator according to 
        /// <paramref name="modificationMethod"/>.
        /// For Encryption/Decryption uses <paramref name="key"></paramref>.</para>
        /// <para>Modifies only first <seealso cref="byte.MaxValue"/> elements</para>
        /// </summary>
        /// <exception cref="ArgumentException"/>
        private IEnumerable<string> ModifyCollection(
            IEnumerable<string>? source,
            string? key,
            EncryptionModificationMethod modificationMethod)
        {
            if (source == null || source.Count() == 0)
            {
                yield return "";
            }

            else
            {
                int limitOfBufferLength = byte.MaxValue;
                var bufferSource = source.Take(limitOfBufferLength);
                foreach (string str in bufferSource)
                    yield return ModifyString(str, key, modificationMethod);
            }
        }


        /// <summary>
        /// <para>Modifies <paramref name="source"/> according to 
        /// <paramref name="modificationMethod"/>.
        /// For Encryption/Decryption uses <paramref name="key"></paramref></para>
        /// </summary>
        /// <exception cref="ArgumentException"/>
        private string ModifyString(
            string? source,
            string? key,
            EncryptionModificationMethod modificationMethod)
        {
            VerifyModificationMethod(modificationMethod);

            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(key))
            {
                return source ?? "";
            }

            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                ushort sourceCharCode = Convert.ToUInt16(source[i]);
                ushort keyCharCode = Convert.ToUInt16(key[i % key.Length]);
                ushort resultCharCode;
                if (modificationMethod == EncryptionModificationMethod.Encrypt)
                {
                    resultCharCode = (ushort)unchecked(sourceCharCode + keyCharCode);
                }

                else
                {
                    resultCharCode = (ushort)unchecked(sourceCharCode - keyCharCode);
                }

                char resultCharacter = Convert.ToChar(resultCharCode);
                resultString.Append(resultCharacter);
            }

            return resultString.ToString();
        }


        /// <summary>
        /// Verifies if <paramref name="modificationMethod"/> parameter is correct
        /// </summary>
        private void VerifyModificationMethod(EncryptionModificationMethod modificationMethod)
        {
            if (modificationMethod != EncryptionModificationMethod.Encrypt
                && modificationMethod != EncryptionModificationMethod.Decrypt)
            {
                throw new ArgumentException(
                    "modifictionMethod parameter should be " +
                    $"\"Encrypt\" or \"Decrypt\"");
            }
        }
    }
}
