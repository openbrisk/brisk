namespace OpenBrisk.Controller.Controllers
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using OpenBrisk.Controller.Model;

	[Route("controller/v1")]
	public class NamespacesController : Controller
	{
		/// <summary>
		/// Get a list of available namespaces.
		/// </summary>
		/// <returns>The infos about the namespaces.</returns>
		[HttpGet("namespaces")]
		public async Task<IActionResult> GetNamespaces()
		{
			return this.Ok(new List<string>());
		}

		/// <summary>
		/// Get info about a namespace.
		/// </summary>
		/// <returns>The info about the namespace.</returns>
		[HttpGet("namespaces/{namespaceName}")]
		public async Task<IActionResult> GetNamespace()
		{
			return this.Ok(new NamespaceInfo());
		}

		/// <summary>
		///Create a new namespace.
		/// </summary>
		/// <returns>The result of the namespace creation operation.</returns>
		/// <param name="namespaceName">The namespace name.</param>
		[HttpPost("namespaces")]
		public async Task<IActionResult> AddNamespace([FromBody]string namespaceName)
		{
			return this.CreatedAtAction("GetNamespace", "Namespaces", new { namespaceName }, namespaceName);
		}
	}
}
