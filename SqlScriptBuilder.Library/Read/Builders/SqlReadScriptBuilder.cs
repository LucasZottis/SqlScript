using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class SqlReadScriptBuilder : ISqlReadScriptBuilder
{
    private ISelectBuilder _selectBuilder;
    private IFromBuilder? _fromBuilder;
    private IWhereBuilder? _whereBuilder;
    private IGroupByBuilder? _groupByBuilder;
    private IOrderByBuilder? _orderByBuilder;

    public ISqlScript Build()
    {
        if ( _selectBuilder == null )
            throw new InvalidOperationException( "No fields selected. Use the Select() method to add fields." );

        var script = new SqlReadScript( ( SelectSection ) _selectBuilder.Build() );

        if ( _fromBuilder != null )
            script.FromSection = ( FromSection ) _fromBuilder.Build();

        if ( _whereBuilder != null )
            script.WhereSection = ( WhereSection ) _whereBuilder.Build();

        return script;
    }

    public ISelectBuilder Select()
    {
        return _selectBuilder ??= new SelectBuilder( this );
    }

    public IFromBuilder From()
    {
        return _fromBuilder ??= new FromBuilder( this );
    }

    public IGroupByBuilder GroupBy()
    {
        return _groupByBuilder ??= new GroupByBuilder( this );
    }

    public IOrderByBuilder OrderBy()
    {
        return _orderByBuilder ??= new OrderByBuilder();
    }

    public IWhereBuilder Where()
    {
        return _whereBuilder ??= new WhereBuilder();
    }
}