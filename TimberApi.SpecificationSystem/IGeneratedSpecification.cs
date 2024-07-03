namespace TimberApi.SpecificationSystem;

public interface IGeneratedSpecification
{
    bool ObjectSpecification { get; }
    
    string SpecificationName { get; }
    
    string FullPath { get; }
    
    string Json { get; }
}