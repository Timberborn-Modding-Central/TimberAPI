using System;

namespace TimberApi.BottomBarSystem;

public class BottomBarButton(
    BottomBarSpec bottomBarSpec,
    string id,
    bool isGroup,
    string? groupId,
    bool hidden,
    int order)
    : IComparable<BottomBarButton>
{
    public BottomBarSpec? BottomBarSpec { get; } = bottomBarSpec;
    
    public string Id { get; } = id;

    public bool IsGroup { get; } = isGroup;

    public string? GroupId { get; } = groupId;

    public bool Hidden { get; } = hidden;

    public int Order { get; } = order;
    public int CompareTo(BottomBarButton other)
    {
        return Order.CompareTo(other.Order);
    }
}