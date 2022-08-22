using TimberApi.Core2.ConsoleSystem;
using TimberApi.Core2.ModSystem;

namespace TimberApi.Core2.ModEntrySystem
{
    public interface IModEntrypoint
    {
        void Entry(IMod mod, IConsoleWriter consoleWriter);
    }
}