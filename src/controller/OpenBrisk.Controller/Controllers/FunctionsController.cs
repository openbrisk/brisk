namespace OpenBrisk.Controller.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using k8s;
	using k8s.Models;
	using Microsoft.AspNetCore.Mvc;
	using OpenBrisk.Controller.Model;

	[Route("controller/v1")]
	public class FunctionsController : Controller
	{
		private readonly IKubernetes kubernetesClient;

		public FunctionsController(IKubernetes kubernetesClient)
		{
			this.kubernetesClient = kubernetesClient;
		}

		/// <summary>
		/// Get a list of infos about the deployed functions.
		/// </summary>
		/// <returns>The function infos.</returns>
		[HttpGet("functions")]
		public async Task<IActionResult> GetFunctions()
		{
			Corev1ServiceList services = await this.kubernetesClient.ListServiceForAllNamespacesAsync(labelSelector: "application=openbrisk");

			return this.Ok(services.Items.Select(x => new FunctionInfo
			{
				Name = x.Metadata.Name,
				Namespace = x.Metadata.NamespaceProperty,
				Runtime = "",
				Version = 0,
				ReplicaCount = x.Spec.Ports.Count,
				InvocationCount = 0,
			}));
		}

		/// <summary>
		/// Get a list of infos about the deployed functions in the namespace.
		/// </summary>
		/// <returns>The function infos.</returns>
		/// <param name="namespaceName">The namespace name.</param>
		[HttpGet("functions/{namespaceName}")]
		public async Task<IActionResult> GetFunctions([FromRoute]string namespaceName)
		{
			Corev1ServiceList services = await this.kubernetesClient.ListNamespacedServiceAsync(namespaceName, labelSelector: "application=openbrisk");

			return this.Ok(services.Items.Select(x => new FunctionInfo
			{
				Name = x.Metadata.Name,
				Namespace = x.Metadata.NamespaceProperty,
				Runtime = "",
				Version = 0,
				ReplicaCount = x.Spec.Ports.Count,
				InvocationCount = 0,
			}));
		}

		/// <summary>
		/// Get info about a specific function.
		/// </summary>
		/// <returns>The function info.</returns>
		/// <param name="namespaceName">The namespace name.</param>
		/// <param name="functionName">The function name.</param>
		[HttpGet("functions/{namespaceName}/{functionName}")]
		public async Task<IActionResult> GetFunction([FromRoute]string namespaceName, [FromRoute]string functionName)
		{
			return this.Ok(new FunctionInfo());
		}

		/// <summary>
		/// Deploy a new function in the namespace.
		/// </summary>
		/// <returns>The result of the deployment operation.</returns>
		/// <param name="functionDescriptor">The function descriptor.</param>
		[HttpPost("functions")]
		public async Task<IActionResult> AddFunction([FromBody]FunctionDescriptor functionDescriptor)
		{
			return this.Ok(null);
		}

		/// <summary>
		/// Deploy an update to an existing function.
		/// </summary>
		/// <returns>The result of the update deployment operation.</returns>
		/// <param name="functionDescriptor">The function descriptor.</param>
		[HttpPut("functions")]
		public async Task<IActionResult> UpdateFunction([FromBody]FunctionDescriptor functionDescriptor)
		{
			return this.Ok(null);
		}

		/// <summary>
		/// Remove an existing function.
		/// </summary>
		/// <returns>The result of the delete operation..</returns>
		/// <param name="namespaceName">The namespace name.</param>
		/// <param name="functionName">The function name.</param>
		[HttpDelete("functions/{namespaceName}/{functionName}")]
		public async Task<IActionResult> DeleteFunction([FromRoute]string namespaceName, [FromRoute]string functionName)
		{
			return this.NoContent();
		}
	}
}
