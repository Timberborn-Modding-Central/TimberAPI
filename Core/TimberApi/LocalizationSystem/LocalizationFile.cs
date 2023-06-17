using TimberApi.ModSystem;

namespace TimberApi.LocalizationSystem
{
    public class LocalizationFile
    {
        public IMod Mod { get; }

        public string FilePath { get; }
        
        public LocalizationFile(IMod mod, string filePath)
        {
            Mod = mod;
            FilePath = filePath;
        }
    }
}