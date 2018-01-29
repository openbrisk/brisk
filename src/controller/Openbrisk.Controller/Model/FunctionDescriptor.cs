namespace Openbrisk.Controller.Model
{
	using System.ComponentModel.DataAnnotations;

	public class Function
	{
		public Function()
		{
			this.Namespace = "openbrisk";
		}

		[Required]
		public string Name
		{
			get;
			set;
		}

		public string Namespace
		{
			get;
			set;
		}

		[Required]
		public string Code
		{
			get;
			set;
		}

		public string Dependencies
		{
			get;
			set;
		}

		[Required]
		public FunctionRuntime Runtime
		{
			get;
			set;
		}
	}
}
