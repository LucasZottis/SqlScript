using System.Text;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    internal interface IFromBuilder
    {
        IFromBuilder AddTable( string table );
        StringBuilder Build();
    }
}