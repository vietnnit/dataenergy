using System;
using System.Linq;
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
using PR.Domain;
using PR.Service;

public partial class Client_Admin_List_CreateProvince : System.Web.UI.UserControl
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
            BindData(cId);
        }
    }    
    #region initControl
    private void BindData(int Id)
    {
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;
            ProvinceService objlogic = new ProvinceService();
            Province obj = new Province();
            obj = objlogic.FindByKey(Id);
            if (obj != null)
            {
                txtTitle.Text = obj.ProvinceName;
                txtProvinceCode.Text = obj.ProvinceCode;
                if (obj.RegionId > 0)
                    ddlParent.SelectedValue = obj.RegionId.ToString();
                txtSorOrder.Text = obj.SortOrder.ToString();                
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
        try
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            //imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        catch
        {
            litModules.Text = "Cập nhật Tỉnh/TP";
        }
    }
    #endregion

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ListProvince/Default.aspx");
    }
    protected void btn_create_click(object sender, EventArgs e)
    {
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            Update();

        }
        catch (Exception ex)
        {

            error.Text = ex.Message.ToString();
        }

    }
    void Update()
    {
        ProvinceService objlogic = new ProvinceService();
        Province obj = new Province();
        obj.ProvinceName = txtTitle.Text.Trim();
        obj.ProvinceCode = txtProvinceCode.Text.Trim();
        obj.SortOrder = Convert.ToInt32(txtSorOrder.Text);
        if (ddlParent.SelectedIndex > 0)
            obj.RegionId = Convert.ToInt32(ddlParent.SelectedValue);                
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out cId);
        if (cId > 0)
        {
            obj.Id = cId;
            if (objlogic.Update(obj) != null)
            {
                error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
                //txtchuyenvienName.Text = "";
                ////ddlGroup.SelectedIndex = 0;
                //ddlLinhVuc.SelectedIndex = 0;
            }
            else
                error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật không thành công !</div>";
        }
        else
        {
            if (objlogic.Insert(obj) > 0)
            {
                error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới thành công !</div>";
                txtTitle.Text = "";
                txtSorOrder.Text = "";
            }
            else
                error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới không thành công !</div>";
        }
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            Update();
        }
        catch (Exception ex)
        {

            error.Text = ex.Message.ToString();
        }
    }
    protected void btn_add_Click_more(object sender, EventArgs e)
    {

        Update();


    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}