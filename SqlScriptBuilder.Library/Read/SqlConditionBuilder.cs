using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read;

internal class SqlConditionBuilder : IConditionBuilder
{
    //private string TableName;
    //private string FieldName;
    //private SqlFunctionBuilder SqlFunction;
    //private ConditionalOperatorBuilder ConditionalOperatorBuilder;
    //protected string? Combiner;

    //protected Field Field { private get; set; } = new();

    protected Condition Condition { private get; set; }

    //public SqlConditionBuilder(string tableAlias, string fieldName, ConditionalOperatorBuilder conditionalOperatorBuilder)
    //{
    //    Condition.Field.TableAlias = tableAlias ?? throw new ArgumentNullException(nameof(tableAlias));
    //    Condition.Field.FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
    //    //FieldName = fieldName ?? throw new ArgumentNullException( nameof( fieldName ) );
    //    //ConditionalOperatorBuilder = conditionalOperatorBuilder ?? throw new ArgumentNullException( nameof( conditionalOperatorBuilder ) );
    //    //Combiner = null;
    //}

    //public SqlConditionBuilder(SqlFunctionBuilder sqlFunctionBuilder, ConditionalOperatorBuilder conditionalOperatorBuilder)
    //{
    //    SqlFunction = sqlFunctionBuilder ?? throw new ArgumentNullException(nameof(sqlFunctionBuilder));
    //    ConditionalOperatorBuilder = conditionalOperatorBuilder ?? throw new ArgumentNullException(nameof(conditionalOperatorBuilder));
    //    Combiner = null;
    //}

    public SqlConditionBuilder()
    {
        Condition = new();
    }

    internal SqlConditionBuilder SetCombiner(string combiner)
    {
        if (string.IsNullOrEmpty(combiner))
            throw new ArgumentException("Combiner cannot be null or empty.");

        Combiner = combiner;
        return this;
    }

    public ISqlScript Build()
    {
        //var sql = $"{TableName}.{FieldName}";
        var sql = string.IsNullOrEmpty(Combiner) ? $"{Combiner} " : "";

        if (SqlFunction is not null)
            sql += SqlFunction.Build().GetScript();
        else
            sql += $"{TableName}.{FieldName}";

        var conditionalOperatorScript = ConditionalOperatorBuilder.Build().GetScript();

        sql += $" {conditionalOperatorScript}";

        return new SqlReadScript(sql);
    }
}