namespace SqlScriptBuilder.Library.Read.Models;

internal class LeftJoin : Join
{
    public LeftJoin() : base(JoinTypeFactory.LeftJoin()) { }
}