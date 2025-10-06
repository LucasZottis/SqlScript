using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

internal interface ITableBuilder : ISqlScriptBuilder
{
    ITableBuilder SetTableName(string tableName);
    ITableBuilder SetAlias(string alias);
}