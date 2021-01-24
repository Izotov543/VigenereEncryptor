using NUnit.Framework;

namespace VigenereEncryptor.Tests
{
    [TestFixture]
    public class DecryptStringMethodTests
    {
        [TestCase("¿Êìß", "key", "Test")]
        [TestCase("fed", "1", "543")]
        [TestCase("҆ҚҳѢ", "der Schlüssel", "Тест")]
        public void ReturnsDecryptedStringWhenParamsNotNullOrEmpty(
            string source,
            string key,
            string expectedResult)
        {
            //Arrange
            VigenereEncryptor encryptor = new VigenereEncryptor();

            //Act
            string actualResult = encryptor.DecryptString(source, key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}