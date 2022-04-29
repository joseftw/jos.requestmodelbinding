using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace JOS.RequestModelBinding.Tests;

public class HomeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _webApplicationFactory;

    public HomeControllerTests(WebApplicationFactory<Startup> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory ?? throw new ArgumentNullException(nameof(webApplicationFactory));
    }

    [Fact]
    public async Task ShouldBindPostRequestCorrectly()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/home?filter=one")
        {
            Headers =
            {
                { "X-Correlation-Id", "my-correlation-id"},
                { "Accept", "application/json"}
            },
            Content = new JsonContent(new
            {
                someString = "Some string",
                someBool = true
            })
        };
        var client = _webApplicationFactory.CreateClient();

        var response = await client.SendAsync(request);
        var s = await response.Content.ReadAsStringAsync();
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseBody = await JsonSerializer.DeserializeAsync<PostRequest>(
            responseStream,
            DefaultJsonSerializer.Options);
        responseBody.ShouldNotBeNull();
        responseBody.Accept.ShouldBe("application/json");
        responseBody.CorrelationId.ShouldBe("my-correlation-id");
        responseBody.Filter.ShouldBe("one");
        responseBody.Body.SomeString.ShouldBe("Some string");
        responseBody.Body.SomeBool.ShouldBeTrue();
    }
}
