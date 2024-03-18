using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using TimberApi.UiBuilderSystem.Presets.Buttons;
using TimberApi.UiBuilderSystem.PresetSystem;
using Timberborn.GameDistrictsMigration;
using Timberborn.TemplateSystem;
using UnityEngine;

namespace TimberApi.UiBuilderSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class UiBuilderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBoxBuilder>().AsTransient();
            containerDefinition.Bind<UIBuilderOld>().AsSingleton();
            containerDefinition.Bind<ComponentBuilder>().AsSingleton();
            containerDefinition.Bind<UiPresetFactory>().AsSingleton();
            
            // New
            
            containerDefinition.Bind<LabelBuilder>().AsTransient();
            containerDefinition.Bind<SliderBuilder>().AsTransient();
            containerDefinition.Bind<ArrowDown>().AsTransient();
            containerDefinition.Bind<ArrowLeft>().AsTransient();
            containerDefinition.Bind<ButtonBuilder>().AsTransient();
            containerDefinition.Bind<VisualElementBuilder>().AsTransient();
            
            containerDefinition.Bind<StyleSheetBuilder>().AsTransient();
            containerDefinition.Bind<UIBuilder>().AsSingleton();
            containerDefinition.Bind<BuilderStyleSheetCache>().AsSingleton();
        }
    }
}
