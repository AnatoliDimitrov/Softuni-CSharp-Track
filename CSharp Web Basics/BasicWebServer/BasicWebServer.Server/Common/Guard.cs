namespace BasicWebServer.Server.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "value";

                throw new ArgumentNullException($"{name} cannot be null");
            }
        }
    }
}
