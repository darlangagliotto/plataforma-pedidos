using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        // POST: api/webhook
        [HttpPost]
        public IActionResult Receive([FromBody] object payload)
        {
            Console.WriteLine("🔔 Webhook recebido no AuthService:");
            Console.WriteLine(payload.ToString());
            return Ok();
        }
    }
}