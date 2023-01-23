using System.Collections.Generic;

namespace Ffinder.Domain
{
    public interface IPlugin : ICriterion
    {
         FileTypes FileType { get; }
         void SetParameters(IDictionary<string, object> parameters);
         IDictionary<string, string> ParameterDescriptions { get; }
    }
}