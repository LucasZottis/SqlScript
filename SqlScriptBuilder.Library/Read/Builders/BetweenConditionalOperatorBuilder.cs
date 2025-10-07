using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class BetweenConditionalOperatorBuilder : ConditionalOperatorBuilder
{
    private readonly object _lastValue;

    public BetweenConditionalOperatorBuilder( object firstValue, object lastValue )
        : base( ConditionalOperatorValue.Between, firstValue )
    {
        _lastValue = lastValue ?? throw new ArgumentNullException( nameof( lastValue ) );
    }

    public override ISqlScript Build()
    {
        return new BetweenConditionalOperator(Value, _lastValue);
    }
}