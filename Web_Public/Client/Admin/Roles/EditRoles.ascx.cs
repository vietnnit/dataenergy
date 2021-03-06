using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;

public partial class Admin_Controls_CreateRoles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            initControl(Id);
            
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
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_edit1.Visible = true;

            hddRoles_ID.Value = Convert.ToString(ID);
            try
            {
                RolesBSO rolesBSO = new RolesBSO();
                IRoles roles = rolesBSO.GetRolesById(ID);
                txtRolesName.Text = roles.RolesName;
                ViewModules();
                string sModules = roles.RolesModules;
                if (!sModules.Equals("")) 
                {
                    string[] sSlip = sModules.Split(new char[] {','});
                    foreach(string s in sSlip)
                    {
                        foreach (ListItem items in chklist.Items)
                        {
                            if (items.Value == s)
                                items.Selected = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
            hddRoles_ID.Value = "";
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_edit1.Visible = false;
            ViewModules();
        }
    }
    #endregion

    #region Viewmodules
    public void ViewModules()
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        DataTable table = modulesBSO.MixModules();
        DataView dataView = new DataView(table);
       // dataView.RowFilter = "Slug <> 'listmodules' and Slug <> 'editmodules' ";
        dataView.RowFilter = "Slug not in ('listmodules','editmodules')";
        DataTable dataTable = dataView.ToTable();
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToCheckBoxList(chklist, dataTable, "Modules_Name", "Slug");


    }
    #endregion

    #region CheckedList
    public string CheckedList()
    {
        string strID = "";
        foreach (ListItem items in chklist.Items)
        {
            if (items.Selected)
                strID += items.Value + ",";
        }
        return strID;
    }
    #endregion

    #region ReceiveHtml
    public IRoles ReceiveHtml()
    {
        IRoles roles = new IRoles();
        roles.RolesID = (hddRoles_ID.Value != "") ? Convert.ToInt32(hddRoles_ID.Value) : 0;
        roles.RolesName = (txtRolesName.Text != "") ? txtRolesName.Text.Trim() : "";
        roles.RolesModules = (CheckedList() != "") ? CheckedList() : "";

        return roles;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        RolesBSO rolesBSO = new RolesBSO();
        IRoles roles = ReceiveHtml();
        try
        {
            if (CheckedList().Equals(""))
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Loi : Xin hay lua chon it nhat 1 quyen </div>";
            }
            else
            {
                int id = rolesBSO.CreateRoles(roles);
                error.Text = error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
                initControl(id);
            }

        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        RolesBSO rolesBSO = new RolesBSO();
        IRoles roles = ReceiveHtml();
        try
        {
            if (CheckedList().Equals(""))
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Loi : Xin hay lua chon it nhat 1 quyen </div>";
            }
            else 
            {
                rolesBSO.UpdateRoles(roles);
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
                initControl(roles.RolesID);
            }
            
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
}
