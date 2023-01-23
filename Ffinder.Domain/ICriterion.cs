using System.IO;

namespace ffinder.Infrastructure
{
    public interface ICriterion
    {
         bool Check(FileInfo fileInfo);
    }
}