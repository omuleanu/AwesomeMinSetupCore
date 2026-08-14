using System.Text.Json;

namespace MinSetupCore.Utils
{
    public static class  AUtil
    {
        public static string JsonEncode(object o)
        {
            return JsonSerializer.Serialize(o, new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Default
            });
        }
    }
}