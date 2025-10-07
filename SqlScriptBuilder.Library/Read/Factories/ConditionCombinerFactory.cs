using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Factories;

public static class ConditionCombinerFactory
{
    public static ConditionCombiner And()
        => new ConditionCombinerAnd();

    public static ConditionCombiner Or()
        => new ConditionCombinerOr();

    public static ConditionCombiner Not()
        => new ConditionCombinerNot();
}