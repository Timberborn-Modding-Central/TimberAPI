using System;

namespace TimberApi.SpecificationSystem;

public class GeneratedObjectSpecAlreadyExistsException(string fullPath)
    : Exception($"The given spec path was already generated \"{fullPath}\"");