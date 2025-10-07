using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

internal interface IJoinBuilder : ISqlScriptBuilder
{
    IJoinBuilder SetJoinedTable(string joinedTableName, string joinedTableFieldName, string? joinedTableAlias = null);
    IJoinBuilder SetTableSource(string tableSource, string tableSourceFieldName);
    IJoinBuilder SetOtherConditions(string otherConditions);
}