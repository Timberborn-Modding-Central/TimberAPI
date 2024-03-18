using System;

namespace TimberApi.PresetSystem.Exceptions
{
    public class PresetRepositoryAlreadyLoadedException : Exception
    {
        public PresetRepositoryAlreadyLoadedException() : base("The preset repository is already loaded.")
        {
        }
    }
}