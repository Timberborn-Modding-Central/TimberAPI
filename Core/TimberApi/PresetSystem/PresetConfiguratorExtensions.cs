using Bindito.Core;
using Timberborn.Planting;

namespace TimberApi.PresetSystem
{
    public static class PresetConfiguratorExtensions
    {
        public static void BindPreset<T>(this IContainerDefinition containerDefinition) where T : class, IPreset
        {
            containerDefinition.MultiBind<IPreset>().To<T>().AsSingleton();
        }
    }
}