namespace TimberApi.Common.Extensions
{
    /// <summary>
    ///     Checks if it's a placeholder and change it to a valid version to check
    /// </summary>
    public static class VersionExtensions
    {
        public static string ReplacePlaceholderWithFakeVersion(this string version, string fakeVersion)
        {
            return version.Contains("PLACEHOLDER") ? fakeVersion : version;
        }
    }
}