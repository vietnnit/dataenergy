using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BSO;
using ePower.DE.Domain;
using ePower.DE.Service;
using System.Web.UI;
using ReportEF;

public partial class Client_Modules_DataEnergy_Product5YearCommon : System.Web.UI.UserControl
{
    MemberValidation memVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportModels rp = new ReportModels();
        var en = rp.DE_Enterprise.FirstOrDefault(o => o.Id == memVal.OrgId);
        var data = (from a in rp.DE_Enterprise
                    join b in rp.DE_BaocaoLinhVuc on a.ReportTemplate equals b.AutoId
                    where a.Id == memVal.OrgId 
                    select b).FirstOrDefault();

        var loadTemp = rp.DE_BaocaoLinhVuc.FirstOrDefault(x => x.PhanLoaiBC == ReportKey.PLAN5 && x.IdLinhVuc == data.IdLinhVuc);
        if (loadTemp != null)
        {
            string ctName = loadTemp.TenControl;
            Control ct = LoadControl(ctName);
            productYearContainer.Controls.Add(ct);
        }
    }
}