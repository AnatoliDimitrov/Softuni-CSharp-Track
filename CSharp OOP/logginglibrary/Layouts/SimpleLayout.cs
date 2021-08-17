namespace logginglibrary.Layouts
{
    class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {

        }
        public string Format => "{0} - {1} - {2}";
    }
}
