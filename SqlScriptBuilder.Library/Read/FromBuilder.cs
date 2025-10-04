using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal class FromBuilder : IFromBuilder
    {
        private readonly ISqlReadScriptBuilder _sqlReadScriptBuilder;
        private readonly IList<string> _tables;
        private readonly IList<IJoinBuilder> _joinBuilders;

        internal FromBuilder()
        {
            _tables = new List<string>();
            _joinBuilders = new List<IJoinBuilder>();
        }

        internal FromBuilder( ISqlReadScriptBuilder sqlReadScriptBuilder) : this()
        {
            _sqlReadScriptBuilder = sqlReadScriptBuilder;
        }

        private IFromBuilder AddTable(string table)
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
                    script.AppendLine(joinBuilder.Build().GetScript());

            return new SqlReadScript(script);
        }

        public IFromBuilder Table( string table )
        {
            return AddTable( table );
        }

        public IGroupByBuilder Group()
        {
            return _sqlReadScriptBuilder.GroupBy();
        }

        public IOrderByBuilder Order()
        {
            return _sqlReadScriptBuilder.OrderBy();
        }

        public IFromBuilder InnerJoin( string joinedTable, string joinedTableField, string tableSource, string tableSourceField, string? joinedTableAlias = null, string? otherConditions = null )
        {
            var joinBuilder = new InnerJoinBuilder(
                joinedTable,
                joinedTableField,
                tableSource,
                tableSourceField
            );

            if ( !string.IsNullOrWhiteSpace( joinedTableAlias ) )
                joinBuilder.SetAlias( joinedTableAlias );

            if ( !string.IsNullOrWhiteSpace( otherConditions ) )
                joinBuilder.SetOtherConditions( otherConditions );

            _joinBuilders.Add( joinBuilder );

            return this;
        }

        public IFromBuilder InnerJoin( string joinedTable, string tableSource, string fieldName, string? otherConditions = null )
        {
            return InnerJoin( joinedTable, fieldName, tableSource, fieldName, null, otherConditions );
        }

        public IFromBuilder InnerJoin( string joinedTable, string joinedTableAlias, string tableSource, string fieldName, string? otherConditions = null )
        {
            return InnerJoin( joinedTable, fieldName, tableSource, fieldName, joinedTableAlias, otherConditions );
        }

        public IFromBuilder LeftJoin( string joinedTable, string tableSource, string fieldName, string? otherConditions = null )
        {
            return LeftJoin( joinedTable, fieldName, tableSource, fieldName, null, otherConditions );
        }

        public IFromBuilder LeftJoin( string joinedTable, string joinedTableAlias, string tableSource, string fieldName, string? otherConditions = null )
        {
            return LeftJoin( joinedTable, fieldName, tableSource, fieldName, joinedTableAlias, otherConditions );
        }

        public IFromBuilder LeftJoin( string joinedTable, string joinedTableField, string tableSource, string tableSourceField, string? joinedTableAlias = null, string? otherConditions = null )
        {
            var joinBuilder = new LeftJoinBuilder(
                joinedTable,
                joinedTableField,
                tableSource,
                tableSourceField
            );

            if ( !string.IsNullOrWhiteSpace( joinedTableAlias ) )
                joinBuilder.SetAlias( joinedTableAlias );

            if ( !string.IsNullOrWhiteSpace( otherConditions ) )
                joinBuilder.SetOtherConditions( otherConditions );

            _joinBuilders.Add( joinBuilder );

            return this;
        }
    }
}