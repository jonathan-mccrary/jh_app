namespace jh_app.Domain.Extensions
{
    /*
     * https://stackoverflow.com/questions/37305985/enum-description-attribute-in-dotnet-core
     */
    public static class EnumerationExtension
    {
        public static string Description(this Enum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field?.GetCustomAttributes(false);

            // Description is in a hidden Attribute class called DisplayAttribute
            // Not to be confused with DisplayNameAttribute
            dynamic? displayAttribute = null;

            if (attributes?.Any() ?? false)
            {
                displayAttribute = attributes.ElementAt(0);
            }

            // return description
            return displayAttribute?.Description ?? "Description Not Found";
        }
    }
}

