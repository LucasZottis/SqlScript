using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library.Read
{
    public class OrderByBuilder : IOrderByBuilder
    {
        private readonly IList<string> _fields;

        public OrderByBuilder()
        {
            _fields = new List<string>();
        }

        public ISqlScript Build()
        {
            var script = new StringBuilder();

            if (_fields.Any())
                script.AppendLine("order by")
                    .AppendLine(string.Join(", ", _fields));

            return new SqlReadScript(script);
        }

        public IOrderByBuilder OrderBy(string field)
        {
            if (!_fields.Contains(field))
                _fields.Add(field);

            return this;
        }
    }
}