namespace Prototype
{
    public class StartUp
    {
        static void Main()
        {
            SandwichMenu menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Beacon", "", "Lettuce, tomato" );
            menu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly" );
            menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato" );

            menu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Beacon", "American", "Lettuce, tomato, Onion, Olives");
            menu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            menu["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

            Sandwich sandwich = menu["BLT"].Clone() as Sandwich;
            Sandwich anotherSandwich = menu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich yetAnotherSandwich = menu["Vegetarian"].Clone() as Sandwich;
        }
    }
}
