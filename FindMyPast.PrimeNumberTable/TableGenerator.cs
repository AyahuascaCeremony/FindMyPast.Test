using System.Collections;
using System.Collections.Generic;

namespace FindMyPast.PrimeNumberTable
{
    public class TableGenerator
    {
        private readonly IValidatePrimeNumbers _primeNumberValidator;

        public TableGenerator(IValidatePrimeNumbers primeNumberValidator)
        {
            _primeNumberValidator = primeNumberValidator;
        }

        public List<List<string>> GenerateWithDimensionOf(int requiredDimension)
        {
            var primeNumbersFound = GetPrimeNumbers(requiredDimension);

            var tableHeader = CreateTableHeader(primeNumbersFound);

            return new List<List<string>>
            {
                tableHeader,
                new List<string> {"2", "4", "6", "10"},
                new List<string> {"3", "6", "9", "15"},
                new List<string> {"5", "10", "15", "25"}
            };
        }

        private List<int> GetPrimeNumbers(int requiredDimension)
        {
            var primeNumbersCounter = 0;
            var primeNumbersFound = new List<int>();
            var counter = 2;
            while (primeNumbersCounter != requiredDimension)
            {
                if (_primeNumberValidator.IsPrime(counter))
                {
                    primeNumbersCounter++;
                    primeNumbersFound.Add(counter);
                }

                counter++;
            }
            return primeNumbersFound;
        }

        private static List<string> CreateTableHeader(List<int> primeNumbersFound)
        {
            var tableHeader = new List<string>();
            tableHeader.Add("");
            foreach (var primeNumber in primeNumbersFound)
            {
                tableHeader.Add(primeNumber.ToString());
            }
            return tableHeader;
        }
    }
}