using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal class WhereBuilder : IWhereBuilder
    {
        //private IDictionary<string, string> _conditions;
        private IList<string> _conditions;

        public WhereBuilder()
        {
            _conditions = new List<string>();
        }

        private IEnumerable<string> GetConditions()
        {
            //return _conditions.Select( f =>
            //{
            //    if ( f.Key == f.Value )
            //    {
            //        return f.Key;
            //    }

            //    return $"{f.Key} AS {f.Value}";
            //} );

            return _conditions;
        }

        public ISqlScript Build()
        {
            var script = new StringBuilder();
            var conditions = GetConditions();

            script.AppendLine("Where");

            foreach (var condition in conditions)
                script.AppendLine(condition);

            return new SqlReadScript( script );
        }

        public IWhereBuilder Where(string condition)
        {
            _conditions.Add(condition);
            return this;
        }
    }
}