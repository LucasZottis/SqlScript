namespace SqlScriptBuilder.Library.Read.Interfaces;

public interface ISqlReadScriptBuilderFactory
{
    ISqlReadScriptBuilder CreateSqlReadScriptBuilder();

    ISelectBuilder CreateSelectBuilder();

    IFromBuilder CreateFromBuilder();

    IGroupByBuilder CreateGroupByBuilder();

    IOrderByBuilder CreateOrderByBuilder();
}