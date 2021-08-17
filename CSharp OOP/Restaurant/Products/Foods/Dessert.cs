﻿namespace Restaurant.Products.Foods
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public virtual double Calories { get; set; }
    }
}
