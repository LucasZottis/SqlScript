using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Interfaces
{
    public interface ISqlReadScriptBuilder : ISqlScriptBuilder
    {
        ISqlReadScriptBuilder Select( string field );
        ISqlReadScriptBuilder Select( string field, string value );
        ISqlReadScriptBuilder From( string table );
        ISqlReadScript Where( string condition );
    }
}