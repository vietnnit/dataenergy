using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using log4net;

/// <summary>
/// Custom asp.net web page to vsolution page
/// </summary>
namespace ePower.Core.Web
{
    public class PageControllerBase : Page
    {
        private ICultureResolver cultureResolver = new DefaultWebCultureResolver();
        private static readonly ILog log = LogManager.GetLogger(typeof(PageControllerBase));
        // values that will be available in page class
        protected UserControl displayView = null;
        protected String displayViewName
        {
            get
            {
                if (ViewState["displayViewName"] != null) return ViewState["displayViewName"].ToString();
                return String.Empty;
            }
            set { ViewState["displayViewName"] = value; }
        }
        protected String noViewSelectedText = "No View Selected";
        private string m_DefaultCulture = ConfigurationSettings.AppSettings.Get("DefaultCulture");

        // define method that concrete page classes must implement
        // and will be called by this base class after Page_Load
        virtual protected void PageLoadEvent(Object sender, System.EventArgs e)
        {
            // overridden in concrete page implementation
        }
        public ICultureResolver CultureResolver
        {
            get { return cultureResolver; }
            set { cultureResolver = value; }
        }
        public virtual CultureInfo UserCulture
        {
            get { return CultureInfo.CurrentCulture; }
        }
        public event EventHandler UserCultureChanged;

        /// <summary>
        /// Raises UserLocaleChanged event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnUserCultureChanged(EventArgs e)
        {
            if (UserCultureChanged != null)
                UserCultureChanged(this, e);
        }

        protected override void InitializeCulture()
        {
            //retrieve culture information from session
            string culture = string.Empty;

            if (!string.IsNullOrEmpty(Context.Request.QueryString["lang"]))
            {
                culture = Context.Request.QueryString["lang"].Trim();
            }
            else
                culture = System.Configuration.ConfigurationSettings.AppSettings["DefaultCulture"].ToString();

            if (Session["VCulture"] != null)
                culture = Session["VCulture"].ToString();

            //check whether a culture is stored in the session
            if (!string.IsNullOrEmpty(culture)) Culture = culture;
            else Culture = m_DefaultCulture;

            CultureInfo userCulture = this.UserCulture;
            Thread.CurrentThread.CurrentUICulture = userCulture;
            if (userCulture.IsNeutralCulture)
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(m_DefaultCulture);
            else
                Thread.CurrentThread.CurrentCulture = userCulture;
        }
        protected void Page_Load(Object sender, System.EventArgs e)
        {
            // get name of view (UserControl) to show in the page 
            //if (!IsPostBack)
            //{
            displayViewName = Context.Request.QueryString["view"];
            if (displayViewName != null && displayViewName != String.Empty)
            {
                try
                {
                    // load view from ASCX file
                    string foldername = Context.Request.QueryString["folder"];
                    if (foldername != null && foldername != string.Empty)
                        displayView = (UserControl)Page.LoadControl(foldername + "\\" + displayViewName + ".ascx");
                    else
                        displayView = (UserControl)Page.LoadControl(displayViewName + ".ascx");
                    displayView.EnableViewState = true;
                }
                catch (Exception ex)
                {
                    log.Fatal("Load page controller has an exception: ", ex);
                }

                // call concrete page class method

                PageLoadEvent(sender, e);
            }
            //}

        }


        #region Sorting support


        #endregion
    }
}
