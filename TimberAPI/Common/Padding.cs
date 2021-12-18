using UnityEngine.UIElements;

namespace TimberbornAPI.Common
{
    public class Padding
    {
        public Length Top;
        public Length Right;
        public Length Bottom;
        public Length Left;

        public Padding()
        {
            Top = 0;
            Right = 0;
            Bottom = 0;
            Left = 0;
        }

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
    }
}