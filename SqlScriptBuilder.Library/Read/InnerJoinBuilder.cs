using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read;

internal class InnerJoinBuilder : JoinBuilder, IInnerJoinBuilder
{
    public InnerJoinBuilder( string joinedTable, string joinedTableField, string tableSource, string tableSourceField ) 
        : base( joinedTable, joinedTableField, tableSource, tableSourceField ) 
    { 
        JoinType = JoinTypeFactory.GetInnerJoin();
    }
}