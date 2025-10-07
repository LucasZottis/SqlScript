using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class Condition : ISqlScript
{
    public ConditionCombiner? Combiner { private get; set; }
    public IField Field { get; set; }
    public ConditionalOperator Operator { get; set; }

    public Condition() : this( new Field() ) { }

    public Condition(IField field)
    {
        Field = field;
    }

    public override string ToString()
    {
        var sql = $"{Field.ToString()} {Operator.ToString()}";

        if ( Combiner is not null )
            sql = $"{Combiner.ToString()} {sql}";

        return sql;
    }
}