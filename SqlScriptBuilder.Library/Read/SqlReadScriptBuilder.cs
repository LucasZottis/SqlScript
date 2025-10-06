using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read;

internal class SqlReadScriptBuilder : ISqlReadScriptBuilder
{
    private ISelectBuilder _selectBuilder;
    private IFromBuilder? _fromBuilder;
    private IWhereBuilder? _whereBuilder;
    private IGroupByBuilder? _groupByBuilder;
    private IOrderByBuilder? _orderByBuilder;

    public ISqlScript Build()
    {
        if ( _selectBuilder == null)
            throw new InvalidOperationException("No fields selected. Use the Select() method to add fields.");

        var script = new StringBuilder()
            .Append( _selectBuilder.Build().GetScript() )
            .Append( _fromBuilder?.Build().GetScript() ?? "")
            .Append( _whereBuilder?.Build().GetScript() ?? "")
            .Append( _groupByBuilder?.Build().GetScript() ?? "")
            .Append( _orderByBuilder?.Build().GetScript() ?? "" );

        return new SqlReadScript(script);
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

    //public ISqlReadScriptBuilder From(string table)
    //{
    //    CheckFromBuilderIsNull();
    //    _fromBuilder.From(table);
    //    return this;
    //}

    //public ISqlReadScriptBuilder GroupBy(string field)
    //{
    //    if (_groupByBuilder == null)
    //        _groupByBuilder = new GroupByBuilder();

    //    _groupByBuilder.GroupBy(field);

    //    return this;
    //}

    //public ISqlReadScriptBuilder OrderBy(string field)
    //{
    //    if (_orderByBuilder == null)
    //        _orderByBuilder = new OrderByBuilder();

    //    _orderByBuilder.OrderBy(field);

    //    return this;
    //}

    //public ISqlReadScriptBuilder Select(string field)
    //{
    //    return Select(field, field);
    //}

    //public ISqlReadScriptBuilder Select(string field, string value)
    //{
    //    CheckSelectBuilderIsNull();
    //    _selectBuilder.AddField(field);
    //    return this;
    //}

    //public ISqlReadScriptBuilder SelectIsNull(string checkExpression, string replacementValue, string fieldName)
    //{
    //    CheckSelectBuilderIsNull();
    //    _selectBuilder.AddIsNull(checkExpression, replacementValue, fieldName);
    //    return this;
    //}

    //public ISqlReadScriptBuilder Where(string condition)
    //{
    //    if (_whereBuilder == null)
    //        _whereBuilder = new WhereBuilder();

    //    _whereBuilder.Where(condition);

    //    return this;
    //}

    //public ISqlReadScriptBuilder InnerJoin(string joinedTable, string tableSource, string field)
    //{
    //    return InnerJoin(joinedTable, field, tableSource, field);
    //}

    //public ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField)
    //{
    //    return InnerJoin(joinedTable, joinedTable, joinedTableField, tableSource, tableSourceField);
    //}

    //public ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField)
    //{
    //    return InnerJoin(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, null);
    //}

    //public ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null)
    //{
    //    CheckFromBuilderIsNull();
    //    _fromBuilder.Join(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, JoinType.InnerJoin, otherConditions);
    //    return this;
    //}

    //public ISqlReadScriptBuilder LeftJoin(string joinedTable, string tableSource, string field)
    //{
    //    return LeftJoin(joinedTable, field, tableSource, field);
    //}

    //public ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField)
    //{
    //    return LeftJoin(joinedTable, joinedTable, joinedTableField, tableSource, tableSourceField);
    //}

    //public ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField)
    //{
    //    return LeftJoin(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, null);
    //}

    //public ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null)
    //{
    //    CheckFromBuilderIsNull();
    //    _fromBuilder.Join(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, JoinType.LeftJoin, otherConditions);
    //    return this;
    //}
}