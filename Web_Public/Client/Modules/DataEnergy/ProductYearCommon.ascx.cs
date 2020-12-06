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

public partial class Client_Modules_DataEnergy_ProductYearCommon : System.Web.UI.UserControl
{
    MemberValidation memVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportModels rp = new ReportModels();
        var en = rp.DE_Enterprise.FirstOrDefault(o => o.Id == memVal.OrgId);
        var are = rp.DE_Area.FirstOrDefault(x => x.Id == en.SubAreaId);

        if (are != null)
        {
            var temp = rp.DE_BaocaoLinhVuc.FirstOrDefault(x => x.TenMauBC.ToUpper() == are.Mau1x.ToUpper() && x.PhanLoaiBC == ReportKey.PLAN);
            if (temp != null)
            {
                string ctName = temp.TenControl;
                Control ct = LoadControl(ctName);
                productYearContainer.Controls.Add(ct);
            }
        }
        else
            throw new Exception("Chưa chọn mẫu báo cáo");
    }
}