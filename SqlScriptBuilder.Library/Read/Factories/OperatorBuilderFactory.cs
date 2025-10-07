using SqlScriptBuilder.Library.Read.Builders;

namespace SqlScriptBuilder.Library.Read.Factories;

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
        => new InConditionalOperatorBuilder<object>( values );

    public static ConditionalOperatorBuilder In<TValue>( IEnumerable<TValue> values )
        => new InConditionalOperatorBuilder<TValue>( values );

    public static ConditionalOperatorBuilder NotIn( object values )
        => new InConditionalOperatorBuilder<object>(values);

    public static ConditionalOperatorBuilder NotIn<TValue>( IEnumerable<TValue> values )
        => new InConditionalOperatorBuilder<TValue>( values, true );

    //public static ConditionalOperatorBuilder Is( object? value )
    //    => new IsConditionalOperatorBuilder( value );

    public static ConditionalOperatorBuilder Between( object firstValue, object lastValue )
        => new BetweenConditionalOperatorBuilder( firstValue, lastValue );
}