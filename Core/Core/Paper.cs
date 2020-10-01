using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
namespace ePower.Core.Utils
{
    public class Paper
    {
        public Paper()
        {
        }
        public static DataTable MakeDataPaper11(int totalPages, int currPages, int recordPerPages)
        {
            DataTable dtRet = new DataTable("DataPaper");
            dtRet.Columns.Add("ID", typeof(string));
            dtRet.Columns.Add("CssClass", typeof(string));
            dtRet.Columns.Add("Text", typeof(string));
            dtRet.Columns.Add("Page", typeof(int));
            dtRet.Columns.Add("Type", typeof(int));
            if (totalPages > 1)
            {
                int ranges = currPages / recordPerPages;
                if (currPages % recordPerPages > 0)
                    ranges += 1;
                int start = recordPerPages * (ranges - 1) + 1;
                int end = start + recordPerPages;
                if (end > totalPages)
                    end = totalPages + 1;
                DataRow dr = null;
                if (currPages > 1)
                {
                    if (start > 1)
                    {
                        int s_page = start - 1;
                        int p_page = s_page;
                        //Trang dau tien
                        dr = dtRet.NewRow();
                        dr["ID"] = "first";
                        dr["CssClass"] = "pager_navi";
                        //dr["Text"] = "Đầu";
                        dr["Text"] = "";
                        dr["Page"] = "1";
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                        //Quay lai
                        dr = dtRet.NewRow();
                        dr["ID"] = "back";
                        dr["CssClass"] = "pager_navi";
                        dr["Text"] = "<img src='images/left_arrow.gif' border='0' />"; //"Trước";
                        dr["Page"] = p_page.ToString();// (currPages - 10).ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                }
                //
                for (int i = start; i < end; i++)
                {
                    if (i == currPages)
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "pager-current";
                        dr["Text"] = "<b style='color:red;'>" + i.ToString() + "</b>";
                        dr["Page"] = i.ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "pager";
                        dr["Text"] = i.ToString();
                        dr["Page"] = i.ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                }
                if (currPages < totalPages)
                {
                    int lastpage = start + 10;
                    if (lastpage - 1 < totalPages)
                    {
                        int s_page = start + 10;
                        int n_page = s_page;
                        //Trang tiep theo
                        dr = dtRet.NewRow();
                        dr["ID"] = "next";
                        dr["CssClass"] = "pager_navi";
                        dr["Text"] = "<img src='images/right_arrow.gif' border='0' />";//"Tiếp";
                        dr["Page"] = n_page.ToString();// (currPages + 10).ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                        //Trang cuoi cung
                        dr = dtRet.NewRow();
                        dr["ID"] = "last";
                        dr["CssClass"] = "pager_navi";
                        //dr["Text"] = "Cuối";
                        dr["Text"] = "";
                        dr["Page"] = totalPages.ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                }
                dtRet.AcceptChanges();
            }
            return dtRet;
        }
        public static DataTable MakeDataPaper(long totalPages, long currPages, long recordPerPages, int displayNumberPage)
        {
            displayNumberPage = 4;
            DataTable dtRet = new DataTable("DataPaper");
            dtRet.Columns.Add("ID", typeof(string));
            dtRet.Columns.Add("CssClass", typeof(string));
            dtRet.Columns.Add("Text", typeof(string));
            dtRet.Columns.Add("Page", typeof(int));
            dtRet.Columns.Add("Type", typeof(int));
            if (totalPages > 1)
            {
                //int ranges = currPages / recordPerPages;
                //if (currPages % recordPerPages > 0)
                //    ranges += 1;
                //int start = recordPerPages * (ranges - 1) + 1;
                //int end = start + recordPerPages;
                ////if (displayNumberPage >= totalPages)
                ////{
                ////    start = 2;
                ////    end = totalPages;
                ////}
                //if (end > totalPages)
                //    end = totalPages + 1;

                int iright = displayNumberPage / 2;
                int ileft = displayNumberPage / 2;
                //int ranges = currPages / displayNumberPage;
                //if (currPages % displayNumberPage > 0)
                //    ranges += 1;
                if (displayNumberPage % 2 == 0)
                    iright -= 1;
                long start = currPages - ileft;
                long end = currPages + iright + 1;

                if (start <= 0)
                {
                    start = 1; end = displayNumberPage + 1;
                }
                if (end > totalPages + 1)
                {
                    end = totalPages + 1;
                    start = end - displayNumberPage;
                    if (start <= 0) start = 1;
                }

                DataRow dr = null;
                if (currPages > 1)
                {
                    //Trang dau tien
                    dr = dtRet.NewRow();
                    dr["ID"] = "first";
                    dr["CssClass"] = "pagination_first";
                    dr["Text"] = "Trang đầu";
                    dr["Page"] = "1";
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                    //Quay lai
                    dr = dtRet.NewRow();
                    dr["ID"] = "back";
                    dr["CssClass"] = "pagination_previous";
                    dr["Text"] = "<";
                    dr["Page"] = (currPages - 1).ToString();
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                }
                //
                for (long i = start; i < end; i++)
                {
                    if (i == currPages)
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "pagination_current";
                        dr["Text"] = i.ToString();
                        dr["Page"] = i.ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "";
                        dr["Text"] = i.ToString();
                        dr["Page"] = i.ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                }
                if (currPages < totalPages)
                {
                    //Trang tiep theo
                    dr = dtRet.NewRow();
                    dr["ID"] = "next";
                    dr["CssClass"] = "pagination_next";
                    dr["Text"] = ">";
                    dr["Page"] = (currPages + 1).ToString();
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                    //Trang cuoi cung
                    dr = dtRet.NewRow();
                    dr["ID"] = "last";
                    dr["CssClass"] = "pagination_last";
                    dr["Text"] = "Trang cuối";
                    dr["Page"] = totalPages.ToString();
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                }
                dtRet.AcceptChanges();
            }
            return dtRet;
        }
        /*public static DataTable MakeDataPaper(int totalPages, int currPages, int recordPerPages)
        {
            DataTable dtRet = new DataTable("DataPaper");
            dtRet.Columns.Add("ID", typeof(string));
            dtRet.Columns.Add("CssClass", typeof(string));
            dtRet.Columns.Add("Text", typeof(string));
            dtRet.Columns.Add("Page", typeof(int));
            dtRet.Columns.Add("Type", typeof(int));
            if (totalPages > 1)
            {
                int ranges = currPages / recordPerPages;
                if (currPages % recordPerPages > 0)
                    ranges += 1;
                int start = recordPerPages * (ranges - 1) + 1;
                int end = start + recordPerPages;
                if (end > totalPages)
                    end = totalPages + 1;
                DataRow dr = null;
                if (currPages > 1)
                {
                    //Trang dau tien
                    dr = dtRet.NewRow();
                    dr["ID"] = "first";
                    dr["CssClass"] = "pager";
                    dr["Text"] = "trangdau.gif";
                    dr["Page"] = "1";
                    dr["Type"] = 1;
                    dtRet.Rows.Add(dr);
                    //Quay lai
                    dr = dtRet.NewRow();
                    dr["ID"] = "back";
                    dr["CssClass"] = "pager";
                    dr["Text"] = "trangtruoc.gif";
                    dr["Page"] = (currPages - 1).ToString();
                    dr["Type"] = 1;
                    dtRet.Rows.Add(dr);
                }
                //
                for (int i = start; i < end; i++)
                {
                    if (i == currPages)
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "pager-current";
                        dr["Text"] = i.ToString();
                        dr["Page"] = i.ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "pager";
                        dr["Text"] = i.ToString();
                        dr["Page"] = i.ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                }
                if (currPages < totalPages)
                {
                    //Trang tiep theo
                    dr = dtRet.NewRow();
                    dr["ID"] = "next";
                    dr["CssClass"] = "pager";
                    dr["Text"] = "trangsau.gif";
                    dr["Page"] = (currPages + 1).ToString();
                    dr["Type"] = 1;
                    dtRet.Rows.Add(dr);
                    //Trang cuoi cung
                    dr = dtRet.NewRow();
                    dr["ID"] = "last";
                    dr["CssClass"] = "pager";
                    dr["Text"] = "trangcuoi.gif";
                    dr["Page"] = totalPages.ToString();
                    dr["Type"] = 1;
                    dtRet.Rows.Add(dr);
                }
                dtRet.AcceptChanges();
            }
            return dtRet;
        }*/
        public static DataTable MakeDataPaper1(int totalPages, int currPages, int recordPerPages)
        {
            DataTable dtRet = new DataTable("DataPaper");
            dtRet.Columns.Add("ID", typeof(string));
            dtRet.Columns.Add("CssClass", typeof(string));
            dtRet.Columns.Add("Text", typeof(string));
            dtRet.Columns.Add("Page", typeof(int));
            dtRet.Columns.Add("Type", typeof(int));
            if (totalPages > 1)
            {
                int ranges = currPages / recordPerPages;
                if (currPages % recordPerPages > 0)
                    ranges += 1;
                int start = recordPerPages * (ranges - 1) + 1;
                int end = start + recordPerPages;
                if (end > totalPages)
                    end = totalPages + 1;
                DataRow dr = null;

                for (int i = start - 1; i < end - 1; i++)
                {
                    if (i == currPages)
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "pager-current";
                        dr["Text"] = (i + 1).ToString();
                        dr["Page"] = (i).ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dtRet.NewRow();
                        dr["ID"] = i.ToString();
                        dr["CssClass"] = "pager";
                        dr["Text"] = (i + 1).ToString();
                        dr["Page"] = (i).ToString();
                        dr["Type"] = 0;
                        dtRet.Rows.Add(dr);
                    }
                }

                dtRet.AcceptChanges();
            }
            return dtRet;
        }
    }

}
