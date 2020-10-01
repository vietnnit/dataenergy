using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePower.DE.Domain;
using ePower.DE.Service;


public partial class Client_Modules_DataEnergy_ListSolution : System.Web.UI.UserControl
{
    MemberValidation m_UserValidation = new MemberValidation();
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)
                return Convert.ToInt32(ViewState["CurrentPage"].ToString());
            else
                return 1;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    private int PageSize
    {
        get
        {
            if (ViewState["PageSize"] != null)
                return Convert.ToInt32(ViewState["PageSize"].ToString());
            else
                return 20;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }

    }

    private void BindData()
    {
        GiaiPhapService comBSO = new GiaiPhapService();
        DataTable list = new DataTable();
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        string strKey = string.Empty;
        if (txtKeyword.Text != "" && txtKeyword.Text.Trim() != "")
        {
            strKey = txtKeyword.Text.Trim();
        }
        if (m_UserValidation != null && m_UserValidation.OrgId > 0)
        {
            list = comBSO.FindList(m_UserValidation.OrgId, strKey, paging);
            if (list != null && list.Rows.Count > 0)
            {
                paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
                Paging.PageSize = PageSize;
                Paging.CurrentPage = CurrentPage;
                Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
                Paging.DataLoad();
                if (paging.PagesCount <= 1)
                {
                    ltrTotal.Text = "Tổng số " + paging.RowsCount + " giải pháp";
                    Paging.Visible = false;
                }
                else
                {
                    int st = (CurrentPage - 1) * PageSize + 1;
                    long end = CurrentPage * PageSize;
                    if (end > paging.RowsCount)
                        end = paging.RowsCount;
                    ltrTotal.Text = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " giải pháp";
                    Paging.Visible = true;
                }
            }
            else
            {
                ltrTotal.Text = "";
                Paging.Visible = false;
            }
            rptSolution.DataSource = list;
            rptSolution.DataBind();
        }
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        int eid = 0;
        if (btnDelete.CommandArgument != "")
        {
            eid = Convert.ToInt32(btnDelete.CommandArgument);
            if (eid > 0)
            {
                GiaiPhap gp = new GiaiPhapService().FindByKey(eid);
                if (m_UserValidation != null && m_UserValidation.OrgId > 0)
                {
                    if (gp != null && gp.EnterpriseId == m_UserValidation.OrgId)
                    {
                        gp.IsDelete = true;
                        if (new GiaiPhapService().Update(gp) != null)
                            BindData();
                        else
                            ScriptManager.RegisterStartupScript(this, GetType(), "showform", "alert('Chưa xóa được giải pháp này. Vui lòng thử lại');", true);
                    }
                }
            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton btnEdit = (LinkButton)sender;
        int eid = 0;
        if (m_UserValidation != null && m_UserValidation.OrgId > 0)
        {
            if (btnEdit.CommandArgument != "")
            {
                eid = Convert.ToInt32(btnEdit.CommandArgument);
                if (eid > 0)
                {
                    GiaiPhap gp = new GiaiPhapService().FindByKey(eid);
                    if (gp != null && gp.EnterpriseId == m_UserValidation.OrgId)
                    {
                        txtnamegp.Text = gp.TenGiaiPhap;
                        txtmotagp.Text = gp.MoTa;
                        hdnSolutionId.Value = btnEdit.CommandArgument;
                        ScriptManager.RegisterStartupScript(this, GetType(), "ac", "updategiaiphap();", true);
                    }
                }
            }
        }
    }

    public void btnSaveSolution_Click(object sender, EventArgs e)
    {
        int eid = 0;
        if (hdnSolutionId.Value != "0")
        {

            eid = Convert.ToInt32(hdnSolutionId.Value);
        }
        GiaiPhap gp = new GiaiPhap();
        GiaiPhapService gpser = new GiaiPhapService();
        if (eid > 0)
        {
            if (txtnamegp.Text != "")
            {
                gp.EnterpriseId = m_UserValidation.OrgId;
                gp.Id = eid;
                gp.MoTa = txtmotagp.Text;
                gp.TenGiaiPhap = txtnamegp.Text;
                if (gpser.Update(gp) != null)
                {
                    ltNoticeSolution.Text = "<div class='alert alert-info'>Cập nhật thành công !</div>";
                    BindData();
                }
                else
                    ltNoticeSolution.Text = "<div class='alert alert-danger'>Không lưu được giải pháp mới. Vui lòng thử lại</div>";
            }
        }
        else
        {
            gp.EnterpriseId = m_UserValidation.OrgId;
            if (txtnamegp.Text != "")
            {
                gp.MoTa = txtmotagp.Text;
                gp.TenGiaiPhap = txtnamegp.Text;
                gp.IsDelete = false;
                if (gpser.Insert(gp) > 0)
                {
                    ltNoticeSolution.Text = "<div class='alert alert-info'>Đã thêm giải pháp mới thành công</div>";
                    BindData();
                }
                else
                    ltNoticeSolution.Text = "<div class='alert alert-danger'>Không lưu được giải pháp mới. Vui lòng thử lại</div>";
            }
        }
    }
}
