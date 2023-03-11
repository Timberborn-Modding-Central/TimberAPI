using System;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarItemButton : IComparable<BottomBarItemButton>
    {
        public bool IsGroup { get; }

        public bool Hidden { get; }

        public int Order { get; }

        public BottomBarToolGroupButton? ToolGroup { get; }

        public BottomBarToolButton? Tool { get; }

        public BottomBarItemButton(BottomBarToolGroupButton toolGroup, int order, bool hidden)
        {
            IsGroup = true;
            ToolGroup = toolGroup;
            Order = order;
            Hidden = hidden;
        }

        public BottomBarItemButton(BottomBarToolButton tool, int order, bool hidden)
        {
            IsGroup = false;
            Tool = tool;
            Order = order;
            Hidden = hidden;
        }

        public int CompareTo(BottomBarItemButton other)
        {
            return Order.CompareTo(other.Order);
        }
    }
}