using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read
{
    internal static class JoinType
    {
        public static IJoinBuilder InnerJoin => new InnerJoinBuilder();
        public static IJoinBuilder LeftJoin => new LeftJoinBuilder();
    }
}