using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace JOS.RequestModelBinding.Tests;

public class JsonContent : StringContent
{
    public JsonContent(dynamic content) : base(
        JsonSerializer.Serialize((object)content, DefaultJsonSerializer.Options),
        Encoding.UTF8,
        "application/json")
    {
            
    }
}
