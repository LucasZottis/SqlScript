using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    public interface ISqlReadScriptBuilder : ISqlScriptBuilder
    {
        ISqlReadScriptBuilder Select(string field);
        ISqlReadScriptBuilder Select(string field, string value);
        ISqlReadScriptBuilder SelectIsNull(string checkExpression, string replacementValue, string fieldName);

        ISqlReadScriptBuilder From(string table);
        ISqlReadScriptBuilder InnerJoin(string joinedTable, string tableSource, string field);
        ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField);
        ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField);
        ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null);

        ISqlReadScriptBuilder LeftJoin(string joinedTable, string tableSource, string field);
        ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField);
        ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField);
        ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null);

        ISqlReadScriptBuilder Where(string condition);
        ISqlReadScriptBuilder GroupBy(string field);
        ISqlReadScriptBuilder OrderBy(string field);
    }
}