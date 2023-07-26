using System.IO;
using UnityEngine;

namespace TimberApi.SpecificationSystem.SpecificationTypes
{
    internal class FileSpecification : ISpecification
    {
        public FileSpecification(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            FilePath = filePath;
            FullName = fileName.Replace(".original", "").Replace(".replace", "").ToLower();
            
            if(FullName.Contains('.'))
            {
                Name = FullName[(FullName.IndexOf('.') + 1)..].ToLower();
                SpecificationName = fileName[..fileName.IndexOf('.')].ToLower();
            }
            else
            {
                Name = "";
                SpecificationName = FullName[(FullName.IndexOf('.') + 1)..].ToLower();
            }
            
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