namespace OpenBrisk.Controller.Model
{
	using System.ComponentModel.DataAnnotations;

	public class FunctionDescriptor
	{
		public FunctionDescriptor()
		{
			this.Namespace = "openbrisk";
		}

		/// <summary>
		/// Gets or sets the name of the function.
		/// </summary>
		/// <value>The name.</value>
		[Required]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the (optional) namespace of the function.
		/// </summary>
		/// <value>The namespace.</value>
		public string Namespace
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the runtime to use for the function.
		/// </summary>
		/// <value>The runtime.</value>
		[Required]
		public FunctionRuntime Runtime
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the code of the function.
		/// </summary>
		/// <value>The code.</value>
		[Required]
		public string Code
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the (optional) dependencies of the function.
		/// </summary>
		/// <value>The dependencies.</value>
		public string Dependencies
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the (optional) custom runtime docker image name.
		/// </summary>
		/// <value>The image.</value>
		public string Image
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the base64-encoded basic auth credentials for a private
		/// docker image registry.
		/// </summary>
		/// <value>The registry.</value>
		public string Registry
		{
			get;
			set;
		}
	}
}
