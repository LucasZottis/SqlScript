using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read;

public abstract class SqlFunctionBuilder : ISqlScriptBuilder
{
    protected const string FIELD_ARGUMENT = "fieldAlias";
    protected string[] Arguments { get; private set; }

    protected SqlFunctionBuilder( int argumentsLength )
    {
        Arguments = new string[ argumentsLength ];
    }

    protected abstract void ValidateArgument( string identifier, string value );

    protected string GetArgument( string argument )
    {
        if ( string.IsNullOrEmpty( argument ) )
            throw new ArgumentException( "Argument cannot be null." );

        var arg = Array.Find( Arguments, a => a?.StartsWith( argument, StringComparison.OrdinalIgnoreCase ) ?? false );

        if ( arg is null )
        {
            if ( argument == FIELD_ARGUMENT )
                return "";

            throw new ArgumentException( $"Argument '{argument}' is required." );
        }

        var parts = arg.Split( [ ':' ], 2, StringSplitOptions.RemoveEmptyEntries );

        if ( parts.Length != 2 )
            throw new ArgumentException( $"Argument '{argument}' is not in the correct format. Expected format: '{argument}:value'." );

        return parts[ 1 ].Trim();
    }

    internal void SetArgument( string identifier, string value )
    {
        ValidateArgument( identifier, value );

        for ( int i = 0; i < Arguments.Length; i++ )
        {
            if ( !string.IsNullOrEmpty( Arguments[ i ] ) )
                continue;

            Arguments[ i ] = $"{identifier}:{value}";
            break;
        }
    }

    internal void SetArguments( params string[] arguments )
    {
        if ( arguments.Length != Arguments.Length )
            throw new ArgumentException( $"IsNull function requires {Arguments.Length} arguments." );

        for ( int i = 0; i < Arguments.Length; i++ )
            Arguments[ i ] = arguments[ i ];
    }

    internal string GetFieldAlias()
    {
        return GetArgument( FIELD_ARGUMENT );
    }

    public abstract ISqlScript Build();
}