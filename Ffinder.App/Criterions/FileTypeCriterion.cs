using System.IO;
using ffinder.Extensions;
using ffinder.Infrastructure;

namespace ffinder.Criterions
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