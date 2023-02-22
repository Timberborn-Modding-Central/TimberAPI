using System.Collections.Generic;
using Timberborn.Persistence;

namespace TimberApi.SpecificationSystem
{
    public interface IApiSpecificationService : ISpecificationService
    {
        IEnumerable<T> GetSpecifications<T>(string specificationName, IObjectSerializer<T> serializer);
    }
}