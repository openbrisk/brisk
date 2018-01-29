namespace OpenBrisk.Controller.Model
{
	using System.Runtime.Serialization;

	public enum FunctionRuntime
	{
		/// <summary>
		/// A custom runtime provided by a custom docker image.
		/// </summary>
		[EnumMember(Value = "custom")]
		Custom,

		/// <summary>
		/// The official .NET Core runtime.
		/// </summary>
		[EnumMember(Value = "dotnetcore")]
		DotNetCore
	}
}