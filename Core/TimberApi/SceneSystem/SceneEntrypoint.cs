using System;

namespace TimberApi.SceneSystem
{
    [Flags]
    public enum SceneEntrypoint
    {
        MainMenu = 1 << 1,
        InGame = 1 << 2,
        MapEditor = 1 << 3,

        All = MainMenu | InGame | MapEditor
    }
}