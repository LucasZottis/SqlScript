using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Models;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class IsNullBuilder : SqlFunctionBuilder
{
    public IsNullBuilder( int argumentsLength ) : base( argumentsLength ) { }

    protected override void ValidateArgument( string identifier, string value )
    {
        if ( string.IsNullOrEmpty( identifier ) )
            throw new ArgumentException( "Argument cannot be null." );

        if ( identifier != "checkExpression" && identifier != "replacementValue" && identifier != FIELD_ARGUMENT )
            throw new ArgumentException( $"Argument '{identifier}' is not recognized." );

        if ( string.IsNullOrEmpty( value ) )
            throw new ArgumentException( $"The argument value of '{identifier}' cannot be null or empty." );
    }

    public override ISqlScript Build()
    {
        //var checkExpression = GetArgument( "checkExpression" );
        //var replacementValue = GetArgument( "replacementValue");
        //var fieldAlias = GetFieldAlias();

        //var script = new StringBuilder()
        //    .Append( $"isnull( {checkExpression}, {replacementValue} ) AS {fieldAlias}" );

        //return new SqlReadScript( script );

        return new IsNullFunction()
        {
            CheckExpression = GetArgument( "checkExpression" ),
            ReplacementValue = GetArgument( "replacementValue" ),
            Alias = GetFieldAlias()
        };
    }
}