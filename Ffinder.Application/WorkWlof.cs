using System;
using System.IO;
using Ffinder.Domain;

namespace Ffinder.Application
{
    public static class WorkWlof
    {
        public static void Start(string path, bool reqursive, IFinder finder, IPluginRepository pluginRepository, IPluginValueRepository pluginValueRepository, Action<FileInfo> fileStream)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            
            if (finder == null)
            {
                throw new ArgumentNullException(nameof(finder));
            }

            if (pluginRepository == null)
            {
                throw new ArgumentNullException(nameof(pluginRepository));
            }

            if (pluginValueRepository == null)
            {
                throw new ArgumentNullException(nameof(pluginValueRepository));
            }

            if (fileStream == null)
            {
                throw new ArgumentNullException(nameof(fileStream));
            }

            var plugins = pluginRepository.GetPlugins();

            foreach(var iPlugin in plugins)
            {
                if(iPlugin.ParameterDescriptions != null)
                {
                    var parameters = pluginValueRepository.GetValues(iPlugin.ParameterDescriptions);

                    iPlugin.SetParameters(parameters);
                }
             }

            finder.FindStream += fileStream;

            finder.Find(path, reqursive, plugins);
        }
    }
}