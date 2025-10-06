using SqlScriptBuilder.Library;
using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read;

namespace SqlScriptBuilder
{
    internal class Program
    {
        static void Main( string[] args )
        {
            var script = ExampleTwo();
            var sql = script.GetScript();

            Console.WriteLine( sql.ToUpper() );
            Console.ReadLine();
        }

        private static ISqlScript ExampleZero()
        {
            var abstractFactory = new SqlScriptBuilderAbstractFactory();
            var factory = abstractFactory.CreateReadFactory();
            var builder = factory.CreateSqlReadScriptBuilder();

            builder.Select().Field( "getdate()" );

            var script = builder.Build();
            return script;
        }

        private static ISqlScript ExampleOne()
        {
            var abstractFactory = new SqlScriptBuilderAbstractFactory();
            var factory = abstractFactory.CreateReadFactory();
            var builder = factory.CreateSqlReadScriptBuilder();

            builder.Select()
                .Field( "registrationdate" )
                .Field( "name" )
                .From()
                .Table( "ship" )
                .Group()
                .By( "registrationdate" )
                .By( "name" )
                .Order()
                .By( "registrationdate" )
                .By( "name desc" );

            var script = builder.Build();

            return script;
        }

        private static ISqlScript ExampleTwo()
        {
            var abstractFactory = new SqlScriptBuilderAbstractFactory();
            var factory = abstractFactory.CreateReadFactory();
            var builder = factory.CreateSqlReadScriptBuilder();

            builder.Select()
                .Field( "Pessoa", "COD_PESSOA" )
                .Field( "PESSOA", "NOM_PESSOA", "nom_cliente" )
                .Field( "PESSOA_JURIDICA", "NOM_FANTASIA" )
                .Field( SqlFunctionFactory.IsNull( "PESSOA_JURIDICA.CNPJ_PESSOA", "PESSOA_FISICA.CPF_PESSOA", "CNPJ_CPF" ) )
                .Field( "ENDERECO", "CEL_ENDERECO" )
                .Field( "ENDERECO", "TEL_ENDERECO" )
                .Field( "ENDERECO", "EMAIL_ENDERECO" )
                .Field( "ENDERECO", "DES_LOGRADOURO" )
                .Field( "ENDERECO", "DES_BAIRRO" )
                .Field( "ENDERECO", "DES_CIDADE" )
                .Field( "ENDERECO", "SIGLA_ESTADO" )
                .From()
                .Table( "PESSOA" )
                .InnerJoin( "CLIENTE", "COD_CLIENTE", "PESSOA", "COD_PESSOA" )
                .LeftJoin( "PESSOA_JURIDICA", "PESSOA", "COD_PESSOA" )
                .LeftJoin( "PESSOA_FISICA", "PESSOA", "COD_PESSOA" )
                .InnerJoin( "ENDERECO", "ENDERECO", "COD_PESSOA", "PESSOA", "COD_PESSOA", "AND TIP_ENDERECO = 0" )
                .InnerJoin( "CIDADE", "ENDERECO", "COD_CIDADE" )
                .InnerJoin( "ESTADO", "CIDADE", "COD_ESTADO" )
                .Where()
                .Condition( "pessoa", "cod_pessoa", ConditionalOperatorBuilderFactory.Equal(5) )
                .GreaterThan( "pessoa", "cod_pessoa", 1 )
                .GreaterOrEqualThan( "pessoa", "cod_pessoa", 2 )
                .Equal( "pessoa", "cod_pessoa", 5 )
                .LessOrEqualThan( "pessoa", "cod_pessoa", 3 )
                .LessThan( "pessoa", "cod_pessoa", 4 )
                .Different( "pessoa", "cod_pessoa", 6 )
                .Like( "pessoa", "NOM_PESSOA", "Antonio%" )
                .NotLike( "pessoa", "NOM_PESSOA", "%Souza" )
                .In( "pessoa", "cod_pessoa", Enumerable.Range(1, 5), true )
                .NotIn( "pessoa", "cod_pessoa", Enumerable.Range( 1, 3 ), true )
                .Between( "pessoa", "dat_cadastro", new DateTime( 2025, 09, 01 ), new DateTime( 2025, 09, 30 ) );
            //.OrderBy( "PESSOA.NOM_PESSOA" )
            //.Build();

            var script = builder.Build();

            return script;
        }
    }
}