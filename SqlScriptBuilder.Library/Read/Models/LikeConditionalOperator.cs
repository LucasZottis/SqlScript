namespace SqlScriptBuilder.Library.Read.Models;

internal class LikeConditionalOperator : ConditionalOperator
{
    public bool Denial { private get; set; }

    public LikeConditionalOperator( string value ) 
        : base( ConditionalOperatorValue.Like, value ) { }

    public override string ToString()
    {
        return $"{( Denial ? "not " : "" )}{Operator} '{Value}'";
    }
}