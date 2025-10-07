using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class SqlReadScript : ISqlReadScript
{
    private ISqlScript _selectSection;
    public ISqlScript? FromSection { private get; set; }
    public ISqlScript? WhereSection { private get; set; }
    //private GroupBySection? _groupBySection;
    //private OrderBySection? _orderBySection;

    public SqlReadScript( SelectSection selectSection )
    {
        _selectSection = selectSection ?? throw new ArgumentNullException( nameof( selectSection ) );
    }

    public override string ToString()
    {
        var sql = _selectSection.ToString();

        if ( FromSection != null )
            sql += FromSection.ToString();

        if ( WhereSection != null )
            sql += WhereSection.ToString();

        return sql;
    }
}