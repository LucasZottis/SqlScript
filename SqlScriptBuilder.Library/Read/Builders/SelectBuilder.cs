using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Builders
{
    internal class SelectBuilder : ISelectBuilder
    {
        private readonly ISqlReadScriptBuilder _sqlReadScriptBuilder;
        private IList<FieldBuilder> _fields;

        internal SelectBuilder()
        {
            _fields = new List<FieldBuilder>();
        }

        public SelectBuilder( ISqlReadScriptBuilder sqlReadScriptBuilder ) : this()
        {
            _sqlReadScriptBuilder = sqlReadScriptBuilder;
        }

        private bool CheckFieldExists( string alias )
        {
            return _fields.Any( f => f.Alias == alias );
        }

        private ISelectBuilder AddField( object field, string? fieldAlias = null, string? tableName = null )
        {
            if ( !CheckFieldExists( fieldAlias ?? field.ToString() ?? string.Empty ) )
            {
                var fieldBuilder = new FieldBuilder( field );

                if ( !string.IsNullOrEmpty( fieldAlias ) )
                    fieldBuilder.SetFieldAlias( fieldAlias );

                if ( !string.IsNullOrEmpty( tableName ) )
                    fieldBuilder.SetTableName( tableName );

                _fields.Add( fieldBuilder );
            }

            return this;
        }

        public ISelectBuilder Field( string field )
        {
            var parts = field.Split( '.' );

            if ( parts.Length == 2 )
                throw new ArgumentException(
                    "Field cannot contain table alias. Use Field(string tableAlias, string field, string fieldAlias) or Field(string tableAlias, string field) methods instead."
                );

            return AddField( field );
        }

        public ISelectBuilder Field( SqlFunctionBuilder sqlFunctionBuilder )
        {
            var fieldName = sqlFunctionBuilder.GetFieldAlias();

            if ( string.IsNullOrEmpty( fieldName ) )
                throw new ArgumentException( "Field alias is required when using SqlFunctionBuilder in SELECT section." );

            return AddField( sqlFunctionBuilder );
        }

        public ISelectBuilder Field( object field, string fieldAlias )
        {
            if ( string.IsNullOrEmpty( fieldAlias ) )
                throw new ArgumentNullException( nameof( fieldAlias ) );

            return AddField( field, fieldAlias );
        }

        public ISelectBuilder Field( string tableAlias, string field )
        {
            var parts = field.Split( " AS " );

            if ( parts.Length == 2 )
                throw new ArgumentException(
                    "Field cannot contain field alias. Use Field(string tableAlias, string field, string fieldAlias) method instead."
                );

            return AddField( field, null, tableAlias );
        }

        public ISelectBuilder Field( string tableAlias, string field, string fieldAlias )
        {
            if ( string.IsNullOrEmpty( tableAlias ) )
                throw new ArgumentNullException( nameof( tableAlias ) );

            if ( string.IsNullOrEmpty( fieldAlias ) )
                throw new ArgumentNullException( nameof( fieldAlias ) );

            return AddField( field, fieldAlias, tableAlias );
        }

        public IFromBuilder From()
        {
            return _sqlReadScriptBuilder.From();
        }

        public ISqlScript Build()
        {
            var selectSection = new SelectSection();

            foreach (var builder in _fields)
                selectSection.AddField((IField)builder.Build());

            return selectSection;
        }
    }
}