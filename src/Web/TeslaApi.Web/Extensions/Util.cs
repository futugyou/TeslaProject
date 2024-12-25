namespace Extensions;

public static class Util
{
    public static T ConvertStringToType<T>(string data) where T : new()
    {
        T t = new();
        string[] parts = data.Split(',');
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            // Get the DataPosition attribute if it exists
            var attribute = property.GetCustomAttribute<DataPositionAttribute>();
            if (attribute != null)
            {
                int position = attribute.Position;

                // Convert the part at the given position to the property type and set the value
                if (position < parts.Length)
                {
                    object value = Convert.ChangeType(parts[position], property.PropertyType);
                    property.SetValue(t, value);
                }
            }
        }
        return t;
    }
}


[AttributeUsage(AttributeTargets.Property)]
public class DataPositionAttribute : Attribute
{
    public int Position { get; private set; }

    public DataPositionAttribute(int position)
    {
        Position = position;
    }
}