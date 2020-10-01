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
public partial class Client_Admin_ListNewsFiles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int cId = 0;
        if (!String.IsNullOrEmpty(Request["id"]))
            int.TryParse(Request["id"].Replace(",", ""), out cId);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);


        hddNewsGroupID.Value = Convert.ToString(cId);

        if (!IsPostBack)
            ViewFiles(cId);
    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    #region ViewFiles
    private void ViewFiles(int cId)
    {
        NewsGroupFileBSO newsgroupFilesBSO = new NewsGroupFileBSO();
        DataTable table = new DataTable();
        if (cId != 0)
            table = newsgroupFilesBSO.GetNewsGroupFileByNewsGroup(cId);
        else
            table = newsgroupFilesBSO.GetNewsGroupFileAll();

        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvFiles, table);
    }
    #endregion


    protected void grvFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvFiles.PageIndex = e.NewPageIndex;

        ViewFiles(Convert.ToInt32(hddNewsGroupID.Value));
    }
    protected void grvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string nName = e.CommandName.ToLower();
        switch (nName)
        {
            case "_edit":
                Response.Redirect("~/Admin/editnewsfiles/" + hddNewsGroupID.Value + "/" + Id + "/Default.aspx");
                break;

            case "_delete":
                NewsGroupFileBSO newsgroupFileBSO = new NewsGroupFileBSO();
                newsgroupFileBSO.DeleteNewsGroupFile(Id);

                ViewFiles(Convert.ToInt32(hddNewsGroupID.Value));
                break;
        }
    }
    protected void grvFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
        }
    }

    protected void btn_delall_Click(object sender, EventArgs e)
    {
        if (FilesID() != "")
        {
            NewsGroupFileBSO fileBSO = new NewsGroupFileBSO();
            fileBSO.DeleteNewsGroupFile(FilesID());
        }
        ViewFiles(Convert.ToInt32(hddNewsGroupID.Value));
    }

    #region FilesID
    private string FilesID()
    {
        string filesId = "";
        foreach (GridViewRow rows in grvFiles.Rows)
        {
            CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
            if (checkbox.Checked)
                filesId += rows.Cells[0].Text + ",";
        }
        return filesId;
    }

    #endregion

    protected void btn_editnewsgroupfiles(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/editnewsfiles/" + hddNewsGroupID.Value + "/0/Default.aspx");

    }
    protected void btn_listnewsgroup(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/listnewsbyuser/Default.aspx");

    }

}
