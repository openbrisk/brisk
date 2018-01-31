namespace OpenBrisk.Gateway.Model
{
	using Newtonsoft.Json;

	public class FunctionInvocationDescriptor
	{
		public FunctionInvocationDescriptor()
		{
			this.IsAsync = false;
			this.Data = string.Empty;
		}

		/// <summary>
		/// Gets or sets a value indicating whether tthe function should be
		/// executed asynchronous.
		/// </summary>
		/// <value><c>true</c> if the call is async; otherwise, <c>false</c>.</value>
		[JsonProperty("async")]
		public bool IsAsync { get; set; }

		/// <summary>
		/// Gets or sets the data passed to the function.
		/// </summary>
		/// <value>The data.</value>
		public string Data { get; set; }
	}
}
