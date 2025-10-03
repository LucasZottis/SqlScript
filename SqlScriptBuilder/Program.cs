using SqlScriptBuilder.Library;
using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder
{
    internal class Program
    {
        static void Main( string[] args )
        {
            var script = ExampleTwo();
            Console.WriteLine( script.GetScript().ToUpper() );
            Console.ReadKey();
        }

        private static ISqlScript ExampleOne()
        {
            var factory = new SqlScriptBuilderFactory();
            var builder = factory.CreateRead();
            var script = builder
                .Select("guid")
                .Select("registrationdate")
                .Select("name")
                .From("ship")
                .Where($"guid = '{Guid.NewGuid()}'")
                .Where("and name = 'NVT GKT'")
                .GroupBy("name")
                .GroupBy("registrationdate")
                .OrderBy("registrationdate")
                .OrderBy("lastupdatedate desc")
                .Build();

            return script;
        }

        private static ISqlScript ExampleTwo()
        {
            var factory = new SqlScriptBuilderFactory();
            var builder = factory.CreateRead();
            var script = builder
                .Select("PESSOA.COD_PESSOA")
                .Select("PESSOA.NOM_PESSOA")
                .Select("PESSOA_JURIDICA.NOM_FANTASIA")
                .SelectIsNull("PESSOA_JURIDICA.CNPJ_PESSOA", "PESSOA_FISICA.CPF_PESSOA", "CNPJ_CPF")
                .Select("ENDERECO.CEL_ENDERECO")
                .Select("ENDERECO.TEL_ENDERECO")
                .Select("ENDERECO.EMAIL_ENDERECO")
                .Select("ENDERECO.DES_LOGRADOURO")
                .Select("ENDERECO.DES_BAIRRO")
                .Select("ENDERECO.DES_CIDADE")
                .Select("ENDERECO.SIGLA_ESTADO")
                .From("PESSOA")
                .InnerJoin("CLIENTE", "COD_CLIENTE", "PESSOA", "COD_PESSOA")
                .LeftJoin("PESSOA_JURIDICA", "PESSOA", "COD_PESSOA")
                .LeftJoin("PESSOA_FISICA", "PESSOA", "COD_PESSOA")
                .InnerJoin("ENDERECO", "ENDERECO", "COD_PESSOA", "PESSOA", "COD_PESSOA", "AND TIP_ENDERECO = 0")
                .InnerJoin("CIDADE", "ENDERECO", "COD_CIDADE")
                .InnerJoin("ESTADO", "CIDADE", "COD_ESTADO")
                .OrderBy("PESSOA.NOM_PESSOA")
                .Build();

            return script;
        }
    }
}