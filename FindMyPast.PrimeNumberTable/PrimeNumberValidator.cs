namespace FindMyPast.PrimeNumberTable
{
    public class PrimeNumberValidator : IValidatePrimeNumbers
    {
        public bool IsPrime(int input)
        {
            for (var i = 2; i < input; i++)
            {
                var divisionRemainder = input%i;
                if (divisionRemainder == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}