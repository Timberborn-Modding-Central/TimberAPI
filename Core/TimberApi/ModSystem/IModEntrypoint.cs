using TimberApi.ConsoleSystem;

namespace TimberApi.ModSystem
{
    public interface IModEntrypoint
    {
        void Entry(IMod mod, IConsoleWriter consoleWriter);
    }
}