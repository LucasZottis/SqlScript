using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read;

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
        return new SqlReadScript( $"{ConditionalOperator} {SqlValueFormatter.Format( Value )}" );
    }
}