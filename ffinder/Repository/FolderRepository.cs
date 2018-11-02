using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ffinder.Infrastructure;

namespace ffinder.Repository
{
    public class FolderRepository : IPluginRepository
    {
        private readonly string _path;
        public FolderRepository(string path)
        {
            if (path == null)
            {
                throw new System.ArgumentNullException(nameof(path));
            }

            _path = path;
        }

        public IEnumerable<IPlugin> GetPlugins()
        {
            foreach(var iFile in Directory.GetFiles(_path))
            {
                if(iFile.Contains("*.dll"))
                {
                    var dll = Assembly.LoadFile(iFile);

                    foreach(var iType in dll.GetExportedTypes())
                    {
                        if(iType.GetInterfaces().Contains(typeof(IPlugin)))
                        {
                            yield return Activator.CreateInstance(iType) as IPlugin;
                        }
                    }
                }
            }
        }
    }
}