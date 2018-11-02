using System.Collections.Generic;
using System.IO;

namespace ffinder.Infrastructure
{
    public interface IPlugin : ICriterion
    {
         FileTypes FileType { get; }
         void SetParameters(IDictionary<string, object> parameters);
         IDictionary<string, string> ParameterDescriptions { get; }
    }
}