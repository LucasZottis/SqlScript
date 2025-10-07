using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Builders;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    public interface ISelectBuilder : ISqlScriptBuilder
    {
        ISelectBuilder Field( string field );
        ISelectBuilder Field( object field, string fieldAlias );
        ISelectBuilder Field( string tableAlias, string field );
        ISelectBuilder Field( string tableAlias, string field, string fieldAlias );
        ISelectBuilder Field( SqlFunctionBuilder sqlFunctionBuilder );

        IFromBuilder From();
    }
}