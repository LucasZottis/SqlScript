namespace SqlScriptBuilder.Library;

internal static class SqlValueFormatter
{
    public static string Format( object? value )
    {
        return value switch
        {
            string str => $"'{str.Replace( "'", "''" )}'", // Escape single quotes in strings
            DateTime dateTime => $"'{dateTime:yyyy-MM-dd HH:mm:ss}'", // Format DateTime
            bool boolean => boolean ? "1" : "0", // Convert bool to 1 or 0
            double d => d.ToString( System.Globalization.CultureInfo.InvariantCulture ), // Ensure dot as decimal separator
            decimal dec => dec.ToString( System.Globalization.CultureInfo.InvariantCulture ), // Ensure dot as decimal separator
            null => "NULL", // Handle null values
            _ => value.ToString() ?? "" // Default case for other types
        };
    }
}