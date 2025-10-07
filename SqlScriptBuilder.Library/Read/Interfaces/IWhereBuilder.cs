using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Builders;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Interfaces;

public interface IWhereBuilder : ISqlScriptBuilder
{
    IWhereBuilder Condition( string tableAlias, string fieldName, ConditionalOperatorBuilder operatorBuilder, ConditionCombiner? combiner = null );
    IWhereBuilder Condition( SqlFunctionBuilder sqlFunctionBuilder, ConditionalOperatorBuilder operatorBuilder, ConditionCombiner? combiner = null );

    IWhereBuilder GreaterThan( string tableAlias, string fieldName, int value,  ConditionCombiner? combiner = null );
    IWhereBuilder GreaterThan( string tableAlias, string fieldName, double value,  ConditionCombiner? combiner = null );
    IWhereBuilder GreaterThan( string tableAlias, string fieldName, decimal value,  ConditionCombiner? combiner = null );
    IWhereBuilder GreaterThan( string tableAlias, string fieldName, DateTime value,  ConditionCombiner? combiner = null );

    IWhereBuilder GreaterThan( SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null );
    IWhereBuilder GreaterThan( SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null );
    IWhereBuilder GreaterThan( SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null );
    IWhereBuilder GreaterThan( SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null );

    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, int value,  ConditionCombiner? combiner = null );
    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, double value,  ConditionCombiner? combiner = null );
    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, decimal value,  ConditionCombiner? combiner = null );
    IWhereBuilder GreaterOrEqualThan( string tableAlias, string fieldName, DateTime value,  ConditionCombiner? combiner = null );

    IWhereBuilder GreaterOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null );
    IWhereBuilder GreaterOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null );
    IWhereBuilder GreaterOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null );
    IWhereBuilder GreaterOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null );

    IWhereBuilder Equal( string tableAlias, string fieldName, int value,  ConditionCombiner? combiner = null );
    IWhereBuilder Equal( string tableAlias, string fieldName, double value,  ConditionCombiner? combiner = null );
    IWhereBuilder Equal( string tableAlias, string fieldName, decimal value,  ConditionCombiner? combiner = null );
    IWhereBuilder Equal( string tableAlias, string fieldName, string value,  ConditionCombiner? combiner = null );
    IWhereBuilder Equal( string tableAlias, string fieldName, DateTime value,  ConditionCombiner? combiner = null );

    IWhereBuilder Equal( SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null );
    IWhereBuilder Equal( SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null );
    IWhereBuilder Equal( SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null );
    IWhereBuilder Equal( SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null );
    IWhereBuilder Equal( SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null );

    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, int value,  ConditionCombiner? combiner = null );
    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, double value,  ConditionCombiner? combiner = null );
    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, decimal value,  ConditionCombiner? combiner = null );
    IWhereBuilder LessOrEqualThan( string tableAlias, string fieldName, DateTime value,  ConditionCombiner? combiner = null );

    IWhereBuilder LessOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null );
    IWhereBuilder LessOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null );
    IWhereBuilder LessOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null );
    IWhereBuilder LessOrEqualThan( SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null );

    IWhereBuilder LessThan( string tableAlias, string fieldName, int value,  ConditionCombiner? combiner = null );
    IWhereBuilder LessThan( string tableAlias, string fieldName, double value,  ConditionCombiner? combiner = null );
    IWhereBuilder LessThan( string tableAlias, string fieldName, decimal value,  ConditionCombiner? combiner = null );
    IWhereBuilder LessThan( string tableAlias, string fieldName, DateTime value,  ConditionCombiner? combiner = null );

    IWhereBuilder LessThan( SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null );
    IWhereBuilder LessThan( SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null );
    IWhereBuilder LessThan( SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null );
    IWhereBuilder LessThan( SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null );

    IWhereBuilder Different( string tableAlias, string fieldName, int value,  ConditionCombiner? combiner = null );
    IWhereBuilder Different( string tableAlias, string fieldName, double value,  ConditionCombiner? combiner = null );
    IWhereBuilder Different( string tableAlias, string fieldName, decimal value,  ConditionCombiner? combiner = null );
    IWhereBuilder Different( string tableAlias, string fieldName, string value,  ConditionCombiner? combiner = null );

    IWhereBuilder Different( SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null );
    IWhereBuilder Different( SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null );
    IWhereBuilder Different( SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null );
    IWhereBuilder Different( SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null );

    IWhereBuilder Like( string tableAlias, string fieldName, string value,  ConditionCombiner? combiner = null );
    IWhereBuilder NotLike( string tableAlias, string fieldName, string value,  ConditionCombiner? combiner = null );

    IWhereBuilder Like( SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null );
    IWhereBuilder NotLike( SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null );

    IWhereBuilder In( string tableAlias, string fieldName, object value,  ConditionCombiner? combiner = null );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<int> list,  ConditionCombiner? combiner = null );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<double> list,  ConditionCombiner? combiner = null );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<decimal> list,  ConditionCombiner? combiner = null );
    IWhereBuilder In( string tableAlias, string fieldName, IEnumerable<string> list,  ConditionCombiner? combiner = null );

    IWhereBuilder In( SqlFunctionBuilder sqlFunctionBuilder, object value, ConditionCombiner? combiner = null );
    IWhereBuilder In( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<int> list, ConditionCombiner? combiner = null );
    IWhereBuilder In( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<double> list, ConditionCombiner? combiner = null );
    IWhereBuilder In( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<decimal> list, ConditionCombiner? combiner = null );
    IWhereBuilder In( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<string> list, ConditionCombiner? combiner = null );

    IWhereBuilder NotIn( string tableAlias, string fieldName, object value,  ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<int> list,  ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<double> list,  ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<decimal> list,  ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( string tableAlias, string fieldName, IEnumerable<string> list,  ConditionCombiner? combiner = null );

    IWhereBuilder NotIn( SqlFunctionBuilder sqlFunctionBuilder, object value, ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<int> list, ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<double> list, ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<decimal> list, ConditionCombiner? combiner = null );
    IWhereBuilder NotIn( SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<string> list, ConditionCombiner? combiner = null );

    //IWhereBuilder Is( string tableAlias, string fieldName, object value, bool denial = false,  ConditionCombiner? combiner = null );
    IWhereBuilder Between( string tableAlias, string fieldName, object firstValue, object lastValue,  ConditionCombiner? combiner = null );
    IWhereBuilder Between( string tableAlias, string fieldName, int firstValue, int lastValue,  ConditionCombiner? combiner = null );
    IWhereBuilder Between( string tableAlias, string fieldName, double firstValue, double lastValue,  ConditionCombiner? combiner = null );
    IWhereBuilder Between( string tableAlias, string fieldName, decimal firstValue, decimal lastValue,  ConditionCombiner? combiner = null );
    IWhereBuilder Between( string tableAlias, string fieldName, DateTime firstValue, DateTime lastValue,  ConditionCombiner? combiner = null );

    IWhereBuilder Between( SqlFunctionBuilder sqlFunctionBuilder, object firstValue, object lastValue, ConditionCombiner? combiner = null );
    IWhereBuilder Between( SqlFunctionBuilder sqlFunctionBuilder, int firstValue, int lastValue, ConditionCombiner? combiner = null );
    IWhereBuilder Between( SqlFunctionBuilder sqlFunctionBuilder, double firstValue, double lastValue, ConditionCombiner? combiner = null );
    IWhereBuilder Between( SqlFunctionBuilder sqlFunctionBuilder, decimal firstValue, decimal lastValue, ConditionCombiner? combiner = null );
    IWhereBuilder Between( SqlFunctionBuilder sqlFunctionBuilder, DateTime firstValue, DateTime lastValue, ConditionCombiner? combiner = null );

    IGroupByBuilder GroupBy();
    IOrderByBuilder OrderBy();
}