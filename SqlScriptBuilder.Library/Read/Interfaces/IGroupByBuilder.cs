using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

public interface IGroupByBuilder : ISqlScriptBuilder
{
    IGroupByBuilder By(string field);

    IOrderByBuilder Order();
}