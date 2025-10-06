using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read;

internal class LeftJoinBuilder : JoinBuilder, ILeftJoinBuilder
{
    public LeftJoinBuilder( string joinedTable, string joinedTableField, string tableSource, string tableSourceField ) 
        : base( joinedTable, joinedTableField, tableSource, tableSourceField ) 
    { 
        JoinType = JoinTypeFactory.GetLeftJoin();
    }
}