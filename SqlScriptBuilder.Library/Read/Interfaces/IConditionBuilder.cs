using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Builders;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Interfaces;

internal interface IConditionBuilder : ISqlScriptBuilder
{
    IConditionBuilder SetCombiner(ConditionCombiner combiner);
    IConditionBuilder SetTableAlias(string tableAlias);
    IConditionBuilder SetFieldName(string fieldName);
    IConditionBuilder SetOperator(ConditionalOperatorBuilder conditionalOperatorBuilder);
    IConditionBuilder SetFunction(IFunctionBuilder functionBuilder);
}