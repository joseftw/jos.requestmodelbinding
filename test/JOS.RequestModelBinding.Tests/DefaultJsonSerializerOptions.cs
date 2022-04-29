using System.Text.Json;

namespace JOS.RequestModelBinding.Tests;

internal static class DefaultJsonSerializer
{
    internal static readonly JsonSerializerOptions Options;

    static DefaultJsonSerializer()
    {
        Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
    }
}
