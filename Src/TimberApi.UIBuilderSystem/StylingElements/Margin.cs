using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.StylingElements;

public struct Margin(Length top, Length right, Length bottom, Length left)
{
    public Length Top = top;
    public Length Right = right;
    public Length Bottom = bottom;
    public Length Left = left;

    public Margin(Length margin) : this(margin, margin, margin, margin)
    {
    }

    public Margin(Length marginX, Length marginY) : this(marginY, marginX, marginY, marginX)
    {
    }

    public static implicit operator Margin(int value)
    {
        return new Margin(value);
    }

    public static implicit operator Margin(Length value)
    {
        return new Margin(value);
    }
}