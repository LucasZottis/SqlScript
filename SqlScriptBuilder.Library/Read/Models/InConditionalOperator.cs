namespace SqlScriptBuilder.Library.Read.Models;

internal class InConditionalOperator<TValue> : ConditionalOperator
{
    public bool Denial { private get; set; }

    public InConditionalOperator( object value )
        : base( ConditionalOperatorValue.In, value ) { }

    public InConditionalOperator( IEnumerable<TValue> values )
        : base( ConditionalOperatorValue.In, values ) { }

    public override string ToString()
    {
        var values = Value as IEnumerable<TValue>;

        if ( values is null || !values.Any() )
            throw new ArgumentException( "Values cannot be null or empty." );

        var formattedValues = string.Join( ", ", values.Select( v => SqlValueFormatter.Format( v ) ) );
        var denialText = Denial ? "NOT " : "";

        return $"{denialText}{Operator} ({formattedValues})";
    }
}