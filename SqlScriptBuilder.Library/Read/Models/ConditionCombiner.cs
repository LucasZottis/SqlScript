namespace SqlScriptBuilder.Library.Read.Models;

public class ConditionCombiner
{
    private readonly string _combiner;

    protected ConditionCombiner(string combiner)
    {
        _combiner = combiner ?? throw new ArgumentNullException(nameof(combiner));
    }

    public override string ToString()
    {
        return _combiner;
    }
}