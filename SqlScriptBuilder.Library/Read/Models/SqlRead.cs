namespace SqlScriptBuilder.Library.Read.Models
{
    internal class SqlRead : SqlScript
    {
        public object SelectSection { private get; set; }
        public object? FromSection { private get; set; }
        public object? WhereSection { private get; set; }
        public object? GroupBySection { get; set; }
        public object? OrderBySection { get; set; }
    }
}