using System.Collections.Generic;
using ffinder.Infrastructure;

namespace ffinder.Repository
{
    public interface IPluginValueRepository
    {
         IDictionary<string, object> GetValues(IDictionary<string, string> descriptions);
    }
}