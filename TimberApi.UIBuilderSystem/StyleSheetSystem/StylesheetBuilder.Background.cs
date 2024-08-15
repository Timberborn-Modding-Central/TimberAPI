using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public partial class StyleSheetBuilder
{
    public StyleSheetBuilder AddBackground(string selector, string imagePath)
    {
        AddSelector(selector, builder => builder.BackgroundImage(imagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundClass(string className, string imagePath)
    {
        AddClass(className, builder => builder.BackgroundImage(imagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundClass(string className, string imagePath, params PseudoClass[] pseudoClasses)
    {
        AddClass(className, pseudoClasses, builder => builder.BackgroundImage(imagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundHoverClass(string className, string imagePath, string secondImagePath)
    {
        AddClass(className, builder => builder.BackgroundImage(imagePath));
        AddClass(className, new[] { PseudoClass.Hover }, builder => builder.BackgroundImage(secondImagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundHoverClass(string className, string imagePath, string secondImagePath,
        PseudoClass additionalPseudoClass)
    {
        AddClass(className, new[] { additionalPseudoClass }, builder => builder.BackgroundImage(imagePath));
        AddClass(className, new[] { additionalPseudoClass, PseudoClass.Hover },
            builder => builder.BackgroundImage(secondImagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundType(SelectorType selectorType, string imagePath)
    {
        AddType(selectorType, builder => builder.BackgroundImage(imagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundType(SelectorType selectorType, string imagePath,
        params PseudoClass[] pseudoClasses)
    {
        AddType(selectorType, pseudoClasses, builder => builder.BackgroundImage(imagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath)
    {
        AddType(selectorType, builder => builder.BackgroundImage(imagePath));
        AddType(selectorType, new[] { PseudoClass.Hover }, builder => builder.BackgroundImage(secondImagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath,
        PseudoClass additionalPseudoClass)
    {
        AddType(selectorType, new[] { additionalPseudoClass }, builder => builder.BackgroundImage(imagePath));
        AddType(selectorType, new[] { additionalPseudoClass, PseudoClass.Hover },
            builder => builder.BackgroundImage(secondImagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundId(string idName, string imagePath)
    {
        AddId(idName, builder => builder.BackgroundImage(imagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundId(string idName, string imagePath, params PseudoClass[] pseudoClasses)
    {
        AddId(idName, pseudoClasses, builder => builder.BackgroundImage(imagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundHoverId(string idName, string imagePath, string secondImagePath)
    {
        AddId(idName, builder => builder.BackgroundImage(imagePath));
        AddId(idName, new[] { PseudoClass.Hover }, builder => builder.BackgroundImage(secondImagePath));

        return this;
    }

    public StyleSheetBuilder AddBackgroundHoverId(string idName, string imagePath, string secondImagePath,
        PseudoClass additionalPseudoClass)
    {
        AddId(idName, new[] { additionalPseudoClass }, builder => builder.BackgroundImage(imagePath));
        AddId(idName, new[] { additionalPseudoClass, PseudoClass.Hover },
            builder => builder.BackgroundImage(secondImagePath));

        return this;
    }
}