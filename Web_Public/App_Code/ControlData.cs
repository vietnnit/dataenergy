using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ControlData
/// </summary>
public class ControlData
{
    public ControlData()
    {
      
    }
    #region "Private Members"
    string _Control = "";
    string _Text = "";
    #endregion
    public string Control
    {
        get { return _Control; }
        set { _Control = value; }
    }
    public string Text
    {
        get { return _Text; }
        set { _Text = value; }
    }
}
