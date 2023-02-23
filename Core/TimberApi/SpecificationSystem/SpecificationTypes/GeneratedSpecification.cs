﻿namespace TimberApi.SpecificationSystem.SpecificationTypes
{
    internal class GeneratedSpecification : ISpecification
    {
        private readonly string _json;

        public GeneratedSpecification(string json, string name, string specificationName)
        {
            _json = json;
            Name = name;
            SpecificationName = specificationName.ToLower();
            FullName = $"{SpecificationName}.{name.ToLower()}";
            IsOriginal = true;
            IsReplace = false;
        }

        public string Name { get; }

        public string SpecificationName { get; }

        public string FullName { get; }

        public bool IsOriginal { get; }

        public bool IsReplace { get; }

        public string LoadJson()
        {
            return _json;
        }
    }
}