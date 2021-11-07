using System;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            FootballBettingContext context = new FootballBettingContext();
            context.Database.Migrate();
        }
    }
}
