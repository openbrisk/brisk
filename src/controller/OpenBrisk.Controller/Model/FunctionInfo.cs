﻿namespace OpenBrisk.Controller.Model
{
	public class FunctionInfo
	{
		/// <summary>
		/// Gets or sets the name of the function.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the namespace for the function.
		/// </summary>
		/// <value>The namespace.</value>
		public string Namespace { get; set; }

		/// <summary>
		/// Gets or sets the runtime image name.
		/// </summary>
		/// <value>The runtime.</value>
		public string Runtime { get; set; }

		/// <summary>
		/// Gets or sets the version of the function.
		/// </summary>
		/// <value>The version.</value>
		public int Version { get; set; }

		/// <summary>
		/// Gets or sets the replica count of the function.
		/// </summary>
		/// <value>The replica count.</value>
		public int ReplicaCount { get; set; }

		/// <summary>
		/// Gets or sets the invocation count of the function.
		/// </summary>
		/// <value>The invocation count.</value>
		public int InvocationCount { get; set; }
	}
}
