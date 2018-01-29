namespace Openbrisk.Controller.Controllers
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using Openbrisk.Controller.Model;

	[Route("controller/v1")]
	public class FunctionsController : Controller
	{
		/// <summary>
		/// Get a list of infos about the deployed functions.
		/// </summary>
		/// <returns>The function infos.</returns>
		[HttpGet("functions")]
		public async Task<IActionResult> GetFunctions()
		{
			return this.Ok(new List<FunctionInfo>());
		}

		/// <summary>
		/// Get a list of infos about the deployed functions in the namespace.
		/// </summary>
		/// <returns>The function infos.</returns>
		/// <param name="namespaceName">The namespace name.</param>
		[HttpGet("functions/{namespaceName}")]
		public async Task<IActionResult> GetFunctions([FromRoute]string namespaceName)
		{
			return this.Ok(new List<FunctionInfo>());
		}

		/// <summary>
		/// Get info about a specific function.
		/// </summary>
		/// <returns>The function info.</returns>
		/// <param name="namespaceName">The namespace name.</param>
		/// <param name="functionName">The function name.</param>
		[HttpGet("functions/{namespaceName}/{functionName}")]
		public async Task<IActionResult> GetFunctions([FromRoute]string namespaceName, [FromRoute]string functionName)
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
