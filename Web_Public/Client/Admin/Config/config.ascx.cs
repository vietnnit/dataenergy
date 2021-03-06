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

public partial class Admin_Controls_Config : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initEditor();
            initControl();
        }
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        if(modules!=null)
            litModules.Text = modules.ModulesName;
    }
    #endregion

    private void initEditor()
    {
        txtIntro_desc.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtIntro_desc.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtIntro_desc.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtIntro_desc.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtIntro_desc.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtIntro_desc.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtIntro_desc.config.entities = false;

        txtIntroduction.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtIntroduction.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtIntroduction.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtIntroduction.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtIntroduction.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtIntroduction.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtIntroduction.config.entities = false;

        txtInfocompany.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtInfocompany.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtInfocompany.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtInfocompany.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtInfocompany.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtInfocompany.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtInfocompany.config.entities = false;

        txtRadSupport.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtRadSupport.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtRadSupport.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtRadSupport.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtRadSupport.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtRadSupport.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtRadSupport.config.entities = false;

        txtRadContact.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtRadContact.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtRadContact.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtRadContact.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtRadContact.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtRadContact.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtRadContact.config.entities = false;

        RadCounter.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        RadCounter.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        RadCounter.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        RadCounter.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        RadCounter.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        RadCounter.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        RadCounter.config.entities = false;

        RadInfo1.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        RadInfo1.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        RadInfo1.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        RadInfo1.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        RadInfo1.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        RadInfo1.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        RadInfo1.config.entities = false;

        RadInfo2.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        RadInfo2.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        RadInfo2.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        RadInfo2.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        RadInfo2.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        RadInfo2.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        RadInfo2.config.entities = false;

        radPopup.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        radPopup.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        radPopup.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        radPopup.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        radPopup.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        radPopup.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        radPopup.config.entities = false;

        radPopup2.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        radPopup2.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        radPopup2.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        radPopup2.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        radPopup2.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        radPopup2.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        radPopup2.config.entities = false;
    }
    #region initControl
    protected void initControl()
    {

        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(Language.language);
        txttitleweb.Text = config.Titleweb;
        txtgoogle.Text = config.Google;
        txtIntro_desc.Text = config.Intro_desc;
        txtIntroduction.Text = config.Introduction;
        txtInfocompany.Text = config.Infocompany;
        new_icon_w.Text = config.New_icon_w;
        new_icon_h.Text = config.New_icon_h;
        new_thumb_w.Text = config.New_thumb_w;
        new_thumb_h.Text = config.New_thumb_h;
        new_large_w.Text = config.New_large_w;
        new_large_h.Text = config.New_large_h;

        product_icon_w.Text = config.Product_icon_w;
        product_icon_h.Text = config.Product_icon_h;
        product_thumb_w.Text = config.Product_thumb_w;
        product_thumb_h.Text = config.Product_thumb_h;
        product_large_w.Text = config.Product_large_w;
        product_large_h.Text = config.Product_large_h;

        txtNoproduct.Text = config.ProductNo;
        txtNoPage.Text = config.ProductNoPage;
        txtCurrency.Text = config.Currency;

        rdblistClose.Checked = config.Status;
        txtCloseComment.Text = config.Closecomment;

        txtRadSupport.Text = config.Support;
        txtRadContact.Text = config.Contact;

        txtEmailFrom.Text = config.Email_from;
        txtEmailTo.Text = config.Email_to;

        RadCounter.Text = config.Counter;
        RadInfo1.Text = config.Info1;
        RadInfo2.Text = config.Info2;

        txtWebName.Text = config.WebName;
        txtWebServerIP.Text = config.WebServerIP;
        txtWebDomain.Text = config.WebDomain;
        txtWebMailServer.Text = config.WebMailServer;

        rdbPopup.Checked = config.IsPopup;
        radPopup.Text = config.Popup;
        radPopup2.Text = config.Popup2;


    }
    #endregion

    #region ReceiveHtml
    protected Config ReceiveHtml()
    {
        Config config = new Config();
        config.Language = Language.language;
        config.Titleweb = txttitleweb.Text;
        config.Google = txtgoogle.Text;
        config.Intro_desc = txtIntro_desc.Text;
        config.Introduction = txtIntroduction.Text;
        config.Infocompany = txtInfocompany.Text;
        config.New_icon_w = new_icon_w.Text;
        config.New_icon_h = new_icon_h.Text;
        config.New_thumb_w = new_thumb_w.Text;
        config.New_thumb_h = new_thumb_h.Text;
        config.New_large_w = new_large_w.Text;
        config.New_large_h = new_large_h.Text;

        config.Product_icon_w = product_icon_w.Text;
        config.Product_icon_h = product_icon_h.Text;
        config.Product_thumb_w = product_thumb_w.Text;
        config.Product_thumb_h = product_thumb_h.Text;
        config.Product_large_w = product_large_w.Text;
        config.Product_large_h = product_large_h.Text;

        config.ProductNo = txtNoproduct.Text;
        config.ProductNoPage = txtNoPage.Text;
        config.Currency = txtCurrency.Text;

        config.Status = rdblistClose.Checked;
        config.Closecomment = txtCloseComment.Text;

        config.Support = txtRadSupport.Text;
        config.Contact = txtRadContact.Text;
        config.Email_from = txtEmailFrom.Text;
        config.Email_to = txtEmailTo.Text;

        config.Counter = RadCounter.Text;
        config.Info1 = RadInfo1.Text;
        config.Info2 = RadInfo2.Text;

        config.WebDomain = txtWebDomain.Text;
        config.WebMailServer = txtWebMailServer.Text;
        config.WebName = txtWebName.Text;
        config.WebServerIP = txtWebServerIP.Text;

        config.IsPopup = rdbPopup.Checked;
        config.Popup = radPopup.Text;
        config.Popup2 = radPopup2.Text;

        return config;

    }
    #endregion

    #region UpdateConfig
    protected void UpdateConfig()
    {
        Config config = ReceiveHtml();
        ConfigBSO configBSO = new ConfigBSO();
        configBSO.UpdateConfig(config);
        initControl();
    }
    #endregion
    protected void btn_common_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlcommon.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlcommon.Text = ex.Message.ToString();
        }
    }
    protected void btnproduct_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlproduct.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlproduct.Text = ex.Message.ToString();
        }
    }
    protected void btn_news_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlnews.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlnews.Text = ex.Message.ToString();
        }
    }

    protected void btnCloseweb(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlCloseweb.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlCloseweb.Text = ex.Message.ToString();
        }

    }
    protected void btn_Support_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            litSupport.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            litSupport.Text = ex.Message.ToString();
        }
    }
    protected void btn_Contact_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            litContact.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            litContact.Text = ex.Message.ToString();

        }
    }
    protected void btnemail_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlEmail.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlEmail.Text = ex.Message.ToString();

        }
    }
    protected void btn_Other_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlOther.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlOther.Text = ex.Message.ToString();
        }
    }
    protected void btnServer_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlServer.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlServer.Text = ex.Message.ToString();

        }
    }

    protected void btn_popup_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateConfig();
            ltlPopup.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật cấu hình Thành công !</div>";
        }
        catch (Exception ex)
        {
            ltlPopup.Text = ex.Message.ToString();
        }
    }
    
}
