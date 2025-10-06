namespace SqlScriptBuilder.Library.Read;

internal static class JoinTypeFactory
{
    public static JoinType InnerJoin()
    {
        return new JoinType( "inner" );
    }

    public static JoinType LeftJoin()
    {
        return new JoinType( "left" );
    }
}