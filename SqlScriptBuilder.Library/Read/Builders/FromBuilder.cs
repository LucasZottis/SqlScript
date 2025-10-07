using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;
using System.Text;

namespace SqlScriptBuilder.Library.Read.Builders
{
    internal class FromBuilder : IFromBuilder
    {
        private readonly ISqlReadScriptBuilder _sqlReadScriptBuilder;
        private readonly IList<ITableBuilder> _tableBuilders;
        private readonly IList<IJoinBuilder> _joinBuilders;

        internal FromBuilder()
        {
            _tableBuilders = [];
            _joinBuilders = [];
        }

        internal FromBuilder(ISqlReadScriptBuilder sqlReadScriptBuilder) : this()
        {
            _sqlReadScriptBuilder = sqlReadScriptBuilder;
        }

        private IFromBuilder AddTable(string table, string? alias)
        {
            var builder = new TableBuilder()
                .SetTableName(table);

            if (!string.IsNullOrEmpty(alias))
                builder.SetAlias(alias);

            _tableBuilders.Add(builder);

            return this;
        }

        private IFromBuilder AddJoin<TJoin>(string joinedTable, string joinedTableField, string tableSource, string tableSourceField, string? joinedTableAlias = null, string? otherConditions = null)
            where TJoin : IJoinBuilder, new()
        {
            var joinBuilder = new TJoin()
                .SetJoinedTable(joinedTable, joinedTableField, joinedTableAlias)
                .SetTableSource(tableSource, tableSourceField);

            if (!string.IsNullOrWhiteSpace(otherConditions))
                joinBuilder.SetOtherConditions(otherConditions);

            _joinBuilders.Add(joinBuilder);

            return this;

        }

        public ISqlScript Build()
        {
            return new FromSection
            {
                Tables = _tableBuilders.Select(t => t.Build()).ToList(),
                Joins = _joinBuilders.Select(t => t.Build()).ToList(),
            };
        }

        public IFromBuilder Table(string table)
        {
            return AddTable(table, null);
        }

        public IFromBuilder Table(string table, string alias)
        {
            return AddTable(table, alias);
        }

        public IFromBuilder InnerJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField, string? joinedTableAlias = null, string? otherConditions = null)
        {
            return AddJoin<InnerJoinBuilder>(joinedTable, joinedTableField, tableSource, tableSourceField, joinedTableAlias, otherConditions);
        }

        public IFromBuilder InnerJoin(string joinedTable, string joinedTableAlias, string tableSource, string fieldName, string? otherConditions = null)
        {
            return InnerJoin(joinedTable, fieldName, tableSource, fieldName, null, null);
        }

        public IFromBuilder InnerJoin(string joinedTable, string tableSource, string fieldName, string? otherConditions = null)
        {
            return InnerJoin(joinedTable, fieldName, tableSource, fieldName, null);
        }

        public IFromBuilder LeftJoin(string joinedTable, string tableSource, string fieldName, string? otherConditions = null)
        {
            return LeftJoin(joinedTable, fieldName, tableSource, fieldName, null, otherConditions);
        }

        public IFromBuilder LeftJoin(string joinedTable, string joinedTableAlias, string tableSource, string fieldName, string? otherConditions = null)
        {
            return LeftJoin(joinedTable, fieldName, tableSource, fieldName, joinedTableAlias, otherConditions);
        }

        public IFromBuilder LeftJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField, string? joinedTableAlias = null, string? otherConditions = null)
        {
            return AddJoin<LeftJoinBuilder>(joinedTable, joinedTableField, tableSource, tableSourceField, joinedTableAlias, otherConditions);
        }

        public IWhereBuilder Where()
        {
            return _sqlReadScriptBuilder.Where();
        }

        public IGroupByBuilder Group()
        {
            return _sqlReadScriptBuilder.GroupBy();
        }

        public IOrderByBuilder Order()
        {
            return _sqlReadScriptBuilder.OrderBy();
        }
    }
}