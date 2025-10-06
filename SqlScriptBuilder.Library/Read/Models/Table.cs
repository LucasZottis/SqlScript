using SqlScriptBuilder.Library.Interfaces;
using System.Globalization;

namespace SqlScriptBuilder.Library.Read.Models;

internal class Table : ISqlScript
{
    public string TableName { protected get; set; }

    public string? Alias { protected get; set; }

    public override string ToString()
    {
        var sql = TableName;

        if (!string.IsNullOrEmpty(Alias))
            sql = $"{TableName} as {Alias}";

        return sql;
    }
}