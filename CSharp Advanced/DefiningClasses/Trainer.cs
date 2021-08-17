using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public object StringBulder { get; private set; }

        public bool HavePokemonWithElement(string element)
        {
            for (int i = 0; i < this.Pokemons.Count; i++)
            {
                if (this.Pokemons[i].Element == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReduceHealthOfPokemons()
        {
            for (int i = 0; i < this.Pokemons.Count; i++)
            {
                Pokemons[i].Health -= 10;
                if (pokemons[i].Health <= 0)
                {
                    Pokemons.RemoveAt(i);
                    i--;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{this.Name} ");
            result.Append($"{this.Badges} ");
            result.Append($"{this.pokemons.Count}");

            return result.ToString();
        }
    }
}
