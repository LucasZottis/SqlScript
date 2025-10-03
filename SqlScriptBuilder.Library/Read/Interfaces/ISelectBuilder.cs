using SqlScriptBuilder.Library.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    internal interface ISelectBuilder : ISqlScriptBuilder
    {
        ISelectBuilder AddField(string field);
        ISelectBuilder AddIsNull(string checkExpression, string replacementValue, string fieldName);
    }
}