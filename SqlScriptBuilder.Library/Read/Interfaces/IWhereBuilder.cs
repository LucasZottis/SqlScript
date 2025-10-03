using SqlScriptBuilder.Library.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    internal interface IWhereBuilder : ISqlScriptBuilder
    {
        IWhereBuilder Where( string table );
        ISqlScript Build();
    }
}