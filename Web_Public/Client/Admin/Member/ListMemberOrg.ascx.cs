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
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Collections.Generic;
public partial class Admin_Member_ListMemberOrg : System.Web.UI.UserControl
{
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)
                return Convert.ToInt32(ViewState["CurrentPage"].ToString());
            else
                return 1;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    private int PageSize
    {
        get
        {
            if (ViewState["PageSize"] != null)
                return Convert.ToInt32(ViewState["PageSize"].ToString());
            else
                return 20;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            BindEnterprise();
            BindData();
        }
    }

    void BindEnterprise()
    {
        IList<Enterprise> list = new List<Enterprise>();
        UserValidation mem = new UserValidation();
        list = new EnterpriseService().GetEnterpriseByOrg(mem.OrgId);
        ddlEnterprise.Items.Clear();
        ddlEnterprise.DataSource = list;
        ddlEnterprise.DataTextField = "Title";
        ddlEnterprise.DataValueField = "Id";
        ddlEnterprise.DataBind();
        ddlEnterprise.Items.Insert(0, new ListItem("---Chọn đơn vị---", ""));
    }
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    protected void grvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn chắc chắn muốn xóa ??');");

        }
    }
    protected void grvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string aId = e.CommandArgument.ToString();
        string aName = e.CommandName.ToLower();
        switch (aName)
        {
            case "_edit":
                Response.Redirect("~/Admins/editMemberforOrg/" + aId + "/Default.aspx");
                break;
            case "_delete":
                MemberService adminBSO = new MemberService();
                ePower.DE.Domain.Member admin = adminBSO.FindByKey(Convert.ToInt32(aId));
                admin.IsDelete = true;
                adminBSO.Update(admin);
                BindData();
                break;
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }
    void BindData()
    {
        int EnterpriseId = 0;

        if (ddlEnterprise.SelectedIndex > 0)
            EnterpriseId = Convert.ToInt32(ddlEnterprise.SelectedValue);

        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        UserValidation mem = new UserValidation();
        DataTable dt = new MemberService().FindList(Convert.ToInt32(mem.OrgId), EnterpriseId, null, null, null, txtKeyword.Text.Trim(), paging);
        grvAdmin.DataSource = dt;
        grvAdmin.DataBind();
        paging.RowsCount = Convert.ToInt32(dt.Rows[0]["Total"]);
        Paging.PageSize = PageSize;
        Paging.CurrentPage = CurrentPage;
        Paging.TotalRecord = Convert.ToInt32(dt.Rows[0]["Total"]);
        Paging.DataLoad();
        if (dt != null && dt.Rows.Count > 0)
        {
            if (Paging.TotalPages <= 1)
            {
                ltTotal.Text = "Có tổng số " + paging.RowsCount + " tài khoản";
                Paging.Visible = false;
            }
            else
            {
                ltTotal.Text = "Có " + dt.Rows.Count + " trong tổng số " + paging.RowsCount + " tài  khoản";
                Paging.Visible = true;
            }
        }
        else
        {
            ltTotal.Text = "Có tổng số " + paging.RowsCount + " tài khoản";
            Paging.Visible = false;
        }
    }
    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEnterprise();
    }
    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();
    }

}
