using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

public interface IWhereBuilder : ISqlScriptBuilder
{
    IWhereBuilder Condition( string tableAlias, string fieldName, ConditionalOperatorBuilder operatorBuilder, bool isOrCombiner = false );
    IWhereBuilder Condition( SqlFunctionBuilder sqlFunctionBuilder, ConditionalOperatorBuilder operatorBuilder, bool isOrCombiner = false );

    IWhereBuilder GreaterThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false );
    IWhereBuilder GreaterThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false );
    IWhereBuilder GreaterThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false );
    IWhereBuilder GreaterThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false );

    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false );
    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false );
    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false );
    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false );

    IWhereBuilder Equal( string tableAlias, string fieldName, int value, bool isOrCombiner = false );
    IWhereBuilder Equal( string tableAlias, string fieldName, double value, bool isOrCombiner = false );
    IWhereBuilder Equal( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false );
    IWhereBuilder Equal( string tableAlias, string fieldName, string value, bool isOrCombiner = false );
    IWhereBuilder Equal( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false );

    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false );
    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false );
    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false );
    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false );

    IWhereBuilder LessThan( string tableAlias, string fieldName, int value, bool isOrCombiner = false );
    IWhereBuilder LessThan( string tableAlias, string fieldName, double value, bool isOrCombiner = false );
    IWhereBuilder LessThan( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false );
    IWhereBuilder LessThan( string tableAlias, string fieldName, DateTime value, bool isOrCombiner = false );

    IWhereBuilder Different( string tableAlias, string fieldName, int value, bool isOrCombiner = false );
    IWhereBuilder Different( string tableAlias, string fieldName, double value, bool isOrCombiner = false );
    IWhereBuilder Different( string tableAlias, string fieldName, decimal value, bool isOrCombiner = false );
    IWhereBuilder Different( string tableAlias, string fieldName, string value, bool isOrCombiner = false );

    IWhereBuilder Like( string tableAlias, string fieldName, string value, bool isOrCombiner = false );
    IWhereBuilder NotLike( string tableAlias, string fieldName, string value, bool isOrCombiner = false );

    IWhereBuilder In( string tableAlias, string fieldName, object value, bool isOrCombiner = false );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<int> list, bool isOrCombiner = false );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<double> list, bool isOrCombiner = false );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<decimal> list, bool isOrCombiner = false );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<string> list, bool isOrCombiner = false );

    IWhereBuilder NotIn( string tableAlias, string fieldName, object value, bool isOrCombiner = false );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<int> list, bool isOrCombiner = false );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<double> list, bool isOrCombiner = false );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<decimal> list, bool isOrCombiner = false );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<string> list, bool isOrCombiner = false );

    //IWhereBuilder Is( string tableAlias, string fieldName, object value, bool denial = false, bool isOrCombiner = false );
    IWhereBuilder Between( string tableAlias, string fieldName, object firstValue, object lastValue, bool isOrCombiner = false );
    IWhereBuilder Between( string tableAlias, string fieldName, int firstValue, int lastValue, bool isOrCombiner = false );
    IWhereBuilder Between( string tableAlias, string fieldName, double firstValue, double lastValue, bool isOrCombiner = false );
    IWhereBuilder Between( string tableAlias, string fieldName, decimal firstValue, decimal lastValue, bool isOrCombiner = false );
    IWhereBuilder Between( string tableAlias, string fieldName, DateTime firstValue, DateTime lastValue, bool isOrCombiner = false );

    IGroupByBuilder GroupBy();
    IOrderByBuilder OrderBy();
}