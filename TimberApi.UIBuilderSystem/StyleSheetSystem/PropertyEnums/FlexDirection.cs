using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum FlexDirection
{
    Row,
    RowReverse,
    Column,
    ColumnReverse
}

public static class FlexDirectionExtension
{
    private static readonly Dictionary<FlexDirection, string> EnumValueMapper = new()
    {
        { FlexDirection.Row, "row" },
        { FlexDirection.RowReverse, "row-reverse" },
        { FlexDirection.Column, "column" },
        { FlexDirection.ColumnReverse, "column-reverse" },
    };
    
    public static string ToUnityString(this FlexDirection alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}