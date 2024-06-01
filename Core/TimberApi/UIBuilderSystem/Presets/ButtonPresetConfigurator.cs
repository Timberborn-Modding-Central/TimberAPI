using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.UiBuilderSystem.Presets.Buttons;

namespace TimberApi.UIBuilderSystem.Presets
{
    [Configurator(SceneEntrypoint.All)]
    public class ButtonPresetConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ArrowDown>().AsTransient();
            containerDefinition.Bind<ArrowLeft>().AsTransient();
            containerDefinition.Bind<ArrowUp>().AsTransient();
            containerDefinition.Bind<ArrowRight>().AsTransient();
            containerDefinition.Bind<ButtonMenu>().AsTransient();
            containerDefinition.Bind<ButtonGame>().AsTransient();
            containerDefinition.Bind<ButtonEmpty>().AsTransient();
            containerDefinition.Bind<ButtonEmptyText>().AsTransient();
            containerDefinition.Bind<ButtonNewGame>().AsTransient();
            containerDefinition.Bind<ClampUp>().AsTransient();
            containerDefinition.Bind<ClampDown>().AsTransient();
            containerDefinition.Bind<PlusButton>().AsTransient();
            containerDefinition.Bind<PlusBatchButton>().AsTransient();
            containerDefinition.Bind<PlusBatchMultiButton>().AsTransient();
            containerDefinition.Bind<MinusButton>().AsTransient();
            containerDefinition.Bind<MinusBatchButton>().AsTransient();
            containerDefinition.Bind<MinusBatchMultiButton>().AsTransient();
            containerDefinition.Bind<CircleButton>().AsTransient();
            containerDefinition.Bind<CloseButton>().AsTransient();
            containerDefinition.Bind<CrossButton>().AsTransient();
            containerDefinition.Bind<WideButton>().AsTransient();
            containerDefinition.Bind<MigrationArrowLeftButton>().AsTransient();
            containerDefinition.Bind<MigrationArrowRightButton>().AsTransient();
            containerDefinition.Bind<CyclerRight>().AsTransient();
            containerDefinition.Bind<CyclerLeft>().AsTransient();
            containerDefinition.Bind<CyclerMainRight>().AsTransient();
            containerDefinition.Bind<CyclerMainLeft>().AsTransient();
        }
    }
}
