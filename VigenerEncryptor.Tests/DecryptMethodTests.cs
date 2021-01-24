using NUnit.Framework;
using System.Collections.Generic;

namespace VigenereEncryptor.Tests
{
    [TestFixture]
    public class DecryptMethodTests
    {
        [TestCase(new string[] { "¿Êìß", "ÞÙëÔÓà" }, "key", new string[] { "Test", "string" })]
        [TestCase(new string[] { "fed", "fed" }, "1", new string[] { "543", "543" })]
        [TestCase(new string[] { "҆ҚҳѢґҕҘһ", "ҥҧҲўҍғ" }, "der Schlüssel", new string[] { "Тестовая", "строка" })]
        public void ReturnsIteratorOfDecryptedStringsWhenParamsNotNullOrEmpty(
            IEnumerable<string> source, 
            string key,
            IEnumerable<string> expectedResult)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();

            //Act
            IEnumerable<string> actualResult = encryptor.Decrypt(source, key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}