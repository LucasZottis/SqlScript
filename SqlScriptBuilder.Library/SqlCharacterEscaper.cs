namespace SqlScriptBuilder.Library
{
    internal static class SqlCharacterEscaper
    {
        public static string EscapeQuotation( this string value )
        {
            if ( string.IsNullOrEmpty( value ) )
                return value;

            return value.Replace( "'", "''" );
        }
    }
}