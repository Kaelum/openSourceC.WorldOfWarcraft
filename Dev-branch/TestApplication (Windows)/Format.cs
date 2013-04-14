using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Permissions;
using System.Text;

namespace TestApplication
{
	/// <summary>
	///		Summary description for Format.
	/// </summary>
	public static class Format
	{
		/// <summary>
		///     Formats a message for logging from an exception.
		/// </summary>
		/// <param name="e">The Exception object to format.</param>
		/// <retvalue>
		///     <para>A nicely formatted exception string, including message and StackTrace information.</para>
		/// </retvalue>
		public static string Exception(Exception e)
		{
			return Exception(e, null);
		}

		/// <summary>
		///     Formats a message for logging from an exception.
		/// </summary>
		/// <param name="e">The Exception object to format.</param>
		/// <param name="catchMsg">The string to prepend to the exception information.</param>
		/// <retvalue>
		///     <para>A nicely formatted exception string, including message and StackTrace information.</para>
		/// </retvalue>
		[RegistryPermissionAttribute(SecurityAction.Assert)]
		public static string Exception(Exception e, string catchMsg)
		{
			StringBuilder strBuilder;
			StackTrace st;
			StackFrame sf;
			MethodBase mb;


			strBuilder = new StringBuilder();

			if (e == null)
			{
				if (!string.IsNullOrEmpty(catchMsg))
				{
					strBuilder.Append(catchMsg);
				}
			}
			else
			{
				st = new StackTrace(e, true);

				if (st.FrameCount > 0)
				{
					sf = st.GetFrame(st.FrameCount - 1);
					mb = sf.GetMethod();

					strBuilder.AppendFormat("{0}.{1}", mb.DeclaringType.FullName, mb.Name);

#if DEBUG
					if (sf.GetFileLineNumber() != 0)
					{
						strBuilder.AppendFormat(": line {0}", sf.GetFileLineNumber());
					}
#endif
				}

				if (!string.IsNullOrEmpty(catchMsg))
				{
					strBuilder.AppendFormat(": {0}", catchMsg);
				}
			}

			while (e != null)
			{
				if (strBuilder.Length != 0)
				{
					strBuilder.Append(Environment.NewLine).Append(Environment.NewLine);
				}

				strBuilder.Append(e.GetType());

				if (e is System.Runtime.InteropServices.ExternalException)
				{
					strBuilder.AppendFormat(" (0x{0,8:X})", ((System.Runtime.InteropServices.ExternalException)e).ErrorCode);
				}

				string message = (e.Message == null ? null : e.Message.Replace("\n", Environment.NewLine));
				string stackTrace = (e.StackTrace == null ? null : e.StackTrace.Replace("\n", Environment.NewLine));

				strBuilder.AppendFormat(": {0}{2}{1}", message, stackTrace, Environment.NewLine);

				if (e is System.Data.SqlClient.SqlException)
				{
					System.Data.SqlClient.SqlException ex = (System.Data.SqlClient.SqlException)e;


					strBuilder.AppendFormat("{0}SQL Errors:{0}", Environment.NewLine);

					for (int i = 0; i < ex.Errors.Count; i++)
					{
						strBuilder.AppendFormat("\t{1}: Msg {2}, Level {3}, State {4}, Line {5}{0}\t\tSource: {6}{0}\t\tProcedure: {7}\t\t{8}",
							Environment.NewLine,
							i,
							ex.Errors[i].Number,
							ex.Errors[i].Class,
							ex.Errors[i].State,
							ex.Errors[i].LineNumber,
							ex.Errors[i].Source,
							ex.Errors[i].Procedure,
							ex.Errors[i].Message
						);
					}
				}

				e = e.InnerException;
			}

			return strBuilder.ToString();
		}
	}
}
