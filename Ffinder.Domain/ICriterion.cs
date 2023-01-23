using System.IO;

namespace Ffinder.Domain
{
    public interface ICriterion
    {
         bool Check(FileInfo fileInfo);
    }
}