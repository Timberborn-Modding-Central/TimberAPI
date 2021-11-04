using TimberbornAPI.Dependency;
using TimberbornAPI.Localizations;

namespace TimberbornAPI {
    /**
     * Entrypoint for all APIs
     * Only use this in Awake()
     */
    public static class TimberAPI {
        /**
         * Entrypoint for Dependency-related utilities
         */
        public static Dependencies Dependencies = new();

        /**
         * Entrypoint for Localization-related utilities
         */
        public static Localization Localization = new();
    }
}
