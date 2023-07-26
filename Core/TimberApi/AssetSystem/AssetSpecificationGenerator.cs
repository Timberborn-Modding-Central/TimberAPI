using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.AssetSystem
{
    public class AssetSpecificationGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            var json = JsonConvert.SerializeObject(new
            {
                IgnoreDirectoryPrefixes = Array.Empty<string>(),
            });
            
            yield return new GeneratedSpecification(json, "", "assetspecification");
        }
    }
}