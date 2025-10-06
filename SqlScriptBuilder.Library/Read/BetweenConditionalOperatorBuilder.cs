using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read;

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
        return new SqlReadScript( $"{ConditionalOperator} {SqlValueFormatter.Format( Value )} AND {SqlValueFormatter.Format( _lastValue )}" );
    }
}