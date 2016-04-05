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

            var table = new List<List<string>>
            {
                tableHeader
            };

            for (var i = 1; i <= requiredDimension; i++)
            {
                table.Add(new List<string> {tableHeader[i]});
            }

            return table;
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