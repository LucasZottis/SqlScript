namespace SqlScriptBuilder.Library.Read;

public static class ConditionalOperatorBuilderFactory
{
    public static ConditionalOperatorBuilder GreaterThan( object value )
        => new ConditionalOperatorBuilder( ConditionalOperatorValue.GreaterThan, value );

    public static ConditionalOperatorBuilder GreaterOrEqualThan( object value )
        => new ConditionalOperatorBuilder( ConditionalOperatorValue.GreaterOrEqualThan, value );

    public static ConditionalOperatorBuilder Equal( object value )
        => new ConditionalOperatorBuilder( ConditionalOperatorValue.Equal, value );

    public static ConditionalOperatorBuilder LessOrEqualThan( object value )
        => new ConditionalOperatorBuilder( ConditionalOperatorValue.LessOrEqualThan, value );

    public static ConditionalOperatorBuilder LessThan( object value )
        => new ConditionalOperatorBuilder( ConditionalOperatorValue.LessThan, value );

    public static ConditionalOperatorBuilder Different( object value )
        => new ConditionalOperatorBuilder( ConditionalOperatorValue.Different, value );

    public static ConditionalOperatorBuilder Like( string value )
        => new LikeConditionalOperatorBuilder( value );

    public static ConditionalOperatorBuilder NotLike( string value )
        => new LikeConditionalOperatorBuilder( value, true );

    public static ConditionalOperatorBuilder In( object values )
        => new InConditionalOperatorBuilder( values );

    public static ConditionalOperatorBuilder In( IEnumerable<object> values )
        => new InConditionalOperatorBuilder( values );

    public static ConditionalOperatorBuilder In( IEnumerable<int> values )
        => new InConditionalOperatorBuilder( values );

    public static ConditionalOperatorBuilder In( IEnumerable<double> values )
        => new InConditionalOperatorBuilder( values );

    public static ConditionalOperatorBuilder In( IEnumerable<decimal> values )
        => new InConditionalOperatorBuilder( values );

    public static ConditionalOperatorBuilder In( IEnumerable<string> values )
        => new InConditionalOperatorBuilder( values );

    public static ConditionalOperatorBuilder NotIn( object values )
        => new InConditionalOperatorBuilder( values, true );

    public static ConditionalOperatorBuilder NotIn( IEnumerable<object> values )
        => new InConditionalOperatorBuilder( values, true );

    public static ConditionalOperatorBuilder NotIn( IEnumerable<int> values )
        => new InConditionalOperatorBuilder( values, true );

    public static ConditionalOperatorBuilder NotIn( IEnumerable<double> values )
        => new InConditionalOperatorBuilder( values, true );

    public static ConditionalOperatorBuilder NotIn( IEnumerable<decimal> values )
        => new InConditionalOperatorBuilder( values, true );

    public static ConditionalOperatorBuilder NotIn( IEnumerable<string> values )
        => new InConditionalOperatorBuilder( values, true );

    //public static ConditionalOperatorBuilder Is( object? value )
    //    => new IsConditionalOperatorBuilder( value );

    public static ConditionalOperatorBuilder Between( object firstValue, object lastValue )
        => new BetweenConditionalOperatorBuilder( firstValue, lastValue );
}