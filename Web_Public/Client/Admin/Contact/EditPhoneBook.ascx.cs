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
using BSO;
using ETO;

public partial class Client_Admin_EditPhoneBook : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int _Id = 0;
            if (!String.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"].Replace(",", ""), out _Id);

            if (!string.IsNullOrEmpty(Request["dll"]))
                NavigationTitle(Request["dll"]);

            Id = _Id;
            if (Id > 0)
            {
                btn_edit.Visible = true;
                btn_add.Visible = false;

                btn_edit1.Visible = true;
                btn_add1.Visible = false;
                BindData();
            }
            else
            {
                btn_edit.Visible = false;
                btn_add.Visible = true;

                btn_edit1.Visible = false;
                btn_add1.Visible = true;
            }
            GetDepartMent();
        }
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
        DataTable dtb = objBSO.GetDetial(Id);
        if (dtb != null)
        {
            if (dtb.Rows.Count > 0)
            {
                txtFullName.Text = dtb.Rows[0]["FullName"].ToString();
                txtHomePhone.Text = dtb.Rows[0]["HomePhone"].ToString();
                txtofficePhone.Text = dtb.Rows[0]["officePhone"].ToString();

                txtPhone1.Text = dtb.Rows[0]["Phone1"].ToString();
                txtPhone2.Text = dtb.Rows[0]["Phone2"].ToString();
                txtAddress.Text = dtb.Rows[0]["Address"].ToString();
                txtEmail.Text = dtb.Rows[0]["Email"].ToString();
                txtOrder.Text = dtb.Rows[0]["Orders"].ToString();
                try
                {
                    if (dtb.Rows[0]["ParentId"].ToString() != "0")
                    {
                        ddlDepartment.SelectedValue = dtb.Rows[0]["ParentId"].ToString();
                    }
                }
                catch { }

            }
        }
    }

    public int Id
    {
        get
        {
            //Check Exist ViewState
            if (ViewState["Id"] != null && ViewState["Id"] is int)
            {
                return (int)ViewState["Id"];
            }
            else

                return 0;
        }
        set { ViewState["Id"] = value; }
    }
    private void GetDepartMent()
    {
        BSO.PhoneBookBSO objBSO = new PhoneBookBSO();
        DataTable dtb = objBSO.GetDepartMent();
        if (dtb != null)
        {
            ddlDepartment.DataSource = dtb;
            ddlDepartment.DataTextField = "FullName";
            ddlDepartment.DataValueField = "id";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, "----- Chọn ------ ");
           
        }
    }

    private ETO.PhoneBook SetData()
    {
        ETO.PhoneBook obj = new PhoneBook();
        obj.FullName = txtFullName.Text;
        obj.Phone1 = txtPhone1.Text;
        obj.Phone2 = txtPhone2.Text;
        obj.Officephone = txtofficePhone.Text;
        obj.HomePhone = txtHomePhone.Text;
        obj.Email = txtEmail.Text;
        obj.Address = txtAddress.Text;
        int _order=0;
        if (!String.IsNullOrEmpty(txtOrder.Text))
            int.TryParse(txtOrder.Text.Replace(",", ""), out _order);
        obj.Orders = _order;
        try
        {
            obj.ParentId = Convert.ToInt32(ddlDepartment.SelectedValue);
        }
        catch { }
        obj.CreatorId = Session["Admin_UserName"].ToString();
        return obj;
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            PhoneBook obj = SetData();
            BSO.PhoneBookBSO objBSO = new PhoneBookBSO();
            objBSO.CreatePhoneBook(obj);
            GetDepartMent();
            clientview.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới Thành công !</div>";
        }
        catch
        { }
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            PhoneBook obj = SetData();
            obj.Id = Id;
            BSO.PhoneBookBSO objBSO = new PhoneBookBSO();
            objBSO.UpdatePhoneBook(obj);
            GetDepartMent();
            clientview.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
        }
        catch
        { }
    }
}
