namespace OpenBrisk.Controller.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	[Route("/")]
	public class HealthController : Controller
	{
		[HttpGet("healthz")]
		public IActionResult HealthCheck() => this.Ok();
	}
}