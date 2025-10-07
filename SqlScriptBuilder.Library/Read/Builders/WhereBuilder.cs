using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Factories;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class WhereBuilder : IWhereBuilder
{
    private IList<ConditionBuilder> _conditions;

    public WhereBuilder()
    {
        _conditions = new List<ConditionBuilder>();
    }

    private void SetCombiner(ConditionBuilder condition, ConditionCombiner? combiner)
    {
        if (combiner == null && _conditions.Any())
            combiner = ConditionCombinerFactory.And();

        if (combiner != null)
            condition.SetCombiner(combiner);
    }

    public ISqlScript Build()
    {
        if (!_conditions.Any())
            throw new InvalidOperationException("No conditions defined for WHERE clause.");

        var whereSection = new WhereSection();

        foreach (var condition in _conditions)
            whereSection.AddCondition((Condition)condition.Build());

        return whereSection;
    }

    public IWhereBuilder Condition(string tableAlias, string fieldName, ConditionalOperatorBuilder operatorBuilder, ConditionCombiner? combiner = null)
    {
        var condition = new ConditionBuilder(tableAlias, fieldName, operatorBuilder);

        SetCombiner(condition, combiner);
        _conditions.Add(condition);

        return this;
    }

    public IWhereBuilder Condition(SqlFunctionBuilder sqlFunctionBuilder, ConditionalOperatorBuilder operatorBuilder, ConditionCombiner? combiner = null)
    {
        var condition = new ConditionBuilder(sqlFunctionBuilder, operatorBuilder);

        SetCombiner(condition, combiner);
        _conditions.Add(condition);

        return this;
    }

    #region GreaterThan
    public IWhereBuilder GreaterThan(string tableAlias, string fieldName, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }

    public IWhereBuilder GreaterThan(string tableAlias, string fieldName, int value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }

    public IWhereBuilder GreaterThan(string tableAlias, string fieldName, double value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }

    public IWhereBuilder GreaterThan(string tableAlias, string fieldName, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }

    public IWhereBuilder GreaterThan(SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }

    public IWhereBuilder GreaterThan(SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }

    public IWhereBuilder GreaterThan(SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }

    public IWhereBuilder GreaterThan(SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterThan(value), combiner);
    }
    #endregion

    #region GreaterOrEqualThan
    public IWhereBuilder GreaterOrEqualThan(string tableAlias, string fieldName, int value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }

    public IWhereBuilder GreaterOrEqualThan(string tableAlias, string fieldName, double value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }

    public IWhereBuilder GreaterOrEqualThan(string tableAlias, string fieldName, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }

    public IWhereBuilder GreaterOrEqualThan(string tableAlias, string fieldName, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }

    public IWhereBuilder GreaterOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }

    public IWhereBuilder GreaterOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }

    public IWhereBuilder GreaterOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }

    public IWhereBuilder GreaterOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.GreaterOrEqualThan(value), combiner);
    }
    #endregion

    #region Equal
    public IWhereBuilder Equal(string tableAlias, string fieldName, int value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(string tableAlias, string fieldName, double value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(string tableAlias, string fieldName, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(string tableAlias, string fieldName, string value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(string tableAlias, string fieldName, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }

    public IWhereBuilder Equal(SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Equal(value), combiner);
    }
    #endregion

    #region LessOrEqualThan
    public IWhereBuilder LessOrEqualThan(string tableAlias, string fieldName, int value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }

    public IWhereBuilder LessOrEqualThan(string tableAlias, string fieldName, double value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }

    public IWhereBuilder LessOrEqualThan(string tableAlias, string fieldName, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }

    public IWhereBuilder LessOrEqualThan(string tableAlias, string fieldName, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }

    public IWhereBuilder LessOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }

    public IWhereBuilder LessOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }

    public IWhereBuilder LessOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }

    public IWhereBuilder LessOrEqualThan(SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessOrEqualThan(value), combiner);
    }
    #endregion

    #region LessThan
    public IWhereBuilder LessThan(string tableAlias, string fieldName, int value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }

    public IWhereBuilder LessThan(string tableAlias, string fieldName, double value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }

    public IWhereBuilder LessThan(string tableAlias, string fieldName, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }

    public IWhereBuilder LessThan(string tableAlias, string fieldName, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }

    public IWhereBuilder LessThan(SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }

    public IWhereBuilder LessThan(SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }

    public IWhereBuilder LessThan(SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }

    public IWhereBuilder LessThan(SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.LessThan(value), combiner);
    }
    #endregion

    #region Different
    public IWhereBuilder Different(string tableAlias, string fieldName, int value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(string tableAlias, string fieldName, double value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(string tableAlias, string fieldName, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(string tableAlias, string fieldName, string value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(string tableAlias, string fieldName, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(SqlFunctionBuilder sqlFunctionBuilder, int value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(SqlFunctionBuilder sqlFunctionBuilder, double value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(SqlFunctionBuilder sqlFunctionBuilder, decimal value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }

    public IWhereBuilder Different(SqlFunctionBuilder sqlFunctionBuilder, DateTime value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Different(value), combiner);
    }
    #endregion

    #region Like
    public IWhereBuilder Like(string tableAlias, string fieldName, string value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Like(value), combiner);
    }

    public IWhereBuilder Like(SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Like(value), combiner);
    }
    #endregion

    #region NotLike
    public IWhereBuilder NotLike(string tableAlias, string fieldName, string value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotLike(value), combiner);
    }

    public IWhereBuilder NotLike(SqlFunctionBuilder sqlFunctionBuilder, string value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.NotLike(value), combiner);
    }
    #endregion

    #region In
    public IWhereBuilder In(string tableAlias, string fieldName, object value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.In(value), combiner);
    }

    public IWhereBuilder In(string tableAlias, string fieldName, IEnumerable<int> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.In(list), combiner);
    }

    public IWhereBuilder In(string tableAlias, string fieldName, IEnumerable<double> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.In(list), combiner);
    }

    public IWhereBuilder In(string tableAlias, string fieldName, IEnumerable<decimal> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.In(list), combiner);
    }

    public IWhereBuilder In(string tableAlias, string fieldName, IEnumerable<string> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.In(list), combiner);
    }

    public IWhereBuilder In(SqlFunctionBuilder sqlFunctionBuilder, object value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.In(value), combiner);
    }

    public IWhereBuilder In(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<int> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.In(list), combiner);
    }

    public IWhereBuilder In(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<double> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.In(list), combiner);
    }

    public IWhereBuilder In(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<decimal> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.In(list), combiner);
    }

    public IWhereBuilder In(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<string> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.In(list), combiner);
    }
    #endregion

    #region NotIn
    public IWhereBuilder NotIn(string tableAlias, string fieldName, object value, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn(value), combiner);
    }

    public IWhereBuilder NotIn(string tableAlias, string fieldName, IEnumerable<int> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }

    public IWhereBuilder NotIn(string tableAlias, string fieldName, IEnumerable<double> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }

    public IWhereBuilder NotIn(string tableAlias, string fieldName, IEnumerable<decimal> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }

    public IWhereBuilder NotIn(string tableAlias, string fieldName, IEnumerable<string> list, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }

    public IWhereBuilder NotIn(SqlFunctionBuilder sqlFunctionBuilder, object value, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.NotIn(value), combiner);
    }

    public IWhereBuilder NotIn(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<int> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }

    public IWhereBuilder NotIn(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<double> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }

    public IWhereBuilder NotIn(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<decimal> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }

    public IWhereBuilder NotIn(SqlFunctionBuilder sqlFunctionBuilder, IEnumerable<string> list, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.NotIn(list), combiner);
    }
    #endregion

    #region Between
    public IWhereBuilder Between(string tableAlias, string fieldName, object firstValue, object lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(string tableAlias, string fieldName, int firstValue, int lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(string tableAlias, string fieldName, double firstValue, double lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(string tableAlias, string fieldName, decimal firstValue, decimal lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(string tableAlias, string fieldName, DateTime firstValue, DateTime lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(tableAlias, fieldName, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(SqlFunctionBuilder sqlFunctionBuilder, object firstValue, object lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(SqlFunctionBuilder sqlFunctionBuilder, int firstValue, int lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(SqlFunctionBuilder sqlFunctionBuilder, double firstValue, double lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(SqlFunctionBuilder sqlFunctionBuilder, decimal firstValue, decimal lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }

    public IWhereBuilder Between(SqlFunctionBuilder sqlFunctionBuilder, DateTime firstValue, DateTime lastValue, ConditionCombiner? combiner = null)
    {
        return Condition(sqlFunctionBuilder, ConditionalOperatorBuilderFactory.Between(firstValue, lastValue), combiner);
    }
    #endregion

    public IGroupByBuilder GroupBy()
    {
        throw new NotImplementedException();
    }

    public IOrderByBuilder OrderBy()
    {
        throw new NotImplementedException();
    }
}