namespace OpenBrisk.Controller.Controllers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using k8s;
	using k8s.Models;
	using Microsoft.AspNetCore.Mvc;
	using OpenBrisk.Controller.Model;

	[Route("controller/v1")]
	public class NamespacesController : Controller
	{
		private readonly IKubernetes kubernetesClient;

		public NamespacesController(IKubernetes kubernetesClient)
		{
			this.kubernetesClient = kubernetesClient;
		}

		/// <summary>
		/// Get a list of available namespaces.
		/// </summary>
		/// <returns>The infos about the namespaces.</returns>
		[HttpGet("namespaces")]
		public async Task<IActionResult> GetNamespaces()
		{
			V1NamespaceList namespaces = await this.kubernetesClient.ListNamespaceAsync(labelSelector: "application=openbrisk");
			return this.Ok(namespaces.Items.Select(x => x.Metadata.Name));
		}

		/// <summary>
		/// Get info about a namespace.
		/// </summary>
		/// <returns>The info about the namespace.</returns>
		/// <param name="namespaceName">The namespace name.</param>
		[HttpGet("namespaces/{namespaceName}")]
		public async Task<IActionResult> GetNamespace([FromRoute]string namespaceName)
		{
			V1Namespace @namespace = await this.kubernetesClient.ReadNamespaceAsync(namespaceName);
			V1ServiceList services = await this.kubernetesClient.ListNamespacedServiceAsync(namespaceParameter: namespaceName, labelSelector: "application=openbrisk");

			return this.Ok(new NamespaceInfo
			{
				Name = @namespace.Metadata.Name,
				FunctionCount = services.Items.Count,
			});
		}

		/// <summary>
		/// Create a new namespace.
		/// </summary>
		/// <returns>The result of the namespace creation operation.</returns>
		/// <param name="namespaceName">The namespace name.</param>
		[HttpPost("namespaces")]
		public async Task<IActionResult> AddNamespace([FromRoute]string namespaceName)
		{
			V1Namespace @namespace = await this.kubernetesClient.CreateNamespaceAsync(new V1Namespace(metadata: new V1ObjectMeta(name: namespaceName, labels: new Dictionary<string, string> { { "application", "openbrisk" } })));

			return this.CreatedAtAction("GetNamespace", "Namespaces", new { namespaceName }, namespaceName);
		}
	}
}
