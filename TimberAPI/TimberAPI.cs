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
        public static IDependencies Dependencies = new Dependencies();

        /**
         * Entrypoint for Localization-related utilities
         */
        public static ILocalization Localization = new Localization();
    }
}
