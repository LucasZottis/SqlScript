namespace SqlScriptBuilder.Library.Read.Models;

internal class InnerJoin : Join
{
    public InnerJoin() : base(JoinTypeFactory.InnerJoin()) { }
}
