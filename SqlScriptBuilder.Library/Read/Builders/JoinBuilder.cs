using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

internal abstract class JoinBuilder : TableBuilder, IJoinBuilder
{
    protected Join Join { get; set; }

    protected JoinBuilder(Join join)
    {
        Join = join;
    }

    //public ISqlScript Build()
    //{
    //    //var script = $"{JoinType} join {JoinedTable} ";
    //    //var joinedTable = JoinedTable;

    //    //if (!string.IsNullOrEmpty(JoinedTableAlias) && JoinedTable != JoinedTableAlias)
    //    //{
    //    //    joinedTable = JoinedTableAlias;
    //    //    script += $"as {joinedTable} ";
    //    //}

    //    //script += $"on {joinedTable}.{JoinedTableField} = {TableSource}.{TableSourceField}";

    //    //if (!string.IsNullOrEmpty(OtherConditions))
    //    //    script += $" {OtherConditions}";

    //    //return new SqlReadScript(script);
    //    return Join;
    //}

    public IJoinBuilder SetOtherConditions(string otherConditions)
    {
        if (string.IsNullOrWhiteSpace(otherConditions))
            throw new ArgumentException("Other conditions cannot be null or whitespace.", nameof(otherConditions));

        Join.OtherConditions = otherConditions;
        return this;
    }

    public IJoinBuilder SetTableSourceName(string tableSourceName)
    {
        Join.TableSourceName = tableSourceName;
        return this;
    }

    public IJoinBuilder SetTableSourceField(string tableSourceField)
    {
        Join.TableSourceField = tableSourceField;
        return this;
    }

    public IJoinBuilder SetJoinedTableField(string joinedTableField)
    {
        Join.JoinedTableField = joinedTableField;
        return this;
    }
}