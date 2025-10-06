using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Models;

internal class Condition : ISqlScript
{
    public string? Combiner { private get; set; }
    public Field Field { get; set; }

    public Condition()
    {
        Field = new Field();
    }

    //public Condition(Function function)
    //{

    //}
}