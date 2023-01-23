using System.Collections.Generic;
using Ffinder.Domain;

namespace Ffinder.Application
{
    public interface IPluginRepository
    {
         IEnumerable<IPlugin> GetPlugins();
    }
}