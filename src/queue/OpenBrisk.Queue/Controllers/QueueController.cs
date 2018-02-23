namespace OpenBrisk.Queue.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;

	[Route("queue/v1")]
	public class QueueController : Controller
	{
		/// <summary>
		/// Invoke a deployed function.
		/// </summary>
		/// <returns>The result of the invoked function.</returns>
		[HttpPost("functions/{namespaceName}/{functionName}")]
		[HttpGet("functions/{namespaceName}/{functionName}")]
		public async Task<IActionResult> InvokeFunction([FromRoute] string namespaceName, [FromRoute] string functionName)
		{
			return this.Accepted();
		}
	}
}
