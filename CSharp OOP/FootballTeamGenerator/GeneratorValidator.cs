using System;

namespace FootballTeamGenerator
{
    public static class GeneratorValidator
    {
        private static int MIN_STAT_VALUE = 0;
        private static int MAX_STAT_VALUE = 100;

        public static int ValidateStat(int stat, string statName)
        {
            if (stat < MIN_STAT_VALUE || stat > MAX_STAT_VALUE)
            {
                throw new ArgumentException(String.Format(GlobalExceptionMessages.invalidStat, statName));
            }

            return stat;
        }

        public static string ValidateName(string name)
        {

            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(GlobalExceptionMessages.invalidName);
            }

            return name;
        }
    }
}
