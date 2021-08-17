namespace Snowballs
{
    using System;
    using System.Numerics;

    class SnowballsStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger winnerSnow = 0;
            BigInteger winnerTime = 0;
            BigInteger winnerValue = 0;
            BigInteger winnerquality = 0;

            for (int i = 0; i < n; i++)
            {
                BigInteger snowballSnow = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime = BigInteger.Parse(Console.ReadLine());
                int snowBallQuality = int.Parse(Console.ReadLine());

                BigInteger snowBallValue = (BigInteger)BigInteger.Pow(snowballSnow / snowballTime, snowBallQuality);

                if (snowBallValue >= (BigInteger)winnerValue)
                {
                    winnerValue = snowBallValue;
                    winnerSnow = snowballSnow;
                    winnerTime = snowballTime;
                    winnerquality = snowBallQuality;
                }
            }
            Console.WriteLine("{0} : {1} = {2} ({3})", winnerSnow, winnerTime, winnerValue, winnerquality);
        }
    }
}
