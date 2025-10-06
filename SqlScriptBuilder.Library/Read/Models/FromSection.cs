using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class FromSection : ISqlScript
{
    public IList<ISqlScript> Tables { private get; set; }

    public void AddTable(Table table)
    {
        Tables.Add(table);
    }
}