using System;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		This exception is thrown when calls to the Community Platform API return an error.
	/// </summary>
	[Serializable]
	public class WorldOfWarcraftApiException : SystemException
	{
		#region Constructors

		/// <summary>
		///		Initializes a new instance of the <see cref="WorldOfWarcraftApiException" /> class.
		/// </summary>
		public WorldOfWarcraftApiException()
			: base() { }

		/// <summary>
		///     Initializes a new instance of the <see cref="WorldOfWarcraftApiException" />
		///     class with serialized data.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		protected WorldOfWarcraftApiException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }

		/// <summary>
		///		Initializes a new instance of the <see cref="WorldOfWarcraftApiException" />
		///		class with the specified error status and reason message.
		/// </summary>
		/// <param name="status">The error status.</param>
		/// <param name="reason">The message that describes the error.</param>
		public WorldOfWarcraftApiException(string status, string reason)
			: base(reason) { Status = status; }

		/// <summary>
		///		Initializes a new instance of the <see cref="WorldOfWarcraftApiException" />
		///		class with a specified error message and a reference to the
		///		inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="status">The error status.</param>
		/// <param name="reason">The message that describes the error.</param>
		/// <param name="innerException">The exception that is the cause
		///     of the current exception. If the innerException parameter is
		///     not a null reference, the current exception is raised in a
		/// c   atch block that handles the inner exception.</param>
		public WorldOfWarcraftApiException(string status, string reason, Exception innerException)
			: base(reason, innerException) { Status = status; }

		#endregion

		#region Public Properties

		/// <summary> Gets or sets the error status.</summary>
		public string Status
		{
			get { return base.Data["Status"] as string; }
			set { base.Data["Status"] = value; }
		}

		#endregion
	}
}
