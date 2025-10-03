using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal class FromBuilder : IFromBuilder
    {
        private IList<string> _tables;

        public FromBuilder()
        {
            _tables = new List<string>();
        }

        public IFromBuilder From( string table )
        {
            if ( !_tables.Contains( table ) )
            {
                _tables.Add( table );
            }

            return this;
        }

        public ISqlScript Build()
        {
            var result = new StringBuilder();

            if ( _tables.Any() )
            {
                result.AppendLine( "FROM" )
                    .AppendLine( string.Join( ", ", _tables ) );
            }

            return new SqlReadScript( result );
        }
    }
}