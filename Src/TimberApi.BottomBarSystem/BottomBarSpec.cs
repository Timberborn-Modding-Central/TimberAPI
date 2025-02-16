using Timberborn.BlueprintSystem;

namespace TimberApi.BottomBarSystem;

public record BottomBarSpec : ComponentSpec
{
    [Serialize(true)]
    public int Section { get; init; } = 1;
}