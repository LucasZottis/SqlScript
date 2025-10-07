using SqlScriptBuilder.Library.Read.Factories;

namespace SqlScriptBuilder.Library.Read.Models;

internal class InnerJoin : Join
{
    public InnerJoin() : base(JoinTypeFactory.InnerJoin()) { }

    public override string ToString()
    {
        return base.ToString();
    }
}
