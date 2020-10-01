using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;
/// <summary>
/// Summary description for HitCounter
/// </summary>
public class WebHitCounter
{
    public WebHitCounter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void UpdateHitCounter(long hitcouter)
    {
        HitCounterBSO hitcounterBSO = new HitCounterBSO();
        hitcounterBSO.UpdateHitCounter(hitcouter);
    }

    public long GetHitCounter()
    {
        HitCounterBSO hitcounterBSO = new HitCounterBSO();
        return hitcounterBSO.GetHitCounter();
    }
}