using System;
using System.Collections.Generic;
using System.IO;
using Ffinder.Domain;
using Ffinder.Domain.Extensions;

namespace Ffinder.Plugins
{
    public class EqualsFileTypePlugin : PluginBase
    {        
        private const string _parameterName = "typeFile"; 
        private Dictionary<string, string> _descriptions = new Dictionary<string, string>()
        {
            { _parameterName, "Тип файла" }
        };

        public override FileTypes FileType { get; }
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

            if(parameters.ContainsKey(_parameterName) && parameters[_parameterName] is FileTypes fileType)
            {
                return fileInfo.GetFileType() == fileType;
            }
            
            throw new ArgumentException("Неправильно указан параметр.");
        }
    }
}