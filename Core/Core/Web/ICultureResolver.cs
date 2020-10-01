using System.Globalization;



namespace ePower.Core.Web
{
    /// <summary>
    /// Strategy interface for <see cref="System.Globalization.CultureInfo"/>
    /// resolution.
    /// </summary>
    public interface ICultureResolver
    {
        /// <summary>
        /// Resolves the <see cref="System.Globalization.CultureInfo"/>
        /// from some context.
        /// </summary>
        /// <remarks>
        /// <p>
        /// The 'context' is determined by the appropriate implementation class.
        /// An example of such a context might be a thread local bound
        /// <see cref="System.Globalization.CultureInfo"/>, or a
        /// <see cref="System.Globalization.CultureInfo"/> sourced from an HTTP
        /// session.
        /// </p>
        /// </remarks>
        /// <returns>
        /// The <see cref="System.Globalization.CultureInfo"/> that should be used
        /// by the caller.
        ///  </returns>
        CultureInfo ResolveCulture();

        /// <summary>
        /// Sets the <see cref="System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <remarks>
        /// <p>
        /// This is an optional operation and does not need to be implemented
        /// such that it actually does anything useful (i.e. it can be a no-op).
        /// </p>
        /// </remarks>
        /// <param name="culture">
        /// The new <see cref="System.Globalization.CultureInfo"/> or
        /// <cref lang="null"/> to clear the current <see cref="System.Globalization.CultureInfo"/>.
        /// </param>
        void SetCulture(CultureInfo culture);
    }
}