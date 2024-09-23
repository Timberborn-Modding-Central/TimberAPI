using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.StylingElements;

public struct Padding(Length top, Length right, Length bottom, Length left)
{
    public Length Top = top;
    public Length Right = right;
    public Length Bottom = bottom;
    public Length Left = left;

    public Padding(Length padding) : this(padding, padding, padding, padding)
    {
    }

    public Padding(Length paddingX, Length paddingY) : this(paddingY, paddingX, paddingY, paddingX)
    {
    }

    public static implicit operator Padding(int value)
    {
        return new Padding(value);
    }

    public static implicit operator Padding(Length value)
    {
        return new Padding(value);
    }
}