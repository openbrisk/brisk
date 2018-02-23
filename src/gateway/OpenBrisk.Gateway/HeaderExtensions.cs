namespace OpenBrisk.Gateway
{
	using System.Linq;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Primitives;

	public static class HeaderExtensions
	{
		public static bool GetAsync(this IHeaderDictionary headers)
		{
			bool executeAsync = false;

			if (headers.TryGetValue("X-OpenBrisk-Async", out StringValues asyncValues))
			{
				if (bool.TryParse(asyncValues.FirstOrDefault(), out bool asyncValue))
				{
					executeAsync = asyncValue;
				}
			}

			return executeAsync;
		}

		public static string GetForwardUrl(this IHeaderDictionary headers)
		{
			string forwardUrl = null;

			if (headers.TryGetValue("X-OpenBrisk-Forward", out StringValues forwardValues))
			{
				forwardUrl = forwardValues.FirstOrDefault();
			}

			return forwardUrl;
		}

		public static string GetForwardedFromFunction(this IHeaderDictionary headers)
		{
			string forwardedFrom = null;

			if (headers.TryGetValue("X-OpenBrisk-Forwarded-Form", out StringValues forwardedFromValues))
			{
				forwardedFrom = forwardedFromValues.FirstOrDefault();
			}

			return forwardedFrom;
		}

		public static string GetFunctionTraceId(this IHeaderDictionary headers)
		{
			string functionTraceId = null;

			if (headers.TryGetValue("X-OpenBrisk-Function-Trace-ID", out StringValues functionTraceIdValues))
			{
				functionTraceId = functionTraceIdValues.FirstOrDefault();
			}

			return functionTraceId;
		}
	}
}