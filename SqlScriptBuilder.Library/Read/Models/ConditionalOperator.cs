using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class ConditionalOperator : ISqlScript
{
    protected string Operator { get; private set; }
    protected object Value { get; private set; }

    public ConditionalOperator(string operatorValue, object value)
    {
        Operator = operatorValue;
        Value = value ?? throw new ArgumentNullException( nameof( value ) );
    }

    public override string ToString()
    {
        return $"{Operator} {SqlValueFormatter.Format( Value )}";
    }
}