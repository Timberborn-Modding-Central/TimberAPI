using TimberApi.UIPresets.Labels;
using TimberApi.UIPresets.ListViews;
using Timberborn.CoreUI;

namespace Tester;

public class MyListItem : DefaultListViewItemWrapper
{
    protected override NineSliceVisualElement InitializeRoot()
    {
        base.InitializeRoot();
        VisualElementBuilder.SetWidth(200);
        VisualElementBuilder.AddComponent<GameTextLabel>(label => label.SetText("First item"));
        return VisualElementBuilder.Build();
    }
}