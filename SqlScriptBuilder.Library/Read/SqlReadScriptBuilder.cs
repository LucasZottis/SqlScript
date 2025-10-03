using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    internal class SqlReadScriptBuilder : ISqlReadScriptBuilder
    {
        private ISelectBuilder _selectBuilder;
        private IFromBuilder _fromBuilder;
        private IWhereBuilder _whereBuilder;
        private IGroupByBuilder _groupByBuilder;
        private IOrderByBuilder _orderByBuilder;

        private void CheckSelectBuilderIsNull()
        {
            if (_selectBuilder == null)
                _selectBuilder = new SelectBuilder();
        }

        private void CheckFromBuilderIsNull()
        {
            if (_fromBuilder == null)
                _fromBuilder = new FromBuilder();
        }

        public ISqlScript Build()
        {
            ISqlScript selectScript = null;
            ISqlScript fromScript = null;
            ISqlScript? whereScript = null;
            ISqlScript? groupByScript = null;
            ISqlScript? orderByscript = null;

            if (_selectBuilder == null)
                throw new InvalidOperationException("No fields selected. Use the Select() method to add fields.");

            if (_fromBuilder == null)
                throw new InvalidOperationException("No tables selected. Use the From() method to add tables.");

            selectScript = _selectBuilder.Build();
            fromScript = _fromBuilder.Build();

            if (_whereBuilder != null)
                whereScript = _whereBuilder.Build();

            if (_groupByBuilder != null)
                groupByScript = _groupByBuilder.Build();

            if (_orderByBuilder != null)
                orderByscript = _orderByBuilder.Build();

            var script = new StringBuilder()
                .Append(selectScript.GetScript())
                .Append(fromScript.GetScript());

            if (whereScript != null)
                script.Append(whereScript.GetScript());

            if (groupByScript != null)
                script.Append(groupByScript.GetScript());

            if (orderByscript != null)
                script.Append(orderByscript.GetScript());

            return new SqlReadScript(script);
        }

        public ISqlReadScriptBuilder From(string table)
        {
            CheckFromBuilderIsNull();
            _fromBuilder.From(table);
            return this;
        }

        public ISqlReadScriptBuilder GroupBy(string field)
        {
            if (_groupByBuilder == null)
                _groupByBuilder = new GroupByBuilder();

            _groupByBuilder.GroupBy(field);

            return this;
        }

        public ISqlReadScriptBuilder OrderBy(string field)
        {
            if (_orderByBuilder == null)
                _orderByBuilder = new OrderByBuilder();

            _orderByBuilder.OrderBy(field);

            return this;
        }

        public ISqlReadScriptBuilder Select(string field)
        {
            return Select(field, field);
        }

        public ISqlReadScriptBuilder Select(string field, string value)
        {
            CheckSelectBuilderIsNull();
            _selectBuilder.AddField(field);
            return this;
        }

        public ISqlReadScriptBuilder SelectIsNull(string checkExpression, string replacementValue, string fieldName)
        {
            CheckSelectBuilderIsNull();
            _selectBuilder.AddIsNull(checkExpression, replacementValue, fieldName);
            return this;
        }

        public ISqlReadScriptBuilder Where(string condition)
        {
            if (_whereBuilder == null)
                _whereBuilder = new WhereBuilder();

            _whereBuilder.Where(condition);

            return this;
        }

        public ISqlReadScriptBuilder InnerJoin(string joinedTable, string tableSource, string field)
        {
            return InnerJoin(joinedTable, field, tableSource, field);
        }

        public ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField)
        {
            return InnerJoin(joinedTable, joinedTable, joinedTableField, tableSource, tableSourceField);
        }

        public ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField)
        {
            return InnerJoin(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, null);
        }

        public ISqlReadScriptBuilder InnerJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null)
        {
            CheckFromBuilderIsNull();
            _fromBuilder.Join(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, JoinType.InnerJoin, otherConditions);
            return this;
        }

        public ISqlReadScriptBuilder LeftJoin(string joinedTable, string tableSource, string field)
        {
            return LeftJoin(joinedTable, field, tableSource, field);
        }

        public ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableField, string tableSource, string tableSourceField)
        {
            return LeftJoin(joinedTable, joinedTable, joinedTableField, tableSource, tableSourceField);
        }

        public ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField)
        {
            return LeftJoin(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, null);
        }

        public ISqlReadScriptBuilder LeftJoin(string joinedTable, string joinedTableAlias, string joinedTableField, string tableSource, string tableSourceField, string otherConditions = null)
        {
            CheckFromBuilderIsNull();
            _fromBuilder.Join(joinedTable, joinedTableAlias, joinedTableField, tableSource, tableSourceField, JoinType.LeftJoin, otherConditions);
            return this;
        }

    }
}