using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.ModSystem;

namespace TimberApi.Core.ModEntrySystem
{
    public interface IModEntrypoint
    {
        void Entry(IMod mod, IConsoleWriter consoleWriter);
    }
}