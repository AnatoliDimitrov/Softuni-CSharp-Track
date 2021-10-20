using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdoNetExercise
{
    class StartUp
    {
        static async Task Main()
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.connectionString);
            await connection.OpenAsync();

            //await using (connection)
            //{
            //    await VillainsNamesWithMinionsAsync(connection);
            //}

            //await using (connection)
            //{
            //    Console.WriteLine("Enter ID");
            //    var id = int.Parse(Console.ReadLine());
            //    await MinionsNamesAsync(connection, id);
            //}

            //await using (connection)
            //{
            //    var minionInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    var minionName = minionInfo[1];
            //    var minionAge = int.Parse(minionInfo[2]);
            //    var minionCity = minionInfo[3];

            //    var villainName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

            //    await AddMinion(connection, minionName, minionAge, minionCity, villainName);

            //    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            //}

            //await using (connection)
            //{
            //    var countryName = Console.ReadLine();
            //    await ChangeTownsNamesAsync(connection, countryName);
            //}

            await using (connection)
            {
                var villainId = int.Parse(Console.ReadLine());
                await DeleteVillain(connection, villainId);
            }
        }

        //TASK 02.
        private static async Task VillainsNamesWithMinionsAsync(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(Queries.villainsWithMinions, connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            await using (reader)
            {

                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]}");
                }
            }

        }

        //TASK 03.
        private static async Task MinionsNamesAsync(SqlConnection connection, int id)
        {
            SqlCommand command = new SqlCommand(Queries.villianName, connection);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            await using (reader)
            {
                var exist = await reader.ReadAsync();

                if (!exist)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Villain: {reader[0]}");
                }
            }

            command = new SqlCommand(Queries.minionsWithNames, connection);
            command.Parameters.AddWithValue("id", id);
            reader = await command.ExecuteReaderAsync();

            await using (reader)
            {
                var minionsExists = await reader.ReadAsync();
                if (!minionsExists)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");

                    while (await reader.ReadAsync())
                    {
                        Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                    }
                }
            }
        }

        //TASK 04.
        private static async Task AddMinion(SqlConnection connection, string minionName, int minionAge, string minionCity, string villainName)
        {
            SqlCommand command = new SqlCommand(Queries.findTown, connection);
            command.Parameters.AddWithValue("townName", minionCity);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            var townId = 0;

            var townExist = false;

            await using (reader)
            {
                townExist = await reader.ReadAsync();
            }

            if (!townExist)
            {
                command = new SqlCommand(Queries.insertTown, connection);
                command.Parameters.AddWithValue("townName", minionCity);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Town {minionCity} was added to the database.");
            }

            command = new SqlCommand(Queries.findTown, connection);
            command.Parameters.AddWithValue("townName", minionCity);
            reader = await command.ExecuteReaderAsync();

            await using (reader)
            {
                await reader.ReadAsync();
                townId = (int) reader[0];
            }

            command = new SqlCommand(Queries.findVillain, connection);
            command.Parameters.AddWithValue("Name", villainName);
            reader = await command.ExecuteReaderAsync();

            var villainExist = false;

            await using (reader)
            {
                villainExist = await reader.ReadAsync();

            }

            if (!villainExist)
            {
                command = new SqlCommand(Queries.insertVillain, connection);
                command.Parameters.AddWithValue("villainName", villainName);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            command = new SqlCommand(Queries.insertMinion, connection);
            command.Parameters.AddWithValue("nam", minionName);
            command.Parameters.AddWithValue("age", minionAge);
            command.Parameters.AddWithValue("townId", townId);
            await command.ExecuteNonQueryAsync();

            var villainId = 0;

            command = new SqlCommand(Queries.findVillain, connection);
            command.Parameters.AddWithValue("Name", villainName);
            reader = await command.ExecuteReaderAsync();

            await using (reader)
            {

                await reader.ReadAsync();
                villainId = (int)reader[0];
            }

            var minionId = 0;

            command = new SqlCommand(Queries.findMinion, connection);
            command.Parameters.AddWithValue("Name", minionName);
            reader = await command.ExecuteReaderAsync();

            await using (reader)
            {
                await reader.ReadAsync();
                minionId = (int)reader[0];
            }

            command = new SqlCommand(Queries.insertIntoMinionsVillains, connection);
            command.Parameters.AddWithValue("minionId", minionId);
            command.Parameters.AddWithValue("villainId", villainId);
            await command.ExecuteNonQueryAsync();
        }

        //TASK 05.
        private static async Task ChangeTownsNamesAsync(SqlConnection connection, string country)
        {
            SqlCommand command = new SqlCommand(Queries.updateTownsNames, connection);
            command.Parameters.AddWithValue("countryName", country);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            var towns = new List<string>();

            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                command = new SqlCommand(Queries.getTownsByCountry, connection);
                command.Parameters.AddWithValue("countryName", country);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    towns.Add((string)reader[0]);
                }
                Console.WriteLine($"{rowsAffected} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", towns)}]");
            } 
        }

        //TASK 06*.
        private static async Task DeleteVillain(SqlConnection connection, int villainId)
        {
            var name = "";
            var command = new SqlCommand(Queries.findVillainById, connection);
            command.Parameters.AddWithValue("villainId", villainId);
            var reader = await command.ExecuteReaderAsync();

            await using (reader)
            {
                var exists = await reader.ReadAsync();
                if (!exists)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }
                name = (string)reader[0];
            }

            command = new SqlCommand(Queries.releaseMinions, connection);
            command.Parameters.AddWithValue("villainId", villainId);
            var rowsAffected = await command.ExecuteNonQueryAsync();

            command = new SqlCommand(Queries.deleteVillain, connection);
            command.Parameters.AddWithValue("villainId", villainId);
            await command.ExecuteNonQueryAsync();

            Console.WriteLine($"{name} was deleted.");
            Console.WriteLine($"{rowsAffected} minions were released.");
        }

        //TASK 07.
    }
}
