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
public partial class Client_Admin_EditNewsFiles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["id"]))
            int.TryParse(Request["id"].Replace(",", ""), out Id);
        

        int cId = 0;
        if (!String.IsNullOrEmpty(Request["group"]))
            int.TryParse(Request["group"].Replace(",", ""), out cId);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            hddNewsGroupID.Value = Convert.ToString(cId);
            ViewFiles(cId);
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

    

    #region ViewFiles
    private void ViewFiles(int cId)
    {
        NewsGroupFileBSO newsgroupFileBSO = new NewsGroupFileBSO();
        DataTable table = new DataTable();
        if (cId != 0)
            table = newsgroupFileBSO.GetNewsGroupFileByNewsGroup(cId);
        else
            table = newsgroupFileBSO.GetNewsGroupFileAll();

        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvFiles, table);
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
            btn_edit1.Visible = true;
            try
            {
                NewsGroupFileBSO newsgroupFileBSO = new NewsGroupFileBSO();
                NewsGroupFile newsgroupFile = newsgroupFileBSO.GetNewsGroupFileByID(Id);


                hddNewsGroupFileID.Value = Convert.ToString(newsgroupFile.NewsGroupFileID);
                hddNewsGroupID.Value = Convert.ToString(newsgroupFile.NewsGroupID);
                hddFileName.Value = newsgroupFile.FileName;
                txtFileName.Text = newsgroupFile.FileName;
                txtTitle.Text = newsgroupFile.Title;
                

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            btn_edit.Visible = false;
            btn_add.Visible = true;

            btn_edit1.Visible = false;
            btn_add1.Visible = true;



        }
    }
    #endregion

    #region ReceiveHtml
    private NewsGroupFile ReceiveHtml()
    {
        NewsGroupFile newsgroupFile = new NewsGroupFile();
        newsgroupFile.NewsGroupFileID = (hddNewsGroupFileID.Value != "") ? Convert.ToInt32(hddNewsGroupFileID.Value) : 0;
        newsgroupFile.NewsGroupID = Convert.ToInt32(hddNewsGroupID.Value);
        newsgroupFile.Title = txtTitle.Text;
        newsgroupFile.FileName = (txtFileName.Text != "") ? txtFileName.Text : hddFileName.Value;

        return newsgroupFile;
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
                NewsGroupFileBSO fileBSO = new NewsGroupFileBSO();
                fileBSO.DeleteNewsGroupFile(Id);

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
    protected void btn_add_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtFileName.Text=="")
            {
          
                ViewFiles(Convert.ToInt32(hddNewsGroupID.Value));
                clientview.Text = "Chưa có file đính kèm";

            }
            else
            {
                NewsGroupFile file = new NewsGroupFile();
                file = ReceiveHtml();


                NewsGroupFileBSO filesBSO = new NewsGroupFileBSO();
                filesBSO.CreateNewsGroupFile(file);


                ViewFiles(Convert.ToInt32(hddNewsGroupID.Value));
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";


            }


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
            NewsGroupFile file = new NewsGroupFile();
            file = ReceiveHtml();


            NewsGroupFileBSO filesBSO = new NewsGroupFileBSO();
            filesBSO.UpdateNewsGroupFile(file);


            ViewFiles(Convert.ToInt32(hddNewsGroupID.Value));
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

  
    protected void btn_listfile(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/listnewsfiles/" + hddNewsGroupID.Value + "/Default.aspx");
    }
    protected void btn_editfile(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/editnewsfiles/" + hddNewsGroupID.Value + "/0/Default.aspx");

    }
    protected void btn_listnewsgroup(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/listnews/Default.aspx");

    }

    protected string GetString(object _txt)
    {
        if (_txt != null)
        {
            Utils objUtil = new Utils();
            return objUtil.Getstring(_txt.ToString());
        }
        return "";
    }
}
