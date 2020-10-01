using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Collections.Generic;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Data.OleDb;
using System.Web.UI;
public partial class Client_Admin_ListDEArea : System.Web.UI.UserControl
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
            BindArea();
            BindData();
        }
    }

    void BindArea()
    {
        IList<Area> list = new List<Area>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        {
            list = new AreaService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        }
        else
            list = (IList<Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
        if (list != null && list.Count > 0)
        {
            var listSearch = from o in list where o.ParentId == 0 || o.ParentId == null orderby o.SortOrder ascending select o;
            ddlParent.DataSource = listSearch;
            ddlParent.DataTextField = "AreaName";
            ddlParent.DataValueField = "Id";
            ddlParent.DataBind();

            ddlFieldParent.DataSource = listSearch;
            ddlFieldParent.DataTextField = "AreaName";
            ddlFieldParent.DataValueField = "Id";
            ddlFieldParent.DataBind();
        }
        else
        {
            ddlParent.DataSource = null;
            ddlParent.DataBind();

            ddlFieldParent.DataSource = null;
            ddlFieldParent.DataBind();
        }
        ddlParent.Items.Insert(0, new ListItem("---Tất cả---", ""));
        ddlFieldParent.Items.Insert(0, new ListItem("---Chọn lĩnh vực cha---", ""));
    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion


    #region ViewNewsGroup
    void BindData()
    {
        AreaService comBSO = new AreaService();
        DataTable list = new DataTable();
        int ParentId = 0;
        if (ddlParent.SelectedIndex > 0)
            ParentId = Convert.ToInt32(ddlParent.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = new AreaService().FindList(ParentId, txtKeyword.Text.Trim(), paging);
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                ltrTotal.Text = "Có tổng số " + paging.RowsCount + " lĩnh vực";
                Paging.Visible = false;
            }
            else
            {
                int st = (CurrentPage - 1) * PageSize + 1;
                long end = CurrentPage * PageSize;
                if (end > paging.RowsCount)
                    end = paging.RowsCount;
                ltrTotal.Text = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " lĩnh vực";
                Paging.Visible = true;
            }

        }
        else
        {
            ltrTotal.Text = "";
            Paging.Visible = false;
        }
        grvArea.DataSource = list;
        grvArea.DataBind();
    }
    #endregion

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();

        string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", Server.MapPath("~/UserFile/DC_2014.xlsx"));
        //string query = String.Format("select * from [{0}$]", "Area");
        string query = String.Format("select * from [{0}$]", "DN");

        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        DataTable myTable = dataSet.Tables[0];
        EnterpriseService comBSO = new EnterpriseService();
        foreach (DataRow drow in myTable.Rows)
        {
            ReportTemp2014 temp = new ReportTemp2014();
            Enterprise area = new Enterprise();
            area.Title = drow["Title"].ToString();
            temp.Title = area.Title;
            if (drow["Address"] != null)
            {
                area.Address = drow["Address"].ToString();
                temp.Address = area.Address;
            }
            //if (drow["Phone"] != null)
            //{
            //    area.Phone = drow["Phone"].ToString();
            //    temp.Phone = area.Phone;
            //}
            area.OrganizationId = Convert.ToInt32(drow["OrgId"]);
            temp.OrgId = area.OrganizationId;

            //if (drow["SubArea"] != null && drow["SubArea"].ToString() != "")
            //{ 

            //}
            if (drow["AreaName"] != null && drow["AreaName"].ToString() != "")
            {
                temp.AreaName = drow["AreaName"].ToString();
                if (drow["AreaName"].ToString() == "Công nghiệp")
                    area.AreaId = 5;
                else
                    if (drow["AreaName"].ToString() == "Nông nghiệp")
                        area.AreaId = 3;
                    else
                        if (drow["AreaName"].ToString() == "Công trình xây dựng")
                            area.AreaId = 6;
                        else
                            area.AreaId = 1;
                temp.AreaId = area.AreaId;
            }
            if (drow["SubAreaName"] != null && drow["SubAreaName"].ToString() != "")
            {
                DataTable dtSub = new AreaService().getAreaByName(drow["SubAreaName"].ToString());
                if (dtSub != null && dtSub.Rows.Count > 0)
                {
                    area.SubAreaId = Convert.ToInt32(dtSub.Rows[0]["Id"]);
                    temp.SubAreaId = area.SubAreaId;
                }
                //else
                //{
                //    Area sub = new Area();
                //    sub.AreaName = drow["SubAreaName"].ToString();
                //    sub.ParentId = area.AreaId;
                //    sub.IsStatus = 1;
                //    sub.SortOrder = 0;
                //    int subId = new AreaService().Insert(sub);
                //    temp.SubAreaId = subId;
                //    area.SubAreaId = subId;
                //}
                area.Info = drow["SubAreaName"].ToString();
                temp.SubAreaName = drow["SubAreaName"].ToString();


            }

            area.ProvinceId = Convert.ToInt32(drow["ProvinceId"]);
            area.ManProvinceId = Convert.ToInt32(drow["ManProvinceId"]);
            int eId = 0;//comBSO.Insert(area);//Them doanh  nghiep
            if (drow["Id"] != null && drow["Id"].ToString().Trim() != "")
                eId = Convert.ToInt32(drow["Id"]);
            if (eId > 0)
            {
                temp.EnterpriseId = eId;
                if (drow["Dien_kWh"] != null && drow["Dien_kWh"].ToString().Trim() != "")
                    temp.Dien_kWh = drow["Dien_kWh"].ToString();

                if (drow["Than_Tan"] != null && drow["Than_Tan"].ToString().Trim() != "")
                    temp.Than_Tan = drow["Than_Tan"].ToString();

                if (drow["DO_Tan"] != null && drow["DO_Tan"].ToString().Trim() != "")
                    temp.DO_Tan = drow["DO_Tan"].ToString();

                if (drow["FO_Tan"] != null && drow["FO_Tan"].ToString().Trim() != "")
                    temp.FO_Tan = drow["FO_Tan"].ToString();

                if (drow["Xang_Tan"] != null && drow["Xang_Tan"].ToString().Trim() != "")
                    temp.Xang_Tan = drow["Xang_Tan"].ToString();

                if (drow["Gas_Tan"] != null && drow["Gas_Tan"].ToString().Trim() != "")
                    temp.Gas_Tan = drow["Gas_Tan"].ToString();

                if (drow["Khi_m3"] != null && drow["Khi_m3"].ToString().Trim() != "")
                    temp.Khi_M3 = drow["Khi_m3"].ToString();

                if (drow["LPG_Tan"] != null && drow["LPG_Tan"].ToString().Trim() != "")
                    temp.LPG_Tan = drow["LPG_Tan"].ToString();

                if (drow["KhacSoDo"] != null && drow["KhacSoDo"].ToString().Trim() != "")
                    temp.KhacSoDo = drow["KhacSoDo"].ToString();

                if (drow["Note"] != null && drow["Note"].ToString().Trim() != "")
                    temp.Note = drow["Note"].ToString();


                EnterpriseYearService eYService = new EnterpriseYearService();
                EnterpriseYear ey = new EnterpriseYear();
                ey.EnterpriseId = eId;

                if (drow["No_TOE"] != null && drow["No_TOE"].ToString().Trim() != "" && Convert.ToDecimal(drow["No_TOE"]) > 0)
                {
                    ey.No_TOE = Convert.ToDecimal(drow["No_TOE"]);
                    temp.No_TOE = ey.No_TOE;
                    temp.Year = 2014;
                    int retTemp = new ReportTemp2014Service().Insert(temp);//Them bao cao tam
                    ey.IsDelete = false;
                    ey.Year = temp.Year;
                    eYService.Insert(ey);//Them nam bao cao
                }

            }

        }
        /* AreaService comBSO = new AreaService();
         foreach (DataRow drow in myTable.Rows)
         {
             Area area = new Area();
             area.AreaName = drow[0].ToString();
             area.ParentId = Convert.ToInt32(drow[1]);
             comBSO.Insert(area);
         }
         */

        /*string con =
@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/UserFile/Data_072016.xlsx") + ";" +
@"Extended Properties='Excel 8.0;HDR=Yes;'";
        using (OleDbConnection connection = new OleDbConnection(con))
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
            using (OleDbDataReader dr = command.ExecuteReader())
            {               
                dt.Load(dr);
                AreaService comBSO = new AreaService();
                foreach (DataRow drow in dt.Rows)
                {
                    Area area = new Area();
                    area.AreaName = drow[0].ToString();
                    area.ParentId = Convert.ToInt32(drow[1]);
                    comBSO.Insert(area);
                }
                //while (dr.Read())
                //{
                //    var row1Col0 = dr[0];                    
                //}
            }
        }*/
    }
    protected void btnImportEN_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", Server.MapPath("~/UserFile/Data_2014.xlsx"));
        //string query = String.Format("select * from [{0}$]", "Area");
        string query = String.Format("select * from [{0}$]", "DN");

        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        DataTable myTable = dataSet.Tables[0];
        EnterpriseService comBSO = new EnterpriseService();
        foreach (DataRow drow in myTable.Rows)
        {
            ReportTemp2014 temp = new ReportTemp2014();
            Enterprise area = new Enterprise();
            area.Title = drow["Title"].ToString();
            temp.Title = area.Title;
            if (drow["Address"] != null)
            {
                area.Address = drow["Address"].ToString();
                temp.Address = area.Address;
            }
            //if (drow["Phone"] != null)
            //{
            //    area.Phone = drow["Phone"].ToString();
            //    temp.Phone = area.Phone;
            //}
            area.OrganizationId = Convert.ToInt32(drow["OrgId"]);
            temp.OrgId = area.OrganizationId;

            //if (drow["SubArea"] != null && drow["SubArea"].ToString() != "")
            //{ 

            //}
            if (drow["AreaName"] != null && drow["AreaName"].ToString() != "")
            {
                temp.AreaName = drow["AreaName"].ToString();
                if (drow["AreaName"].ToString() == "Công nghiệp")
                    area.AreaId = 5;
                else
                    if (drow["AreaName"].ToString() == "Nông nghiệp")
                        area.AreaId = 3;
                    else
                        if (drow["AreaName"].ToString() == "Công trình xây dựng")
                            area.AreaId = 6;
                        else
                            area.AreaId = 1;
                temp.AreaId = area.AreaId;
            }
            if (drow["SubAreaName"] != null && drow["SubAreaName"].ToString() != "")
            {
                DataTable dtSub = new AreaService().getAreaByName(drow["SubAreaName"].ToString().Trim());
                if (dtSub != null && dtSub.Rows.Count > 0)
                {
                    area.SubAreaId = Convert.ToInt32(dtSub.Rows[0]["Id"]);
                    temp.SubAreaId = area.SubAreaId;
                }
                else
                {
                    Area sub = new Area();
                    sub.AreaName = drow["SubAreaName"].ToString().Trim();
                    sub.ParentId = area.AreaId;
                    sub.IsStatus = 1;
                    sub.SortOrder = 0;
                    int subId = new AreaService().Insert(sub);
                    temp.SubAreaId = subId;
                    area.SubAreaId = subId;
                }
                area.Info = drow["SubAreaName"].ToString().Trim();
                temp.SubAreaName = drow["SubAreaName"].ToString().Trim();

            }

            area.ProvinceId = Convert.ToInt32(drow["ProvinceId"]);
            area.ManProvinceId = Convert.ToInt32(drow["ManProvinceId"]);
            int eId = comBSO.Insert(area);//Them doanh  nghiep            
            if (eId > 0)
            {
                temp.EnterpriseId = eId;
                if (drow["Dien_kWh"] != null && drow["Dien_kWh"].ToString().Trim() != "")
                    temp.Dien_kWh = drow["Dien_kWh"].ToString();

                if (drow["Than_Tan"] != null && drow["Than_Tan"].ToString().Trim() != "")
                    temp.Than_Tan = drow["Than_Tan"].ToString();

                if (drow["DO_Tan"] != null && drow["DO_Tan"].ToString().Trim() != "")
                    temp.DO_Tan = drow["DO_Tan"].ToString();

                if (drow["FO_Tan"] != null && drow["FO_Tan"].ToString().Trim() != "")
                    temp.FO_Tan = drow["FO_Tan"].ToString();

                if (drow["Xang_Tan"] != null && drow["Xang_Tan"].ToString().Trim() != "")
                    temp.Xang_Tan = drow["Xang_Tan"].ToString();

                if (drow["Gas_Tan"] != null && drow["Gas_Tan"].ToString().Trim() != "")
                    temp.Gas_Tan = drow["Gas_Tan"].ToString();

                if (drow["Khi_m3"] != null && drow["Khi_m3"].ToString().Trim() != "")
                    temp.Khi_M3 = drow["Khi_m3"].ToString();

                if (drow["LPG_Tan"] != null && drow["LPG_Tan"].ToString().Trim() != "")
                    temp.LPG_Tan = drow["LPG_Tan"].ToString();

                if (drow["Khac_SoDo"] != null && drow["Khac_SoDo"].ToString().Trim() != "")
                    temp.KhacSoDo = drow["Khac_SoDo"].ToString();

                //if (drow["Note"] != null && drow["Note"].ToString().Trim() != "")
                //    temp.Note = drow["Note"].ToString();

                EnterpriseYearService eYService = new EnterpriseYearService();
                EnterpriseYear ey = new EnterpriseYear();
                ey.EnterpriseId = eId;

                if (drow["No_TOE"] != null && drow["No_TOE"].ToString().Trim() != "" && Convert.ToDecimal(drow["No_TOE"]) > 0)
                {
                    ey.No_TOE = Convert.ToDecimal(drow["No_TOE"]);
                    temp.No_TOE = ey.No_TOE;
                    temp.Year = 2014;
                    int retTemp = new ReportTemp2014Service().Insert(temp);//Them bao cao tam
                    ey.IsDelete = false;
                    ey.Year = temp.Year;
                    eYService.Insert(ey);//Them nam bao cao
                }
            }

        }

    }

    protected void btn_Order_Click(object sender, EventArgs e)
    {
        if (grvArea.Rows != null && grvArea.Rows.Count > 2)
        {
            foreach (GridViewRow row in grvArea.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtOrder");
                if (textOrder != null && textOrder.Text != "" && textOrder.Text.Trim() != "")
                {
                    int pID = Convert.ToInt32(row.Cells[0].Text);
                    int pOrder = 0;
                    try
                    {
                        pOrder = Convert.ToInt32(textOrder.Text);
                        Area objArea = new Area();
                        objArea = new AreaService().FindByKey(pID);
                        if (objArea != null)
                        {
                            objArea.SortOrder = pOrder;
                            new AreaService().Update(objArea);
                        }
                    }
                    catch { }
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        AreaService areaService = new AreaService();
        Area objArea = new Area();
        int fId = 0;
        if (hdnEditId.Value != "")
        {
            try
            {
                fId = Convert.ToInt32(hdnEditId.Value.Trim());
            }
            catch
            { }
        }
        objArea.AreaName = txtTitle.Text.Trim();
        if (ddlFieldParent.SelectedValue != "")
            objArea.ParentId = Convert.ToInt32(ddlFieldParent.SelectedValue);
        int fOrder = 0;
        try
        {
            fOrder = Convert.ToInt32(txtSorOrder.Text);
            objArea.SortOrder = fOrder;
        }
        catch { }
        if (fId > 0)
        {
            objArea.Id = fId;
            if (areaService.Update(objArea) != null)
            {
                BindData();
                hdnEditId.Value = "0";
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatefield();", true);
        }
        else
        {
            objArea.IsDelete = false;
            objArea.IsStatus = 1;
            if (areaService.Insert(objArea) > 0)
            {
                BindData();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showform", "addfield();", true);
        }
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }

    protected void grvArea_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int iEditId = 0;
        iEditId = Convert.ToInt32(e.CommandArgument.ToString());
        string aName = e.CommandName.ToLower();
        if (iEditId > 0)
        {
            AreaService objlogic = new AreaService();
            if (aName.Contains("_edit"))
            {
                Area obj = new Area();
                obj = objlogic.FindByKey(iEditId);
                if (obj != null)
                {
                    hdnEditId.Value = iEditId.ToString();
                    txtTitle.Text = obj.AreaName;
                    txtSorOrder.Text = obj.SortOrder.ToString();
                    if (obj.ParentId > 0)
                        ddlFieldParent.SelectedValue = obj.ParentId.ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatefield();", true);
                }
            }
            else if (aName.Contains("_delete"))
            {
                Area obj = new Area();
                obj = objlogic.FindByKey(iEditId);
                if (obj != null)
                {
                    obj.IsDelete = true;
                    if (objlogic.Update(obj) != null)
                    {
                        BindData();
                    }
                }
            }
        }
    }
}
