namespace SqlScriptBuilder.Library.Read;

internal class JoinType
{
    private readonly string _type;

    public JoinType( string type)
    {
        _type = type;
    }

    public override string ToString()
    {
        return _type;
    }
}