using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ffinder.Infrastructure;

namespace ffinder
{
    public class Finder : IFinder
    {
        private bool _paused;
        private bool _abort;
        public event Action<FileInfo> FindStream;

        public void Find(string path, bool reqursive, IEnumerable<ICriterion> criterions)
        {
            if (path == null)
            {
                throw new System.ArgumentNullException(nameof(path));
            }

            if (criterions == null || !criterions.Any())
            {
                throw new System.ArgumentException(nameof(criterions));
            }

            foreach (var iFile in Directory.GetFiles(path))
            {
                while (_paused && !_abort)
                {
                    Thread.Sleep(100);
                }

                if (_abort)
                {
                    break;
                }

                var fileInfo = new FileInfo(iFile);

                if (criterions.All(x => x.Check(fileInfo)))
                {
                    FindStream?.Invoke(fileInfo);
                }
            }

            if (reqursive)
            {
                foreach(var iDirectory in Directory.GetDirectories(path))
                {
                    Find(iDirectory, reqursive, criterions);
                }
            }
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Continue()
        {
            _paused = false;
        }

        public void Abort()
        {
            _abort = true;
        }
    }
}