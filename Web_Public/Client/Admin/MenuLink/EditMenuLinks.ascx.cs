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
using DAO;
using BSO;
public partial class Admin_Controls_EditMenuLinks : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"], out ID);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            BindDropDownList();
            initControl(ID);
        }

    }
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    #region initControl
    protected void initControl(int ID)
    {
        if (ID > 0)
        {
            txtMenuLinksID.Value = Convert.ToString(ID);
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;
            try
            {
                MenuLinksBSO menuLinksBSO = new MenuLinksBSO();

                MenuLinks menuLinksRows = menuLinksBSO.GetMenuLinksById(ID);
                ddlMenuLinks.SelectedValue = menuLinksRows.MenuLinksParent.ToString();
                txtMenuLinksName.Text = menuLinksRows.MenuLinksName;
                txtMenuLinksUrl.Text = menuLinksRows.MenuLinksUrl;
                txtRadHelp.Text = menuLinksRows.MenuLinksHelp;
                hddIcon.Value = menuLinksRows.MenuLinksIcon;
                hddFile.Value = menuLinksRows.FileName;
                txtimage4_3.Text = menuLinksRows.MenuLinksIcon;
                txtFileName.Text = menuLinksRows.FileName;

                rdbStatus.Checked = menuLinksRows.Status;
                rdbIsView.Checked = menuLinksRows.IsView;
                chkFlash.Checked = menuLinksRows.IsFlash;
                txtPosition.Text = menuLinksRows.Position;
                ddlTarget.SelectedValue = menuLinksRows.Target.ToString();
                txtWidth.Text =  menuLinksRows.Width.ToString();
                txtHeight.Text = menuLinksRows.Height.ToString();
                hddHit.Value = menuLinksRows.Hit.ToString();

                if (menuLinksRows.IsFlash)
                {
                    txtFileName.Visible = true;
                    panelFilename.Visible = true;
                }
                else
                {
                    txtFileName.Visible = false;
                    panelFilename.Visible = false;
                }

                if (menuLinksRows.MenuLinksIcon != "")
                    img_thumb.Text = "<img src='" + menuLinksRows.MenuLinksIcon + "' width='48px'>";
                if (menuLinksRows.IsFlash && menuLinksRows.FileName != "")
                {
                    ltlFileName.Text = "<a href='" + menuLinksRows.FileName + "' target = '_blank'>File Flash</a>";
                }


            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            ddlMenuLinks.SelectedIndex = 0;
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_add2.Visible = true;
            btn_edit1.Visible = false;

            chkFlash.Checked = false;
            txtFileName.Visible = false;
            panelFilename.Visible = false;
        }
    }
    #endregion

    #region BindDropDownList
    protected void BindDropDownList()
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
      //  DataTable table = menuLinksBSO.GetAllMenuLinks();
        DataTable table = menuLinksBSO.MixMenuLinks(Language.language);
        commonBSO commonBSO = new commonBSO();
        ddlMenuLinks.Items.Clear();
      commonBSO.FillToDropDown(ddlMenuLinks, table, "~ Cấp độ menuLinks ~", "0", "MenuLinksName", "MenuLinksID", "");
    }
    #endregion

    #region AddNews
    protected void Add()
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
        MenuLinks menuLinks = ReceiveHtml();
        try
        {

            int id = menuLinksBSO.AddMenuLinks(menuLinks);
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            initControl(id);

        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }

    }
    #endregion

    #region Edit
    protected void Edit()
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
        MenuLinks menuLinks = ReceiveHtml();
        try
        {
            menuLinksBSO.EditMenuLinks(menuLinks);
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(menuLinks.MenuLinksID);
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }
    #endregion

    #region ReceiveHtml
    public MenuLinks ReceiveHtml()
    {
        MenuLinks menuLinks = new MenuLinks();
        
        menuLinks.MenuLinksID = (txtMenuLinksID.Value != "") ? Convert.ToInt32(txtMenuLinksID.Value) : 0;
        menuLinks.MenuLinksName = (txtMenuLinksName.Text != "") ? txtMenuLinksName.Text.Trim() : "";
        menuLinks.MenuLinksOrder = 0;
        menuLinks.MenuLinksParent = (ddlMenuLinks.SelectedValue != "") ? Convert.ToInt32(ddlMenuLinks.SelectedValue) : 0;
        menuLinks.MenuLinksUrl = (txtMenuLinksUrl.Text != "") ? txtMenuLinksUrl.Text.Trim() : "";
        menuLinks.MenuLinksHelp = txtRadHelp.Text;
        menuLinks.MenuLinksIcon = (txtimage4_3.Text != "") ? txtimage4_3.Text : hddIcon.Value;
        menuLinks.FileName = (txtFileName.Text != "") ? txtFileName.Text : hddFile.Value;

        menuLinks.Status = rdbStatus.Checked;
        menuLinks.IsView = rdbIsView.Checked;
        menuLinks.IsFlash = chkFlash.Checked;
        menuLinks.Target = ddlTarget.SelectedValue;
        menuLinks.Position = (txtPosition.Text != "") ? txtPosition.Text.Trim() : "";
        menuLinks.Width = Convert.ToInt32(txtWidth.Text);
        menuLinks.Height = Convert.ToInt32(txtHeight.Text);

        menuLinks.Hit = (hddHit.Value != "") ? Convert.ToInt32(hddHit.Value) : 0;
        menuLinks.Language = Language.language;
        return menuLinks;
    }
    #endregion

    protected string GetString(object _txt)
    {
        if (_txt != null)
        {
            Utils objUtil = new Utils();
            return objUtil.Getstring(_txt.ToString());
        }
        return "";
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Add();
        BindDropDownList();
        AspNetCache.Reset();
    }
    protected void btn_add_Click_more(object sender, EventArgs e)
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
        MenuLinks menuLinks = ReceiveHtml();
        try
        {

            int id = menuLinksBSO.AddMenuLinks(menuLinks);
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            BindDropDownList();
            AspNetCache.Reset();
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
        
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        Edit();
        BindDropDownList();
        AspNetCache.Reset();
    }
    protected void chkFlash_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFlash.Checked)
        {
            txtFileName.Visible = true;
            panelFilename.Visible = true;
        }
        else
        {
            txtFileName.Visible = false;
            panelFilename.Visible = false;
        }
    }
    protected void ddlMenuLinks_SelectedIndexChanged(object sender, EventArgs e)
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
        MenuLinks menuLinksRows = menuLinksBSO.GetMenuLinksById(Convert.ToInt32(ddlMenuLinks.SelectedValue));

        if (menuLinksRows != null)
        {
            txtPosition.Text = menuLinksRows.Position;
            txtWidth.Text = menuLinksRows.Width.ToString();
            txtHeight.Text = menuLinksRows.Height.ToString();
        }
    }
}
