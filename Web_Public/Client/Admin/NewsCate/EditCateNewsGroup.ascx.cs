using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ETO;
using BSO;

public partial class Client_Admin_EditCateNewsGroup : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out cId);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        
       


        if (!IsPostBack)
        {
            initControl(cId);
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

    #region Bind_ddlPageLayout
    protected void Bind_ddlPageLayout()
    {
        SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
        DataTable table = _pageLayoutBSO.GetSYS_PageLayoutAll(Language.language);
        commonBSO commonBSO = new commonBSO();
        ddlPageLayout.Items.Clear();
        commonBSO.FillToDropDown(ddlPageLayout, table, "", "", "PageName", "Id", "");
    }
    #endregion

    #region initControl
    private void initControl(int Id)
    {
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;
            try
            {

                CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
                CateNewsGroup catenewsGroup = catenewsGroupBSO.GetCateNewsGroupById(Id);
                hddCateNewsGroupID.Value = Convert.ToString(catenewsGroup.CateNewsGroupID);
                
                txtCateNewsGroupName.Text = catenewsGroup.CateNewsGroupName;
                txtShortName.Text = catenewsGroup.ShortName;
                txtGroupCate.Text = catenewsGroup.GroupCate.ToString();
                txtDescription.Text = catenewsGroup.Description;
                hddOrder.Value = Convert.ToString(catenewsGroup.Order);
                txtMenu.Text = Convert.ToString(catenewsGroup.Menu);
    
                chkView.Checked = catenewsGroup.IsView;
                chkHome.Checked = catenewsGroup.IsHome;
                chkMenu.Checked = catenewsGroup.IsMenu;
                chkNews.Checked = catenewsGroup.IsNew;
                chkPage.Checked = catenewsGroup.IsPage;
                chkRegister.Checked = catenewsGroup.IsRegister;
                chkFaq.Checked = catenewsGroup.IsFaq;
                chkOfficial.Checked = catenewsGroup.IsOfficial;

                hddIcon.Value = catenewsGroup.Icon;
                txtimage4_3.Text = catenewsGroup.Icon;

                if (catenewsGroup.Icon != "")
                    img_thumb.Text = "<img src='" + catenewsGroup.Icon + "' width='48px'>";

                rdbUrl.Checked = catenewsGroup.IsUrl;
                txtUrl.Text = catenewsGroup.Url;

                txtPosition.Text = Convert.ToString(catenewsGroup.Position);

                if (catenewsGroup.IsUrl == true)
                {
                    txtUrl.Visible = true;
                    panelFilename.Visible = true;

                }
                else
                {
                    txtUrl.Visible = false;
                    panelFilename.Visible = false;
                }

                Bind_ddlPageLayout();
                ddlPageLayout.SelectedValue = Convert.ToString(catenewsGroup.PageLayoutID);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            Bind_ddlPageLayout();
            ddlPageLayout.SelectedIndex = 0;

            btn_edit.Visible = false;
            btn_add.Visible = true;

            btn_edit1.Visible = false;
            btn_add1.Visible = true;
            btn_add2.Visible = true;
            rdbUrl.Checked = false;
            panelFilename.Visible = false;

        }
    }
    #endregion

    

    #region ReceiveHtml
    private CateNewsGroup ReceiveHtml()
    {
        

        CateNewsGroup catenewsGroup = new CateNewsGroup();
        catenewsGroup.CateNewsGroupID = (hddCateNewsGroupID.Value != "") ? Convert.ToInt32(hddCateNewsGroupID.Value) : 0;
        catenewsGroup.CateNewsGroupName = txtCateNewsGroupName.Text;
        catenewsGroup.ShortName = txtShortName.Text;
        catenewsGroup.GroupCate = (txtGroupCate.Text != "") ? Convert.ToInt32(txtGroupCate.Text) : 0;
        catenewsGroup.Order = (hddOrder.Value != "") ? Convert.ToInt32(hddOrder.Value) : 0;
        catenewsGroup.Description = txtDescription.Text;
        catenewsGroup.IsView = chkView.Checked;
        catenewsGroup.IsHome = chkHome.Checked;
        catenewsGroup.IsMenu = chkMenu.Checked;
        catenewsGroup.IsNew = chkNews.Checked;
        catenewsGroup.IsPage = chkPage.Checked;
        catenewsGroup.IsRegister = chkRegister.Checked;
        catenewsGroup.IsFaq = chkFaq.Checked;
        catenewsGroup.IsOfficial = chkOfficial.Checked;

        catenewsGroup.Menu = (txtMenu.Text != "") ? Convert.ToInt32(txtMenu.Text) : 0;

        catenewsGroup.Icon = (txtimage4_3.Text != "") ? txtimage4_3.Text : hddIcon.Value;

        catenewsGroup.IsUrl = rdbUrl.Checked;
        catenewsGroup.Url = txtUrl.Text;

        catenewsGroup.Position = (txtPosition.Text != "") ? Convert.ToInt32(txtPosition.Text) : 0;
        catenewsGroup.Language = Language.language;
        catenewsGroup.PageLayoutID = Convert.ToInt32(ddlPageLayout.SelectedValue);

        return catenewsGroup;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            CateNewsGroup catenewsGroup = ReceiveHtml();
            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();

            int id = catenewsGroupBSO.CreateCateNewsGroup(catenewsGroup);

            if (!Session["Admin_UserName"].ToString().Equals("administrator"))
            {
                AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                DataTable table = adminRolesBSO.GetAdminRolesByUserName(Session["Admin_UserName"].ToString());

                CateNewsGroupPermissionBSO catenewGroupPermissionBSO = new CateNewsGroupPermissionBSO();
                CateNewsGroupPermission cateNewsGroupPermission = new CateNewsGroupPermission();

                if (table.Rows.Count > 0)
                {
                    foreach (DataRow subrow in table.Rows)
                    {
                        cateNewsGroupPermission.CateNewsGroupID = id;
                        cateNewsGroupPermission.RolesID = Convert.ToInt32(subrow["RolesID"].ToString());
                        cateNewsGroupPermission.Permission = "";
                        cateNewsGroupPermission.UserName = Session["Admin_UserName"].ToString();
                        cateNewsGroupPermission.Created = DateTime.Now;
                        cateNewsGroupPermission.Language = Language.language;

                        catenewGroupPermissionBSO.CreateCateNewsGroupPermission(cateNewsGroupPermission);
                    }


                }

            }

            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            initControl(id);
            AspNetCache.Reset();
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

    protected void btn_add_Click_more(object sender, EventArgs e)
    {
        try
        {
            CateNewsGroup catenewsGroup = ReceiveHtml();
            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();

            int id = catenewsGroupBSO.CreateCateNewsGroup(catenewsGroup);

            if (!Session["Admin_UserName"].ToString().Equals("administrator"))
            {
                AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                DataTable table = adminRolesBSO.GetAdminRolesByUserName(Session["Admin_UserName"].ToString());

                CateNewsGroupPermissionBSO catenewGroupPermissionBSO = new CateNewsGroupPermissionBSO();
                CateNewsGroupPermission cateNewsGroupPermission = new CateNewsGroupPermission();

                if (table.Rows.Count > 0)
                {
                    foreach (DataRow subrow in table.Rows)
                    {
                        cateNewsGroupPermission.CateNewsGroupID = id;
                        cateNewsGroupPermission.RolesID = Convert.ToInt32(subrow["RolesID"].ToString());
                        cateNewsGroupPermission.Permission = "";
                        cateNewsGroupPermission.UserName = Session["Admin_UserName"].ToString();
                        cateNewsGroupPermission.Created = DateTime.Now;
                        cateNewsGroupPermission.Language = Language.language;

                        catenewGroupPermissionBSO.CreateCateNewsGroupPermission(cateNewsGroupPermission);
                    }


                }

            }

            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            AspNetCache.Reset();
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            CateNewsGroup catenewsGroup = ReceiveHtml();
            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();

            catenewsGroupBSO.UpdateCateNewsGroup(catenewsGroup);

            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(catenewsGroup.CateNewsGroupID);
            AspNetCache.Reset();
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

    protected void rdbUrl_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbUrl.Checked)
        {
            txtUrl.Visible = true;
            panelFilename.Visible = true;
        }
        else
        {
            txtUrl.Visible = false;
            panelFilename.Visible = false;
        }
    }



}
