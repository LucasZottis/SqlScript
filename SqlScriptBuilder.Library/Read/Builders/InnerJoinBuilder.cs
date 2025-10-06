using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class InnerJoinBuilder : JoinBuilder, IInnerJoinBuilder
{
    public InnerJoinBuilder() 
        : base(new InnerJoin()) { }
}