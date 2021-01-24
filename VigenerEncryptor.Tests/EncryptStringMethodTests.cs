using NUnit.Framework;

namespace VigenereEncryptor.Tests
{
    [TestFixture]
    public class EncryptStringMethodTests
    {
        [TestCase("Source string", "")]
        [TestCase("Source string", null)]
        public void ReturnsSourceStringIfNullOrEmptyKey(string source, string key)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();

            //Act
            string result = encryptor.EncryptString(source, key);

            //Assert
            Assert.AreEqual(source, result);
        }


        [TestCase("", "key")]
        [TestCase(null, "key")]
        public void ReturnsEmptyStringIfNullOrEmptySource(string source, string key)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();

            //Act
            string result = encryptor.EncryptString(source, key);

            //Assert
            Assert.IsEmpty(result);
        }


        [TestCase("Test", "key", "¿Êìß")]
        [TestCase("543", "1", "fed")]
        [TestCase("Тест", "der Schlüssel", "҆ҚҳѢ")]
        public void ReturnsEncryptedStringWhenParamsNotNullOrEmpty(
            string source, 
            string key, 
            string expectedResult)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();

            //Act
            string actualResult = encryptor.EncryptString(source, key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}