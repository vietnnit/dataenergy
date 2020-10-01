using System.Globalization;
using System.Threading;

namespace ePower.Core.Web
{
    /// <summary>
    /// <see cref="ICultureResolver"/> implementation
    /// that simply returns the <see cref="System.Globalization.CultureInfo"/>
    /// value of the
    /// <see cref="DefaultCulture"/>
    /// property (if said property value is not <cref lang="null"/>), or the
    /// <see cref="System.Globalization.CultureInfo"/> of the current thread if it is
    /// <cref lang="null"/>.
    /// </summary>
    /// <author>Aleksandar Seovic</author>
    public class DefaultCultureResolver : ICultureResolver
    {
        private CultureInfo defaultCulture;

        /// <summary>
        /// The default <see cref="System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <value>
        /// The default <see cref="System.Globalization.CultureInfo"/>.
        /// </value>
        public CultureInfo DefaultCulture
        {
            get { return defaultCulture; }
            set { defaultCulture = value; }
        }

        /// <summary>
        /// Returns the default <see cref="System.Globalization.CultureInfo"/>. 
        /// </summary>
        /// <remarks>
        /// <p>
        /// It tries to get the <see cref="System.Globalization.CultureInfo"/>
        /// from the value of the
        /// <see cref="DefaultCulture"/>
        /// property and falls back to the <see cref="System.Globalization.CultureInfo"/> of the
        /// current thread if the
        /// <see cref="DefaultCulture"/>
        /// is <cref lang="null"/>.
        /// </p>
        /// </remarks>
        /// <returns>
        /// The default <see cref="System.Globalization.CultureInfo"/>
        /// </returns>
        protected virtual CultureInfo GetDefaultLocale()
        {
            if (defaultCulture != null)
            {
                return defaultCulture;
            }
            else
            {
                return Thread.CurrentThread.CurrentCulture;
            }
        }

        /// <summary>
        /// Resolves the <see cref="System.Globalization.CultureInfo"/>
        /// from some context.
        /// </summary>
        /// <remarks>
        /// <p>
        /// The 'context' in this implementation is the
        /// <see cref="System.Globalization.CultureInfo"/> value of the
        /// <see cref="DefaultCulture"/>
        /// property (if said property value is not <cref lang="null"/>), or the
        /// <see cref="System.Globalization.CultureInfo"/> of the current thread if it is
        /// <cref lang="null"/>.
        /// </p>
        /// </remarks>
        /// <returns>
        /// The <see cref="System.Globalization.CultureInfo"/> that should be used
        /// by the caller.
        ///  </returns>
        public virtual CultureInfo ResolveCulture()
        {
            return GetDefaultLocale();
        }

        /// <summary>
        /// Sets the <see cref="System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="culture">
        /// The new <see cref="System.Globalization.CultureInfo"/> or
        /// <cref lang="null"/> to clear the current <see cref="System.Globalization.CultureInfo"/>.
        /// </param>
        /// <seealso cref="DefaultCulture"/>
        /// <seealso cref="ICultureResolver.SetCulture"/>
        public virtual void SetCulture(CultureInfo culture)
        {
            defaultCulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

        }
    }
}