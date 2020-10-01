using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DAO;

namespace BSO
{
    public class commonBSO
    {
        public commonBSO() 
        {
            //contrustor
        }
        #region FillToDropDown
        public void FillToDropDown(
            DropDownList dropDownList,
            DataTable dataTable,
            string firstDisplayMember,
            string firstValueMember,
            string displayMember,
            string valueMember,
            string selectedIndex) 
            {
                if (firstDisplayMember != "" && firstValueMember != "")
                {
                    dropDownList.Items.Add(new ListItem(firstDisplayMember, firstValueMember));
                }
                dropDownList.DataSource = dataTable;
                dropDownList.DataTextField = displayMember;
                dropDownList.DataValueField = valueMember;
                dropDownList.DataBind();
                if (selectedIndex != "") 
                {
                    try 
                    { 
                        dropDownList.SelectedValue = selectedIndex;
                    }
                    catch(Exception ex)
                    {
                        throw new BusinessException(ex.Message.ToString());
                    }
                    
                }
            }
        #endregion

        #region FillToGridView
        public void FillToGridView(GridView gridview , DataTable datatable) 
        {
            if (datatable != null)
                gridview.DataSource = datatable;
            else 
                gridview.DataSource = null;
            gridview.DataBind();
        }
        #endregion

        #region FillToCheckBoxList
        public void FillToCheckBoxList(CheckBoxList checkboxlist,DataTable datatable,string displayMember,string valueMember) 
        {
            if (datatable != null)
            {
                checkboxlist.DataSource = datatable;
                checkboxlist.DataTextField = displayMember;
                checkboxlist.DataValueField = valueMember;
            }
            else
                checkboxlist.DataSource = null;
            checkboxlist.DataBind();
        }
        #endregion

        #region FillToRadioList
        public void FillToRadioList(
            RadioButtonList radiolist, 
            DataTable datatable, 
            string displayMember, 
            string valueMember)
        {
            if (datatable != null)
            {
                radiolist.DataSource = datatable;
                radiolist.DataTextField = displayMember;
                radiolist.DataValueField = valueMember;
            }
            else
                radiolist.DataSource = null;
            radiolist.DataBind();
        }

        public void FillToRadioList(
            RadioButtonList radiolist,
            DataTable datatable,
            string displayMember,
            string valueMember,
            string selectedIndex)
        {
            if (datatable != null)
            {
                radiolist.DataSource = datatable;
                radiolist.DataTextField = displayMember;
                radiolist.DataValueField = valueMember;
            }
            else
                radiolist.DataSource = null;
            radiolist.DataBind();

            if (selectedIndex != "")
            {
                try
                {
                    radiolist.SelectedValue = selectedIndex;
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex.Message.ToString());
                }

            }
        }
        #endregion

        

        #region UploadImage
        public string UploadImage(FileUpload file_upload,string save_path, int max_width,int max_height) 
        {
            string filename = "";
            if(file_upload.HasFile)
            {
               
                filename += ReNameFile(file_upload.FileName);
                save_path = save_path + filename;

                Stream sStream = file_upload.FileContent;
                try
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(sStream))
                    {
                        if (image.Width <= max_width && image.Height <= max_height)
                        {

                            file_upload.SaveAs(save_path);
                        }
                        else if (image.Width > max_width || image.Height > max_height)
                        {
                            //dieu chinh kich thuoc theo ty le moi'
                            double widthRatio = (double)image.Width / (double)max_width;
                            double heightRatio = (double)image.Height / (double)max_height;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(image.Width / ratio);
                            int newHeight = (int)(image.Height / ratio);

                            //tao doi duong img voi kich thuoc va kieu file moi'
                            System.Drawing.Image oThumbNail = new Bitmap(newWidth, newHeight, image.PixelFormat);

                            //Dieu chinh chat luong hinh anh
                            Graphics oGraphic = Graphics.FromImage(oThumbNail);
                            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Rectangle oRectangle = new Rectangle(0, 0, newWidth, newHeight);

                            //tao ra hinh anh moi' voi kich thuoc va chat luong moi'
                            oGraphic.DrawImage(image, oRectangle);

                            //Luu buc anh duoc resize xuong may'
                            oThumbNail.Save(save_path, image.RawFormat);

                        }
                    }
                }
                catch 
                {
                    filename = "";
                }
                sStream.Dispose();
                sStream.Close();

            }
            return filename;
        }

        public string UploadImage(FileUpload file_upload, string save_path, int max_width, int max_height, string filename1)
        {
              string filename = "";
            if (file_upload.HasFile)
            {

                filename += filename1 + ReNameFile(file_upload.FileName);
                save_path = save_path + filename;

                Stream sStream = file_upload.FileContent;
                try
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(sStream))
                    {
                        if (CheckFileType(filename))
                        {
                            if (Path.GetExtension(filename).ToLower() == ".gif")
                            {
                                file_upload.SaveAs(save_path);
                            }
                            else
                            {
                                if (image.Width <= max_width && image.Height <= max_height)
                                {

                                    file_upload.SaveAs(save_path);
                                }
                                else if (image.Width > max_width || image.Height > max_height)
                                {
                                    //dieu chinh kich thuoc theo ty le moi'
                                    double widthRatio = (double)image.Width / (double)max_width;
                                    double heightRatio = (double)image.Height / (double)max_height;
                                    double ratio = Math.Max(widthRatio, heightRatio);
                                    int newWidth = (int)(image.Width / ratio);
                                    int newHeight = (int)(image.Height / ratio);

                                    //tao doi duong img voi kich thuoc va kieu file moi'
                                    System.Drawing.Image oThumbNail = new Bitmap(newWidth, newHeight, image.PixelFormat);

                                    //Dieu chinh chat luong hinh anh
                                    Graphics oGraphic = Graphics.FromImage(oThumbNail);
                                    oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                                    oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                                    oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    Rectangle oRectangle = new Rectangle(0, 0, newWidth, newHeight);

                                    //tao ra hinh anh moi' voi kich thuoc va chat luong moi'
                                    oGraphic.DrawImage(image, oRectangle);

                                    //Luu buc anh duoc resize xuong may'
                                    oThumbNail.Save(save_path, image.RawFormat);

                                }
                            }
                        }
                        else
                            return filename;
                    }
                }
                catch
                {
                    filename = "";
                }
                sStream.Dispose();
                sStream.Close();

            }
            return filename;
        }
        #endregion

        #region UploadFile
        public string UploadFile(FileUpload fileupload, string savepath, Int64 size)
        {
            string filename = "";
            if (fileupload.HasFile)
            {

                string name = fileupload.FileName;
                HttpPostedFile file = fileupload.PostedFile;
                if (file.ContentLength <= size && TypeFileUpload(name))
                {
                    filename += ReNameFile(name);
                    savepath += filename;
                    fileupload.SaveAs(savepath);
                    return filename;
                }
                else
                {
                    return filename;
                }

            }
            else
            {
                return filename;
            }
        }

        public string UploadFile(FileUpload fileupload, string savepath, Int64 size, string filenamef)
        {
            string filename = "";
            if (fileupload.HasFile)
            {

                string name = fileupload.FileName;
                HttpPostedFile file = fileupload.PostedFile;
                if (file.ContentLength <= size && TypeFileUpload(name))
                {
                    filename += filenamef + ReNameFile(name);
                    savepath += filename;
                    fileupload.SaveAs(savepath);

                    return filename;
                }
                else
                {
                    return filename;
                }

            }
            else
            {
                return filename;
            }
        }

        #endregion

        #region UploadVideo
        public string UploadVideo(FileUpload fileupload, string savepath, Int64 size)
        {
            string filename = "";
            if (fileupload.HasFile)
            {

                string name = fileupload.FileName;
                HttpPostedFile file = fileupload.PostedFile;
                if (file.ContentLength <= size && TypeVideoUpload(name))
                {
                    filename += ReNameFile(name);
                    savepath += filename;
                    fileupload.SaveAs(savepath);
                    return filename;
                }
                else
                {
                    return filename;
                }

            }
            else
            {
                return filename;
            }
        }

        public string UploadVideo(FileUpload fileupload, string savepath, Int64 size, string filenamef)
        {
            string filename = "";
            if (fileupload.HasFile)
            {

                string name = fileupload.FileName;
                HttpPostedFile file = fileupload.PostedFile;
                if (file.ContentLength <= size && TypeVideoUpload(name))
                {
                    filename += filenamef + ReNameFile(name);
                    savepath += filename;
                    fileupload.SaveAs(savepath);
                    return filename;
                }
                else
                {
                    return filename;
                }

            }
            else
            {
                return filename;
            }
        }

        #endregion

        #region UploadFileAudio
        public string UploadFileAudio(FileUpload fileupload, string savepath, Int64 size, string filenamef)
        {
            string filename = "";
            if (fileupload.HasFile)
            {

                string name = fileupload.FileName;
                HttpPostedFile file = fileupload.PostedFile;
                if (file.ContentLength <= size && TypeAudioUpload(name))
                {
                    filename += filenamef + ReNameFile(name);
                    savepath += filename;
                    fileupload.SaveAs(savepath);
                    //return filename;
                }
            //    else
            //    {
            //        return filename;
            //    }

            }
            //else
            //{
                return filename;
            //}
        }
        #endregion

        #region UploadFlash
        public string UploadFlash(FileUpload fileupload, string savepath, Int64 size)
        {
            string filename = "";
            if (fileupload.HasFile)
            {

                string name = fileupload.FileName;
                HttpPostedFile file = fileupload.PostedFile;
                if (file.ContentLength <= size && TypeFlashUpload(name))
                {
                    filename += ReNameFile(name);
                    savepath += filename;
                    fileupload.SaveAs(savepath);
                    return filename;
                }
                else
                {
                    return filename;
                }

            }
            else
            {
                return filename;
            }
        }

        public string UploadFlash(FileUpload fileupload, string savepath, Int64 size, string filenamef)
        {
            string filename = "";
            if (fileupload.HasFile)
            {

                string name = fileupload.FileName;
                HttpPostedFile file = fileupload.PostedFile;
                if (file.ContentLength <= size && TypeFlashUpload(name))
                {
                    filename += filenamef + ReNameFile(name);
                    savepath += filename;
                    fileupload.SaveAs(savepath);
                    return filename;
                }
                else
                {
                    return filename;
                }

            }
            else
            {
                return filename;
            }
        }
        #endregion

        #region CheckFileType
        private bool CheckFileType(string filename) 
        {
            string str = Path.GetExtension(filename).ToLower();
            switch(str)
            {
                case ".gif":
                    return true;
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".jpeg":
                    return true;
                case ".bmb":
                    return true;
                case ".GIF":
                    return true;
                case ".JPG":
                    return true;
                case ".PNG":
                    return true;
                case ".JPEG":
                    return true;
                case ".BMB":
                    return true;
                default:
                    return false;
            }
        }

        private bool TypeFileUpload(string filename)
        {
            string str = Path.GetExtension(filename).ToLower();
            switch (str)
            {
                case ".doc":
                    return true;
                case ".xls":
                    return true;
                case ".zip":
                    return true;
                case ".rar":
                    return true;
                case ".ppt":
                    return true;
                case ".docx":
                    return true;
                case ".xlsx":
                    return true;
                case ".pptx":
                    return true;
                case ".DOC":
                    return true;
                case ".DOCX":
                    return true;
                case ".PPT":
                    return true;
                case ".PPTX":
                    return true;
                case ".ZIP":
                    return true;
                case ".RAR":
                    return true;
                case ".XLS":
                    return true;
                case ".XLSX":
                    return true;
                case ".pdf":
                    return true;
                case ".PDF":
                    return true;
                default:
                    return false;
            }
        }

        private bool TypeVideoUpload(string filename)
        {
            string str = Path.GetExtension(filename).ToLower();
            switch (str)
            {
                case ".flv":
                    return true;

                case ".FLV":
                    return true;

                default:
                    return false;
            }
        }

        private bool TypeAudioUpload(string filename)
        {
            string str = Path.GetExtension(filename).ToLower();
            switch (str)
            {
                case ".mp3":
                    return true;
                case ".MP3":
                    return true;
                default:
                    return false;
            }
        }

        private bool TypeFlashUpload(string filename)
        {
            string str = Path.GetExtension(filename).ToLower();
            switch (str)
            {
                case ".swf":
                    return true;

                case ".SWF":
                    return true;
                default:
                    return false;
            }
        }
        #endregion

        #region ReNameFile
        private string ReNameFile(string str) 
        {
            string newstr = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string substring = Path.GetExtension(str);
            int sublength = substring.Length;
            int length = str.Length;
            string oldstr = str.Substring(0, length - sublength);
            string rename = str.Replace(oldstr, newstr);
            return rename;
        }

      
        #endregion

        #region DeleteFile
        public void DeleteFile(string path) 
        {
            try 
            {
                FileInfo fileinfo = new FileInfo(path);
                if (fileinfo.Exists)
                    fileinfo.Delete();
                else
                    throw new BusinessException("Khong tin thay file de xoa");
            }
            catch(Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
        }
        #endregion

        #region cutString
        public string cutString(string sString, int len, string more)
        {
            string str = String.Empty;
            if (sString.Equals("") || sString.Length <= len)
                str = sString;
            if (sString.Length > len)
            {
                str = sString.Substring(0, len);
                str = str.Substring(0, str.LastIndexOf(" "));
                str = (!more.Equals("")) ? str + more : str;
            }
            return str;

        }
        #endregion

        //public string enCode(string Pass)
        //{

        //    EDData.clsEDData EDD = new EDData.clsEDData();
        //    string s = null;
        //    object s1 = null;
        //    EDD.SetKey("EVNIT_16LDH", EDData.EDKeyTypeEnum.eEDString, ref s1);
        //    s = EDD.EncryptStr(Pass, EDData.EDDataType.eHex);
        //    return EDD.EncryptStr(Pass, EDData.EDDataType.eHex);
        //}

        //public string DeCode(string Pass)
        //{
        //    EDData.clsEDData EDD = new EDData.clsEDData();
        //    string s = null;
        //    object s1 = null;
        //    EDD.SetKey("EVNIT_16LDH", EDData.EDKeyTypeEnum.eEDString, ref s1);
        //    s = EDD.DecryptStr(Pass, EDData.EDDataType.eHex);
        //    return EDD.DecryptStr(Pass, EDData.EDDataType.eHex);
        //}


        public DataTable CreateDataView(string SQL)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            table = null;
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.CommandTimeout = 5;
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            table = new DataTable();
                            adapter.Fill(table);
                            command.Dispose();
                        }
                        catch
                        {
                            table = null;
                        }
                    }
                }
                catch
                {
                    table = null;
                }
                finally
                {
                    if (connection != null)
                        connection.Close();

                }
            }
            return table;
        }
  

    }
}
