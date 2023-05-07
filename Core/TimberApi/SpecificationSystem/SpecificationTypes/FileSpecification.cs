using System.IO;

namespace TimberApi.SpecificationSystem.SpecificationTypes
{
    internal class FileSpecification : ISpecification
    {
        public FileSpecification(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            FilePath = filePath;
            FullName = fileName.Replace(".original", "").Replace(".replace", "").ToLower();
            Name = FullName[(FullName.IndexOf('.') + 1)..].ToLower();
            SpecificationName = fileName[..fileName.IndexOf('.')].ToLower();
            IsOriginal = fileName.ToLower().EndsWith("original");
            IsReplace = fileName.ToLower().EndsWith("replace");
        }

        public string Name { get; }

        public string SpecificationName { get; }


        private string FilePath { get; }

        public string FullName { get; }

        public bool IsOriginal { get; }

        public bool IsReplace { get; }

        public string LoadJson()
        {
            return File.ReadAllText(FilePath);
        }
    }
}