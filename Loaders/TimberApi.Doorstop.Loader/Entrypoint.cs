using System;
using System.IO;
using TimberApi.Doorstop.Loader;

namespace Doorstop
{
    internal class Entrypoint
    {
        public static void Start()
        {
            var timberApiRootPath = Directory.GetParent(Environment.GetEnvironmentVariable("DOORSTOP_INVOKE_DLL_PATH")!)!.Parent.ToString();
            string modsPath = Path.Combine(timberApiRootPath, "mods");
            DoorstopLoader.Run(timberApiRootPath, modsPath);
        }
    }
}