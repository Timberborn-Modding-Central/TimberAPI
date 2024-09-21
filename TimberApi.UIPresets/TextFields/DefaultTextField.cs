using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;
using StyleValueType = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleValueType;
using WhiteSpace = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.WhiteSpace;

namespace TimberApi.UIPresets.TextFields;

public class DefaultTextField : DefaultTextField<DefaultTextField>
{
    protected override DefaultTextField BuilderInstance => this;
}

public abstract class DefaultTextField<TBuilder> : BaseBuilder<TBuilder, TextField>
    where TBuilder : BaseBuilder<TBuilder, TextField>
{
    protected TextFieldBuilder TextFieldBuilder = null!;

    protected string SizeClass = "";
    
    protected string MultiLineClass = "";
    
    public TBuilder MultiLine()
    {
        TextFieldBuilder.SetMultiLine(true);
        MultiLineClass = "api__default-text-field--multi-line";
        return BuilderInstance;
    }
    
    public TBuilder SetHeight(float height)
    {
        TextFieldBuilder.SetHeight(height);
        return BuilderInstance;
    }
    
    public TBuilder SetWidth(float width)
    {
        TextFieldBuilder.SetWidth(width);
        return BuilderInstance;
    }
    
    public TBuilder Large()
    {
        SizeClass = "api__default-text-field--large";
        return BuilderInstance;
    }
    
    public TBuilder SetTextAlign(TextAnchor textAnchor)
    {
        TextFieldBuilder.SetStyle(style => style.unityTextAlign = textAnchor);
        return BuilderInstance;
    }
    
    protected override TextField InitializeRoot()
    {
        TextFieldBuilder = UIBuilder.Create<TextFieldBuilder>()
            .AddClass("api__default-text-field");

        return TextFieldBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__default-text-field", builder => builder
                .NineSlicedBackgroundImage("UI/Images/Backgrounds/bg-input", 8, 0.5f)
            )
            .AddSelector(".api__default-text-field > .unity-base-field__input", builder => builder
                .PaddingX(2)
                .PaddingY(4)
                .Color(new Color(0.8f, 0.8f, 0.8f))
                .UnityTextAlign(UnityTextAlign.MiddleCenter)
                .UnityCursorColor(new Color(0.8f, 0.8f, 0.8f))
                .UnitySelectionColor(new Color(0.32f, 0.49f, 0.45f, 0.5f))
            )
            .AddSelector(".api__default-text-field:disabled", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-input-disabled", StyleValueType.ResourcePath)
                .Opacity(1)
            )
            .AddSelector(".api__default-text-field:hover:enabled", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-input-hover", StyleValueType.ResourcePath)
            )
            .AddSelector(".api__default-text-field--multi-line > .unity-base-field__input", builder => builder
                .WhiteSpace(WhiteSpace.Normal)
                .UnityTextAlign(UnityTextAlign.UpperLeft)
                .Height(100, Dimension.Unit.Percent)
            )
            .AddSelector(".api__default-text-field--large > .unity-base-field__input", builder => builder
                .Padding(5)
            );
    }

    public override TextField Build()
    {
        if(! string.IsNullOrWhiteSpace(MultiLineClass))
        {
            TextFieldBuilder.AddClass(MultiLineClass);
        }
        
        if(! string.IsNullOrWhiteSpace(SizeClass))
        {
            TextFieldBuilder.AddClass(SizeClass);
        }
        
        return TextFieldBuilder
            .Build();
    }
}