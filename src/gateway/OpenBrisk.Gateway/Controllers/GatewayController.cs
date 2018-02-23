namespace OpenBrisk.Gateway.Controllers
{
	using System;
	using System.Linq;
	using System.Net.Http;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Primitives;
	using OpenBrisk.Gateway.Model;

	[Route("gateway/v1")]
	public class GatewayController : Controller
	{
		private static Lazy<HttpClient> client = new Lazy<HttpClient>(() =>
		{
			return new HttpClient
			{

			};
		});

		/// <summary>
		/// Invoke a deployed function.
		/// </summary>
		/// <returns>The result of the invoked function.</returns>
		/// <param name="functionInvocationDescriptor">The function invocation descriptor.</param>
		[HttpPost("functions/{namespaceName}/{functionName}")]
		public async Task<IActionResult> InvokeFunction([FromRoute]string namespaceName, [FromRoute]string functionName,
														[FromBody]FunctionInvocationDescriptor functionInvocationDescriptor)
		{
			// Read async control header: X-OpenBrisk-Async: true|false
			bool executeAsync = false;
			if (this.Request.Headers.TryGetValue("X-OpenBrisk-Async", out StringValues asyncValues))
			{
				if (bool.TryParse(asyncValues.FirstOrDefault(), out bool asyncValue))
				{
					executeAsync = asyncValue;
				}
			}

			// Read forward control header: X-OpenBrisk-Forward: url
			string forwardUrl = null;
			if (this.Request.Headers.TryGetValue("X-OpenBrisk-Forward", out StringValues forwardValues))
			{
				forwardUrl = forwardValues.FirstOrDefault();
			}

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
			request.Headers.Add("X-OpenBrisk-Function-ID", Guid.NewGuid().ToString("N"));
			//request.Headers.Add("");

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
