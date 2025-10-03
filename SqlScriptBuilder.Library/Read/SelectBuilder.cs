using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal class SelectBuilder : ISelectBuilder
    {
        private IDictionary<string, string> _fields;

        public SelectBuilder()
        {
            _fields = new Dictionary<string, string>();
        }

        private IEnumerable<string> GetFields()
        {
            return _fields.Select( f =>
            {
                if ( f.Key == f.Value )
                {
                    return f.Key;
                }

                return $"{f.Key} AS {f.Value}";
            } );
        }

        public ISelectBuilder AddField( string field )
        {
            return AddField( field, field );
        }

        private ISelectBuilder AddField( string field, string value )
        {
            if ( !_fields.ContainsKey( field ) )
            {
                _fields.Add( field, value );
            }

            return this;
        }

        public StringBuilder Build()
        {
            var script = new StringBuilder();
            var fields = GetFields();

            script.AppendLine( "SELECT" );
            script.AppendLine( string.Join( ", ", fields ) );

            return script;
        }
    }
}