using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

public class ConditionalOperatorBuilder : ISqlScriptBuilder
{
    protected string ConditionalOperator { get; private set; }
    protected object Value { get; private set; }

    public ConditionalOperatorBuilder( string conditionalOperator, object value )
    {
        ConditionalOperator = conditionalOperator ?? throw new ArgumentNullException( nameof( conditionalOperator ) );
        Value = value ?? throw new ArgumentNullException( nameof( value ) );
    }

    public virtual ISqlScript Build()
    {
        return new ConditionalOperator(ConditionalOperator, Value );
    }
}