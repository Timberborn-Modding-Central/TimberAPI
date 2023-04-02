using System;
using Timberborn.WorldSerialization;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarButton : IComparable<BottomBarButton>
    {
        public string Id { get; }

        public bool IsGroup { get; }

        public string? GroupId { get; }

        public bool Hidden { get; }

        public int Order { get; }

        public ObjectSave? ButtonInformation { get; }

        public BottomBarButton(string id, bool isGroup, string? groupId, bool hidden, int order, ObjectSave? buttonInformation)
        {
            Id = id;
            IsGroup = isGroup;
            GroupId = groupId;
            Hidden = hidden;
            Order = order;
            ButtonInformation = buttonInformation;
        }

        public int CompareTo(BottomBarButton other)
        {
            return Order.CompareTo(other.Order);
        }
    }
}