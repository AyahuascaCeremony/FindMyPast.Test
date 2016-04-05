using System.Collections;
using System.Collections.Generic;
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
            Assert.That(resultTable[2][3], Is.EqualTo("15"));
        }

        [TestCase(2,4,7)]
        [TestCase(3,5,9)]
        public void RowHeadersAndColumnsShouldBeValidated(int firstHeadingValue, int secondHeadingValue, int thirdHeadingValue)
        {
            var primeNumberValidator = new StubPrimeNumberValidator();
            primeNumberValidator.LoadWith(new[] {firstHeadingValue, secondHeadingValue, thirdHeadingValue}); // not actual prime numbers

            var tableGenerator = new TableGenerator(primeNumberValidator);

            var resultTable = tableGenerator.GenerateWithDimensionOf(3);

            Assert.That(resultTable[0][1], Is.EqualTo(firstHeadingValue.ToString()));
            Assert.That(resultTable[0][2], Is.EqualTo(secondHeadingValue.ToString()));
            Assert.That(resultTable[0][3], Is.EqualTo(thirdHeadingValue.ToString()));

            Assert.That(resultTable[1][0], Is.EqualTo(firstHeadingValue.ToString()));
            Assert.That(resultTable[2][0], Is.EqualTo(secondHeadingValue.ToString()));
            Assert.That(resultTable[3][0], Is.EqualTo(thirdHeadingValue.ToString()));
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
