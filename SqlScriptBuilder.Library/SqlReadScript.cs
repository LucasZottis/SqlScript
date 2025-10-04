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

        public SqlReadScript( string script )
        {
            _script = new StringBuilder( script );
        }

        public string GetScript()
        {
            return _script.ToString();
        }
    }
}