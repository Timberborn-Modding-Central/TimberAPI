using System;

namespace TimberApi.UIPresets.ListViews.Exceptions;

public class DefaultListViewMakeItemHasNotBeenSet : Exception
{
    public DefaultListViewMakeItemHasNotBeenSet() : base("The `DefaultListView` requires `SetMakeItem` to be set within the building process.")
    {
    }
}