using SqlScriptBuilder.Library.Interfaces;
using System.Text;

namespace SqlScriptBuilder.Library
{
    public class SqlReadScript : ISqlReadScript
    {
        private StringBuilder _script;

        public SqlReadScript( StringBuilder script )
        {
            _script = script;
        }

        public override string ToString()
        {
            return _script.ToString();
        }
    }
}