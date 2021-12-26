using UnityEngine.UIElements;

namespace TimberbornAPI.Common
{
    public struct Margin
    {
        public Length Top;
        public Length Right;
        public Length Bottom;
        public Length Left;
        
        public Margin(Length padding)
        {
            Top = padding;
            Right = padding;
            Bottom = padding;
            Left = padding;
        }

        public Margin(Length paddingX, Length paddingY)
        {
            Top = paddingY;
            Bottom = paddingY;
            Left = paddingX;
            Right = paddingX;
        }

        public Margin(Length top, Length right, Length bottom, Length left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }
        
        public static implicit operator Margin(int value) {
            return new Margin(value);
        }
        
        public static implicit operator Margin(Length value) {
            return new Margin(value);
        }
    }
}