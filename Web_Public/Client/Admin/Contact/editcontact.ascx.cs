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
public partial class Admin_Controls_editcontact : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            ViewDate();
            initControl(Id);
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

    #region initControl
    protected void initControl(int Id)
    {
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_edit1.Visible = true;
            try
            {
                ContactBSO contactBSO = new ContactBSO();
                Contact contact = contactBSO.GetContactById(Id);

                hddContactID.Value = Convert.ToString(contact.ContactID);

                txtEmail.Text = contact.Email;

                txtName.Text = contact.Name;
                txtAddress.Text = contact.Address;
                txtTel.Text = contact.Tel;
                txtFax.Text = contact.Fax;

                txtCity.Text = contact.City;
                txtCompany.Text = contact.Company;

               


                cboDay1.SelectedValue = contact.Date.Day.ToString();
                cboMonth1.SelectedValue = contact.Date.Month.ToString();
                cboYear1.SelectedValue = contact.Date.Year.ToString();
                cboMinutes1.SelectedValue = contact.Date.Minute.ToString();
                cboHour1.SelectedValue = contact.Date.Hour.ToString();




                txtRequire.Text = contact.Require;


            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else if (Id == 0)
        {
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_edit1.Visible = false;
        }
    }
    #endregion



    #region ViewDate
    public void ViewDate()
    {

        for (int i = 1; i <= 31; i++)
            cboDay1.Items.Add(Convert.ToString(i));
        for (int i = 1; i <= 12; i++)
            cboMonth1.Items.Add(Convert.ToString(i));
        for (int i = 2009; i <= 2100; i++)
            cboYear1.Items.Add(Convert.ToString(i));
        for (int i = 0; i < 24; i++)
            cboHour1.Items.Add(Convert.ToString(i));
        for (int i = 0; i < 60; i++)
            cboMinutes1.Items.Add(Convert.ToString(i));

        cboDay1.SelectedValue = DateTime.Now.Day.ToString();
        cboMonth1.SelectedValue = DateTime.Now.Month.ToString();
        cboYear1.SelectedValue = DateTime.Now.Year.ToString();
        cboMinutes1.SelectedValue = DateTime.Now.Minute.ToString();
        cboHour1.SelectedValue = DateTime.Now.Hour.ToString();

        
    }
    #endregion

    #region ReceiveHtml
    public Contact ReceiveHtml()
    {
        Contact contact = new Contact();
        contact.ContactID = (hddContactID.Value != "") ? Convert.ToInt32(hddContactID.Value) : 0;

        contact.Email = (txtEmail.Text != "") ? txtEmail.Text.Trim() : "";
        contact.Name = (txtName.Text != "") ? txtName.Text.Trim() : "";
        contact.Address = (txtAddress.Text != "") ? txtAddress.Text.Trim() : "";
        contact.Tel = (txtTel.Text != "") ? txtTel.Text.Trim() : "";
        contact.Fax = (txtFax.Text != "") ? txtFax.Text.Trim() : "";

        contact.City = (txtCity.Text != "") ? txtCity.Text.Trim() : "";
        contact.Company = (txtCompany.Text != "") ? txtCompany.Text.Trim() : "";


        contact.Date = new DateTime(Convert.ToInt16(cboYear1.SelectedValue),
                                    Convert.ToInt16(cboMonth1.SelectedValue),
                                    Convert.ToInt16(cboDay1.SelectedValue),
                                    Convert.ToInt16(cboHour1.SelectedValue),
                                    Convert.ToInt16(cboMinutes1.SelectedValue), 0);


        contact.Attact = "";
        contact.Require = txtRequire.Text;

        return contact;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Contact contact = ReceiveHtml();
        try
        {
            ContactBSO contactBSO = new ContactBSO();
            contactBSO.CreateContact(contact);
            error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới Thành công !</div>";
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {

        try
        {
            Contact contact = ReceiveHtml();
            ContactBSO contactBSO = new ContactBSO();
            contactBSO.UpdateContact(contact);
            error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
}
