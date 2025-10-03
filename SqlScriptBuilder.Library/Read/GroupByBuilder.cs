using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    public class GroupByBuilder : IGroupByBuilder
    {
        private readonly IList<string> _fields;

        public GroupByBuilder()
        {
            _fields = new List<string>();
        }

        public ISqlScript Build()
        {
            var script = new StringBuilder();

            if (_fields.Any())
            {
                script.AppendLine("group by")
                    .AppendLine(string.Join(", ", _fields));
            }

            return new SqlReadScript(script);
        }

        public IGroupByBuilder GroupBy(string field)
        {
            if (!_fields.Contains(field))
                _fields.Add(field);
                
            return this;
        }
    }
}