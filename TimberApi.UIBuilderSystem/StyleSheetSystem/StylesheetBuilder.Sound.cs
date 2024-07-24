using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public partial class StyleSheetBuilder
{
    public StyleSheetBuilder AddClickSound(string selector, string sound)
    {
        AddSelector(selector, builder => builder.Add(Property.ClickSound, sound, StyleValueType.String));

        return this;
    }

    public StyleSheetBuilder AddClickSoundClass(string className, string sound)
    {
        AddClass(className, builder => builder.Add(Property.ClickSound, sound, StyleValueType.String));

        return this;
    }
}