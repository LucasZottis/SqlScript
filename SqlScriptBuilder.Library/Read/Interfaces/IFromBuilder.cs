using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

public interface IFromBuilder : ISqlScriptBuilder
{
    IFromBuilder Table( string table );
    IFromBuilder Join( string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, IJoinBuilder joinBuilder, string otherConditions = null);

    //internal bool HasTable( string tableName );

    IGroupByBuilder Group();
    IOrderByBuilder Order();
}