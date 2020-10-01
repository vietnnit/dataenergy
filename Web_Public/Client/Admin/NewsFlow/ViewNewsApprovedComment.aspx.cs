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
public partial class Admin_Controls_ViewNewsApprovedComment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            if (!int.TryParse(Request["Id"].Replace(",", ""), out Id))
                Response.Redirect("~/Admin/home/Default.aspx");
        if (!IsPostBack)
        {
            txtNewsGroupID.Value = Convert.ToString(Id);
            GetNewsCommentById(Id);
        }
    }
    private void GetNewsCommentById(int cId)
    {
        NewsApprovedCommentBSO newsApprovedCommentBSO = new NewsApprovedCommentBSO();

        DataTable table = newsApprovedCommentBSO.GetNewsApprovedCommentByNewsID(cId);


        lblComment.Text = table.Rows.Count.ToString();

        DataListProductComment.DataSource = table;
        DataListProductComment.DataBind();


    }

    #region ReceiveHtml
    protected NewsApprovedComment ReceiveHtml()
    {


        NewsApprovedComment newsApprovedComment = new NewsApprovedComment();
        newsApprovedComment.ApprovedCommentNewsID = 0;
        newsApprovedComment.NewsID = Convert.ToInt32(txtNewsGroupID.Value);
        newsApprovedComment.Content = txtContent.Text;
        newsApprovedComment.DateCreated = DateTime.Now;
        newsApprovedComment.Actived = true;
        newsApprovedComment.UserName = Session["Admin_UserName"].ToString();

        return newsApprovedComment;
    }
    #endregion

    protected void Send_Click(object sender, EventArgs e)
    {

        NewsApprovedComment newsApprovedComment = ReceiveHtml();
        if (txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
        {
            NewsApprovedCommentBSO newsApprovedCommentBSO = new NewsApprovedCommentBSO();
            newsApprovedCommentBSO.CreateNewsApprovedComment(newsApprovedComment);

            GetNewsCommentById(Convert.ToInt32(txtNewsGroupID.Value));

            //ConfigBSO configBSO = new ConfigBSO();
            //Config config = configBSO.GetAllConfig(Language.language);

            //string strBody = Resources.resource.T_ApprovedComment_email_title + config.WebName + " (" + config.WebDomain + ") : <br>";
            //strBody += "<b>" + Resources.resource.T_ApprovedComment_Title + ": </b> " + newsApprovedComment.Title + "<br>";
            //strBody += "<b>" + Resources.resource.T_ApprovedComment_Name + " : </b> " + newsApprovedComment.FullName + "<br>";

            //strBody += "<b>" + Resources.resource.T_ApprovedComment_Email + " : </b> " + newsApprovedComment.Email + "<br>";
            //strBody += "<b>" + Resources.resource.T_ApprovedComment_ID + " : </b> " + newsApprovedComment.NewsID + "<br>";
            //strBody += "<b>" + Resources.resource.T_ApprovedComment_Content + " : </b> <br>" + newsApprovedComment.Content + "<br>";

            //NewsGroupBSO newsBSO = new NewsGroupBSO();
            //NewsGroup news = newsBSO.GetNewsGroupById(newsApprovedComment.NewsID);

            //strBody += "<b>Title : </b>  <a href='" + config.WebDomain + "/d4/news/" + GetString(news.Title) + "-" + hddGroupCate.Value + "-" + newsApprovedComment.NewsID + ".aspx'>" + news.Title + "</a><br>";

            //MailBSO mailBSO = new MailBSO();
            //mailBSO.EmailFrom = newsApprovedComment.Email;


            //mailBSO.EmailFrom = config.Email_from;

            //string strObj = Resources.resource.T_ApprovedComment_email_title + config.WebName + " (" + config.WebDomain + ") - Date: " + DateTime.Now.ToString("dd:MM:yyyy");
            //mailBSO.SendMail(config.Email_to, strObj, strBody);



            //int Id = Convert.ToInt32(txtNewsGroupID.Value);
            //Response.Redirect("~/d5/news/" + GetString(news.Title) + "-" + hddGroupCate.Value + "-" + Id + "-2.aspx");
        }


    }
}
