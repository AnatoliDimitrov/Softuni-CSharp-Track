namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = "";

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputInfo[0];
                string pokemonName = inputInfo[1];
                string element = inputInfo[2];
                int health = int.Parse(inputInfo[3]);

                Pokemon currentPokemon = new Pokemon(pokemonName, element, health);

                Trainer currentTrainer = trainers
                    .Find(t => t.Name == trainerName);

                if (currentTrainer == null)
                {
                    trainers.Add(new Trainer(trainerName));
                    trainers[trainers.Count - 1].Pokemons.Add(currentPokemon);
                }
                else
                {
                    currentTrainer.Pokemons.Add(currentPokemon);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {

                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].HavePokemonWithElement(input))
                    {
                        trainers[i].Badges++;
                    }
                    else
                    {
                        trainers[i].ReduceHealthOfPokemons();
                    }
                }
            }

            trainers = trainers
                .OrderByDescending(t => t.Badges)
                .ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer);
            }
        }

        public static List<Person> Over30(List<Person> people)
        {
            return people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
