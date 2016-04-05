using System;
using System.Collections;
using System.Collections.Generic;

namespace FindMyPast.PrimeNumberTable
{
    public class TableGenerator
    {
        private const int TOP_LEFT_CORNER = 0;
        private readonly IValidatePrimeNumbers _primeNumberValidator;
        private List<int> _primeNumbers;

        public TableGenerator(IValidatePrimeNumbers primeNumberValidator)
        {
            _primeNumberValidator = primeNumberValidator;
        }

        public List<List<int>> GenerateWithDimensionOf(int requiredDimension)
        {
            _primeNumbers = GetPrimeNumbers(requiredDimension);

            var tableHeader = CreateTableHeader(_primeNumbers);

            var table = new List<List<int>>
            {
                tableHeader
            };

            for (var i = 0; i < requiredDimension; i++)
            {
                table.Add(CreateTableRow(i));
            }

            return table;
        }

        private List<int> CreateTableRow(int rowIndex)
        {
            var tableRow = new List<int>();

            var rowValue = _primeNumbers[rowIndex];
            tableRow.Add(rowValue);

            foreach (var primeNumber in _primeNumbers)
            {
                tableRow.Add(rowValue * primeNumber);
            }
            return tableRow;
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

        private static List<int> CreateTableHeader(List<int> primeNumbersFound)
        {
            var tableHeader = new List<int>();
            tableHeader.Add(TOP_LEFT_CORNER);
            foreach (var primeNumber in primeNumbersFound)
            {
                tableHeader.Add(primeNumber);
            }
            return tableHeader;
        }
    }
}