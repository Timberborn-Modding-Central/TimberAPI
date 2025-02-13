using Bindito.Core;

namespace TimberApi.UIPresets.Buttons;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
public class ButtonPresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<ArrowDownButton>().AsTransient();
        Bind<ArrowLeftButton>().AsTransient();
        Bind<ArrowUpButton>().AsTransient();
        Bind<ArrowRightButton>().AsTransient();
        Bind<MenuButton>().AsTransient();
        Bind<GameButton>().AsTransient();
        Bind<EmptyButton>().AsTransient();
        Bind<EmptyTextButton>().AsTransient();
        Bind<NewGameButton>().AsTransient();
        Bind<ClampUpButton>().AsTransient();
        Bind<ClampDownButton>().AsTransient();
        Bind<PlusButton>().AsTransient();
        Bind<PlusBatchButton>().AsTransient();
        Bind<PlusBatchMultiButton>().AsTransient();
        Bind<MinusButton>().AsTransient();
        Bind<MinusBatchButton>().AsTransient();
        Bind<MinusBatchMultiButton>().AsTransient();
        Bind<CircleButton>().AsTransient();
        Bind<CloseButton>().AsTransient();
        Bind<CrossButton>().AsTransient();
        Bind<WideButton>().AsTransient();
        Bind<MigrationArrowLeftButton>().AsTransient();
        Bind<MigrationArrowRightButton>().AsTransient();
        Bind<CyclerRightButton>().AsTransient();
        Bind<CyclerLeftButton>().AsTransient();
        Bind<CyclerMainRightButton>().AsTransient();
        Bind<CyclerMainLeftButton>().AsTransient();
    }
}