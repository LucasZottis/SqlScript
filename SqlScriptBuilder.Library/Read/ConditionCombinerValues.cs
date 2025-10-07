namespace SqlScriptBuilder.Library.Read;

internal static class ConditionCombinerValues
{
    public static string And { get; private set; } = "and";
    public static string Or { get; private set; } = "or";
    public static string Not { get; private set; } = "not";
}