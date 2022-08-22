using System;

namespace TimberApi.Core2.ConfiguratorSystem
{
    [Flags]
    public enum SceneConfiguratorEntry
    {
        Global = 1,
        MainMenu = 1 << 1,
        InGame = 1 << 2,
        MapEditor = 1 << 3,


        All = MainMenu | InGame | MapEditor
    }
}