namespace OpenBrisk.Gateway.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net.Http;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using OpenBrisk.Gateway.Services;

	[Route("")]
	public class GatewayController : Controller
	{
		private readonly IKubernetesService kubernetesService;

		private const string ServicesUrl = "cluster.local";
		private static readonly Lazy<HttpClient> client = new Lazy<HttpClient>(() => new HttpClient(new HttpClientHandler
		{
			AllowAutoRedirect = false,
			UseCookies = false
		}));

		public GatewayController(IKubernetesService kubernetesService)
		{
			this.kubernetesService = kubernetesService;
		}

		/// <summary>
		/// Invoke a deployed function.
		/// 
		/// Note: https://github.com/aspnet/Proxy
		/// </summary>
		/// <returns>The result of the invoked function.</returns>
		[HttpPost("functions/{namespaceName}/{functionName}")]
		[HttpGet("functions/{namespaceName}/{functionName}")]
		public async Task<IActionResult> InvokeFunction([FromRoute]string namespaceName, [FromRoute]string functionName)
		{
			// Validate function invocation request.
			if (!this.FunctionExsist(functionName, namespaceName))
			{
				return this.NotFound($"/{namespaceName}/{functionName}");
			}

			// Read async control header: X-OpenBrisk-Async: true|false
			bool executeAsync = this.Request.Headers.GetAsync();

			// Read forward control header: X-OpenBrisk-Forward: url
			string forwardUrl = this.Request.Headers.GetForwardUrl();

			// Read forwarded from info header: X-OpenBrisk-Forwarded-Form: function (/default/base64)
			string forwardedFrom = this.Request.Headers.GetForwardedFromFunction();

			// Read function traceid  header: X-OpenBrisk-Function-ID: guid
			string functionTraceId = this.Request.Headers.GetFunctionTraceId();

			// Create the uri where the request is proxied to. 
			Uri targetUri = this.CreateTargetUri(executeAsync, namespaceName, functionName);

			// Create and send the proxy request.
			HttpRequestMessage request = this.CreateProxyRequest(targetUri, executeAsync ? forwardUrl : null, functionTraceId, forwardedFrom);
			HttpResponseMessage response = await client.Value.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, this.HttpContext.RequestAborted);

			// Return the result from the upstream target.
			return this.Proxy(response); // TODO: Forward to url if requested.
		}

		private Uri CreateTargetUri(bool executeAsync, string namespaceName, string functionName)
		{
			// TODO: Config via ENV
			Uri targetUri = executeAsync
				? new Uri($"http://localhost:8003/queue/v1/functions/{namespaceName}/{functionName}")   // Queue
				: new Uri($"http://{functionName}.{namespaceName}.{ServicesUrl}:8080");                 // Function 

			return targetUri;
		}

		private HttpRequestMessage CreateProxyRequest(Uri targetUri, string forwardUrl, string functionTraceId, string forwardedFrom)
		{
			HttpMethod httpMethod = this.GetHttpMethod();
			HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, targetUri);

			// Copy request body.
			if (httpMethod == HttpMethod.Post)
			{
				StreamContent streamContent = new StreamContent(this.Request.Body);
				requestMessage.Content = streamContent;
			}

			// Set request headers.
			requestMessage.Headers.Add("X-OpenBrisk-Function-ID", functionTraceId);
			if (!string.IsNullOrWhiteSpace(forwardUrl))
			{
				requestMessage.Headers.Add("X-OpenBrisk-Forward", forwardUrl);
			}
			if (!string.IsNullOrWhiteSpace(forwardedFrom))
			{
				requestMessage.Headers.Add("X-OpenBrisk-Forwarded-Form", forwardedFrom);
			}

			return requestMessage;
		}

		private HttpMethod GetHttpMethod()
		{
			if (HttpMethods.IsGet(this.Request.Method))
			{
				return HttpMethod.Get;
			}
			if (HttpMethods.IsPost(this.Request.Method))
			{
				return HttpMethod.Post;
			}

			throw new InvalidOperationException($"Unknown http method: {this.Request.Method}");
		}

		private bool FunctionExsist(string functionName, string namespaceName)
		{
			return true; // TODO
		}
	}
}
