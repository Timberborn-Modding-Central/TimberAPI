namespace TimberApi.StyleSheetSystem
{
    public partial class StyleSheetBuilder
    {
        public StyleSheetBuilder AddBackground(string selector, string imagePath)
        {
            AddSelector(selector, builder => builder.AddBackgroundImage(imagePath));

            return this;
        }
 
        public StyleSheetBuilder AddBackgroundClass(string className, string imagePath)
        {
            AddClass(className, builder => builder.AddBackgroundImage(imagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundClass(string className, string imagePath, params PseudoClass[] pseudoClasses)
        {
            AddClass(className, pseudoClasses, builder => builder.AddBackgroundImage(imagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundHoverClass(string className, string imagePath, string secondImagePath)
        {
            AddClass(className, builder => builder.AddBackgroundImage(imagePath));
            AddClass(className, new[] { PseudoClass.Hover }, builder => builder.AddBackgroundImage(secondImagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundHoverClass(string className, string imagePath, string secondImagePath, PseudoClass additionalPseudoClass)
        {
            AddClass(className, new[] { additionalPseudoClass }, builder => builder.AddBackgroundImage(imagePath));
            AddClass(className, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddBackgroundImage(secondImagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundType(SelectorType selectorType, string imagePath)
        {
            AddType(selectorType, builder => builder.AddBackgroundImage(imagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundType(SelectorType selectorType, string imagePath, params PseudoClass[] pseudoClasses)
        {
            AddType(selectorType, pseudoClasses, builder => builder.AddBackgroundImage(imagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath)
        {
            AddType(selectorType, builder => builder.AddBackgroundImage(imagePath));
            AddType(selectorType, new[] { PseudoClass.Hover }, builder => builder.AddBackgroundImage(secondImagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundHoverType(SelectorType selectorType, string imagePath, string secondImagePath, PseudoClass additionalPseudoClass)
        {
            AddType(selectorType, new[] { additionalPseudoClass }, builder => builder.AddBackgroundImage(imagePath));
            AddType(selectorType, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddBackgroundImage(secondImagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundId(string idName, string imagePath)
        {
            AddId(idName, builder => builder.AddBackgroundImage(imagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundId(string idName, string imagePath, params PseudoClass[] pseudoClasses)
        {
            AddId(idName, pseudoClasses, builder => builder.AddBackgroundImage(imagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundHoverId(string idName, string imagePath, string secondImagePath)
        {
            AddId(idName, builder => builder.AddBackgroundImage(imagePath));
            AddId(idName, new[] { PseudoClass.Hover }, builder => builder.AddBackgroundImage(secondImagePath));

            return this;
        }
        
        public StyleSheetBuilder AddBackgroundHoverId(string idName, string imagePath, string secondImagePath, PseudoClass additionalPseudoClass)
        {
            AddId(idName, new[] { additionalPseudoClass }, builder => builder.AddBackgroundImage(imagePath));
            AddId(idName, new[] { additionalPseudoClass, PseudoClass.Hover }, builder => builder.AddBackgroundImage(secondImagePath));

            return this;
        }
    }
}