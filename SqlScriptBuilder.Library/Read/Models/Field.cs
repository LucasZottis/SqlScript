using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class Field : IField
{
    public string? TableAlias { private get; set; }
    public string FieldName { private get; set; }
    public string? Alias { private get; set; }

    public override string ToString()
    {
        var sql = FieldName;

        if (!string.IsNullOrEmpty(TableAlias))
            sql = $"{TableAlias}.{FieldName}";

        if (!string.IsNullOrEmpty(Alias))
            sql += $" as {Alias}";

        return sql;
    }
}