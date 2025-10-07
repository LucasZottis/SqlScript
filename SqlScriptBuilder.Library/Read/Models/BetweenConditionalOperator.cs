namespace SqlScriptBuilder.Library.Read.Models;

internal class BetweenConditionalOperator : ConditionalOperator
{
    private object _lastValue;

    public BetweenConditionalOperator( object firstValue, object lastValue ) 
        : base( ConditionalOperatorValue.Between, firstValue )
    {
        _lastValue = lastValue;
    }

    public override string ToString()
    {
        return $"{Operator} {SqlValueFormatter.Format( Value )} AND {SqlValueFormatter.Format( _lastValue )}";
    }
}