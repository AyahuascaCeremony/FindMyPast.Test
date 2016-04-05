using System;
using System.Collections;
using System.Collections.Generic;

namespace FindMyPast.PrimeNumberTable
{
    public class TableGenerator
    {
        private const int TOP_LEFT_CORNER = 0;
        private readonly IValidatePrimeNumbers _primeNumberValidator;

        public TableGenerator(IValidatePrimeNumbers primeNumberValidator)
        {
            _primeNumberValidator = primeNumberValidator;
        }

        public List<List<int>> GenerateWithDimensionOf(int requiredDimension)
        {
            var primeNumbersFound = GetPrimeNumbers(requiredDimension);

            var tableHeader = CreateTableHeader(primeNumbersFound);

            var table = new List<List<int>>
            {
                tableHeader
            };

            for (var i = 1; i <= requiredDimension; i++)
            {
                var tableRow = new List<int>();
                var rowValue = tableHeader[i];

                foreach (var headerValue in tableHeader)
                {
                    if (headerValue == TOP_LEFT_CORNER)
                    {
                        tableRow.Add(rowValue);
                    }
                    else
                    {
                        var columnValue = headerValue;
                        tableRow.Add(rowValue*columnValue);
                    }
                }
                table.Add(tableRow);
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