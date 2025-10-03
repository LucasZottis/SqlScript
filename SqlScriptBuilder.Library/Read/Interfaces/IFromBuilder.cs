using SqlScriptBuilder.Library.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    internal interface IFromBuilder : ISqlScriptBuilder
    {
        IFromBuilder From( string table );
    }
}