using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;

namespace SqlScriptBuilder.Library.Read
{
    internal abstract class JoinBuilder : IJoinBuilder
    {
        protected string JoinedTable { get; private set; }
        protected string? JoinedTableAlias { get; private set; }
        protected string JoinedTableField { get; private set; }
        protected string TableSource { get; private set; }
        protected string TableSourceField { get; private set; }
        protected string? OtherConditions { get; private set; }
        protected JoinType JoinType { get; set; }

        public JoinBuilder( string joinedTable, string joinedTableField, string tableSource, string tableSourceField )
        {
            JoinedTable = joinedTable;
            JoinedTableField = joinedTableField;
            TableSource = tableSource;
            TableSourceField = tableSourceField;
            ValidateJoin();
        }

        private void ValidateJoin()
        {
            if ( string.IsNullOrWhiteSpace( JoinedTable ) )
                throw new ArgumentException( "Joined table is required." );

            if ( string.IsNullOrWhiteSpace( JoinedTableField ) )
                throw new ArgumentException( "Joined table field is required." );

            if ( string.IsNullOrWhiteSpace( TableSource ) )
                throw new ArgumentException( "Table source is required." );

            if ( string.IsNullOrWhiteSpace( TableSourceField ) )
                throw new ArgumentException( "Table source field is required." );
        }

        public ISqlScript Build()
        {
            var script = $"{JoinType} join {JoinedTable} ";
            var joinedTable = JoinedTable;

            if ( !string.IsNullOrEmpty( JoinedTableAlias ) && JoinedTable != JoinedTableAlias )
            {
                joinedTable = JoinedTableAlias;
                script += $"as {joinedTable} ";
            }

            script += $"on {joinedTable}.{JoinedTableField} = {TableSource}.{TableSourceField}";

            if ( !string.IsNullOrEmpty( OtherConditions ) )
                script += $" {OtherConditions}";

            return new SqlReadScript( script );
        }

        public void SetAlias( string alias )
        {
            if ( string.IsNullOrWhiteSpace( alias ) )
                throw new ArgumentException( "Alias cannot be null or whitespace.", nameof( alias ) );

            JoinedTableAlias = alias;
        }

        public void SetOtherConditions( string otherConditions )
        {
            if ( string.IsNullOrWhiteSpace( otherConditions ) )
                throw new ArgumentException( "Other conditions cannot be null or whitespace.", nameof( otherConditions ) );

            OtherConditions = otherConditions;
        }
    }
}