using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces;

public interface ISqlReadScriptBuilder : ISqlScriptBuilder
{
    ISelectBuilder Select();
    IFromBuilder From();
    IWhereBuilder Where();
    IGroupByBuilder GroupBy();
    IOrderByBuilder OrderBy();
}