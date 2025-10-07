using SqlScriptBuilder.Library.Read.Factories;
using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library;

public class SqlScriptBuilderAbstractFactory
{
    //private readonly SqlScriptOperation _sqlScriptOperation;

    //public SqlScriptBuilderFactory( SqlScriptOperation sqlScriptOperation )
    //{
    //    _sqlScriptOperation = sqlScriptOperation;
    //}

    //public ISqlScriptBuilder Create()
    //{
    //    return _sqlScriptOperation switch
    //    {
    //        //SqlScriptOperation.Create => new SqlCreateScript(),
    //        SqlScriptOperation.Read => new SqlReadScriptBuilder(),
    //        //SqlScriptOperation.Update => new SqlUpdateScript(),
    //        //SqlScriptOperation.Delete => new SqlDeleteScript(),
    //        _ => throw new NotImplementedException()
    //    };
    //}

    public ISqlReadScriptBuilderFactory CreateReadFactory()
    {
        return new SqlReadScriptBuilderFactory();
    }
}