using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read;

internal class LikeConditionalOperatorBuilder : ConditionalOperatorBuilder
{
    private readonly bool _denial;

    public LikeConditionalOperatorBuilder( string value, bool denial = false )
        : base( ConditionalOperatorValue.Like, value )
    {
        _denial = denial;
    }

    public override ISqlScript Build()
    {
        var value = Value.ToString()
            .EscapeQuotation();

        return new SqlReadScript( $"{( _denial ? "not " : "" )}{ConditionalOperator} '{value}'" );
    }
}