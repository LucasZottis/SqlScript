using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class WhereBuilder : IWhereBuilder
{
    private IList<SqlConditionBuilder> _conditions;

    public WhereBuilder()
    {
        _conditions = new List<SqlConditionBuilder>();
    }

    public ISqlScript Build()
    {
        var script = new StringBuilder();

        script.AppendLine( "Where" );

        foreach ( var condition in _conditions )
            script.AppendLine( condition.Build().GetScript() );

        return new SqlReadScript( script );
    }

    public IWhereBuilder Condition( string tableAlias, string fieldName, ConditionalOperatorBuilder operatorBuilder, bool isOrCombiner = false )
    {
        var condition = new SqlConditionBuilder( tableAlias, fieldName, operatorBuilder );

        if ( _conditions.Any() )
            condition.SetCombiner( isOrCombiner ? "OR" : "AND" );

        _conditions.Add( condition );
        return this;
    }

    public IWhereBuilder Condition( SqlFunctionBuilder sqlFunctionBuilder, ConditionalOperatorBuilder operatorBuilder, bool isOrCombiner = false )
    {
        var condition = new SqlConditionBuilder( sqlFunctionBuilder, operatorBuilder );

        if ( _conditions.Any() )
            condition.SetCombiner( isOrCombiner ? "OR" : "AND" );

        _conditions.Add( condition );
        return this;
    }

    public IWhereBuilder GreaterThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan( value ), isOrCombiner );
    }

    public IWhereBuilder GreaterThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan( value ), isOrCombiner );
    }

    public IWhereBuilder GreaterThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan( value ), isOrCombiner );
    }

    public IWhereBuilder GreaterThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan( value ), isOrCombiner );
    }

    public IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder Equal( string tableAlias, string fieldName, int value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal( value ), isOrCombiner );
    }

    public IWhereBuilder Equal( string tableAlias, string fieldName, double value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal( value ), isOrCombiner );
    }

    public IWhereBuilder Equal( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal( value ), isOrCombiner );
    }

    public IWhereBuilder Equal( string tableAlias, string fieldName, string value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal( value ), isOrCombiner );
    }

    public IWhereBuilder Equal( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal( value ), isOrCombiner );
    }

    public IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan( value ), isOrCombiner );
    }

    public IWhereBuilder LessThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan( value ), isOrCombiner );
    }

    public IWhereBuilder LessThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan( value ), isOrCombiner );
    }

    public IWhereBuilder LessThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan( value ), isOrCombiner );
    }

    public IWhereBuilder LessThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan( value ), isOrCombiner );
    }

    public IWhereBuilder Different( string tableAlias, string fieldName, int value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different( value ), isOrCombiner );
    }

    public IWhereBuilder Different( string tableAlias, string fieldName, double value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different( value ), isOrCombiner );
    }

    public IWhereBuilder Different( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different( value ), isOrCombiner );
    }

    public IWhereBuilder Different( string tableAlias, string fieldName, string value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different( value ), isOrCombiner );
    }

    public IWhereBuilder Different( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different( value ), isOrCombiner );
    }

    public IWhereBuilder Like( string tableAlias, string fieldName, string value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Like( value ), isOrCombiner );
    }

    public IWhereBuilder NotLike( string tableAlias, string fieldName, string value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotLike( value ), isOrCombiner );
    }

    public IWhereBuilder In( string tableAlias, string fieldName, object value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.In( value ), isOrCombiner );
    }

    public IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<int> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.In( list ), isOrCombiner );
    }

    public IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<double> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.In( list ), isOrCombiner );
    }

    public IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<decimal> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.In( list ), isOrCombiner );
    }

    public IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<string> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.In( list ), isOrCombiner );
    }

    public IWhereBuilder NotIn( string tableAlias, string fieldName, object value, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn( value ), isOrCombiner );
    }

    public IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<int> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn( list ), isOrCombiner );
    }

    public IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<double> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn( list ), isOrCombiner );
    }

    public IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<decimal> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn( list ), isOrCombiner );
    }

    public IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<string> list, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn( list ), isOrCombiner );
    }

    public IWhereBuilder Between( string tableAlias, string fieldName, object firstValue, object lastValue, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between( firstValue, lastValue ), isOrCombiner );
    }

    public IWhereBuilder Between( string tableAlias, string fieldName, int firstValue, int lastValue, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between( firstValue, lastValue ), isOrCombiner );
    }

    public IWhereBuilder Between( string tableAlias, string fieldName, double firstValue, double lastValue, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between( firstValue, lastValue ), isOrCombiner );
    }

    public IWhereBuilder Between( string tableAlias, string fieldName, decimal firstValue, decimal lastValue, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between( firstValue, lastValue ), isOrCombiner );
    }

    public IWhereBuilder Between( string tableAlias, string fieldName, DateTime firstValue, DateTime lastValue, bool isOrCombiner = false )
    {
        return Condition( tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between( firstValue, lastValue ), isOrCombiner );
    }
}