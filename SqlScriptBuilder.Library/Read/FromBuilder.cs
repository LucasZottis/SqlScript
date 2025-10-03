using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal class FromBuilder : IFromBuilder
    {
        private readonly IList<string> _tables;
        private readonly IList<IJoinBuilder> _joinBuilders;

        public FromBuilder()
        {
            _tables = new List<string>();
            _joinBuilders = new List<IJoinBuilder>();
        }

        public IFromBuilder From(string table)
        {
            if (!_tables.Contains(table))
                _tables.Add(table);

            return this;
        }

        public ISqlScript Build()
        {
            var script = new StringBuilder();

            if (_tables.Any())
                script.AppendLine("FROM")
                    .AppendLine(string.Join(", ", _tables));

            if (_joinBuilders.Any())
                foreach (var joinBuilder in _joinBuilders)
                    script.Append(joinBuilder.Build().GetScript());

            return new SqlReadScript(script);
        }

        public IFromBuilder Join(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, IJoinBuilder joinBuilder, string otherConditions = null)
        {
            joinBuilder.Join(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, otherConditions);
            _joinBuilders.Add(joinBuilder);
            return this;
        }
    }
}