using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class IsNullFunction : IFunction
{
    public string CheckExpression { get; set; }
    public string ReplacementValue { get; set; }
    public string? Alias { get; set; }

    public override string ToString()
    {
        var isNull = $"isnull( {CheckExpression}, {ReplacementValue} )";

        if (!string.IsNullOrWhiteSpace(Alias))
            isNull += $" as {Alias}";

        return isNull;
    }
}