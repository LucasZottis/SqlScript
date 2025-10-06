using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

internal interface IJoinBuilder : ITableBuilder
{
    //IJoinBuilder Join(string joinedTable, string tableSource, string field);

    //IJoinBuilder Join(string joinedTable, string joinedTableField, string tableSource, string tableSourceField);

    //IJoinBuilder Join(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField);

    //IJoinBuilder Join(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null);

    //void SetAlias( string alias );
    IJoinBuilder SetJoinedTableField(string joinedTableField);
    IJoinBuilder SetTableSourceName(string tableSourceName);
    IJoinBuilder SetTableSourceField(string tableSourceField);
    IJoinBuilder SetOtherConditions(string otherConditions);
}