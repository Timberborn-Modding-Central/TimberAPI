using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem.StylingElements
{
    public struct Padding
    {
        public Length Top;
        public Length Right;
        public Length Bottom;
        public Length Left;

        public Padding(Length padding)
        {
            Top = padding;
            Right = padding;
            Bottom = padding;
            Left = padding;
        }

        public Padding(Length paddingX, Length paddingY)
        {
            Top = paddingY;
            Bottom = paddingY;
            Left = paddingX;
            Right = paddingX;
        }

        public Padding(Length top, Length right, Length bottom, Length left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
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
}