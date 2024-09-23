using System;

namespace TimberApi.SpecificationSystem;

public class GeneratedObjectSpecificationAlreadyExistsException : Exception
{
    public GeneratedObjectSpecificationAlreadyExistsException(string fullPath)
        : base($"The given specification path was already generated \"{fullPath}\"")
    {
    }
}