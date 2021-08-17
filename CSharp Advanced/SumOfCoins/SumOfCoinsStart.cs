using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        Array.Sort(availableCoins);

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var collectedCoins = new Dictionary<int, int>();

        int min = coins.Min();

        int index = coins.Count - 1;

        while (targetSum > 0)
        {
            if (min > targetSum)
            {
                return new Dictionary<int, int>(); ;
            }

            int coinsCount = 0;
            if (coins[index] > targetSum)
            {
                index--;
                continue;
            }
            else
            {
                coinsCount = targetSum / coins[index];
                targetSum = targetSum % coins[index];

                collectedCoins.Add(coins[index], coinsCount);
            }
        }
        return collectedCoins;
    }
}