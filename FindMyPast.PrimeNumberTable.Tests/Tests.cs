using System.Linq;
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

            var resultTable = tableGenerator.GenerateWithDimensionOf(3);

            Assert.That(resultTable.Count, Is.EqualTo(4));
            Assert.That(resultTable[2][3], Is.EqualTo(15));
        }

        [TestCase(2,4,7)]
        [TestCase(3,5,9)]
        public void RowHeadersAndColumnsShouldBeValidated(int firstHeadingValue, int secondHeadingValue, int thirdHeadingValue)
        {
            var primeNumberValidator = new StubPrimeNumberValidator();
            primeNumberValidator.LoadWith(new[] {firstHeadingValue, secondHeadingValue, thirdHeadingValue}); // not actual prime numbers

            var tableGenerator = new TableGenerator(primeNumberValidator);

            var resultTable = tableGenerator.GenerateWithDimensionOf(3);

            Assert.That(resultTable[0][1], Is.EqualTo(firstHeadingValue));
            Assert.That(resultTable[0][2], Is.EqualTo(secondHeadingValue));
            Assert.That(resultTable[0][3], Is.EqualTo(thirdHeadingValue));

            Assert.That(resultTable[1][0], Is.EqualTo(firstHeadingValue));
            Assert.That(resultTable[2][0], Is.EqualTo(secondHeadingValue));
            Assert.That(resultTable[3][0], Is.EqualTo(thirdHeadingValue));
        }

        [Test]
        public void TableValuesShouldBeCorrect()
        {
            var primeNumberValidator = new StubPrimeNumberValidator();
            primeNumberValidator.LoadWith(new[] { 2, 4, 7 }); // not actual prime numbers

            var tableGenerator = new TableGenerator(primeNumberValidator);

            var resultTable = tableGenerator.GenerateWithDimensionOf(3);

            Assert.That(resultTable[1][1], Is.EqualTo(4));  // 2*2
            Assert.That(resultTable[1][2], Is.EqualTo(8));  // 2*4
            Assert.That(resultTable[1][3], Is.EqualTo(14)); // 2*7

            Assert.That(resultTable[2][1], Is.EqualTo(8));  // 4*2
            Assert.That(resultTable[2][2], Is.EqualTo(16)); // 4*4
            Assert.That(resultTable[2][3], Is.EqualTo(28)); // 4*7

            Assert.That(resultTable[3][1], Is.EqualTo(14)); // 7*2
            Assert.That(resultTable[3][2], Is.EqualTo(28)); // 7*4
            Assert.That(resultTable[3][3], Is.EqualTo(49)); // 7*7
        }
    }

    public class StubPrimeNumberValidator : IValidatePrimeNumbers
    {
        private int[] _stubbedValidValues;

        public void LoadWith(int[] stubbedValidValues)
        {
            _stubbedValidValues = stubbedValidValues;
        }

        public bool IsPrime(int input)
        {
            if (_stubbedValidValues.Contains(input))
            {
                return true;
            }
            return false;
        }
    }
}
