using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ffinder.Infrastructure
{
    public interface IFinder
    {
         event Action<FileInfo> FindStream; 
         void Find(string path, bool reqursive, IEnumerable<ICriterion> criterions);
         void Pause();
         void Continue();
         void Abort();
    }
}