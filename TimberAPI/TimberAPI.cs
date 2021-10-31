using TimberbornAPI.Dependency;

namespace TimberbornAPI {
    /**
     * Entrypoint for all APIs
     * Only use this in Awake()
     */
    public static class TimberAPI {
        /**
         * Entrypoint for Dependency-related utilities
         */
        public static Dependencies Dependencies = new Dependencies();
    }
}
