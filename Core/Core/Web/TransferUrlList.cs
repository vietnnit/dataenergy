using System;
using System.Web;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;

namespace ePower.Core.Web
{
	/// <summary>
	/// Summary description for UrlRewriter.
	/// </summary>
	public class TransferUrlList
	{
		private static TransferUrlList instance = null;
		private static StringDictionary urls;

		private TransferUrlList()
		{
			// prevent code using the default constructor
			// by making it private
		}
		/// <summary>
		/// public method to return single instance of class 
		/// </summary>
		/// <returns>single instance of class</returns>
		public static TransferUrlList GetInstance()
		{
			// see if instance already created
			if (instance == null)
			{
				// create the instance
				instance = new TransferUrlList();
				urls = new StringDictionary();
				String xmlFilePath = HttpContext.Current.Request.MapPath(ConfigurationSettings.AppSettings.Get("TransferURL"));
				// read list of transfer URLs from XML file
				try
				{
					using (XmlReader reader = XmlReader.Create(xmlFilePath))
					{
						while (reader.Read())
						{
							if (reader.LocalName == "item")
							{
								// populate StringDictionary
								urls.Add(reader.GetAttribute("name"), reader.GetAttribute("url"));
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Transfer url list: Cannot load URL transfer list", ex);
				}
			}
			return instance;
		}
		/// <summary>
		/// public method to return URL for a specified name
		/// </summary>
		/// <param name="urlPathName"></param>
		/// <returns>returns original URL if not found</returns>
		public String GetTransferUrl(String urlPathName)
		{
			if (urls.ContainsKey(urlPathName))
			{
				return urls[urlPathName];
			}
			else
			{
				return urlPathName;
			}
		}
	}
}
