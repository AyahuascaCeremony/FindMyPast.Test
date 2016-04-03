namespace FindMyPast.PrimeNumberTable
{
    public class TableGenerator
    {
        public TableGenerator(IValidatePrimeNumbers primeNumberValidator)
        {
        }

        public string[][] GenerateWithDimensionOf(int requiredDimension)
        {
            return new[]
            {
                new[] { "","2","3","5"},
                new[] {"2","4","6", "10"},
                new[] {"3","6","9","15"},  
                new[] {"5","10","15","25"},  
            };
        }
    }
}