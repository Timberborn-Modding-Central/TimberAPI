using TimberApi.Core.ConsoleSystem;

namespace TimberApi.Internal
{
    public class TimberApiGameStartLogger
    {
        private readonly IConsoleWriter _consoleWriter;

        public TimberApiGameStartLogger(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
            FinishedInitializingTimberApiLog();
        }

        public void FinishedInitializingTimberApiLog()
        {
            _consoleWriter.Log("TimberAPI 0.0.0.0");
        }
    }
}