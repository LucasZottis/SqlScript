using System.Globalization;

namespace SqlScriptBuilder.Library.Read.Models;

internal class Join : Table
{
    public string JoinedTableField { private get; set; }
    public string TableSourceName { private get; set; }
    public string TableSourceField { private get; set; }
    public string? OtherConditions { private get; set; }

    protected JoinType JoinType { private get; set; }

    public Join(JoinType joinType)
    {
        JoinType = joinType;
    }

    public override string ToString()
    {
        var sql = $"{JoinType} join {base.ToString()}";

        sql += $" on {Alias ?? TableName}.{JoinedTableField}";
        sql += $" = {TableSourceName}.{TableSourceField}";

        if (!string.IsNullOrEmpty(OtherConditions))
            sql += $" {OtherConditions}";

        return sql;
    }
}