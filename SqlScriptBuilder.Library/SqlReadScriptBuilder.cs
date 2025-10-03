using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library
{
    internal class SqlReadScriptBuilder : ISqlReadScriptBuilder
    {
        //private IDictionary<string, string> _fields;
        //private IList<string> _tables;

        private ISelectBuilder _selectBuilder;
        private IFromBuilder _fromBuilder;

        //public SqlReadScriptBuilder()
        //{
        //    _fields = new Dictionary<string, string>();
        //    _tables = new List<string>();
        //}

        //private string GetFields()
        //{
        //    return string.Join( ", ", _fields.Select( f => $"{f.Key} AS {f.Value}" ) );
        //}

        public ISqlScript Build()
        {
            if ( _selectBuilder == null )
                throw new InvalidOperationException( "No fields selected. Use the Select() method to add fields." );

            if ( _selectBuilder == null )
                throw new InvalidOperationException( "No fields selected. Use the Select() method to add fields." );

            var script = new StringBuilder()
                .Append( _selectBuilder.Build() )
                .Append( _fromBuilder.Build() );

            return new SqlReadScript( script );
        }

        public ISqlReadScriptBuilder From( string table )
        {
            if ( _fromBuilder == null )
                _fromBuilder = new FromBuilder();
            //if ( !_tables.Contains( table ) )
            //{
            //    _tables.Add( table );
            //}

            return this;
        }

        public ISqlReadScriptBuilder Select( string field )
        {
            return Select( field, field );
        }

        public ISqlReadScriptBuilder Select( string field, string value )
        {
            if ( _selectBuilder == null )
                _selectBuilder = new SelectBuilder();

            _selectBuilder.AddField( field );

            return this;
        }
    }
}