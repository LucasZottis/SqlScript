using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

public interface IFromBuilder : ISqlScriptBuilder
{
    IFromBuilder Table( string table );
    IFromBuilder InnerJoin( string joinedTable, string tableSource, string fieldName, string? otherConditions = null);
    IFromBuilder InnerJoin( string joinedTable, string joinedTableAlias, string tableSource, string fieldName, string ? otherConditions = null);
    IFromBuilder InnerJoin( string joinedTable, string joinedTableField, string tableSource, string tableSourceField, string? joinedTableAlias = null, string ? otherConditions = null);

    IFromBuilder LeftJoin( string joinedTable, string tableSource, string fieldName, string? otherConditions = null );
    IFromBuilder LeftJoin( string joinedTable, string joinedTableAlias, string tableSource, string fieldName, string? otherConditions = null );
    IFromBuilder LeftJoin( string joinedTable, string joinedTableField, string tableSource, string tableSourceField, string? joinedTableAlias = null, string? otherConditions = null );

    IWhereBuilder Where();
    IGroupByBuilder Group();
    IOrderByBuilder Order();
}