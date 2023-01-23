using System;
using System.Collections.Generic;
using System.IO;

namespace Ffinder.Domain
{
    public abstract class PluginBase : IPlugin
    {
        private IDictionary<string, object> _parameters;

        protected abstract bool Check(FileInfo fileInfo, IDictionary<string, object> parameters = null);

        public abstract FileTypes FileType { get; }

        public abstract IDictionary<string, string> ParameterDescriptions { get; }

        public bool Check(FileInfo fileInfo)
        {
            return Check(fileInfo, _parameters);
        }
       
        public void SetParameters(IDictionary<string, object> parameters)
        {
            if (ParameterDescriptions == null)
            {
                throw new ArgumentException("У плагина отсутствуют параметры.", nameof(parameters));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            foreach(var iParameter in parameters)
            {
                if(!ParameterDescriptions.ContainsKey(iParameter.Key))
                {
                    throw new ArgumentException($"Неправильно указан параметр. [{iParameter.Key}]");
                }

                if(iParameter.Value == null)
                {
                    throw new ArgumentNullException(nameof(iParameter.Key));
                }
            }

            _parameters = parameters;
        }
    }
}