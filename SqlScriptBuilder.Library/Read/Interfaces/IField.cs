using SqlScriptBuilder.Library.Interfaces;

namespace SqlScriptBuilder.Library.Read.Interfaces
{
    internal interface IField : ISqlScript
    {
        public string? Alias { set; }
    }
}