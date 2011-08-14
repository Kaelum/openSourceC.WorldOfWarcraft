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

		#region Attributes

		/// <summary>Gets or sets the private key.</summary>
		[ConfigurationProperty("privateKey", IsRequired = false)]
		public string PrivateKey
		{
			get { return (string)base["privateKey"]; }
			set { base["privateKey"] = value; }
		}

		/// <summary>Gets or sets the public key.</summary>
		[ConfigurationProperty("publicKey", IsRequired = false)]
		public string PublicKey
		{
			get { return (string)base["publicKey"]; }
			set { base["publicKey"] = value; }
		}

		#endregion

		#region Elements

		/// <summary></summary>
		[ConfigurationProperty("apis", IsRequired = true)]
		[ConfigurationCollection(typeof(ApiSettingsCollection))]
		public ApiSettingsCollection ApiSettings
		{
			get { return (ApiSettingsCollection)base["apis"]; }
		}

		/// <summary></summary>
		[ConfigurationProperty("regions", IsRequired = true)]
		[ConfigurationCollection(typeof(RegionSettingsCollection))]
		public RegionSettingsCollection RegionSettings
		{
			get { return (RegionSettingsCollection)base["regions"]; }
		}

		#endregion
	}

	/// <summary>
	///		Contains a collection of <see cref="T:ApiSettingsCollection"/> objects.
	///	</summary>
	[ConfigurationCollection(typeof(ApiSettings))]
	public class ApiSettingsCollection : ConfigurationElementCollection
	{
		#region Contructors

		/// <summary>
		///		Creates a new instance of a <see cref="T:ApiSettingsCollection"/> class.
		///	</summary>
		public ApiSettingsCollection() : base(StringComparer.OrdinalIgnoreCase) { }

		#endregion

		#region Index Accessors

		/// <summary>
		///		Gets or sets the <see cref="ApiSettings"/> object at the specified index
		///		in the collection.
		///	</summary>
		/// <param name="index">The index of a <see cref="ApiSettings"/> object in the
		///		collection.</param>
		/// <returns>
		///		The <see cref="ApiSettings"/> object at the specified index.
		///	</returns>
		public ApiSettings this[int index]
		{
			get { return (ApiSettings)base.BaseGet(index); }

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
		///		Gets or sets the <see cref="ApiSettings"/> object with the specified key
		///		in the collection.
		///	</summary>
		/// <param name="key">The key of an <see cref="ApiSettings"/> object in this
		///		collection.</param>
		/// <returns>
		///		The <see cref="ApiSettings"/> object with the specified key.
		///	</returns>
		public new ApiSettings this[string key]
		{
			get { return (ApiSettings)base.BaseGet(key); }
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
			return new ApiSettings();
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
			return ((ApiSettings)element).Key;
		}

		#endregion
	}

	/// <summary>
	///		Represents an API configuration file section.
	///	</summary>
	public class ApiSettings : ConfigurationElement
	{
		#region Public Properties

		/// <summary>Gets the key (api code).</summary>
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

		/// <summary>Gets or sets the path from the host.</summary>
		[ConfigurationProperty("path", IsRequired = true)]
		public string Path
		{
			get { return (string)base["path"]; }
			set { base["path"] = value; }
		}

		#endregion
	}

	/// <summary>
	///		Contains a collection of <see cref="T:RegionSettingsCollection"/> objects.
	///	</summary>
	[ConfigurationCollection(typeof(RegionSettings))]
	public class RegionSettingsCollection : ConfigurationElementCollection
	{
		#region Contructors

		/// <summary>
		///		Creates a new instance of a <see cref="T:DataFactorySettingsCollection"/> class.
		///	</summary>
		public RegionSettingsCollection() : base(StringComparer.OrdinalIgnoreCase) { }

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
		///		Gets or sets the <see cref="RegionSettings"/> object with the specified key
		///		in the collection.
		///	</summary>
		/// <param name="key">The name of a <see cref="RegionSettings"/> object in this
		///		collection.</param>
		/// <returns>
		///		The <see cref="RegionSettings"/> object with the specified key.
		///	</returns>
		public new RegionSettings this[string key]
		{
			get { return (RegionSettings)base.BaseGet(key); }
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

		#region Attributes

		/// <summary>Gets or sets the name of the default region.</summary>
		[ConfigurationProperty("default", IsRequired = true)]
		public string Default
		{
			get { return (string)base["default"]; }
			set { base["default"] = value; }
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
		[ConfigurationProperty("host", IsRequired = true)]
		public string Host
		{
			get { return (string)base["host"]; }
			set { base["host"] = value; }
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
