namespace SqlScriptBuilder.Library.Read;

internal static class JoinTypeFactory
{
    public static JoinType GetInnerJoin()
    {
        return new JoinType( "inner" );
    }

    public static JoinType GetLeftJoin()
    {
        return new JoinType( "left" );
    }
}