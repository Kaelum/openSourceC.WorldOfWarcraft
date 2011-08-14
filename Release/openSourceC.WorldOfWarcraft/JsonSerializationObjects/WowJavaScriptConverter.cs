using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for WowJavaScriptConverter.
	/// </summary>
	public class WowJavaScriptConverter : JavaScriptConverter
	{
		/// <summary>January 1, 1970 @ Midnight UTC.</summary>
		public static readonly DateTime ZeroDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


		/// <summary>
		///		
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static long ConvertDateTimeToLong(DateTime value)
		{
			return (long)value.Subtract(WowJavaScriptConverter.ZeroDate).TotalMilliseconds;
		}

		/// <summary>
		///		
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static DateTime ConvertLongToDateTime(long value)
		{
			return WowJavaScriptConverter.ZeroDate.AddMilliseconds(value);
		}

		/// <summary>
		///		Converts the provided dictionary into an object of the specified type.
		/// </summary>
		/// <param name="dictionary"></param>
		/// <param name="type"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}

			//if (type == typeof(ListItemCollection))
			//{
			//    // Create the instance to deserialize into.
			//    ListItemCollection list = new ListItemCollection();

			//    // Deserialize the ListItemCollection's items.
			//    ArrayList itemsList = (ArrayList)dictionary["List"];

			//    for (int i = 0; i < itemsList.Count; i++)
			//        list.Add(serializer.ConvertToType<ListItem>(itemsList[i]));

			//    return list;
			//}

			if (type == typeof(DateTime))
			{
				return ZeroDate.AddMilliseconds((double)dictionary["value"]);
			}

			return null;
		}

		/// <summary>
		///		
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///		Gets a collection of the supported types.
		/// </summary>
		public override IEnumerable<Type> SupportedTypes
		{
			get
			{
				return new ReadOnlyCollection<Type>(new List<Type>(new Type[] {
					typeof(DateTime),
				}));
			}
		}
	}
}
