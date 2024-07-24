using Bindito.Core;

namespace TimberApi.UIPresets.Buttons;

[Context("Game")]
public class ButtonPresetConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ArrowDownButton>().AsTransient();
        containerDefinition.Bind<ArrowLeftButton>().AsTransient();
        containerDefinition.Bind<ArrowUpButton>().AsTransient();
        containerDefinition.Bind<ArrowRightButton>().AsTransient();
        containerDefinition.Bind<MenuButton>().AsTransient();
        containerDefinition.Bind<GameButton>().AsTransient();
        containerDefinition.Bind<EmptyButton>().AsTransient();
        containerDefinition.Bind<EmptyTextButton>().AsTransient();
        containerDefinition.Bind<NewGameButton>().AsTransient();
        containerDefinition.Bind<ClampUpButton>().AsTransient();
        containerDefinition.Bind<ClampDownButton>().AsTransient();
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
        containerDefinition.Bind<CyclerRightButton>().AsTransient();
        containerDefinition.Bind<CyclerLeftButton>().AsTransient();
        containerDefinition.Bind<CyclerMainRightButton>().AsTransient();
        containerDefinition.Bind<CyclerMainLeftButton>().AsTransient();
    }
}