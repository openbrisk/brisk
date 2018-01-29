namespace OpenBrisk.Gateway.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	[Route("gateway")]
	public class HealthController : Controller
	{
		[HttpGet("healthz")]
		public IActionResult HealthCheck() => this.Ok();
	}
}