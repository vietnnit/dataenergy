using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;
public partial class ViewWidgetPreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
        
        if (cookie_lang == null || cookie_lang["Lang"] == null || cookie_lang["Lang"] == string.Empty)
        {
            cookie_lang = new HttpCookie("LangInfo_CMS");
            cookie_lang["Lang"] = "vi-VN";
            cookie_lang.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie_lang);
        }
        Language.language = cookie_lang["Lang"].ToString();
        Session["Lang"] = cookie_lang["Lang"].ToString();

        Config config = new Config();
        if (AspNetCache.CheckCache("Config_" + Language.language) == false)
        {
            ConfigBSO configBSO = new ConfigBSO();

            config = configBSO.GetAllConfig(Language.language);
            AspNetCache.SetCacheWithTime("Config_" + Language.language, config, 150);
        }
        else
        {
            config = (Config)AspNetCache.GetCache("Config_" + Language.language);
        }
        Page.Title = config.Titleweb;

        if (!string.IsNullOrEmpty(Request["id"]))
        {
            SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
            SYS_WidgetPageLayout _widgetPageLayout = _widgetPageLayoutBSO.GetSYS_WidgetPageLayoutById(Convert.ToInt32(Request["id"].ToString()));

            if (_widgetPageLayout != null)
            {
                SYS_WidgetBSO _widgetBSO = new SYS_WidgetBSO();
                SYS_Widget _widget = _widgetBSO.GetSYS_WidgetById(_widgetPageLayout.WidgetId);
                if (_widget != null)
                {
                    if (_widget.WidgetControl != "")
                    {
                        Control objControl1 = (Control)this.Page.LoadControl(ResolveUrl("~") + "Client/Modules/" + _widget.WidgetDir + "/" + _widget.WidgetControl + ".ascx");
                        objControl1.ID = _widgetPageLayout.Id.ToString();
                        PlaceHolder1.Controls.Add(objControl1);

                      //  PlaceHolder1.Controls.Add(LoadControl(ResolveUrl("~") + _widget.WidgetDir + "/" + _widget.WidgetControl));
                       
                        ControlAddParameter(objControl1, _widgetPageLayout.Title, _widgetPageLayout.Icon, _widgetPageLayout.Value, Convert.ToInt32(_widgetPageLayout.Record), _widgetPageLayout.Info, _widgetPageLayout.Value2, Convert.ToInt32(_widgetPageLayout.Record2), _widgetPageLayout.HTML);
                    }
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


}
