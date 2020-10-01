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

public partial class Client_Admin_ListPhoneBook : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
        litModules.Text = modules.ModulesName;
    }
    #endregion

    private void BindData()
    {
        BSO.PhoneBookBSO objBSO = new PhoneBookBSO();
        DataTable dtb = objBSO.MixPhoneBook();
        if (dtb != null)
        {
            grvPhoneBook.DataSource = dtb;
            grvPhoneBook.DataBind();
        }
    }
    
    protected void grvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string cName = e.CommandName.ToLower();
        switch (cName)
        {
            case "_mail":
                Response.Redirect("~/Admin/sendemail/" + Id + "/Default.aspx");
                break;
            case "_edit":
                Response.Redirect("~/Admin/editphonebook/" + Id + "/Default.aspx");
                break;
            case "_delete":
                BSO.PhoneBookBSO objBSO = new PhoneBookBSO();
                objBSO.Delete(Id);
                BindData();
                break;
        }
    }
    protected void grvContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

        }
    }

    protected void grvContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPhoneBook.PageIndex = e.NewPageIndex;
        BindData();
    }

    protected void btn_Order_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvPhoneBook.Rows)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtOrder");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int ID = Convert.ToInt32(row.Cells[0].Text);

            BSO.PhoneBookBSO objBSO = new PhoneBookBSO();
            objBSO.PhoneBookUpOrder(ID, cOrder);

        }
        BindData();
    }
}
