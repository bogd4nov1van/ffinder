using System.Collections.Generic;
using System.IO;
using Ffinder.Domain;

namespace Ffinder.Plugins
{
    public class ContainsFileNamePlugin : PluginBase
    {        
        private const string _parameterName = "subString"; 
        private Dictionary<string, string> _descriptions = new Dictionary<string, string>()
        {
            { _parameterName, "Подстрака" }
        };

        public override FileTypes FileType => FileTypes.Txt;
        public override IDictionary<string, string> ParameterDescriptions => _descriptions;

        protected override bool Check(FileInfo fileInfo, IDictionary<string, object> parameters = null)
        {
            if (fileInfo == null)
            {
                throw new System.ArgumentNullException(nameof(fileInfo));
            }

            if (parameters == null)
            {
                throw new System.ArgumentNullException(nameof(parameters));
            }

            var paramValue = parameters[_parameterName].ToString();

            return fileInfo.Name.Contains(paramValue);
        }
    }
}