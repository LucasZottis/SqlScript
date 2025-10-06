using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read;

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
        var values = Value as IEnumerable<TValue>;

        if ( values is null || !values.Any() )
            throw new ArgumentException( "Values cannot be null or empty." );

        var formattedValues = string.Join( ", ", values.Select( v => SqlValueFormatter.Format(v) ) );
        var denialText = _denial ? "NOT " : "";

        return new SqlReadScript( $"{denialText}{ConditionalOperator} ({formattedValues})" );
    }
}