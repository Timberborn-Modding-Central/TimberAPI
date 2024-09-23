using System;

namespace TimberApi.SpecificationSystem;

public class GeneratedObjectSpecificationAlreadyExistsException(string fullPath)
    : Exception($"The given specification path was already generated \"{fullPath}\"");