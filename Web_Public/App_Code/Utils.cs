using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Text;
using ETO;
using BSO;
using System.Collections.Generic;
using System.IO;

/// Summary description for Utils
/// </summary>
public class Utils
{

    public Utils()
    {

    }
    public static string LoadMasterPage(string urlRoot, string strSlugPage, HttpRequest request, Page pageContainer, PlaceHolder placeHolderMainContent)
    {
        //IList<SYS_PageLayout> list = new List<SYS_PageLayout>();
        string strMaster = "MasterPage.master";
        if (strSlugPage != string.Empty)
        {
            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            SYS_PageLayout _pageLayout = new SYS_PageLayout();

            if (!AspNetCache.CheckCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_")))
            {
                _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug(strSlugPage, Language.language);
                if (_pageLayout == null)
                    _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug("home", Language.language);

                AspNetCache.SetCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_"), _pageLayout);
            }
            else
                _pageLayout = (SYS_PageLayout)AspNetCache.GetCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_"));


            if (_pageLayout != null)
            {

                SYS_TemplatePageBSO _templateBSO = new SYS_TemplatePageBSO();
                SYS_TemplatePage _template = new SYS_TemplatePage();

                if (!AspNetCache.CheckCache("Template_" + _pageLayout.TemplateId))
                {
                    _template = _templateBSO.GetSYS_TemplatePageById(_pageLayout.TemplateId);
                    AspNetCache.SetCache("Template_" + _pageLayout.TemplateId, _template);
                }
                else
                    _template = (SYS_TemplatePage)AspNetCache.GetCache("Template_" + _pageLayout.TemplateId);


                if (_template != null)
                {
                    strMaster = _template.MasterControl;
                }

            }

        }

        return strMaster;

    }

    public static string LoadMasterPage(string urlRoot, string strSlugPage, HttpRequest request, Page pageContainer, PlaceHolder placeHolderMainContent, string lang)
    {
        //IList<SYS_PageLayout> list = new List<SYS_PageLayout>();
        string strMaster = "MasterPage.master";
        if (strSlugPage != string.Empty)
        {
            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            SYS_PageLayout _pageLayout = new SYS_PageLayout();

            if (!AspNetCache.CheckCache("PageLayout_" + strSlugPage + "_" + lang.Replace("-", "_")))
            {
                _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug(strSlugPage, lang);
                if (_pageLayout == null)
                    _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug("home", lang);

                AspNetCache.SetCache("PageLayout_" + strSlugPage + "_" + lang.Replace("-", "_"), _pageLayout);
            }
            else
                _pageLayout = (SYS_PageLayout)AspNetCache.GetCache("PageLayout_" + strSlugPage + "_" + lang.Replace("-", "_"));


            if (_pageLayout != null)
            {

                SYS_TemplatePageBSO _templateBSO = new SYS_TemplatePageBSO();
                SYS_TemplatePage _template = new SYS_TemplatePage();

                if (!AspNetCache.CheckCache("Template_" + _pageLayout.TemplateId))
                {
                    _template = _templateBSO.GetSYS_TemplatePageById(_pageLayout.TemplateId);
                    AspNetCache.SetCache("Template_" + _pageLayout.TemplateId, _template);
                }
                else
                    _template = (SYS_TemplatePage)AspNetCache.GetCache("Template_" + _pageLayout.TemplateId);


                if (_template != null)
                {
                    strMaster = _template.MasterControl;
                }

            }

        }

        return strMaster;

    }

    public static void AddWidgetPage(string urlRoot, string strSlugPage, HttpRequest request, Page pageContainer, PlaceHolder placeHolderMainContent)
    {
        //IList<SYS_PageLayout> list = new List<SYS_PageLayout>();

        if (strSlugPage != string.Empty)
        {
            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            SYS_PageLayout _pageLayout = new SYS_PageLayout();

            if (!AspNetCache.CheckCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_")))
            {
                _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug(strSlugPage, Language.language);
                if (_pageLayout == null)
                    _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug("home", Language.language);

                AspNetCache.SetCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_"), _pageLayout);
            }
            else
                _pageLayout = (SYS_PageLayout)AspNetCache.GetCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_"));


            if (_pageLayout != null)
            {

                SYS_TemplatePageBSO _templateBSO = new SYS_TemplatePageBSO();
                SYS_TemplatePage _template = new SYS_TemplatePage();

                if (!AspNetCache.CheckCache("Template_" + _pageLayout.TemplateId))
                {
                    _template = _templateBSO.GetSYS_TemplatePageById(_pageLayout.TemplateId);
                    AspNetCache.SetCache("Template_" + _pageLayout.TemplateId, _template);
                }
                else
                    _template = (SYS_TemplatePage)AspNetCache.GetCache("Template_" + _pageLayout.TemplateId);


                if (_template != null)
                {
                    string _path = urlRoot + "Client/Skins/Templates/" + _template.TemplateControl;
                    Control objControl = (Control)pageContainer.LoadControl(_path);
                    placeHolderMainContent.Controls.Add(objControl);
                    AddWidgetPageLayout(objControl, _pageLayout.Id, urlRoot, pageContainer);

                }

            }

        }

    }
    private static void AddWidget(Control objControl, int PagelayoutId, string urlRoot, Page pageContainer)
    {
        ControlCollection _controls = objControl.Controls;

        SYS_WidgetPageBSO _widgetBSO = new SYS_WidgetPageBSO();
        DataTable tblWidget = new DataTable();


        //if (!AspNetCache.CheckCache(Constants.CacheWidgetAll))
        //{
        //    listUserControlAll = new SYS_WidgetPageBSO().GetSYS_WidgetPageByPageLayoutId(PagelayoutId, true);
        //    AspNetCache.SetCache(Constants.CacheWidgetAll, listUserControlAll);
        //}
        //else
        //    listUserControlAll = (IList<WidgetPage>)AspNetCache.GetCache(Constants.CacheWidgetAll);



        foreach (Control obj1 in _controls)
        {
            if (obj1 != null && obj1.ID != null)
            {
                if (!AspNetCache.CheckCache("Widget_" + PagelayoutId + "_" + obj1.ID))
                {
                    tblWidget = _widgetBSO.GetSYS_WidgetPageByRegionId(obj1.ID, PagelayoutId, true, Language.language);
                    AspNetCache.SetCache("Widget_" + PagelayoutId + "_" + obj1.ID, tblWidget);
                }
                else
                    tblWidget = (DataTable)AspNetCache.GetCache("Widget_" + PagelayoutId + "_" + obj1.ID);


                if (tblWidget != null && tblWidget.Rows.Count > 0)
                    for (int i = 0; i < tblWidget.Rows.Count; i++)
                    {
                        //try
                        //{
                        DataRow row = tblWidget.Rows[i];

                        string _path2 = urlRoot + "Client/Modules/" + row["WidgetDir"].ToString() + "/" + row["WidgetControl"].ToString() + ".ascx";
                        Control objControl1 = (Control)pageContainer.LoadControl(_path2);
                        objControl1.ID = row["Id"].ToString();
                        obj1.Controls.Add(objControl1);
                        ControlAddParameter(objControl1, row["WidgetTitle"].ToString(), row["WidgetIcon"].ToString(), row["WidgetValue"].ToString(), Convert.ToInt32(row["WidgetRecord"].ToString()), row["WidgetInfo"].ToString(), row["WidgetValue2"].ToString(), Convert.ToInt32(row["WidgetRecord2"].ToString()), row["WidgetHTML"].ToString());
                        //    (objControl1, row["WidgetTitle"].ToString(), row["WidgetIcon"].ToString(), row["WidgetValue"].ToString(), Convert.ToInt32(row["WidgetRecord"].ToString()), row["WidgetInfo"].ToString());
                        //obj1.Controls.Add(new LiteralControl("<br/>"));
                        //}
                        //catch (Exception ex)
                        //{
                        //   // Tool.Message(ex);
                        //    //throw ex;
                        //}
                    }
            }
        }
    }

    private static void AddWidgetPageLayout(Control objControl, int PagelayoutId, string urlRoot, Page pageContainer)
    {
        ControlCollection _controls = objControl.Controls;

        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable tblWidget = new DataTable();

        foreach (Control obj1 in _controls)
        {
            if (obj1 != null && obj1.ID != null)
            {
                if (!AspNetCache.CheckCache("Widget_" + PagelayoutId + "_" + obj1.ID))
                {
                    tblWidget = _widgetBSO.GetSYS_WidgetPageLayoutByRegionId(obj1.ID, PagelayoutId, true, Language.language);
                    AspNetCache.SetCache("Widget_" + PagelayoutId + "_" + obj1.ID, tblWidget);
                }
                else
                    tblWidget = (DataTable)AspNetCache.GetCache("Widget_" + PagelayoutId + "_" + obj1.ID);


                if (tblWidget != null && tblWidget.Rows.Count > 0)
                    for (int i = 0; i < tblWidget.Rows.Count; i++)
                    {
                        DataRow row = tblWidget.Rows[i];

                        string _path2 = urlRoot + "Client/Modules/" + row["WidgetDir"].ToString() + "/" + row["WidgetControl"].ToString() + ".ascx";
                        Control objControl1 = (Control)pageContainer.LoadControl(_path2);
                        objControl1.ID = row["Id"].ToString();
                        obj1.Controls.Add(objControl1);
                        ControlAddParameter(objControl1, row["Title"].ToString(), row["Icon"].ToString(), row["Value"].ToString(), Convert.ToInt32(row["Record"].ToString()), row["Info"].ToString(), row["Value2"].ToString(), Convert.ToInt32(row["Record2"].ToString()), row["HTML"].ToString());
                    }
            }
        }
    }

    private static void ControlAddParameter(Control _control, string title, string icon, string value, int record, string info, string value2, int record2, string html)
    {

        Control _controlsTitle = _control.FindControl("hddTitle");
        if (_controlsTitle != null)
        {
            Type objTypeTitle = _controlsTitle.GetType();
            if (objTypeTitle.Name == "HiddenField")
            {
                HiddenField objlbl = (HiddenField)_controlsTitle;
                objlbl.Value = title;
            }
        }

        Control _controlsTitle1 = _control.FindControl("lblTitle");
        if (_controlsTitle1 != null)
        {
            Type objTypeTitle1 = _controlsTitle1.GetType();
            if (objTypeTitle1.Name == "Label")
            {
                Label objlbl1 = (Label)_controlsTitle1;
                objlbl1.Text = title;
            }
        }

        Control _controlsIcon = _control.FindControl("imgIcon");
        if (_controlsIcon != null)
        {
            Type objTypeIcon = _controlsIcon.GetType();
            if (objTypeIcon.Name == "Image")
            {
                Image objimg = (Image)_controlsIcon;
                objimg.ImageUrl = "~/Upload/Widgets/Icons/" + icon;
            }
        }


        Control _controlsValue = _control.FindControl("hddValue");
        if (_controlsValue != null)
        {
            Type objTypeValue = _controlsValue.GetType();
            if (objTypeValue.Name == "HiddenField")
            {
                HiddenField objvalue = (HiddenField)_controlsValue;
                objvalue.Value = value;
            }
        }

        Control _controlsRecord = _control.FindControl("hddRecord");
        if (_controlsRecord != null)
        {
            Type objTypeRecord = _controlsRecord.GetType();
            if (objTypeRecord.Name == "HiddenField")
            {
                HiddenField objRecord = (HiddenField)_controlsRecord;
                objRecord.Value = record.ToString();
            }
        }

        Control _controlsHelp = _control.FindControl("ltlAdvModule");
        if (_controlsHelp != null)
        {
            Type objTypeHelp = _controlsHelp.GetType();
            if (objTypeHelp.Name == "Literal")
            {
                Literal objHelp = (Literal)_controlsHelp;
                objHelp.Text = info;
            }
        }

        Control _controlsValue2 = _control.FindControl("hddValue2");
        if (_controlsValue2 != null)
        {
            Type objTypeValue2 = _controlsValue2.GetType();
            if (objTypeValue2.Name == "HiddenField")
            {
                HiddenField objvalue2 = (HiddenField)_controlsValue2;
                objvalue2.Value = value2;
            }
        }

        Control _controlsRecord2 = _control.FindControl("hddRecord2");
        if (_controlsRecord2 != null)
        {
            Type objTypeRecord2 = _controlsRecord2.GetType();
            if (objTypeRecord2.Name == "HiddenField")
            {
                HiddenField objRecord2 = (HiddenField)_controlsRecord2;
                objRecord2.Value = record2.ToString();
            }
        }

        Control _controlsHTML = _control.FindControl("ltlHTML");
        if (_controlsHTML != null)
        {
            Type objTypeHTML = _controlsHTML.GetType();
            if (objTypeHTML.Name == "Literal")
            {
                Literal objHTML = (Literal)_controlsHTML;
                objHTML.Text = html;
            }
        }
    }

    public string GetIpAddress()
    {
        return HttpContext.Current.Request.UserHostAddress;
    }


    public string GetInfoUser()
    {
        return (string)AspNetCache.GetCache(GetIpAddress());
    }

    public static DateTime GetMonday(int week)
    {
        DateTime today = DateTime.Today;
        DateTime monday = DateTime.Today;
        //int j = Convert.ToInt32(Request.Params["w"]);
        //  int j = Convert.ToInt32(Session["TGian"].ToString());
        // int j = 1; //TGian = 1, w=1
        int j = week;
        if (j == 1)
        {
            j = 1;
            //Session["TGian"] = 1;
            today = DateTime.Today;
        }
        else
        {
            today = today.AddDays((j * 7) - 7);
        }

        monday = DateTime.Today;

        for (int i = 0; i < 7; i++)
        {
            if (today.AddDays(-i).DayOfWeek == DayOfWeek.Monday)
            {
                monday = today.AddDays(-i);
            }

        }

        return monday;


    }

    public static DateTime GetSunday(int week)
    {
        DateTime today = DateTime.Today;
        DateTime sunday = DateTime.Today;
        //int j = Convert.ToInt32(Request.Params["w"]);
        //  int j = Convert.ToInt32(Session["TGian"].ToString());
        // int j = 1; //TGian = 1, w=1
        int j = week;
        if (j == 1)
        {
            j = 1;
            //Session["TGian"] = 1;
            today = DateTime.Today;
        }
        else
        {
            today = today.AddDays((j * 7) - 7);
        }


        sunday = DateTime.Today;
        for (int i = 0; i < 7; i++)
        {

            if (today.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
            {
                sunday = today.AddDays(i);
            }
        }

        return sunday;

    }

    public string Getstring(string _txt)
    {

        Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string v_str_FormD = _txt.Normalize(NormalizationForm.FormD);
        return RemoveExtraSpaces(UCS2Convert(v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ", "-").Replace(":", "")));
    }

    private string RemoveExtraSpaces(string s)
    {
        if (!s.Contains("--")) return s;

        return RemoveExtraSpaces(s.Replace("--", "-"));
    }

    public static String UCS2Convert(String sContent)
    {
        sContent = sContent.Trim();
        String sUTF8Lower = "a|á|à|ả|ã|ạ|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ|đ|e|é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ|i|í|ì|ỉ|ĩ|ị|o|ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ|u|ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự|y|ý|ỳ|ỷ|ỹ|ỵ";

        String sUTF8Upper = "A|Á|À|Ả|Ã|Ạ|Ă|Ắ|Ằ|Ẳ|Ẵ|Ặ|Â|Ấ|Ầ|Ẩ|Ẫ|Ậ|Đ|E|É|È|Ẻ|Ẽ|Ẹ|Ê|Ế|Ề|Ể|Ễ|Ệ|I|Í|Ì|Ỉ|Ĩ|Ị|O|Ó|Ò|Ỏ|Õ|Ọ|Ô|Ố|Ồ|Ổ|Ỗ|Ộ|Ơ|Ớ|Ờ|Ở|Ỡ|Ợ|U|Ú|Ù|Ủ|Ũ|Ụ|Ư|Ứ|Ừ|Ử|Ữ|Ự|Y|Ý|Ỳ|Ỷ|Ỹ|Ỵ";

        String sUCS2Lower = "a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|d|e|e|e|e|e|e|e|e|e|e|e|e|i|i|i|i|i|i|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|u|u|u|u|u|u|u|u|u|u|u|u|y|y|y|y|y|y";

        String sUCS2Upper = "A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|D|E|E|E|E|E|E|E|E|E|E|E|E|I|I|I|I|I|I|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|U|U|U|U|U|U|U|U|U|U|U|U|Y|Y|Y|Y|Y|Y";

        String[] aUTF8Lower = sUTF8Lower.Split(new Char[] { '|' });

        String[] aUTF8Upper = sUTF8Upper.Split(new Char[] { '|' });

        String[] aUCS2Lower = sUCS2Lower.Split(new Char[] { '|' });

        String[] aUCS2Upper = sUCS2Upper.Split(new Char[] { '|' });

        Int32 nLimitChar;

        nLimitChar = aUTF8Lower.GetUpperBound(0);

        for (int i = 1; i <= nLimitChar; i++)
        {

            sContent = sContent.Replace(aUTF8Lower[i], aUCS2Lower[i]);

            sContent = sContent.Replace(aUTF8Upper[i], aUCS2Upper[i]);

        }
        string sUCS2regex = @"[A-Za-z0-9- ]";
        string sEscaped = new Regex(sUCS2regex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty);
        if (string.IsNullOrEmpty(sEscaped))
            return sContent;
        sEscaped = sEscaped.Replace("[", "\\[");
        sEscaped = sEscaped.Replace("]", "\\]");
        sEscaped = sEscaped.Replace("^", "\\^");
        string sEscapedregex = @"[" + sEscaped + "]";
        return new Regex(sEscapedregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty);
    }


    public static string FixHtml(string Html)
    {
        string strOutput = Html;
        //Stripts the <p> tags from the Html
        string pregex = @"<p[^>.]*>&nbsp;</p>";
        System.Text.RegularExpressions.Regex p = new System.Text.RegularExpressions.Regex(pregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
        strOutput = p.Replace(strOutput, "<br>");

        //Stripts the <link> tags from the Html
        string linkregex = @"<link[\s\S]*?>";
        System.Text.RegularExpressions.Regex link = new System.Text.RegularExpressions.Regex(linkregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
        strOutput = link.Replace(strOutput, string.Empty);

        //Stripts the <style> tags from the Html
        string styleregex = @"<style[^>.]*>[\s\S]*?</style>";
        System.Text.RegularExpressions.Regex styles = new System.Text.RegularExpressions.Regex(styleregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
        strOutput = styles.Replace(strOutput, string.Empty);

        //Stripts the [if tags from the Html
        string ifregex = @"<!--[^>.]*>[\s\S]*?<![^>.]*-->";
        System.Text.RegularExpressions.Regex iftag = new System.Text.RegularExpressions.Regex(ifregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
        strOutput = iftag.Replace(strOutput, string.Empty);
        return strOutput;
    }
    public static string SubString(string sSource, int length)
    {
        if (string.IsNullOrEmpty(sSource))
            return string.Empty;
        if (sSource.Length <= length)
            return sSource;

        string mSource = sSource;
        int nLength = length;

        int m = mSource.Length;
        while (nLength > 0 && mSource[nLength].ToString() != " ")
        {
            nLength--;
        }
        mSource = mSource.Substring(0, nLength);
        return mSource + "...";
    }
    public static string FixSubString(string sSource, int length)
    {
        if (string.IsNullOrEmpty(sSource))
            return string.Empty;
        if (sSource.Length <= length)
            return sSource;
        return sSource.Substring(0, length) + "...";
    }

    public static bool isMobileBrowser()
    {
        //GETS THE CURRENT USER CONTEXT
        HttpContext context = HttpContext.Current;

        //FIRST TRY BUILT IN ASP.NT CHECK
        if (context.Request.Browser.IsMobileDevice)
        {
            return true;
        }
        //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
        if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
        {
            return true;
        }
        //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
        if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
            context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
        {
            return true;
        }
        //AND FINALLY CHECK THE HTTP_USER_AGENT 
        //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            //Create a list of all mobile types
            string[] mobiles =
                new[]
                {
                    "midp", "j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                    "NEC", "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };

            //Loop through each item in the list created above 
            //and check if the header contains that text
            foreach (string s in mobiles)
            {
                if (context.Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static string getURLThumbImage(string url, int size)
    {
        string result = "";
        if (url != "" && size != 0)
        {
            result = checkImgCache(url, size);
            if (result == "")
            {
                if (Variables.sWebRoot == "")
                {
                    result = Variables.sThumbImage + "img.ashx?url=" + url + "&w=" + size.ToString();
                }
                else
                {
                    result = Variables.sThumbImage + "imgUrl.ashx?url=" + Variables.sWebRoot + url + "&w=" + size.ToString();
                }
            }
        }
        return result;

    }
    public static string checkImgCache(string url, int _width)
    {

        string noImageUrl = @"images\no_photo.jpg";
        string appPath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + Path.DirectorySeparatorChar;

        if (String.IsNullOrEmpty(url))
        {
            appPath += noImageUrl;
        }
        else
        {
            if (System.IO.File.Exists((appPath + url.Replace("%20", " "))))
            {
                appPath += url;
            }
            else
            {
                appPath += noImageUrl;
            }
        }

        string imgPath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "/Upload/NewsImgCache/";  //Path.DirectorySeparatorChar;
        string strRealname = Path.GetFileNameWithoutExtension(appPath);
        string exts = Path.GetExtension(appPath);

        if (System.IO.File.Exists(imgPath + strRealname + "_w" + _width + exts))
        {
            string rootPath = HttpContext.Current.Request.ApplicationPath;
            if (rootPath.Substring(rootPath.Length - 1, 1) != "/")
                rootPath += "/";
            return rootPath + "Upload/NewsImgCache/" + strRealname + "_w" + _width + exts;
        }
        else
            return "";
    }

    #region UploadFileAudio
    public static string UploadFileAudio(FileUpload fileupload, string savepath, Int64 size, string filenamef)
    {
        string filename = "";
        if (fileupload.HasFile)
        {

            string name = fileupload.FileName;
            HttpPostedFile file = fileupload.PostedFile;
            if (file.ContentLength <= size && TypeAudioUpload(name))
            {
                filename += filenamef + ReNameFile(name);
                savepath += filename;
                fileupload.SaveAs(savepath);
                //return filename;
            }
            //    else
            //    {
            //        return filename;
            //    }

        }
        //else
        //{
        return filename;
        //}
    }
    private static bool TypeAudioUpload(string filename)
    {
        string str = Path.GetExtension(filename).ToLower();
        switch (str)
        {
            case ".mp3":
                return true;
            case ".MP3":
                return true;
            default:
                return false;
        }
    }

    #endregion

    #region ReNameFile
    private static string ReNameFile(string str)
    {
        string newstr = DateTime.Now.ToString("ddMMyyyyHHmmss");
        string substring = Path.GetExtension(str);
        int sublength = substring.Length;
        int length = str.Length;
        string oldstr = str.Substring(0, length - sublength);
        string rename = str.Replace(oldstr, newstr);
        return rename;
    }


    #endregion

    public static void GetNavigation(string strSlugPage, string g, string cId, string Id, string urlRoot)
    {
        if (strSlugPage != string.Empty)
        {
            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            SYS_PageLayout _pageLayout = new SYS_PageLayout();

            if (!AspNetCache.CheckCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_")))
            {
                _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug(strSlugPage, Language.language);
                if (_pageLayout == null)
                    _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutBySlug("home", Language.language);

                AspNetCache.SetCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_"), _pageLayout);
            }
            else
                _pageLayout = (SYS_PageLayout)AspNetCache.GetCache("PageLayout_" + strSlugPage + "_" + Language.language.Replace("-", "_"));

            Navigation.TitleName = _pageLayout.PageName;
            Navigation.TitleCate = "<li><a href='" + urlRoot + "'>Trang chủ</a></li>";

            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            CateNewsBSO catenewsBSO = new CateNewsBSO();


            if (strSlugPage == "du-an")
            {
                if (!String.IsNullOrEmpty(Id))
                {
                    Navigation.TitleName = "Thông tin dự án";

                    string cate = "<li><a href='" + urlRoot + "c2/du-an-c/du-an-1.aspx'>Dự án";
                    cate += "</a></li>";
                    Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                    Navigation.TitleCate += cate;
                }
            }
            else
                if (strSlugPage == "detailvideos")
                {
                    if (!String.IsNullOrEmpty(cId))
                    {
                        VideosCateBSO videosCateBSO = new VideosCateBSO();
                        VideosCate videoCate = videosCateBSO.GetVideosCateById(Convert.ToInt32(cId));

                        Navigation.TitleName = "<a href='" + urlRoot + "thu-vien-video" + "-" + videoCate.VideosCateID + ".aspx'>" + videoCate.VideosCateName + "</a>";

                        string cate = "<li><a href='" + urlRoot + "thu-vien-video.aspx'>Thư viện Video";
                        string s1 = "";
                        while (videoCate.ParentCateID != 0)
                        {
                            int pId = videoCate.ParentCateID;
                            videoCate = videosCateBSO.GetVideosCateById(pId);
                            s1 = "<li><a href='" + urlRoot + "thu-vien-video/" + videoCate.VideosCateName + "-" + videoCate.VideosCateID + ".aspx'>" + videoCate.VideosCateName + "</a></li>" + s1;
                        }

                        //   cate += "Video"; //Sửa lại
                        cate += "</a></li>";
                        cate += s1;
                        Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                        Navigation.TitleCate += cate;
                    }
                }
                else
                    if (strSlugPage == "detailalbums")
                    {
                        if (!String.IsNullOrEmpty(cId))
                        {
                            AlbumsCateBSO albumsCateBSO = new AlbumsCateBSO();
                            AlbumsCate videoCate = albumsCateBSO.GetAlbumsCateById(Convert.ToInt32(cId));

                            Navigation.TitleName = "<a href='" + urlRoot + "thu-vien-video" + "-" + videoCate.AlbumsCateID + ".aspx'>" + videoCate.AlbumsCateName + "</a>";

                            string cate = "<li><a href='" + urlRoot + "thu-vien-video.aspx'>Thư viện Video";
                            string s1 = "";
                            while (videoCate.ParentCateID != 0)
                            {
                                int pId = videoCate.ParentCateID;
                                videoCate = albumsCateBSO.GetAlbumsCateById(pId);
                                s1 = "<li><a href='" + urlRoot + "thu-vien-video/" + videoCate.AlbumsCateName + "-" + videoCate.AlbumsCateID + ".aspx'>" + videoCate.AlbumsCateName + "</a></li>" + s1;
                            }

                            //   cate += "Video"; //Sửa lại
                            cate += "</a></li>";
                            cate += s1;
                            Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                            Navigation.TitleCate += cate;
                        }
                    }
                    else
                        if (strSlugPage == "dh")
                        {
                            if (!String.IsNullOrEmpty(g))
                            {
                                Navigation.TitleName = "<a href='" + urlRoot + "tim-truong/0-0-0-0-0-0-0/search.aspx'>Thông tin trường</a>";

                                Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                            }
                        }
                        else
                            if (strSlugPage == "dang-ky-ts")
                            {
                                if (!String.IsNullOrEmpty(g))
                                {
                                    Navigation.TitleName = "<a href='" + urlRoot + "c2/dh-dk/Dang-ky-tuyen-sinh-truc-tuyen-20.aspx'>Trang Đăng ký tuyển sinh</a>";

                                    Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                                }
                            }
                            else
                                if (strSlugPage == "dh-dk")
                                {
                                    if (!String.IsNullOrEmpty(g))
                                    {
                                        Navigation.TitleName = "<a href='" + urlRoot + "c2/dh-dk/Dang-ky-tuyen-sinh-truc-tuyen-20.aspx'>Trang Đăng ký tuyển sinh</a>";

                                        Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                                    }
                                }
                                else
                                    if (!String.IsNullOrEmpty(Id))
                                    {

                                        NewsGroup newsgroup = newsgroupBSO.GetNewsGroupById(Convert.ToInt32(Id));
                                        if (newsgroup != null && newsgroup.CateNewsID > 0)
                                        {
                                            CateNews catenews = catenewsBSO.GetCateNewsById(newsgroup.CateNewsID);
                                            CateNewsGroup cateNewsGroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate, Language.language);

                                            Navigation.TitleName = "<a href='" + urlRoot + "c3/" + catenewsBSO.GetSlugByCateId(catenews.CateNewsID) + "/" + GetString(catenews.CateNewsName) + "-" + catenews.GroupCate + "-" + catenews.CateNewsID + ".aspx'>" + catenews.CateNewsName + "</a>";

                                            string cate = "<li><a href='" + urlRoot + "c2/" + cateNewsgroupBSO.GetSlugById(cateNewsGroup.CateNewsGroupID) + "/" + GetString(cateNewsGroup.CateNewsGroupName) + "-" + catenews.GroupCate + ".aspx'>";
                                            string s1 = "";
                                            while (catenews.ParentNewsID != 0)
                                            {
                                                int pId = catenews.ParentNewsID;
                                                catenews = catenewsBSO.GetCateNewsById(pId);
                                                s1 = "<li><a href='" + urlRoot + "c3/" + catenewsBSO.GetSlugByCateId(catenews.CateNewsID) + "/" + GetString(catenews.CateNewsName) + "-" + catenews.GroupCate + "-" + catenews.CateNewsID + ".aspx'>" + catenews.CateNewsName + "</a></li>" + s1;
                                            }

                                            cate += cateNewsGroup.CateNewsGroupName.ToString(); //Sửa lại
                                            cate += "</a></li>";
                                            cate += s1;
                                            Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                                            Navigation.TitleCate += cate;
                                        }

                                    }
                                    else
                                    {
                                        if (!String.IsNullOrEmpty(cId) && !String.IsNullOrEmpty(g))
                                        {
                                            CateNews cateNewsById = catenewsBSO.GetCateNewsById(Convert.ToInt32(cId));
                                            CateNewsGroup groupByGroupCate = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(Convert.ToInt32(g), Language.language);

                                            if (groupByGroupCate != null && cateNewsById != null)
                                            {
                                                Navigation.TitleName = cateNewsById.CateNewsName;

                                                string cate = "<li><a href='" + urlRoot + "c2/" + cateNewsgroupBSO.GetSlugById(groupByGroupCate.CateNewsGroupID) + "/" + GetString(groupByGroupCate.CateNewsGroupName) + "-" + cateNewsById.GroupCate + ".aspx' title='" + groupByGroupCate.CateNewsGroupName + "'>";
                                                string s1 = "";
                                                while (cateNewsById.ParentNewsID != 0)
                                                {
                                                    int parentNewsId = cateNewsById.ParentNewsID;
                                                    cateNewsById = catenewsBSO.GetCateNewsById(parentNewsId);
                                                    s1 = "<li><a href='" + urlRoot + "c3/" + catenewsBSO.GetSlugByCateId(cateNewsById.CateNewsID) + "/" + GetString(cateNewsById.CateNewsName) + "-" + cateNewsById.GroupCate + "-" + cateNewsById.CateNewsID + ".aspx' title='" + cateNewsById.CateNewsName + "'>" + cateNewsById.CateNewsName + "</a></li>" + s1;
                                                }

                                                cate += groupByGroupCate.CateNewsGroupName.ToString() + "</a></li>" + s1;
                                                Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                                                Navigation.TitleCate += cate;
                                            }

                                        }
                                        else
                                        {
                                            if (!String.IsNullOrEmpty(g))
                                            {

                                                CateNewsGroup groupByGroupCate = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(Convert.ToInt32(g), Language.language);
                                                Navigation.TitleCate = "<li><a href='" + urlRoot + "Default.aspx'>" + Resources.resource.T_home + "</a></li>";
                                                if (groupByGroupCate != null)
                                                {
                                                    Navigation.TitleName = groupByGroupCate.CateNewsGroupName;
                                                }

                                            }
                                        }
                                    }


        }

    }

    public static string GetString(object _txt)
    {
        if (_txt != null)
        {
            Utils objUtil = new Utils();
            return objUtil.Getstring(_txt.ToString());
        }
        return "";
    }


}
