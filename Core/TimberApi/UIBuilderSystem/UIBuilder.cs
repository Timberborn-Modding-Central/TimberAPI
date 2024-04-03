using System;
using Bindito.Core;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem
{
    public class UIBuilder
    {
        private readonly VisualElementInitializer _visualElementInitializer;

        private readonly IContainer _container;
        
        public UIBuilder(IContainer container, VisualElementInitializer visualElementInitializer)
        {
            _container = container;
            _visualElementInitializer = visualElementInitializer;
        }
        
        private BaseBuilder Create(Type builderType)
        { 
            var builder = (BaseBuilder) _container.GetInstance(builderType);
            builder.Initialize();

            return builder;
        }
        
        private BaseBuilder Create(string name, Type builderType)
        {
            var builder = Create(builderType);

            builder.SetName(name);
            return builder;
        }
        
        public TBuilder Create<TBuilder>()
            where TBuilder : BaseBuilder
        {
            return (TBuilder) Create(typeof(TBuilder));
        }
        
        public TBuilder Create<TBuilder>(string name)
            where TBuilder : BaseBuilder
        {
            return (TBuilder) Create(name, typeof(TBuilder));
        }
        
        public VisualElement Build(Type builderType)
        {
            return Create(builderType).BuildElement();
        }
        
        public VisualElement Build(string name, Type builderType)
        {
            return Create(name, builderType).BuildElement();
        }
        
        public VisualElement Build<TBuilder>()
            where TBuilder : BaseBuilder
        {
            return Build(typeof(TBuilder));
        }
        
        public VisualElement Build<TBuilder>(string name)
        {
            return Build(name, typeof(TBuilder));
        }
        
        public TElement Build<TBuilder, TElement>()
            where TBuilder : BaseBuilder<TBuilder, TElement>
            where TElement : VisualElement, new()
        {
            return (TElement) Create(typeof(TBuilder)).BuildElement();
        }
        
        public TElement Build<TBuilder, TElement>(string name)
            where TBuilder : BaseBuilder<TBuilder, TElement>
            where TElement : VisualElement, new()
        {
            return (TElement) Create(name, typeof(TBuilder)).BuildElement();
        }
        
        public TElement Build<TElement>(Type builderType)
            where TElement : VisualElement, new()
        {
            return (TElement) Create(builderType).BuildElement();
        }
        
        public TElement Build<TElement>(string name, Type builderType)
            where TElement : VisualElement, new()
        {
            return (TElement) Create(name, builderType).BuildElement();
        }
        
        public void Initialize(VisualElement element)
        {
            _visualElementInitializer.InitializeVisualElement(element);
        }
    }
}
