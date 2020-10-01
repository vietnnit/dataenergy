using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

/// <summary>
/// Summary description for Cache
/// </summary>
public class AspNetCache
{
	private static object tobj = new object();

	// Hide constructors
	private AspNetCache() { }

	public static bool CheckCache(string key)
	{
		lock (tobj) { return (HttpRuntime.Cache[key] != null); }
	}

	public static object GetCache(string key)
	{
		lock (tobj) { return HttpRuntime.Cache[key]; }
	}

	/// <summary>
	/// Set cache for an object with time alive 3 minutes
	/// </summary>
	/// <param name="key">cache key</param>
	/// <param name="val"></param>
	public static void SetCache(string key, object val)
	{
		//HttpRuntime.Cache[key] = val;
		string strAspNetCacheTime = ConfigurationManager.AppSettings.Get("AspNetCacheTime");
		double cacheTime;
		if (strAspNetCacheTime != null && double.TryParse(strAspNetCacheTime,out cacheTime))
			cacheTime = double.Parse(strAspNetCacheTime);
		else cacheTime = 5;
		SetCacheWithTime(key, val, cacheTime);
	}

	/// <summary>
	/// Set cache with time alive
	/// </summary>
	/// <param name="key">Cache Key</param>
	/// <param name="val">value</param>
	/// <param name="Min">Time alive minutes</param>
	public static void SetCacheWithTime(string key, object val, double Min)
	{
		lock (tobj)
		{
			HttpRuntime.Cache.Remove(key);
			HttpRuntime.Cache.Insert(key, val, null, DateTime.Now.AddMinutes(Min), TimeSpan.Zero);
		}
	}
	/// <summary>
	/// Remove cache from Cache
	/// </summary>
	/// <param name="key">cache key</param>
	public static void RemoveCache(string key)
	{
		lock (tobj) { HttpRuntime.Cache.Remove(key); }
	}
	/// <summary>
	/// Reset all cache
	/// </summary>
	public static void Reset()
	{
		lock (tobj)
		{
			IDictionaryEnumerator ce = HttpRuntime.Cache.GetEnumerator();
			while (ce.MoveNext()) HttpRuntime.Cache.Remove(ce.Key as string);
		}
	}
	/// <summary>
	/// Remove group cache with string prefix
	/// </summary>
	/// <param name="prefix"></param>
	public static void RemoveCacheWithPrefix(string prefix)
	{
		lock (tobj)
		{
			string key;
			IDictionaryEnumerator ce = HttpRuntime.Cache.GetEnumerator();
			while (ce.MoveNext())
			{
				key = ce.Key as string;
				if (key.StartsWith(prefix)) HttpRuntime.Cache.Remove(key);
			}
		}
	}
}