using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public static class GlobalExceptionsMessages
    {
        public static string invalidFlourType = "Invalid type of dough.";

        public static string InvalidDoughWeight = "Dough weight should be in the range [1..200].";

        public static string invalidToppingWeight = "{0} weight should be in the range [1..50].";

        public static string invalidToppingType = "Cannot place {0} on top of your pizza.";

        public static string invalidPizzaName = "Pizza name should be between 1 and 15 symbols.";

        public static string invalidCountOfToppings = "Number of toppings should be in range [0..10].";
    }
}
