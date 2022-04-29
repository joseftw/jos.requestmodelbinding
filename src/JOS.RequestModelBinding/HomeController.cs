using Microsoft.AspNetCore.Mvc;

namespace JOS.RequestModelBinding;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class HomeController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromRequest]PostRequest req)
    {
        return new OkObjectResult(req);
    } 
}
