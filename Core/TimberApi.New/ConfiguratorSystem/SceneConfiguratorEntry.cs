using System;

namespace TimberApi.Core2.ConfiguratorSystem
{
    [Flags]
    public enum SceneConfiguratorEntry
    {
        MainMenu = 1 << 1,
        InGame = 1 << 2,
        MapEditor = 1 << 3,


        All = MainMenu | InGame | MapEditor
    }
}