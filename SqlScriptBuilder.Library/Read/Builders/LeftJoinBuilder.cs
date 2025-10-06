using SqlScriptBuilder.Library.Read.Builders;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read;

internal class LeftJoinBuilder : JoinBuilder, ILeftJoinBuilder
{
    public LeftJoinBuilder()
        : base(new LeftJoin()) { }
}