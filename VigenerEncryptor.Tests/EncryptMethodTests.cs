using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VigenerEncryptor.Tests.Utils;

namespace VigenereEncryptor.Tests
{
    [TestFixture]
    public class EncryptMethodTests
    {
        [TestCase(new string[] { "Source", "string" }, "")]
        [TestCase(new string[] { "Source", "string" }, null)]
        public void ReturnsSourceIteratorIfNullOrEmptyKey(IEnumerable<string> source, string key)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();

            //Act
            IEnumerable<string> result = encryptor.Encrypt(source, key);

            //Assert
            Assert.AreEqual(source, result);
        }


        [TestCase(new string[] { }, "key")]
        [TestCase(null, "key")]
        public void ReturnsIteratorWhithEmptyStringIfNullOrEmptySource(
            IEnumerable<string> source, 
            string key)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();
            List<string> expectedResult = new List<string> { "" };

            //Act
            IEnumerable<string> actualResult = encryptor.Encrypt(source, key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCase(new string[] { "Test", "string" }, "key", new string[] { "¿Êìß", "ÞÙëÔÓà" })]
        [TestCase(new string[] { "543", "543" }, "1", new string[] { "fed", "fed" })]
        [TestCase(new string[] { "Тестовая", "строка" }, "der Schlüssel", new string[] { "҆ҚҳѢґҕҘһ", "ҥҧҲўҍғ" })]
        public void ReturnsIteratorOfEncryptedStringsWhenParamsNotNullOrEmpty(
            IEnumerable<string> source, 
            string key,
            IEnumerable<string> expectedResult)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();

            //Act
            IEnumerable<string> actualResult = encryptor.Encrypt(source, key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void EncrypteLimitedNumberOfElements()
        {
            //Arrange
            //limitOfElements should be the same as limitOfBufferLength in VigenereEncryptor.ModifyCollection method
            int limitOfElements = byte.MaxValue;
            VigenereEncryptor encryptor = new VigenereEncryptor();
            IEnumerable<string> source = TestListGenerator.GetList(limitOfElements + 1);

            //Act
            int actualResult = encryptor.Encrypt(source, "key").Count();

            //Assert
            Assert.AreEqual(limitOfElements, actualResult);
        }
    }
}