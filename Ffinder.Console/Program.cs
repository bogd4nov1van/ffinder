﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ffinder.Domain;

namespace Ffinder.Console
{
    
    class Program
    {
        class PluginRepo : IPluginRepository
        {
            public IEnumerable<IPlugin> GetPlugins()
            {
                return new Collection<IPlugin>()
                {
                    new ContainsFileNamePlugin(),
                    new EqualsFileTypePlugin()
                };
            }
        }

        class PlugValueRepo : IPluginValueRepository
        {
            public IDictionary<string, object> GetValues(IDictionary<string, string> descriptions)
            {
                var result = new Dictionary<string, object>();

                foreach(var iDesc in descriptions)
                {
                    if(iDesc.Key == "typeFile")
                    {
                        result.Add(iDesc.Key, FileTypes.Txt);
                    }
                    else
                    {
                        Console.WriteLine($"Введите {iDesc.Value}");
                        var value = Console.ReadLine();
                        result.Add(iDesc.Key, value);
                    }
                }

                return result;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь:");
            var path = Console.ReadLine();

            Console.WriteLine("Производить ли поиск в подкаталогах? y - да");
            var reqursive = Console.ReadKey().Key == ConsoleKey.Y ? true : false;

            WorkWlof.Start(path, 
                           reqursive, 
                           new Finder(), 
                           new PluginRepo(), 
                           new PlugValueRepo(), 
                           (fileInfo) => Console.WriteLine(fileInfo.FullName));    
        }
    }
}
