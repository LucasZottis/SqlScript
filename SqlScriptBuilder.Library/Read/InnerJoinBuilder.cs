using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read
{
    internal class InnerJoinBuilder : JoinBuilder, IInnerJoinBuilder
    {
        protected override string BuildJoin(Tuple<string, string, string, string, string, string> join)
        {
            var result = $"inner join {join.Item1}";
            var joinedTable = join.Item1;

            if (join.Item1 != join.Item2)
                joinedTable = join.Item2;

            result += $" on {joinedTable}.{join.Item3} = {join.Item4}.{join.Item5}";

            if (!string.IsNullOrEmpty(join.Item6))
                result += $" {join.Item6}";

            return result;
        }
    }
}