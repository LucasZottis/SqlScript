using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read;

internal class InConditionalOperatorBuilder : ConditionalOperatorBuilder
{
    private readonly bool _denial;

    public InConditionalOperatorBuilder( object value, bool denial = false )
        : base( ConditionalOperatorValue.In, value )
    {
        _denial = denial;
    }

    public InConditionalOperatorBuilder( IEnumerable<object> values, bool denial = false )
        : base( ConditionalOperatorValue.In, values )
    {
        _denial = denial;
    }

    public InConditionalOperatorBuilder( IEnumerable<int> values, bool denial = false )
        : base( ConditionalOperatorValue.In, values )
    {
        _denial = denial;
    }

    public InConditionalOperatorBuilder( IEnumerable<double> values, bool denial = false )
        : base( ConditionalOperatorValue.In, values )
    {
        _denial = denial;
    }

    public InConditionalOperatorBuilder( IEnumerable<decimal> values, bool denial = false )
        : base( ConditionalOperatorValue.In, values )
    {
        _denial = denial;
    }

    public InConditionalOperatorBuilder( IEnumerable<string> values, bool denial = false )
        : base( ConditionalOperatorValue.In, values )
    {
        _denial = denial;
    }

    public override ISqlScript Build()
    {
        var values = Value as IEnumerable<object>;

        if ( values is null || !values.Any() )
            throw new ArgumentException( "Values cannot be null or empty." );

        var formattedValues = string.Join( ", ", values.Select( SqlValueFormatter.Format ) );
        var denialText = _denial ? "NOT " : "";

        return new SqlReadScript( $"{denialText}{ConditionalOperator} ({formattedValues})" );
    }
}