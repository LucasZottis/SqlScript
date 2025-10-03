using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal class WhereBuilder : IWhereBuilder
    {
        private IDictionary<string, string> _conditions;

        private IEnumerable<string> GetConditions()
        {
            return _conditions.Select( f =>
            {
                if ( f.Key == f.Value )
                {
                    return f.Key;
                }

                return $"{f.Key} AS {f.Value}";
            } );
        }

        public ISqlScript Build()
        {
            var script = new StringBuilder();
            var conditions = GetConditions();

            script.AppendLine( "Where" )
                .AppendLine( string.Join( ", ", conditions ) );

            return new SqlReadScript( script );
        }

        public IWhereBuilder Where( string table )
        {
            return this;
        }
    }
}