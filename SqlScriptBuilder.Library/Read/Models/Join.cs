using SqlScriptBuilder.Library.Interfaces;
using System.Globalization;

namespace SqlScriptBuilder.Library.Read.Models;

internal class Join : ISqlScript
{
    public Table JoinedTable { private get; set; }
    public string JoinedTableField { private get; set; }

    //public string TableSourceName { private get; set; }
    public Table TableSource { private get; set; }
    public string TableSourceField { private get; set; }

    public string? OtherConditions { private get; set; }

    protected JoinType JoinType { private get; set; }

    public Join(JoinType joinType)
    {
        JoinType = joinType;
    }

    public override string ToString()
    {
        var sql = $" {JoinType} join {JoinedTable}";

        sql += $" on {JoinedTable}.{JoinedTableField}";
        sql += $" = {TableSource}.{TableSourceField}";

        if (!string.IsNullOrEmpty(OtherConditions))
            sql += $" {OtherConditions}";

        return sql;
    }
}