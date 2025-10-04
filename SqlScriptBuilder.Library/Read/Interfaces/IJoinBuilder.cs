using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    public interface IJoinBuilder : ISqlScriptBuilder
    {
        //IJoinBuilder Join(string joinedTable, string tableSource, string field);

        //IJoinBuilder Join(string joinedTable, string joinedTableField, string tableSource, string tableSourceField);

        //IJoinBuilder Join(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField);

        //IJoinBuilder Join(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null);

        void SetAlias( string alias );
        void SetOtherConditions( string otherConditions );
    }
}