using UnityEngine;

namespace TimberApi.SpecificationSystem.SpecificationTypes
{
    internal class TimberbornSpecification : ISpecification
    {
        public TimberbornSpecification(TextAsset specificationAsset)
        {
            var name = specificationAsset.name;
            FullName = name.ToLower();
            Name = FullName[(FullName.IndexOf('.') + 1)..].ToLower();
            SpecificationAsset = specificationAsset;
            SpecificationName = name[..name.IndexOf('.')].ToLower();
            IsOriginal = true;
            IsReplace = false;
        }

        private TextAsset SpecificationAsset { get; }

        public string Name { get; }

        public string SpecificationName { get; }

        public string FullName { get; }

        public bool IsOriginal { get; }

        public bool IsReplace { get; }

        public string LoadJson()
        {
            return SpecificationAsset.text;
        }
    }
}