using System.Text;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    internal interface ISelectBuilder
    {
        ISelectBuilder AddField(string field);
        StringBuilder Build();
    }
}