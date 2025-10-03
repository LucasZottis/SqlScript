using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    public interface IOrderByBuilder : ISqlScriptBuilder
    {
        IOrderByBuilder OrderBy(string field);
    }
}