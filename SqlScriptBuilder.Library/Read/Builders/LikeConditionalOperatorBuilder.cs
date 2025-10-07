using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

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

        return new LikeConditionalOperator( value )
        {
            Denial = _denial
        };
    }
}