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

public partial class Admin_Controls_EditCateNews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out cId);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        

        int group = 0;
        if (!String.IsNullOrEmpty(Request["group"]))
            if (!int.TryParse(Request["group"].Replace(",", ""), out group))
                Response.Redirect("~/Admin/home/Default.aspx");

        if (group == 0)
            Response.Redirect("~/Admin/home/Default.aspx");
        else
        {

            if (!IsPostBack)
            {
                HddGroupCate.Value = Convert.ToString(group);
                ViewCateGroup(group);

                initControl(cId);
            }
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

    #region ViewCateGroup
    private void ViewCateGroup(int group)
    {
        ddlCateNews.Items.Clear();
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateGroupRolesUrl(Language.language, group, Session["Admin_UserName"].ToString());
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToDropDown(ddlCateNews, table, "~~ Danh mục gốc ~~", "0", "CateNewsName", "CateNewsID", "");
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
                CateNewsBSO catenewsBSO = new CateNewsBSO();
                CateNews catenews = catenewsBSO.GetCateNewsById(Id);
                hddCateNewsID.Value = Convert.ToString(catenews.CateNewsID);
                hddParentID.Value = Convert.ToString(catenews.ParentNewsID);
                ddlCateNews.SelectedValue = Convert.ToString(catenews.ParentNewsID);

                ddlCateNews.Items.Remove(new ListItem(catenews.CateNewsName,Convert.ToString(catenews.CateNewsID)));
                
                txtCateNewsName.Text = catenews.CateNewsName;
                hddCateNewsOrder.Value = Convert.ToString(catenews.CateNewsOrder);
                hddCateNewsTotal.Value = Convert.ToString(catenews.CateNewsTotal);
                //rdbGroupCate.SelectedValue = Convert.ToString(catenews.GroupCate);
                hddIcon.Value = catenews.Icon;
                txtimage4_3.Text = catenews.Icon;

                if(catenews.Icon != "")
                    img_thumb.Text = "<img src='" + catenews.Icon + "' width='48px'>";

                txtSlogan.Text = catenews.Slogan;
                hddUserName.Value = Session["Admin_UserName"].ToString();
                hddCreated.Value = DateTime.Now.ToString();

                txtGroupCate.Text = Convert.ToString(catenews.GroupCate);

          //      HddGroupCate.Value = Convert.ToString(catenews.GroupCate);

                rdbType.Checked = catenews.isUrl;
                txtUrl.Text = catenews.Url;
                rdbStatus.Checked = catenews.Status;
                txtShortName.Text = catenews.ShortName;

                if (catenews.isUrl == true)
                {
                    txtUrl.Visible = true;
                    panelUrl.Visible = true;
                }
                else
                {
                    txtUrl.Visible = false;
                    panelUrl.Visible = false;
                }

                ViewCateGroup(catenews.GroupCate);
                Bind_ddlPageLayout();
                ddlPageLayout.SelectedValue = Convert.ToString(catenews.PageLayoutID);

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            txtGroupCate.Text = Convert.ToString(HddGroupCate.Value);
            Bind_ddlPageLayout();
            ddlPageLayout.SelectedIndex = 0;

            btn_edit.Visible = false;
            btn_add.Visible = true;

            btn_edit1.Visible = false;
            btn_add1.Visible = true;
            btn_add2.Visible = true;
            rdbType.Checked = false;
            txtUrl.Visible = false;
            panelUrl.Visible = false;

        }
    }
    #endregion

    

    #region ReceiveHtml
    private CateNews ReceiveHtml()
    {

      
        CateNews catenews = new CateNews();
        catenews.CateNewsID = (hddCateNewsID.Value != "") ? Convert.ToInt32(hddCateNewsID.Value) : 0;
        catenews.ParentNewsID = (ddlCateNews.SelectedValue != "") ? Convert.ToInt32(ddlCateNews.SelectedValue) : 0;
        catenews.CateNewsName = txtCateNewsName.Text;
        catenews.CateNewsOrder = (hddCateNewsOrder.Value != "") ? Convert.ToInt32(hddCateNewsOrder.Value) : 0;
        catenews.CateNewsTotal = (hddCateNewsTotal.Value != "") ? Convert.ToInt32(hddCateNewsTotal.Value) : 0;
        catenews.Language = Language.language;
        //catenews.GroupCate = Convert.ToInt32(HddGroupCate.Value);
        catenews.GroupCate = (txtGroupCate.Text != "") ? Convert.ToInt32(txtGroupCate.Text) : Convert.ToInt32(HddGroupCate.Value);

        catenews.Icon = (txtimage4_3.Text != "") ? txtimage4_3.Text : hddIcon.Value;
        catenews.Slogan = txtSlogan.Text;

        catenews.UserName = (hddUserName.Value != "") ? hddUserName.Value : Session["Admin_UserName"].ToString();
        catenews.Created = (hddCreated.Value != "") ? Convert.ToDateTime(hddCreated.Value) : DateTime.Now;

        catenews.isUrl = rdbType.Checked;
        catenews.Url = txtUrl.Text;
        catenews.Status = rdbStatus.Checked;
        catenews.ShortName = txtShortName.Text;
        catenews.PageLayoutID = Convert.ToInt32(ddlPageLayout.SelectedValue);

        catenews.Roles = "";
        return catenews;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            CateNews catenews = ReceiveHtml();
            CateNewsBSO catenewsBSO = new CateNewsBSO();

            int catenews1 = catenewsBSO.CreateCateNewGet(catenews);

            if (!Session["Admin_UserName"].ToString().Equals("administrator"))
            {
                AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                DataTable table = adminRolesBSO.GetAdminRolesByUserName(Session["Admin_UserName"].ToString());

                CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();
                CateNewsPermission cateNewsPermission = new CateNewsPermission();

                if (table.Rows.Count > 0)
                {
                    foreach (DataRow subrow in table.Rows)
                    {
                        cateNewsPermission.CateNewsID = catenews1;
                        cateNewsPermission.RolesID = Convert.ToInt32(subrow["RolesID"].ToString());
                        //cateNewsPermission.Permission = subrow["Permission"].ToString();
                        cateNewsPermission.Permission = "";
                        cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                        cateNewsPermission.Created = DateTime.Now;
                        cateNewsPermission.Language = Language.language;
                        catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);
                    }


                }

            }
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            initControl(catenews1);
            AspNetCache.Reset();
           // ViewCateGroup(Convert.ToInt32(HddGroupCate.Value));

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
            CateNews catenews = ReceiveHtml();
            CateNewsBSO catenewsBSO = new CateNewsBSO();

            int catenews1 = catenewsBSO.CreateCateNewGet(catenews);

            if (!Session["Admin_UserName"].ToString().Equals("administrator"))
            {
                AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                DataTable table = adminRolesBSO.GetAdminRolesByUserName(Session["Admin_UserName"].ToString());

                CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();
                CateNewsPermission cateNewsPermission = new CateNewsPermission();

                if (table.Rows.Count > 0)
                {
                    foreach (DataRow subrow in table.Rows)
                    {
                        cateNewsPermission.CateNewsID = catenews1;
                        cateNewsPermission.RolesID = Convert.ToInt32(subrow["RolesID"].ToString());
                        //cateNewsPermission.Permission = subrow["Permission"].ToString();
                        cateNewsPermission.Permission = "";
                        cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                        cateNewsPermission.Created = DateTime.Now;
                        cateNewsPermission.Language = Language.language;

                        catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);
                    }


                }

            }
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            ViewCateGroup(Convert.ToInt32(HddGroupCate.Value));
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
            CateNews catenews = ReceiveHtml();

            CateNewsBSO catenewsBSO = new CateNewsBSO();
            //if (CheckedList().Equals(""))
            //{
            //    clientview.Text = "Loi : Xin hay lua chon it nhat 1 quyen";
            //}
            //else
            //{
            catenewsBSO.UpdateCateNews(catenews);

            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(catenews.CateNewsID);
            AspNetCache.Reset();
           // ViewCateGroup(Convert.ToInt32(HddGroupCate.Value));
            //}
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }


    protected void rdbType_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbType.Checked)
        {
            txtUrl.Visible = true;
            panelUrl.Visible = true;
        }
        else
        {
            txtUrl.Visible = false;
            panelUrl.Visible = false;
        }
    }

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Group/listcatenews/" + HddGroupCate.Value + "/Default.aspx");

    }
    protected void btn_create_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Group/editcatenews/" + HddGroupCate.Value + "/Default.aspx");

    }
}