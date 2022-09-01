using System.IO;

namespace TimberApi.Internal.SpecificationSystem.SpecificationTypes
{
    public class FileSpecification : ISpecification
    {
        public FileSpecification(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            FilePath = filePath;
            FullName = fileName.Replace(".original", "").ToLower();
            SpecificationName = fileName[..fileName.IndexOf('.')].ToLower();
            IsOriginal = fileName.ToLower().EndsWith("original");
        }

        private string FilePath { get; }

        public string FullName { get; }

        public string SpecificationName { get; }

        public bool IsOriginal { get; }

        public string LoadJson()
        {
            return File.ReadAllText(FilePath);
        }
    }
}