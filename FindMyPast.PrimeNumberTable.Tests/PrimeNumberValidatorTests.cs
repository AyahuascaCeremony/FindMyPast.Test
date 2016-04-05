using NUnit.Framework;

namespace FindMyPast.PrimeNumberTable.Tests
{
    [TestFixture]
    class PrimeNumberValidatorTests
    {
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(17)]
        [TestCase(19)]
        [TestCase(23)]
        [TestCase(379)]
        [TestCase(379)]
        public void TheseAreValidPrimeNumbers(int testValue)
        {
            var primeNumberValidator = new PrimeNumberValidator();

            Assert.True(primeNumberValidator.IsPrime(testValue));
        }
    }
}
