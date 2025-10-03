using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal abstract class JoinBuilder : IJoinBuilder
    {
        /// <summary>
        /// Field 1: JoinedTable
        /// Field 2: JoinedTableAlias
        /// Field 3: JoinedTableField
        /// Field 3: TableSource
        /// Field 4: TableSourceField
        /// </summary>
        protected IList<Tuple<string, string, string, string, string, string>> Joins { get; private set; }

        public JoinBuilder()
        {
            Joins = new List<Tuple<string, string, string, string, string, string>>();
        }

        private IEnumerable<string> GetJoins()
        {
            if (!Joins.Any())
                return [];

            return Joins.Select(join => BuildJoin(join));
        }

        protected abstract string BuildJoin(Tuple<string, string, string, string, string, string> join);

        public ISqlScript Build()
        {
            var script = new StringBuilder();
            var joins = GetJoins();

            foreach (var join in joins)
                script.AppendLine(join);

            return new SqlReadScript(script);
        }

        public IJoinBuilder Join(string joinedTable, string tableSource, string field)
        {
            return Join(joinedTable, field, tableSource, field);
        }

        public IJoinBuilder Join(string joinedTable, string joinedTableField, string tableSource, string tableSourceField)
        {
            return Join(joinedTable, joinedTable, joinedTableField, tableSource, tableSourceField);
        }

        public IJoinBuilder Join(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField)
        {
            Joins.Add(new(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, null));

            return this;
        }

        public IJoinBuilder Join(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null)
        {
            Joins.Add(new(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, otherConditions));

            return this;
        }
    }
}