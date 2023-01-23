using System.Collections.Generic;

namespace Ffinder.Application
{
    public interface IPluginValueRepository
    {
         IDictionary<string, object> GetValues(IDictionary<string, string> descriptions);
    }
}