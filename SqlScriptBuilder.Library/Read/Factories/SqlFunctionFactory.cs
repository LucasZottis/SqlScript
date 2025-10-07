using SqlScriptBuilder.Library.Read.Builders;

namespace SqlScriptBuilder.Library.Read.Factories
{
    public class SqlFunctionFactory
    {
        private SqlFunctionFactory() { }

        public static SqlFunctionBuilder IsNull( string checkExpression, string replacementValue, string? fieldAlias = null )
        {
            var function = new IsNullBuilder( 3 );

            function.SetArgument( nameof( checkExpression ), checkExpression );
            function.SetArgument( nameof( replacementValue ), replacementValue );

            if ( !string.IsNullOrEmpty( fieldAlias ) )
                function.SetArgument( nameof( fieldAlias ), fieldAlias );

            return function;
        }
    }
}