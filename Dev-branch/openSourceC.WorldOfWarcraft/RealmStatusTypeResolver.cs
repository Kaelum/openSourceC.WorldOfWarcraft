using System;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for RealmStatusTypeResolver.
	/// </summary>
	public class RealmStatusTypeResolver : JavaScriptTypeResolver
	{
		/// <summary>
		///		
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public override Type ResolveType(string id)
		{
			return Type.GetType(id);
		}

		/// <summary>
		///		
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public override string ResolveTypeId(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}

			if (type != typeof(Realm))
			{
				//
			}

			return type.Name;
		}
	}
}
