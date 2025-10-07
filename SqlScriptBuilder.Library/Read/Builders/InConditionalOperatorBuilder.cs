using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class InConditionalOperatorBuilder<TValue> : ConditionalOperatorBuilder
{
    private readonly bool _denial;

    public InConditionalOperatorBuilder( object value, bool denial = false )
        : base( ConditionalOperatorValue.In, value )
    {
        _denial = denial;
    }

    public InConditionalOperatorBuilder( IEnumerable<TValue> values, bool denial = false )
        : base( ConditionalOperatorValue.In, values )
    {
        _denial = denial;
    }

    public override ISqlScript Build()
    {
        return new InConditionalOperator<TValue>( Value )
        {
            Denial = _denial
        };
    }
}