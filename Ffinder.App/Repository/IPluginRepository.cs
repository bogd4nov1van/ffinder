using System.Collections.Generic;
using ffinder.Infrastructure;

namespace ffinder.Repository
{
    public interface IPluginRepository
    {
         IEnumerable<IPlugin> GetPlugins();
    }
}