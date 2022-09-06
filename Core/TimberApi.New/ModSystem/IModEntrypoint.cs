using TimberApi.New.ConsoleSystem;

namespace TimberApi.New.ModSystem
{
    public interface IModEntrypoint
    {
        void Entry(IMod mod, IConsoleWriter consoleWriter);
    }
}