namespace TimberApi.StyleSheetSystem
{
    public partial class StyleSheetBuilder
    {
        #region Single slice

        public StyleSheetBuilder AddNineSlicedBackground(string selector, string imagePath, float slice, float sliceScale)
        {
            AddSelector(selector, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));

            return this;
        }
 
        public StyleSheetBuilder AddNineSlicedBackgroundClass(string className, string imagePath, float slice, float sliceScale)
        {
            AddClass(className, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundClass(string className, string imagePath, float slice, float sliceScale, params PseudoClass[] pseudoClasses)
        {
            AddClass(className, pseudoClasses, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverClass(string className, string imagePath, string secondImagePath, float slice, float sliceScale)
        {
            AddClass(className, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));
            AddClass(className, new[] { PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverClass(string className, string imagePath, string secondImagePath, float slice, float sliceScale, PseudoClass additionalPseudoClass)
        {
            AddClass(className, new[] { additionalPseudoClass }, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));
            AddClass(className, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundType(SelectorType selectorType, string imagePath, float slice, float sliceScale)
        {
            AddType(selectorType, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundType(SelectorType selectorType, string imagePath, float slice, float sliceScale, params PseudoClass[] pseudoClasses)
        {
            AddType(selectorType, pseudoClasses, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath, float slice, float sliceScale)
        {
            AddType(selectorType, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));
            AddType(selectorType, new[] { PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath, float slice, float sliceScale, PseudoClass additionalPseudoClass)
        {
            AddType(selectorType, new[] { additionalPseudoClass }, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));
            AddType(selectorType, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundId(string idName, string imagePath, float slice, float sliceScale)
        {
            AddId(idName, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundId(string idName, string imagePath, float slice, float sliceScale, params PseudoClass[] pseudoClasses)
        {
            AddId(idName, pseudoClasses, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverId(string idName, string imagePath, string secondImagePath, float slice, float sliceScale)
        {
            AddId(idName, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));
            AddId(idName, new[] { PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, slice, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverId(string idName, string imagePath, string secondImagePath, float slice, float sliceScale, PseudoClass additionalPseudoClass)
        {
            AddId(idName, new[] { additionalPseudoClass }, builder => builder.AddNineSlicedBackgroundImage(imagePath, slice, sliceScale));
            AddId(idName, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, slice, sliceScale));

            return this;
        }

        #endregion

        #region Seperated slices

        public StyleSheetBuilder AddNineSlicedBackground(string selector, string imagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
        {
            AddSelector(selector, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
 
        public StyleSheetBuilder AddNineSlicedBackgroundClass(string className, string imagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
        {
            AddClass(className, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundClass(string className, string imagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale, params PseudoClass[] pseudoClasses)
        {
            AddClass(className, pseudoClasses, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverClass(string className, string imagePath, string secondImagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
        {
            AddClass(className, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));
            AddClass(className, new[] { PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverClass(string className, string imagePath, string secondImagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale, PseudoClass additionalPseudoClass)
        {
            AddClass(className, new[] { additionalPseudoClass }, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));
            AddClass(className, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundType(SelectorType selectorType, string imagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
        {
            AddType(selectorType, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundType(SelectorType selectorType, string imagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale, params PseudoClass[] pseudoClasses)
        {
            AddType(selectorType, pseudoClasses, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
        {
            AddType(selectorType, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));
            AddType(selectorType, new[] { PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale, PseudoClass additionalPseudoClass)
        {
            AddType(selectorType, new[] { additionalPseudoClass }, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));
            AddType(selectorType, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundId(string idName, string imagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
        {
            AddId(idName, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundId(string idName, string imagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale, params PseudoClass[] pseudoClasses)
        {
            AddId(idName, pseudoClasses, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverId(string idName, string imagePath, string secondImagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
        {
            AddId(idName, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));
            AddId(idName, new[] { PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }
        
        public StyleSheetBuilder AddNineSlicedBackgroundHoverId(string idName, string imagePath, string secondImagePath, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale, PseudoClass additionalPseudoClass)
        {
            AddId(idName, new[] { additionalPseudoClass }, builder => builder.AddNineSlicedBackgroundImage(imagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));
            AddId(idName, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddNineSlicedBackgroundImage(secondImagePath, sliceTop, sliceRight, sliceBottom, sliceLeft, sliceScale));

            return this;
        }

        #endregion
    }
}