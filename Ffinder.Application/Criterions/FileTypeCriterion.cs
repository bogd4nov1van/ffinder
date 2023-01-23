using System.IO;
using Ffinder.Domain;

namespace Ffinder.Application
{
    public class FileTypeCriterion : ICriterion
    {
        public FileTypeCriterion(FileTypes fileType)
        {
            FileType = fileType;
        }
        public FileTypes FileType { get; }

        public bool Check(FileInfo file)
        {
            return FileType == file.GetFileType();
        }
    }
}