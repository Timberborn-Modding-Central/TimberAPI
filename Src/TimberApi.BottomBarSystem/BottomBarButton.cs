using System;
using Timberborn.SerializationSystem;

namespace TimberApi.BottomBarSystem;

public class BottomBarButton(
    string id,
    bool isGroup,
    string? groupId,
    bool hidden,
    int order,
    ObjectSave? buttonInformation)
    : IComparable<BottomBarButton>
{
    public string Id { get; } = id;

    public bool IsGroup { get; } = isGroup;

    public string? GroupId { get; } = groupId;

    public bool Hidden { get; } = hidden;

    public int Order { get; } = order;

    public ObjectSave? ButtonInformation { get; } = buttonInformation;

    public int CompareTo(BottomBarButton other)
    {
        return Order.CompareTo(other.Order);
    }
}