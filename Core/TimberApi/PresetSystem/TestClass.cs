using System.Drawing;
using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.UiBuilderSystem;
using TimberApi.UiBuilderSystem.ElementSystem;
using Test = JetBrains.Annotations.MeansImplicitUseAttribute;

namespace TimberApi.PresetSystem
{
    [Test]
    public class TestClass
    {
        private readonly UIBuilder _uiBuilder;
        
        public void Test()
        {
            _uiBuilder.CreateComponentBuilder().CreateButton()
                .AddPreset<SliderBuilder>("DiamondSlider", builder => builder.SetName("Test"));
        }
        
        public dynamic Anonymouse()
        {
            return new
            {
                Height = 100,
                Width = 100,
                Color = Color.Black
            };
        }
    }

    [Configurator(SceneEntrypoint.InGame)]
    public class PresetConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            // Is this a problem to register them like this
            containerDefinition.MultiBind<IPresetBuilder<SliderBuilder>>().To<TestPreset>();
            
            // New
            containerDefinition.MultiBindPreset<SliderBuilder>().To<TestPreset>();
            
            // Not sure yet if I can make this possible, might make it possible to make custom builders (probably never going to happen). Might require reflections :(
            containerDefinition.MultiBind<IPresetBuilder>().To<TestPreset>();
        }
    }

    public static class TestExtender
    {
        public static IBindingBuilder<IPresetBuilder<T>> MultiBindPreset<T>(this IContainerDefinition containerDefinition) where T : class
        {
            return containerDefinition.MultiBind<IPresetBuilder<T>>();
        }
    }
    

    public class TestPreset : IPresetBuilder<SliderBuilder>
    {
        public string Id => "DiamondSlider";
        
        public SliderBuilder Build(SliderBuilder builder)
        {
            return builder
                .SetLabel("HelloWorld")
                .SetHeight(100)
                .SetWidth(100)
                .SetLowValue(10)
                .SetHighValue(100);
        }
    }

    public interface IPresetBuilder<TBuilder> : IPresetBuilder
    {
        TBuilder Build(TBuilder builder);
    }

    public interface IPresetBuilder
    {
        string Id { get; }
    }

    public class HelloWorld
    {
        public int Height { get; set; }
    }

    public class Builder
    {
        public void AddPreset()
        {
            
        }
    }

    public class ListBuilder
    {
        public void SetName()
        {
            
        }
    }
    
    public class ButtonBuilder
    {
        public void SetName()
        {
            
        }
    }
    
}