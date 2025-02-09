using Bindito.Core;
using Timberborn.Buildings;
using Timberborn.TemplateSystem;

namespace TimberApi.EntityLinkerSystem;

[Context("Game")]
public class EntityLinkerSystemConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<EntityLinkObjectSerializer>().AsSingleton();
        Bind<PickObjectTool>().AsSingleton();
        MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
    }

    private static TemplateModule ProvideTemplateModule()
    {
        var builder = new TemplateModule.Builder();
        builder.AddDecorator<BuildingSpec, EntityLinker>();
        return builder.Build();
    }
}