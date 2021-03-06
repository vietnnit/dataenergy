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

public partial class Admin_Controls_sendmail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        txtRadFull.DisableFilter(Telerik.Web.UI.EditorFilters.ConvertCharactersToEntities);

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


    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);

            MailBSO mailBSO = new MailBSO();
            mailBSO.EmailFrom = config.Email_from;

            PhoneBookBSO emailBSO = new PhoneBookBSO();
            DataTable table = emailBSO.GetListPhoneBook();


            string subject = txtTitle.Text;
            string body = txtRadFull.Content;

            for (int i = 0; i < table.Rows.Count; i++)
                mailBSO.SendMail(table.Rows[i]["Email"].ToString(), subject, body);

            clientview.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Gửi mail đến danh sách người dùng thành công !</div>";

        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

}
