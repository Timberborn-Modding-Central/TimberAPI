using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem
{
    public struct Margin
    {
        public Length Top;
        public Length Right;
        public Length Bottom;
        public Length Left;

        public Margin(Length margin)
        {
            Top = margin;
            Right = margin;
            Bottom = margin;
            Left = margin;
        }

        public Margin(Length marginX, Length marginY)
        {
            Top = marginY;
            Bottom = marginY;
            Left = marginX;
            Right = marginX;
        }

        public Margin(Length top, Length right, Length bottom, Length left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
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
}