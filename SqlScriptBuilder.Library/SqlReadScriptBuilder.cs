using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library
{
    internal class SqlReadScriptBuilder : ISqlReadScriptBuilder
    {
        private ISelectBuilder _selectBuilder;
        private IFromBuilder _fromBuilder;
        private IFromBuilder _whereBuilder;

        public ISqlScript Build()
        {
            ISqlScript selectScript = null;
            ISqlScript fromscript = null;
            ISqlScript? whereScript = null;

            if ( _selectBuilder == null )
                throw new InvalidOperationException( "No fields selected. Use the Select() method to add fields." );

            if ( _fromBuilder == null )
                throw new InvalidOperationException( "No tables selected. Use the From() method to add tables." );

            selectScript = _selectBuilder.Build();
            fromscript = _fromBuilder.Build();

            if ( _whereBuilder != null )
                whereScript = _whereBuilder.Build();

            var script = new StringBuilder()
                .Append( selectScript.GetScript() )
                .Append( fromscript.GetScript() );

            if ( whereScript != null )
                script.Append( whereScript.GetScript() );

            return new SqlReadScript( script );
        }

        public ISqlReadScriptBuilder From( string table )
        {
            if ( _fromBuilder == null )
                _fromBuilder = new FromBuilder();

            _fromBuilder.From( table );

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