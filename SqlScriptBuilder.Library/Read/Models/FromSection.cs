using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class FromSection : ISqlScript
{
    public IList<ISqlScript> Tables { private get; set; }
    public IList<ISqlScript> Joins { private get; set; }

    public FromSection()
    {
        Tables = [];
        Joins = [];
    }

    //public void AddTable(ISqlScript table)
    //    => Tables.Add(table);

    //public void AddJoin(ISqlScript join)
    //    => Tables.Add(join);

    //public void AddJoins(IEnumerable<ISqlScript> joins)
    //{
    //    foreach(var join in joins)
    //        Joins.Add(join);
    //}

    override public string ToString()
    {
        if (Tables == null || Tables.Count == 0)
            return string.Empty;

        var tables = Tables.Select(t => t.ToString());
        var joins = Joins.Select(j => j.ToString());

        return " FROM " + string.Join(", ", tables) + string.Join(" ", joins);
    }
}