using SqlScriptBuilder.Library.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read;

internal class FieldBuilder : ISqlScriptBuilder
{
    //private string _fieldAlias;
    private string? _tableName;
    private object _field;

    internal string? Alias { get; private set; }

    public FieldBuilder( object field )
    {
        _field = field;
    }

    private string BuildField()
    {
        switch ( _field )
        {
            case ISqlScriptBuilder sqlFunctionBuilder:
                return sqlFunctionBuilder.Build().GetScript();
            default:
                return _field.ToString() ?? string.Empty;
        }
    }

    internal FieldBuilder SetTableName( string tableName )
    {
        _tableName = tableName;
        return this;
    }

    internal FieldBuilder SetFieldAlias( string fieldAlias )
    {
        Alias = fieldAlias;
        return this;
    }

    public ISqlScript Build()
    {
        if ( !string.IsNullOrEmpty( _tableName ) )
        {
            var script = $"{_tableName}.{_field}";

            if ( !string.IsNullOrEmpty( Alias ) )
                script += $" AS {Alias}";

            return new SqlReadScript( script );
        }

        if ( !string.IsNullOrEmpty( Alias ) )
            return new SqlReadScript( $"{BuildField()} AS {Alias}" );

        return new SqlReadScript( $"{BuildField()}" );
    }
}