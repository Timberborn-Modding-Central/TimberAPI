using Timberborn.BlueprintSystem;

namespace TimberApi.BottomBarSystem;

public record BottomBarSpec : ComponentSpec
{
    [Serialize]
    public int Section { get; init; } = 1;
}