using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


/// <summary>
/// The class stores all global variables for the application.
/// </summary>
public class Variables
{

    public static string sThumbImage = ConfigurationManager.AppSettings.Get("sThumbImage");
    public static string sWebRoot = ConfigurationManager.AppSettings.Get("sWebRoot");
    //public static string sWebMenu = ConfigurationSettings.AppSettings["sWebMenu"];
    //public static string sWapRoot = ConfigurationSettings.AppSettings["sWapRoot"];
    //public static string sWebReport = ConfigurationSettings.AppSettings["sWebReport"];
    //public static string sWebImageRoot = ConfigurationSettings.AppSettings["ImagePathRoot"];
    //public static string sWebImage = ConfigurationSettings.AppSettings["ImageDBPath"];
    //public static string sWebVideo = ConfigurationSettings.AppSettings["VideoDBPath"];
    //public static string sWebAudio = ConfigurationSettings.AppSettings["AudioDBPath"];
    //public static string sLinkToBanner = ConfigurationSettings.AppSettings["LinkToBanner"];

    //public static string uRL_NEW = ConfigurationSettings.AppSettings["URL_NEW"];
    //public static string sPhotoUploadImage = ConfigurationSettings.AppSettings["PhotoUploadImage"];
    //public static string sAvatarImage = ConfigurationSettings.AppSettings["AvatarImage"];
    //public static string sLinkUserProfile = ConfigurationSettings.AppSettings["linkuserprofile"];//link show image

    ////public static string sAlbumImage = ConfigurationSettings.AppSettings["AlbumImagePath"];

    //public static string sFLVPlayer = ConfigurationSettings.AppSettings["FLVPlayer"];//link show image
    //public static string sVideoDBPathVIEW = ConfigurationSettings.AppSettings["VideoDBPathVIEW"];
    public static string sDomain = ConfigurationManager.AppSettings.Get("sDomain");
}

public enum LogType
{
    AUDITREPORT = 0,
    ANNUALREPORT = 1
}
public enum AuditReportStatus
{
    PROPOSE = 0,
    SENT = 1,       
    EDIT = 2,
    CONFIRMED = 3
}