using SqlScriptBuilder.Library.Read.Builders;
using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read.Factories;

internal class SqlReadScriptBuilderFactory : ISqlReadScriptBuilderFactory
{
    public SqlReadScriptBuilderFactory() { }

    public IFromBuilder CreateFromBuilder()
    {
        return new FromBuilder();
    }

    public IGroupByBuilder CreateGroupByBuilder()
    {
        return new GroupByBuilder();
    }

    public IOrderByBuilder CreateOrderByBuilder()
    {
        return new OrderByBuilder();
    }

    public ISelectBuilder CreateSelectBuilder()
    {
        return new SelectBuilder();
    }

    public ISqlReadScriptBuilder CreateSqlReadScriptBuilder()
    {
        return new SqlReadScriptBuilder();
    }
}