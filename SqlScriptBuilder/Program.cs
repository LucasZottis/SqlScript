using SqlScriptBuilder.Library;
using SqlScriptBuilder.Library.Enums;
using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder
{
    internal class Program
    {
        static void Main( string[] args )
        {
            var factory = new SqlScriptBuilderFactory();
            var builder = factory.CreateRead();
            var script = builder
                .Select( "guid" )
                .Select("registrationdate")
                .Select( "name" )
                .From( "ship" )
                .Build();

            Console.WriteLine( script.GetScript().ToUpper() );
        }
    }
}
