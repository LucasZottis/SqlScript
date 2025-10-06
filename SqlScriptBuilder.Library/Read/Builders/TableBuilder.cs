using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class TableBuilder : ITableBuilder
{
    private readonly Table _table = new Table();

    public ITableBuilder SetTableName(string tableName)
    {
        _table.TableName = tableName;
        return this;
    }

    public ITableBuilder SetAlias(string alias)
    {
        _table.Alias = alias;
        return this;
    }

    public ISqlScript Build()
    {
        return _table;
    }
}