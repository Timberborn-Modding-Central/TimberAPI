namespace TimberApi.Common.Extensions
{
    /// <summary>
    ///     Checks if it's a placeholder and change it to a valid version to check
    /// </summary>
    public static class VersionExtensions
    {
        public static string ConvertVersionPlaceholder(this string version)
        {
            return version.Contains("PLACEHOLDER") ? "0.0.0.0" : version;
        }
    }
}