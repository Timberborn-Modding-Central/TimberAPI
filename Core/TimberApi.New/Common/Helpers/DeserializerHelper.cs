namespace TimberApi.Core.Common
{
    public static class DeserializerHelper
    {
        public static string Wrap(string type, string json) => "{\"" + type + "\":" + json + "}";
    }
}