using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    internal interface IFromBuilder : ISqlScriptBuilder
    {
        IFromBuilder From( string table );
        //IFromBuilder Join( string joinedTable, string tableSource, string tableSourceField, IJoinBuilder joinBuilder );
        //IFromBuilder Join( string joinedTable, string joinedTableField, string tableSource, string tableSourceField, IJoinBuilder joinBuilder);
        IFromBuilder Join( string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, IJoinBuilder joinBuilder, string otherConditions = null);

        //IFromBuilder InnerJoin(string joinedTable, string tableSource, string field);
        //IFromBuilder InnerJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField);
        //IFromBuilder InnerJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField);
    }
}