namespace MyWebServer.Server.Common
{
    using System;
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value==null)
            {
                //if name is null > set ="Value"
                name ??= "Value";

                throw new ArgumentException($"{name} cannot be null.");
            }
        }
        
    }
}
