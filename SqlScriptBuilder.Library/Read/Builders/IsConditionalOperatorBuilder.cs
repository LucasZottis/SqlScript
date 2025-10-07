namespace SqlScriptBuilder.Library.Read.Builders;

internal class IsConditionalOperatorBuilder : ConditionalOperatorBuilder
{
    private readonly bool _denial;

    public IsConditionalOperatorBuilder( object? value, bool denial = false )
        : base( ConditionalOperatorValue.Is, value )
    {
        _denial = denial;
    }
}