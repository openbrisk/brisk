namespace OpenBrisk.Gateway.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using OpenBrisk.Gateway.Model;

	[Route("gateway/v1")]
	public class GatewayController : Controller
	{
		/// <summary>
		/// Invoke a deployed function.
		/// </summary>
		/// <returns>The result of the invoked function.</returns>
		/// <param name="functionInvocationDescriptor">The function invocation descriptor.</param>
		[HttpPost("functions/{namespaceName}/{functionName}")]
		public async Task<IActionResult> InvokeFunction([FromBody]FunctionInvocationDescriptor functionInvocationDescriptor)
		{
			if (functionInvocationDescriptor.IsAsync)
			{
				return this.Accepted();
			}
			else
			{
				return this.Ok();
			}
		}
	}
}
