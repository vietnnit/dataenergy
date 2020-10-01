using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace ePower.Core.Web
{
    /// <summary>
    /// Default culture resolver for web applications. Contains some common utility methods for web culture resolvers.
    /// </summary>
    /// <author>Aleksandar Seovic</author>
    public class DefaultWebCultureResolver : DefaultCultureResolver
    {
        /// <summary>
        /// Returns default culture. If <see cref="DefaultCultureResolver.DefaultCulture"/> property is not set, 
        /// it tries to get culture from the request headers
        /// and falls back to a current thread's culture if no headers are available.
        /// </summary>
        /// <returns>Default culture to use.</returns>
        protected override CultureInfo GetDefaultLocale()
        {
            if (DefaultCulture != null)
            {
                return base.DefaultCulture;
            }
            string Lang="vi-VN";
            if (HttpContext.Current.Session["SessionCurrentLanguage"] != null && HttpContext.Current.Session["SessionCurrentLanguage"].ToString() != string.Empty)
                Lang = HttpContext.Current.Session["SessionCurrentLanguage"].ToString();
            CultureInfo culture = GetCulture(Lang);
            if (culture != null)
            {
                return culture;
            }

            return Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// Extracts the users favorite language from "accept-language" header of the current request.
        /// </summary>
        /// <returns>a language string if any or <c>null</c>, if no languages have been sent with the request</returns>
        protected virtual string GetRequestLanguage()
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Request != null && ArrayUtils.HasLength(context.Request.UserLanguages))
            {                
                return context.Request.UserLanguages[0];
            }
            return null;    
        }

        /// <summary>
        /// Resolves a culture by name.
        /// </summary>
        /// <param name="cultureName">the name of the culture to get</param>
        /// <returns>a (possible neutral!) <see cref="CultureInfo"/> or <c>null</c>, if culture could not be resolved</returns>
        public CultureInfo GetCulture(string cultureName)
        {
            try { return new CultureInfo(cultureName.Split(';')[0]); } catch { }
            return null;
        }

        /// <summary>
        /// Resolves the culture from the context.
        /// </summary>
        /// <returns>Culture that should be used to render view.</returns>
        public override CultureInfo ResolveCulture()
        {
            return GetDefaultLocale();
        }   
    }
}