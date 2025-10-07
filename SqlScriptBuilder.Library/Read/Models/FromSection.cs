using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class FromSection : ISqlScript
{
    public IList<ISqlScript> Tables { private get; set; }

    public FromSection()
    {
        Tables = [];
    }

    public void AddTable(Table table)
    {
        Tables.Add(table);
    }

    override public string ToString()
    {
        if ( Tables == null || Tables.Count == 0 )
            return string.Empty;

        var tables = Tables.Where( t => t is not Join ).Select(t => t.ToString() );
        var joins = Tables.Where( t => t is Join ).Select(j => j.ToString() );

        return " FROM " + string.Join( ", ", tables ) + string.Join(", ", joins );
    }
}