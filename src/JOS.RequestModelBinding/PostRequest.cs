using Microsoft.AspNetCore.Mvc;

namespace JOS.RequestModelBinding;

public class PostRequest
{
    [FromBody]
    public PostRequestBody Body { get; set; } = null!;

    [FromHeader(Name = "Accept")]
    public string Accept { get; set; } = null!;

    [FromHeader(Name = "X-Correlation-Id")]
    public string CorrelationId { get; set; } = null!;

    [FromQuery(Name = "filter")]
    public string Filter { get; set; } = null!;
}

public class PostRequestBody
{
    public string SomeString { get; set; } = null!;
    public bool SomeBool { get; set; }
}
