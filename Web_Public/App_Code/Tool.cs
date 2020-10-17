using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Xml;
using System.Net;
using System.Net.Mail;
using System.Text;

using System.Collections.Generic;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Tool
/// </summary>
public class Tool : System.Web.UI.Page
{
    public Tool()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void BindYear(DropDownList ddlYear, string strFristName, string strFristValue)
    {
        for (int i = DateTime.Now.Year + 1; i >= 1999; i--)
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        ddlYear.Items.Insert(0, new ListItem("---" + strFristName + "---", strFristValue));
        //ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
    }
    public static void Message(object _Page, string strMessage)
    {
        //((Page)_Page).ClientScript.RegisterClientScriptBlock(_Page.GetType(), "Validate", "<script language = 'javascript'>alert('" + strMessage + "');</script>", true);
        ((Page)_Page).RegisterClientScriptBlock("Validate", "<script language = 'javascript'>alert('" + strMessage + "');</script>");

    }

    public static void MessageConfirm(object _Page, string strMessage)
    {
        //((Page)_Page).ClientScript.RegisterClientScriptBlock(_Page.GetType(), "Validate", "<script language = 'javascript'>alert('" + strMessage + "');</script>", true);
        ((Page)_Page).RegisterClientScriptBlock("Validate", "<script language = 'javascript'>confirm('" + strMessage + "');</script>");

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Page"></param>
    /// <param name="strMessage"></param>
    /// <param name="formReturn"></param>
    public static void MessageReturn(object _Page, string strMessage, string formReturn)
    {
        if (strMessage.Equals(""))
        {
            ((Page)_Page).RegisterClientScriptBlock("Validate", "<script language = 'javascript'>;document.location.href = '" + formReturn + "';</script>");

        }
        else
        {
            ((Page)_Page).RegisterClientScriptBlock("Validate", "<script language = 'javascript'>alert('" + strMessage + "');document.location.href = '" + formReturn + "';</script>");

        }

    }

    public static void confirm(string msg, string hiddenfield_name)
    {
        string sMsg = msg.Replace("\n", "\\n");
        sMsg = msg.Replace("\"", "'");

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<INPUT type=hidden value='0' name='" + hiddenfield_name + "'>");

        sb.Append(@"<script language='javascript'>");

        sb.Append(@" if(confirm('" + sMsg + @"'))");
        sb.Append(@" { ");
        sb.Append("document.forms[0]." + hiddenfield_name + ".value='1';"
          + "document.forms[0].submit(); }");
        sb.Append(@" else { ");
        sb.Append("document.forms[0]." + hiddenfield_name + ".value='0'; }");

        sb.Append(@"</script>");

        //     content = sb.ToString();
    }

    public static string ConvertDecimalToString(object dNumber)
    {
        IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);
        if (dNumber != DBNull.Value && dNumber != null && !String.IsNullOrEmpty(dNumber.ToString()))
        {
            //return Convert.ToDecimal(dNumber).ToString("G29");
            if (Convert.ToDecimal(dNumber) > 0)
                //return String.Format("{0,-15:N0}", Convert.ToDecimal(dNumber, culture));
                return Convert.ToDecimal(dNumber).ToString("G29", culture);
            return "0";
        }
        return "";
    }
    public static string ConvertDecimalToString(object dNumber, int part)
    {
        if (part < 0) part = 0;
        if (dNumber != DBNull.Value && dNumber != null && !String.IsNullOrEmpty(dNumber.ToString()))
        {
            string strNumberZero = "";
            for (int i = 0; i < part; i++)
                strNumberZero = strNumberZero + "0";
            if (strNumberZero != "") strNumberZero = "," + strNumberZero;
            //return Convert.ToDecimal(dNumber).ToString("G29");
            try
            {
                if (Convert.ToDecimal(dNumber) > 0)
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);
                    if (strNumberZero != "")
                        return String.Format(culture, "{0,-15:N" + part + "}", Convert.ToDecimal(dNumber)).Replace(strNumberZero, "");
                    else
                        return String.Format(culture, "{0,-15:N0}", Convert.ToDecimal(dNumber));

                }
            }
            catch { return dNumber.ToString(); }
            return "0";
        }
        return "";
    }
    //public static string FormatNumber(object dNumber)
    //{
    //    if (dNumber != DBNull.Value && dNumber != null && !String.IsNullOrEmpty(dNumber.ToString()))
    //    {
    //        string str = "";
    //        //return Convert.ToDecimal(dNumber).ToString("G29");
    //        decimal so=Convert.ToDecimal(dNumber);
    //        int du = 0;
    //        if (so > 0)
    //        {
    //            while (so >= 1000)
    //            {
    //                du = so % 1000;
    //                str = so + str;
    //            }
    //        }
    //    }
    //    return "";
    //}
    public static string GetCurrentDateTime(string culture)
    {
        string str = "";
        string str2 = DateTime.Now.DayOfWeek.ToString();
        if (culture == "vi-VN")
        {
            switch (str2)
            {
                case "Monday":
                    str2 = "Thứ hai";
                    break;

                case "Tuesday":
                    str2 = "Thứ ba";
                    break;

                case "Wednesday":
                    str2 = "Thứ tư";
                    break;

                case "Thursday":
                    str2 = "Thứ năm";
                    break;

                case "Friday":
                    str2 = "Thứ sáu";
                    break;

                case "Saturday":
                    str2 = "Thứ bảy";
                    break;

                case "Sunday":
                    str2 = "Chủ nhật";
                    break;
            }
        }
        return ((str + str2) + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }

    public string GetDayOfWeek(string strDayOfWeek, short iLanguage)
    {
        if (iLanguage == 1)
        {
            switch (strDayOfWeek)
            {
                case "Monday":
                    strDayOfWeek = "Thứ hai";
                    return strDayOfWeek;

                case "Tuesday":
                    strDayOfWeek = "Thứ ba";
                    return strDayOfWeek;

                case "Wednesday":
                    strDayOfWeek = "Thứ tư";
                    return strDayOfWeek;

                case "Thursday":
                    strDayOfWeek = "Thứ năm";
                    return strDayOfWeek;

                case "Friday":
                    strDayOfWeek = "Thứ sáu";
                    return strDayOfWeek;

                case "Saturday":
                    strDayOfWeek = "Thứ bảy";
                    return strDayOfWeek;

                case "Sunday":
                    strDayOfWeek = "Chủ nhật";
                    return strDayOfWeek;
            }
        }
        return strDayOfWeek;
    }




    public int IsInList(string strList, string strItem, char strSeparate)
    {
        if ((strList != null) && (strList != ""))
        {
            string[] strArray = strList.Split(new char[] { strSeparate });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] == strItem)
                {
                    return 1;
                }
            }
        }
        return 0;
    }



    public string ReplaceBadChar(string strSource)
    {
        string str = strSource;
        return str.Replace("'", "&#39;").Replace("\"", "&#34;");
    }

    public string RestoreBadChar(string strSource)
    {
        string str = strSource;
        return str.Replace("&#39;", "'").Replace("&#34;", "\"");
    }

    public static bool IsNumberDigit(string strInput)
    {
        return Regex.IsMatch(strInput, "^[0-9]+$", RegexOptions.Compiled);
    }


    //15-08-2008 Khanh 
    //public string GeneratePage(int iNumPageDisplay, int iTotalPage, int iCurrentPage, string strFirstPage, string strLastPage, params string[] hidPage)
    //{
    //    string str = "";
    //    //hdnCurrentpage=3;
    //    if (iTotalPage > 1)
    //    {
    //        if (iCurrentPage == 1)
    //        {
    //            str = "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + "1" + "," + iCurrentPage.ToString() + ")'> " + " </a>" + "<font color='red'><b><u>" + strFirstPage + "</u></b></font>";
    //        }
    //        else
    //        {
    //            str = "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + "1" + "," + iCurrentPage.ToString() + ")'> " + strFirstPage + " </a>";
    //        }
    //        if (iTotalPage > 10 && iCurrentPage > 1)
    //        {
    //            str += "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + "-1" + "," + iCurrentPage.ToString() + ")'> " + "<<" + " </a>";
    //        }
    //        string str2 = "";
    //        int num = 0;
    //        int num2 = 1;
    //        int num3 = iTotalPage;
    //        int _iPre;
    //        int _iNext;
    //        num = iNumPageDisplay / 2;
    //        //num = iNumPageDisplay;
    //        if ((iCurrentPage - 1) <= num)
    //        {
    //            num2 = 1;
    //            num3 = num + iCurrentPage - 1;
    //        }
    //        else if ((iCurrentPage - num) >= 1)
    //        {
    //            num2 = iCurrentPage - num;
    //        }
    //        if (num2 == 1)
    //        {
    //            num = iNumPageDisplay;
    //            if (num > iTotalPage)
    //            {
    //                num3 = iTotalPage;
    //            }
    //            else
    //            {
    //                num3 = num;
    //            }
    //        }
    //        else
    //        {
    //            if ((iCurrentPage + num) <= iTotalPage)
    //            {
    //                num3 = iCurrentPage + num;
    //            }
    //        }
    //        if (num2 < num3)
    //        {
    //            for (int i = num2 + 1; i <= num3 - 1; i++)
    //            {
    //                str2 = i.ToString();
    //                if (i == iTotalPage)
    //                {
    //                    str2 = strLastPage;
    //                }
    //                if (i == iCurrentPage)
    //                {
    //                    str2 = "<b><u>" + str2 + "</u></b>";
    //                }

    //                else
    //                {
    //                    if (hidPage != null && hidPage.Length > 0)
    //                    {
    //                        str2 = "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + i.ToString() + "," + "10" + ")'> " + str2 + " </a>";
    //                    }
    //                    else
    //                    {
    //                        str2 = "<a href='javascript:GotoPage(" + i.ToString() + ")'> " + str2 + " </a>";
    //                    }
    //                }
    //                str = str + str2;
    //            }
    //        }
    //        _iNext = iTotalPage - 1;
    //        if (iTotalPage > 10 && iCurrentPage < iTotalPage)
    //        {
    //            str += "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + "-2" + "," + iCurrentPage.ToString() + ")'> " + ">>" + " </a>";
    //        }
    //        string _strLastPage = strLastPage;
    //        if (iCurrentPage == iTotalPage)
    //        {
    //            str += "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + num3.ToString() + "," + iCurrentPage.ToString() + ")'> " + " </a>" + "<font color='red'><b><u>" + _strLastPage + "</u></b></font>";
    //        }
    //        else
    //        {
    //            str += "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + iTotalPage.ToString() + "," + iCurrentPage.ToString() + ")'> " + _strLastPage + " </a>";
    //        }
    //    }
    //    //str += "<a href='javascript:GotoPageMasterNext(\"" + hidPage[0] + "\", " + num3.ToString() + "," + iCurrentPage.ToString() + ")'> " + _strLastPage + " </a>";
    //    return str;
    //}


    //public ArrayList Record(long _iRecord)
    //{
    //    long Irecord = 0;
    //    long txt;
    //    int sochia;
    //    ArrayList arr = new ArrayList();
    //    if (_iRecord <= 100)
    //    {
    //        if (_iRecord % 10 == 0)
    //        {
    //            Irecord = _iRecord / 10;
    //        }
    //        else
    //        {
    //            Irecord = _iRecord / 10 + 1;
    //        }

    //        for (int i = 1; i <= Irecord; i++)
    //        {
    //            txt = i * 10;
    //            arr.Add(txt);
    //        }
    //    }
    //    else
    //    {
    //        if (_iRecord <= 500)
    //        {
    //            if (_iRecord % 10 == 0)
    //            {
    //                Irecord = _iRecord / 50;
    //            }
    //            else
    //            {
    //                Irecord = _iRecord / 50 + 1;
    //            }

    //            for (int i = 1; i <= Irecord; i++)
    //            {
    //                txt = i * 50;
    //                arr.Add(txt);
    //            }
    //        }
    //        else
    //        {
    //            if (_iRecord % 10 == 0)
    //            {
    //                Irecord = _iRecord / 100;
    //            }
    //            else
    //            {
    //                Irecord = _iRecord / 100 + 1;
    //            }

    //            for (int i = 1; i <= Irecord; i++)
    //            {
    //                txt = i * 100;
    //                arr.Add(txt);
    //            }
    //        }
    //    }
    //    return arr;

    //}
    //30-08-2008 khanh
    public int dateCompa(string date)
    {
        int day, month, year;
        try
        {
            day = int.Parse(date.Substring(0, 2));
            month = int.Parse(date.Substring(3, 2));
            year = int.Parse(date.Substring(6, 4));
        }
        catch
        {
            day = 0;
            month = 0;
            year = 0;
        }
        int ComparDate;
        if (month <= 12 && month > 0)
        {
            ComparDate = int.Parse(DateTime.DaysInMonth(year, month).ToString());

        }
        else
        {
            ComparDate = 14;
            day = 0;
        }

        if (day <= ComparDate && month <= 12 && day > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    //03-09-2008
    //public void CreateChild(ArrayList arrPrameter, DataSet dset, string rootNodeName, string Element, string foder, string fileName)
    //{
    //    XmlDocument xmlDoc = new XmlDocument();
    //    XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
    //    XmlElement rootNode = xmlDoc.CreateElement(rootNodeName);
    //    xmlDoc.InsertAfter(xmlDeclaration, xmlDoc.DocumentElement);
    //    xmlDoc.AppendChild(rootNode);
    //    for (int i = dset.Tables[0].Rows.Count - 1; i >= 0; i--)
    //    {
    //        XmlElement parentNode = xmlDoc.CreateElement(Element);
    //        parentNode.SetAttribute("ID", "" + dset.Tables[0].Rows[i][Element + "ID"]);
    //        xmlDoc.DocumentElement.PrependChild(parentNode);
    //        for (int j = 0; j < arrPrameter.Count; j++)
    //        {

    //            XmlElement Xmlobj = xmlDoc.CreateElement(arrPrameter[j].ToString());
    //            XmlText XmlobjText = xmlDoc.CreateTextNode("" + dset.Tables[0].Rows[i][arrPrameter[j].ToString()]);
    //            parentNode.AppendChild(Xmlobj);
    //            Xmlobj.AppendChild(XmlobjText);
    //        }
    //        xmlDoc.Save(Server.MapPath("../../Xml/" + foder + "/" + fileName + ".xml"));
    //    }
    //}

    //public int CheckFileExists(string strFileName)
    //{
    //    try
    //    {
    //        string[] strFileNames;
    //        int iCheck = 0;
    //        string strName;
    //        strFileNames = System.IO.Directory.GetFiles(Server.MapPath("~") + "\\Upload\\");
    //        int iLength = strFileNames.Length;
    //        for (int i = 0; i < iLength; i++)
    //        {
    //            strName = GetFileName(strFileNames[i]);
    //            if (strName.Trim() == strFileName.Trim())
    //                break;
    //            iCheck++;
    //        }
    //        if (iCheck == iLength)
    //            return 0;
    //    }
    //    catch (Exception ex)
    //    { }
    //    return 1;
    //}
    private string GetFileName(string strValue)
    {
        if (strValue != "")
        {
            string[] strArr;
            strArr = strValue.Split(new char[] { '\\' });
            return strArr[strArr.Length - 1];
        }
        return "";
    }

    public static string GetHostName()
    {
        if (HttpContext.Current.Request.Url.Port != 80)
        {
            return "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/";
        }
        else
        {
            return "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath + "/";
        }
    }
    public static string ddmmyyyy_to_mmddyyyy(string strValue)
    {
        if (strValue != "")
        {
            string[] strArray = strValue.Split(new char[] { '/' });
            string str = strArray[0];
            string str2 = strArray[1];
            string str3 = strArray[2];
            return (str2 + "/" + str + "/" + str3);
        }
        return "";
    }

    public static string GetFileType(string strFilePathServer, string strFilePath)
    {
        string returnValue = String.Empty;
        if (File.Exists(strFilePathServer))
        {
            FileInfo fileInfo = new FileInfo(strFilePathServer);
            string fileExtension = fileInfo.Extension;
            switch (fileExtension)
            {
                case ".swf":
                    returnValue = "<OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0";
                    returnValue += "align=\"center\" classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000>";//height=\"479\" width=\"729\"
                    returnValue += "<PARAM NAME=\"movie\" VALUE=\"" + strFilePath + "\"><PARAM NAME=\"quality\" VALUE=\"high\">";
                    returnValue += "<PARAM NAME=\"wmode\" VALUE=\"transparent\"> <embed src=\"" + strFilePath + "\" width=\"729\" height=\"479\"  align=\"center\" quality=\"high\"  pluginspage=\"http://www.macromedia.com/go/getflashplayer\"  type=\"application/x-shockwave-flash\"></embed></OBJECT>";
                    break;
                default:
                    returnValue = "<img src='" + strFilePath + "' border='0' alt='' />";
                    break;
            }
        }
        return returnValue;
    }

    public static string DisplayImage(string strImagePath, string strImageWidth, string strImageHeight)
    {
        string str5;
        string str = "";
        string str2 = "";
        string str3 = "";
        if (strImageWidth != "")
        {
            str2 = "width='" + strImageWidth + "'";
        }
        if (strImageHeight != "")
        {
            str3 = "height='" + strImageHeight + "'";
        }
        if (strImagePath.ToLower().EndsWith(".swf"))
        {
            str5 = str;
            str5 = ((str5 + "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' " + str2 + " " + str3 + ">") + "<param name='movie' value='" + strImagePath + "' />") + "<param name='quality' value='high' />";
            return ((str5 + "<embed src='" + strImagePath + "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' " + str2 + " " + str3 + "></embed>") + "</object>");
        }
        str5 = str;
        return (str5 + "<img src='" + strImagePath + "' " + str2 + " " + str3 + " border='0' />");
    }

    /// <summary>
    /// Adds an up- or down-arrow image to GridView header.
    /// </summary>
    /// <param name="grid">Gridview.</param>
    /// <param name="row">Header row of gridview.</param>
    public void AddGlyph(GridView grid, GridViewRow row, string sortColumn, string sortDirection)
    {
        // Find the column sorted on
        for (int i = 0; i < grid.Columns.Count; i++)
        {
            if (grid.Columns[i].SortExpression == sortColumn)
            {
                // Add a space between header and symbol
                Literal literal = new Literal();
                literal.Text = "&nbsp;";
                row.Cells[i].Controls.Add(literal);

                Image image = new Image();
                image.ImageUrl = (sortDirection == "ASC" ?
                  ResolveUrl("~/") + "App_Themes/Default/Images/DownArr.gif" :
                  ResolveUrl("~/") + "App_Themes/Default/Images/UpArr.gif");
                image.Width = 10;
                image.Height = 8;

                row.Cells[i].Controls.Add(image);

                return;
            }
        }
    }

    public bool CheckExistUrl(string strUrl)
    {
        WebRequest serverRequest = WebRequest.Create(strUrl);
        WebResponse serverResponse;
        bool checkResult = true;
        try //Try to get response from server 
        {
            serverResponse = serverRequest.GetResponse();
        }
        catch //If could not obtain any response 
        {
            checkResult = false;
        }
        return checkResult;
    }

    //public static string GetCategoryLink(string link, string categoryId, string culture, Page page)
    //{
    //    string strReturn = string.Empty;
    //    strReturn = page.ResolveUrl("~/") + "News/Category/" + categoryId + "/" + culture + "";

    //    if (!string.IsNullOrEmpty(link))
    //    {
    //        strReturn = page.ResolveUrl("~/") + link + "/" + categoryId + "/" + culture + "";
    //    }
    //    if (!string.IsNullOrEmpty(link) && link.Contains("http://"))
    //    {
    //        strReturn = link;
    //    }

    //    return strReturn;
    //}

    /// <summary>
    /// Gui email
    /// </summary>
    /// <param name="fromAddress">From address</param>
    /// <param name="toAddress">To address</param>
    /// <param name="subject">Subject of email</param>
    /// <param name="body">Body of email</param>
    /// <param name="smtpServer">SmtpServer</param>
    /// <param name="smtpPort">SmtpPort</param>
    /// <param name="userName">Username</param>
    /// <param name="pass">Password</param>
    /// <param name="enableSsl">Enable or disable SSL</param>
    /// <param name="displayName">Display name</param>
    /// System.Configuration.ConfigurationManager.AppSettings["smtpServer"].ToString();
    //public bool SendMail(string toAddress, string cc, string subject, string body)//, string smtpServer, int smtpPort, string userName, string pass, bool enableSsl
    //{
    //    bool checkOk = true;
    //    MailMessage message = new MailMessage();
    //    message.IsBodyHtml = true;
    //    string fromAddress = System.Configuration.ConfigurationManager.AppSettings["fromAddress"].ToString();
    //    string displayName= System.Configuration.ConfigurationManager.AppSettings["displayName"].ToString();
    //    message.From = new MailAddress(fromAddress, displayName);
    //    message.Subject = subject;
    //    message.SubjectEncoding = Encoding.UTF8;
    //    message.Body = body;


    //    //message.Attachments.Add(new Attachment());
    //    foreach (string s in toAddress.Split(';'))
    //        message.To.Add(new MailAddress(s));
    //    if (cc.Trim() != "")
    //    {
    //        foreach (string s in cc.Split(';'))
    //            message.CC.Add(new MailAddress(s));
    //    }
    //    message.BodyEncoding = Encoding.UTF8;

    //    //Read from Web.config.xml
    //    string smtpServer = System.Configuration.ConfigurationManager.AppSettings["smtpServer"].ToString();
    //    int smtpPort = 25;
    //    string userName = "";
    //    string pass = "";
    //    bool enableSsl = false;

    //    SmtpClient smtp = new SmtpClient(smtpServer);
    //    smtp.Credentials = new System.Net.NetworkCredential(userName, pass);
    //    smtp.EnableSsl = enableSsl;
    //    try
    //    {
    //        smtp.Send(message);
    //    }
    //    catch (Exception ex)
    //    {
    //        checkOk = false;
    //    }
    //    return checkOk;
    //}

    //public bool SendMail(string _fromEmail,string toAddress, string cc, string subject, string body)//, string smtpServer, int smtpPort, string userName, string pass, bool enableSsl
    //{
    //    bool checkOk = true;
    //    MailMessage message = new MailMessage();
    //    message.IsBodyHtml = true;
    //    string fromAddress = _fromEmail;
    //    string displayName = System.Configuration.ConfigurationManager.AppSettings["displayName"].ToString();
    //    message.From = new MailAddress(fromAddress, displayName);
    //    message.Subject = subject;
    //    message.SubjectEncoding = Encoding.UTF8;
    //    message.Body = body;


    //    //message.Attachments.Add(new Attachment());
    //    foreach (string s in toAddress.Split(';'))
    //        message.To.Add(new MailAddress(s));
    //    if (cc.Trim() != "")
    //    {
    //        foreach (string s in cc.Split(';'))
    //            message.CC.Add(new MailAddress(s));
    //    }
    //    message.BodyEncoding = Encoding.UTF8;

    //    //Read from Web.config.xml
    //    string smtpServer = System.Configuration.ConfigurationManager.AppSettings["smtpServer"].ToString();
    //    int smtpPort = 25;
    //    string userName = "";
    //    string pass = "";
    //    bool enableSsl = false;

    //    SmtpClient smtp = new SmtpClient(smtpServer);
    //    smtp.Credentials = new System.Net.NetworkCredential(userName, pass);
    //    smtp.EnableSsl = enableSsl;
    //    try
    //    {
    //        smtp.Send(message);
    //    }
    //    catch (Exception ex)
    //    {
    //        checkOk = false;
    //    }
    //    return checkOk;
    //}

    public static string ReplaceHackCode(string strSource)
    {
        string str = strSource;
        if (!string.IsNullOrEmpty(str))
        {
            return str.Replace("'", "&#39;").Replace("\"", "&#34;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
        else return str;
    }

    public static string GetStringStandard(string strContent)
    {
        return strContent.Replace("" + (char)13, "<br />");
    }

    /// <summary>
    /// Code to upload file to FTP Server
    /// </summary>
    /// <param name="strFilePath">Complete physical path of the file to be uploaded</param>
    /// <param name="strFTPPath">FTP Path</param>
    /// <param name="strUserName">FTP User account name</param>
    /// <param name="strPassword">FTP User password</param>
    /// <returns>Boolean value based on result</returns>
    //public static string UploadToFTP(string strFilePath, string strFTPPath, string strUserName, string strPassword)
    //{
    //    string returnValue = "";
    //    try
    //    {
    //        //Create a FTP Request Object and Specfiy a Complete Path
    //        string strFileName = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1);
    //        FtpWebRequest reqObj = (FtpWebRequest)WebRequest.Create(strFTPPath + @"/" + strFileName);
    //        //Call A FileUpload Method of FTP Request Object
    //        reqObj.Method = WebRequestMethods.Ftp.UploadFile;
    //        //If you want to access Resourse Protected You need to give User Name and PWD
    //        reqObj.Credentials = new NetworkCredential(strUserName, strPassword);
    //        // Copy the contents of the file to the request stream.
    //        StreamReader sourceStream = new StreamReader(strFilePath);
    //        byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
    //        sourceStream.Close();
    //        reqObj.ContentLength = fileContents.Length;
    //        Stream requestStream = reqObj.GetRequestStream();
    //        requestStream.Write(fileContents, 0, fileContents.Length);
    //        requestStream.Close();
    //        FtpWebResponse response = (FtpWebResponse)reqObj.GetResponse();
    //        response.Close();
    //        returnValue = strFileName;
    //    }
    //    catch
    //    {       // report error
    //    }
    //    return returnValue;
    //}

    //public static string UpLoadImage(HtmlInputFile File1, string strServerPath)
    //{
    //    string returnValue = "";
    //    if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
    //    {
    //        string fileName = Path.GetFileName(File1.PostedFile.FileName);
    //        string filename = strServerPath + @"\" + fileName;
    //        try
    //        {
    //            File1.PostedFile.SaveAs(filename);
    //            returnValue = fileName;
    //        }
    //        catch
    //        {
    //        }
    //    }
    //    return returnValue;
    //}


    /// <summary>
    /// Disable_s the enable_ control.
    /// </summary>
    /// <param name="controlName">Name of the control.</param>
    /// <param name="status">if set to <c>true</c> [status].</param>
    //public static void Disable_Enable_Control(Control controlName, bool status)
    //{
    //    if (controlName != null)
    //    {
    //        controlName.Visible = status;
    //    }
    //}
    //public static readonly SHA1CryptoServiceProvider PWD_CRYPTO = new SHA1CryptoServiceProvider();
    //public static string HashPassword(string password)
    //{
    //    if (password == null) throw new ArgumentNullException("password");

    //    byte[] encryptedBytes = PWD_CRYPTO.ComputeHash(Encoding.UTF8.GetBytes(password));

    //    StringBuilder sb = new StringBuilder();
    //    foreach (byte b in encryptedBytes) sb.AppendFormat("{0:x2}", b);

    //    return sb.ToString();
    //}

    //public static string EncodeToSHA1(string value)
    //{
    //    UnicodeEncoding uEncode = new UnicodeEncoding();
    //    byte[] byteValue = uEncode.GetBytes(value);
    //    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
    //    byte[] hash = sha1.ComputeHash(byteValue);
    //    return BitConverter.ToString(hash);
    //}

    public static string safeString(string unSafe)
    {
        return removeStr(unSafe, Bad_String);
    }

    private static string removeStr(string strRaw, string[] badStr)
    {
        if (string.IsNullOrEmpty(strRaw)) return "";
        int i;
        string tmp = strRaw.ToLower();
        foreach (string remove in badStr)
        {
            i = tmp.IndexOf(remove);
            if (i > -1)
            {
                int n = tmp.Length;
                if (n > 1)
                {
                    int j = tmp.IndexOfAny(new char[] { ';', '-', ' ' }, i);
                    if (j - i > n) n = j - i;
                }
                tmp = tmp.Remove(i, n);
                strRaw = strRaw.Remove(i, n);
            }
        }
        return strRaw.Trim();
    }

    private static string[] Bad_String = { "'", "\\", "<", ">", "--", "select", "insert", "update", "delete", "drop", "exec", "sp_", "xp_", "html" };

    public static string getType_Date(string txtDate)
    {
        string sDate = txtDate.Trim().Replace("/", "");
        return sDate;
    }

    public static string SubString(string sSource, int length)
    {
        if (string.IsNullOrEmpty(sSource))
            return string.Empty;
        if (sSource.Length <= length)
            return sSource;

        string mSource = sSource;
        int nLength = length;

        int m = mSource.Length;
        while (nLength > 0 && mSource[nLength].ToString() != " ")
        {
            nLength--;
        }
        mSource = mSource.Substring(0, nLength);
        return mSource + "...";
    }

    public static string StripTagsCharArray(string source)
    {
        if (source != null)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
        else
            return "";
    }

    public static int CountWords1(string s)
    {
        MatchCollection collection = Regex.Matches(s, @"[\S]+");
        return collection.Count;
    }

    /// <summary>
    /// Count word with loop and character tests.
    /// </summary>
    public static int CountWords2(string s)
    {
        int c = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (char.IsWhiteSpace(s[i - 1]) == true)
            {
                if (char.IsLetterOrDigit(s[i]) == true ||
                    char.IsPunctuation(s[i]))
                {
                    c++;
                }
            }
        }
        if (s.Length > 2)
        {
            c++;
        }
        return c;
    }

    public static string GetCurrentDateTimeDay(string culture)
    {
        string str = "";
        string str2 = DateTime.Now.DayOfWeek.ToString();
        if (culture == "vi-VN")
        {
            switch (str2)
            {
                case "Monday":
                    str2 = "Thứ hai";
                    break;

                case "Tuesday":
                    str2 = "Thứ ba";
                    break;

                case "Wednesday":
                    str2 = "Thứ tư";
                    break;

                case "Thursday":
                    str2 = "Thứ năm";
                    break;

                case "Friday":
                    str2 = "Thứ sáu";
                    break;

                case "Saturday":
                    str2 = "Thứ bảy";
                    break;

                case "Sunday":
                    str2 = "Chủ nhật";
                    break;
            }
        }
        return ((str + str2) + ", " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
    }
    public static string TrangThaiGui(int SendStatus, bool blApproved)
    {
        string str2 = "";
        if (!blApproved)
        {
            switch (SendStatus)
            {
                case 0:
                    str2 = "Đang soạn thảo";
                    break;

                case 1:
                    str2 = "Đã chuyển báo cáo SCT";
                    break;

                case 2:
                    str2 = "Đang duyệt";
                    break;
                case 3:
                    str2 = "Bổ sung, hiệu chỉnh báo cáo";
                    break;
                case 4:
                    str2 = "Đã bổ sung, hiệu chỉnh";
                    break;
                case 5:
                    str2 = "Hoàn thành báo cáo";
                    break;
            }
            return str2;
        }
        else
            return "Hoàn thành báo cáo";
    }
    public static string TrangThaiKToan(int SendStatus)
    {
        string str2 = "";

        switch (SendStatus)
        {
            case 0:
                str2 = "Đang soạn thảo";
                break;

            case 1:
                str2 = "Đã gửi báo cáo";
                break;

            case 2:
                str2 = "Đang soạn thảo";
                break;
            case 3:
                str2 = "Đã xác nhận";
                break;
        }
        return str2;

    }

    public static string TrangThaiBaoCao(int Status)
    {
        string str2 = "";

        switch (Status)
        {
            case 0:
                str2 = "Đang soạn thảo";
                break;
            case 1:
                str2 = "Đã chuyển báo cáo SCT";
                break;
            case 2:
                str2 = "Đang duyệt";
                break;
            case 3:
                str2 = "Đã phê duyệt";
                break;
            case 4:
                str2 = "Đang bổ sung, hiệu chỉnh";
                break;
            case 5:
                str2 = "Đã bổ sung, hiệu chỉnh";
                break;
        }
        return str2;

    }

}