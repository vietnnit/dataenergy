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
public partial class Admin_Controls_listcontact : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
            ViewContact();
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

    #region ViewContact
    private void ViewContact()
    {
        ContactBSO contactBSO = new ContactBSO();
        DataTable table = contactBSO.GetContactAll();
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvContact, table);
    }
    #endregion

    protected void grvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string cName = e.CommandName.ToLower();
        switch (cName)
        {
            case "_edit":
                Response.Redirect("~/Admin/editcontact/" + Id + "/Default.aspx");
                break;
            case "_delete":
                ContactBSO contactBSO = new ContactBSO();
                contactBSO.DeleteContact(Id);
                ViewContact();
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
}
