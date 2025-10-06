using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class SelectSection : ISqlScript
{
    public IList<IField> Fields { private get; set; }

    public SelectSection()
    {
        Fields = new List<IField>();
    }

    public void AddField(IField field)
    {
        Fields.Add(field);
    }

    private IEnumerable<string> GetFields()
    {
        return Fields.Select(f =>
        {
            return f.ToString();
        });
    }

    public override string ToString()
    {
        var fields = GetFields();
        var sql = string.Join($", {Environment.NewLine}", fields);

        return sql;
    }
}