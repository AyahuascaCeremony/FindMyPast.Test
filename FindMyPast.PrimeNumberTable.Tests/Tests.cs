using NUnit.Framework;

namespace FindMyPast.PrimeNumberTable.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GettingStartedWithExampleProvided()
        {
            var primeNumberValidator = new StubPrimeNumberValidator();
            primeNumberValidator.LoadWith(new[] {2, 3, 5});

            var tableGenerator = new TableGenerator(primeNumberValidator);

            string[][] resultTable = tableGenerator.GenerateWithDimensionOf(3);

            Assert.That(resultTable.Length, Is.EqualTo(4));
            Assert.That(resultTable[2][3], Is.EqualTo("15"));
        }
    }

    public class StubPrimeNumberValidator : IValidatePrimeNumbers
    {
        private int[] _stubbedValidValues;

        public void LoadWith(int[] stubbedValidValues)
        {
            _stubbedValidValues = stubbedValidValues;
        }
    }
}
