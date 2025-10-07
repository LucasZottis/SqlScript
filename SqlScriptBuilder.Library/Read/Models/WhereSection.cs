using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class WhereSection : ISqlScript
{
    private readonly IList<Condition> _conditions;

    public WhereSection()
    {
        _conditions = new List<Condition>();
    }

    public void AddCondition( Condition condition )
    {
        _conditions.Add( condition ?? throw new ArgumentNullException( nameof( condition ) ) );
    }

    public override string ToString()
    {
        var sql = "where";

        foreach ( var condition in _conditions )
            sql += $" {condition}";

        return sql;
    }
}