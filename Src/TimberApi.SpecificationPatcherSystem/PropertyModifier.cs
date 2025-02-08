namespace TimberApi.SpecificationPatcherSystem;

internal class PropertyModifier(string modifier, string argument)
{
    public string Modifier { get; } = modifier;

    public string Argument { get; } = argument;
}