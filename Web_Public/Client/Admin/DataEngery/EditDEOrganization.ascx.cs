using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BSO;
using ETO;
using ePower.DE.Domain;
using ePower.DE.Service;

public partial class Client_Admin_EditDEOrganization : System.Web.UI.UserControl
{
    int OrgId
    {
        get
        {
            if (ViewState["OrgId"] != null)
                return (int)ViewState["OrgId"];
            else
                return 0;
        }
        set { ViewState["OrgId"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out cId);
        OrgId = cId;
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        else
        {

        }

        if (!IsPostBack)
        {
            BindProvince();           
            initControl(cId);
        }
    }
    #region initControl
    private void initControl(int Id)
    {
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;
            OrganizationService objlogic = new OrganizationService();
            Organization obj = new Organization();
            obj = objlogic.FindByKey(Id);
            if (obj != null)
            {
                txtTitle.Text = obj.Title;
                if (obj.ProvinceId > 0)
                    ddlProvince.SelectedValue = obj.ProvinceId.ToString();
                if (obj.SortOrder > 0)
                    txtSorOrder.Text = obj.SortOrder.ToString();
                txtEmail.Text = obj.Email;
                txtNote.Text = obj.Note;
                txtAddress.Text = obj.Address;
                txtPhone.Text = obj.Phone;
            }
        }
        else
        {
            btn_add.Visible = true;
            btn_edit.Visible = false;
        }
    }
    #endregion
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        txtSorOrder.Text = "0";
        txtTitle.Text = "";
    }

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ListOrganization/Default.aspx");
    }
    protected void btn_create_click(object sender, EventArgs e)
    {
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            int cId = 0;
            if (!String.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"].Replace(",", ""), out cId);
            OrganizationService objlogic = new OrganizationService();
            Organization obj = new Organization();
            obj = objlogic.FindByKey(cId);
            if (obj != null)
            {
                obj.Title = txtTitle.Text;
                //obj.ParentId = Convert.ToInt32(ddlParentArea.SelectedValue);

                //obj.IsStatus = 1;
                obj.Id = cId;
                if (objlogic.Update(obj) != null)
                    error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật Sở/Tập đoàn thành công !</div>";
                else
                    error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật Sở/Tập đoà không thành công !</div>";
            }
            else
            {
                error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật Chuyên viên Thất bại !</div>";
            }
        }
        catch (Exception ex)
        {

            error.Text = ex.Message.ToString();
        }
    }
    void BindProvince()
    {
        IList<Province> list = new List<Province>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Provice_All))
        {
            list = new ProvinceService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Provice_All, list);
        }
        else
            list = (IList<Province>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Provice_All);
        ddlProvince.DataSource = list;
        ddlProvince.DataTextField = "ProvinceName";
        ddlProvince.DataValueField = "Id";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));
    }
    protected void btn_add_Click_more(object sender, EventArgs e)
    {

        try
        {
            OrganizationService objlogic = new OrganizationService();
            Organization obj = new Organization();
            obj.Title = txtTitle.Text;
            obj.SortOrder = Convert.ToInt32(txtSorOrder.Text);
            obj.Email = txtEmail.Text.Trim();
            obj.Note = txtNote.Text.Trim();
            if (ddlProvince.SelectedIndex > 0)
                obj.ProvinceId = Convert.ToInt32(ddlProvince.SelectedValue);
            obj.Phone = txtPhone.Text;
            if (OrgId > 0)
            {
                obj.Id = OrgId;
                if (objlogic.Update(obj) != null)
                    error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
                else
                    error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật không thành công !</div>";
            }
            else
            {
                if (objlogic.Insert(obj) > 0)
                    error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới thành công !</div>";
                else
                    error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật không thành công !</div>";

            }
        }
        catch (Exception ex)
        {

            error.Text = ex.Message.ToString();
        }
    }
    //protected void BindData()
    //{

    //    ddlParentArea.Items.Clear();
    //    OrganizationBSO comBSO = new OrganizationBSO();
    //    IList<OrganizationDTO> list = new List<OrganizationDTO>();
    //    list = comBSO.FindAll();

    //    ddlParentArea.DataTextField = "OrgName";
    //    ddlParentArea.DataValueField = "OrgId";
    //    ddlParentArea.DataSource = list;
    //    ddlParentArea.DataBind();
    //    ddlParentArea.Items.Insert(0, new ListItem("~~ Chọn cơ quan cấp trên ~~"));
    //}
}