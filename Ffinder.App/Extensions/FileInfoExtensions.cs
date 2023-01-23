using System;
using System.IO;
using ffinder.Infrastructure;

namespace ffinder.Extensions
{
    public static class FileInfoExtensions
    {
        public static FileTypes GetFileType(this FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                throw new System.ArgumentNullException(nameof(fileInfo));
            }

            var extension = Path.GetExtension(fileInfo.FullName);

            foreach(var iFileType in (FileTypes[])Enum.GetValues(typeof(FileTypes)))
            {
                if($".{iFileType.ToString().ToLower()}" == extension.ToLower())
                {
                    return iFileType;
                }
            }

            return FileTypes.Undefind;
        }
    }
}