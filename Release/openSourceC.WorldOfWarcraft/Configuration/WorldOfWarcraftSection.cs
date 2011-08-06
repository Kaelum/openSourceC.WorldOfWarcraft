using System;
using System.Configuration;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for WorldOfWarcraftSection.
	/// </summary>
	public class WorldOfWarcraftSection : ConfigurationSection
	{
		/// <summary>Gets the configuration file section name.</summary>
		public const string SectionName = "openSourceC/worldOfWarcraft";

		private static WorldOfWarcraftSection _configSection = null;
		private static object _configSectionLock = new object();


		#region Instance

		/// <summary>
		///		Gets the singleton instance of <see cref="WorldOfWarcraftSection"/>.
		/// </summary>
		public static WorldOfWarcraftSection Instance
		{
			get
			{
				if (_configSection == null)
				{
					lock (_configSectionLock)
					{
						if (_configSection == null)
						{
							_configSection = (WorldOfWarcraftSection)ConfigurationManager.GetSection(SectionName);

							if (_configSection == null)
							{
								throw new ConfigurationErrorsException(string.Format("Section {0} does not exist in the configuration file.", SectionName));
							}
						}
					}
				}

				return _configSection;
			}
		}

		#endregion

		#region Public Properties

		/// <summary>Gets or sets the name of the default region.</summary>
		[ConfigurationProperty("defaultRegion", IsRequired = true)]
		public string DefaultRegion
		{
			get { return (string)base["defaultRegion"]; }
			set { base["defaultRegion"] = value; }
		}

		/// <summary></summary>
		[ConfigurationProperty("regions", IsRequired = true)]
		[ConfigurationCollection(typeof(RegionsCollection))]
		public RegionsCollection Regions
		{
			get { return (RegionsCollection)base["regions"]; }
		}

		#endregion
	}

	/// <summary>
	///		Contains a collection of <see cref="T:RegionsCollection"/> objects.
	///	</summary>
	[ConfigurationCollection(typeof(RegionSettings))]
	public class RegionsCollection : ConfigurationElementCollection
	{
		#region Contructors

		/// <summary>
		///		Creates a new instance of a <see cref="T:DataFactorySettingsCollection"/> class.
		///	</summary>
		public RegionsCollection() : base(StringComparer.OrdinalIgnoreCase) { }

		#endregion

		#region Index Accessors

		/// <summary>
		///		Gets or sets the <see cref="RegionSettings"/> object at the specified index
		///		in the collection.
		///	</summary>
		/// <param name="index">The index of a <see cref="RegionSettings"/> object in the
		///		collection.</param>
		/// <returns>
		///		The <see cref="RegionSettings"/> object at the specified index.
		///	</returns>
		public RegionSettings this[int index]
		{
			get { return (RegionSettings)base.BaseGet(index); }

			set
			{
				if (base.BaseGet(index) != null)
				{
					base.BaseRemoveAt(index);
				}

				this.BaseAdd(index, value);
			}
		}

		/// <summary>
		///		Gets or sets the <see cref="RegionSettings"/> object with the specified name
		///		in the collection.
		///	</summary>
		/// <param name="name">The name of a <see cref="RegionSettings"/> object in the
		///		collection.</param>
		/// <returns>
		///		The <see cref="RegionSettings"/> object with the specified name.
		///	</returns>
		public new RegionSettings this[string name]
		{
			get { return (RegionSettings)base.BaseGet(name); }
		}

		#endregion

		#region Override Methods

		/// <summary>
		///		Creates a new <see cref="ConfigurationElement"/>.
		/// </summary>
		/// <returns>
		///		A new <see cref="ConfigurationElement"/>.
		/// </returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new RegionSettings();
		}

		/// <summary>
		///		Gets the element key for a specified configuration element when overridden in a
		///		derived class.
		/// </summary>
		/// <param name="element">The <see cref="ConfigurationElement"/> to return the key for.</param>
		/// <returns>
		///		An <see cref="object"/> that acts as the key for the specified <see cref="ConfigurationElement"/>.
		/// </returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((RegionSettings)element).Key;
		}

		#endregion
	}

	/// <summary>
	///		Represents a region configuration file section.
	///	</summary>
	public class RegionSettings : ConfigurationElement
	{
		#region Public Properties

		/// <summary>Gets or sets the base url.</summary>
		[ConfigurationProperty("baseUrl", IsRequired = true)]
		public string BaseUrl
		{
			get { return (string)base["baseUrl"]; }
			set { base["baseUrl"] = value; }
		}

		/// <summary>Gets the key (region code).</summary>
		[ConfigurationProperty("key", IsRequired = true, IsKey = true)]
		public string Key
		{
			get { return (string)base["key"]; }
		}

		/// <summary>Gets or sets the name.</summary>
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)base["name"]; }
			set { base["name"] = value; }
		}

		#endregion
	}
}
