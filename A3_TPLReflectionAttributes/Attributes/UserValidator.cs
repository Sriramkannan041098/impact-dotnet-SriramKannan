using System.Reflection;

namespace A3_TPLReflectionAttributes.Attributes
{
    public class UserValidator
    {
        public void Validate(User user)
        {
            Type userType =  user.GetType();

            PropertyInfo[] properties =  userType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MaxLengthNoAttribute? attribute = property.GetCustomAttribute< MaxLengthNoAttribute >();

                if (attribute == null)
                {
                    continue;
                }

                object? propertyValue = property.GetValue(user);

                if (propertyValue is string value)
                {
                    if (value.Length > attribute.MaxLength)
                    {
                        Console.WriteLine( $"Warning       : Property '{property.Name}' exceeds maximum length of {attribute.MaxLength}.");
                        Console.WriteLine( $"Actual length : {value.Length}" );
                    }
                    else
                    {
                        Console.WriteLine($"Property '{property.Name}' is valid." );
                    }
                }
            }
        }
    }
}
