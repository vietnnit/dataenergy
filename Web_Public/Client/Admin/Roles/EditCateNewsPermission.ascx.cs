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
using DAO;
using Telerik.Web.UI;
public partial class Client_Admin_EditCateNewsPermission : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        
        hddRoles.Value = Convert.ToString(Id);
       
        if (!IsPostBack)
        {
            RolesBSO rolesBSO = new RolesBSO();
            IRoles roles = rolesBSO.GetRolesById(Id);
            ltlTitle.Text = roles.RolesName;

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
    protected void initControl(int Id)
    {
        if (Id > 0)
        {
            ViewCateAll();
            VierPermissionID();
        }
        else 
        {
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Lựa chọn Nhóm người dùng trước khi phân quyền </div>";
        }
    }
    #endregion

    #region ViewCateAll
    private void ViewCateAll()
    {
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateNewsNamePermission(Language.language,Session["Admin_UserName"].ToString());
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();

    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        DataTable datatable = CateNewsID();
        
        try
        {
            CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();

            DataTable table1 = catenewPermissionBSO.GetCateNewsPermissionByRoles(Convert.ToInt32(hddRoles.Value), Language.language);
            
            if (table1.Rows.Count > 0)
                catenewPermissionBSO.DeleteCateNewsPermissionRoles(Convert.ToInt32(hddRoles.Value), Language.language);

            CateNewsPermission cateNewsPermission = new CateNewsPermission();

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    cateNewsPermission.CateNewsID = Convert.ToInt32(subrow["CateNewsID"].ToString());
                    cateNewsPermission.RolesID = Convert.ToInt32(hddRoles.Value);
              //      cateNewsPermission.Permission = subrow["Permission"].ToString();
                    cateNewsPermission.Permission = "";
                    cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                    cateNewsPermission.Created = DateTime.Now;
                    cateNewsPermission.Language = Language.language;

                    catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);

                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
                  //  initControl(cateNewsPermission.RolesID);
                    
                }

                
            }

            
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        
    }

    #region VierPermissionID
    private void VierPermissionID()
    {
        //PermissionBSO permissionBSO = new PermissionBSO();
        //DataTable table = permissionBSO.GetPermissionAll();
        //DataView dataView = new DataView(table);
        //dataView.Sort = "PermissionID ASC";
        //DataTable dataTable = dataView.ToTable();
        //commonBSO commonBSO = new commonBSO();
        
        CateNewsPermissionBSO cateNewsPermissionBSO = new CateNewsPermissionBSO();
        CateNewsPermission cateNewsPermission = new CateNewsPermission();

        foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
        {
            //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");
            CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");

            //commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");

            if (cateNewsPermissionBSO.CheckExitPermission(Convert.ToInt32(hddRoles.Value), Convert.ToInt32(dataItem["CateNewsID"].Text)))
            {

                //Permission
                //cateNewsPermission = cateNewsPermissionBSO.GetCateNewsPermission(Convert.ToInt32(hddRoles.Value), Convert.ToInt32(dataItem["CateNewsID"].Text));

                //if (cateNewsPermission != null)
                //{
                //    string sPermission = cateNewsPermission.Permission;
                //    if (!sPermission.Equals(""))
                //    {
                //        string[] sSlip = sPermission.Split(new char[] { ',' });
                //        foreach (string s in sSlip)
                //        {
                //            foreach (ListItem items in chklist.Items)
                //            {
                //                if (items.Value == s)
                //                    items.Selected = true;
                //            }
                //        }
                //    }
                //}

                //CateID
                chkId.Checked = true;
            }
            
        }


    }
    #endregion

    #region CateNewsID
    private DataTable CateNewsID()
    {
        DataTable datatable = new DataTable();
        datatable.Columns.Add("CateNewsID");
        //datatable.Columns.Add("Permission");

        foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
        {
            CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");
            //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");

            //string strID = "";
            //foreach (ListItem items in chklist.Items)
            //{
            //    if (items.Selected)
            //        strID += items.Value + ",";
            //}

            if (chkId.Checked)
            {
                DataRow datarow = datatable.NewRow();
                datarow["CateNewsID"] = dataItem["CateNewsID"].Text;
                //datarow["Permission"] = strID;

                datatable.Rows.Add(datarow);
            }

        }
       
        return datatable;
    }

    #endregion

}
