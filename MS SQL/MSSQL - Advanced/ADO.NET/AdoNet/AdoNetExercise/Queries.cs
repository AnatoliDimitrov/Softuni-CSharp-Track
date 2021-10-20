using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetExercise
{
    public static class Queries
    {
        public const string villainsWithMinions = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                 FROM Villains AS v 
                                                 JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                GROUP BY v.Id, v.Name 
                                               HAVING COUNT(mv.VillainId) > 3 
                                                ORDER BY COUNT(mv.VillainId)";

        public const string minionsWithNames = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                        m.Name, 
                                                        m.Age
                                                   FROM MinionsVillains AS mv
                                                   JOIN Minions As m ON mv.MinionId = m.Id
                                                  WHERE mv.VillainId = @Id
                                               ORDER BY m.Name";

        public const string villianName = @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string findTown = @"SELECT Id FROM Towns WHERE Name = @townName";

        public const string insertTown = @"INSERT INTO Towns (Name) VALUES (@townName)";

        public const string findVillain = @"SELECT Id FROM Villains WHERE Name = @Name";

        public const string insertVillain = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string findMinion = @"SELECT Id FROM Minions WHERE Name = @Name";

        public const string insertMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";

        public const string insertIntoMinionsVillains = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public const string updateTownsNames = @"UPDATE Towns
                                                    SET Name = UPPER(Name)
                                                  WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string getTownsByCountry = @" SELECT t.Name 
                                                     FROM Towns as t
                                                     JOIN Countries AS c ON c.Id = t.CountryCode
                                                    WHERE c.Name = @countryName";

        public const string findVillainById = @"SELECT Name FROM Villains WHERE Id = @villainId";

        public const string releaseMinions = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

        public const string deleteVillain = @"DELETE FROM Villains WHERE Id = @villainId";
    }
}
