namespace OpenBrisk.Controller.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	[Route("controller")]
	public class HealthController : Controller
	{
		[HttpGet("healthz")]
		public IActionResult HealthCheck() => this.Ok();
	}
}