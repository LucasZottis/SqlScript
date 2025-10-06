using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

internal interface IConditionBuilder : ISqlScriptBuilder
{
    IConditionBuilder SetCombiner(ConditionalOperatorBuilder conditionalOperatorBuilder);
    IConditionBuilder SetTableAlias(string tableAlias);
    IConditionBuilder SetFieldName(string fieldName);
    IConditionBuilder SetFieldName(ConditionalOperatorBuilder conditionalOperatorBuilder);
    IConditionBuilder SetFunction(IFunctionBuilder functionBuilder);
}