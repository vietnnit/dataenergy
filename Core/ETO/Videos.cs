using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Videos
    {
        public Videos() 
        {
            //constructor
        }

        private int videosid;
        public int VideosID 
        {
            get { return videosid; }
            set { videosid = value; }
        }

        private int videoscateid;
        public int VideosCateID
        {
            get { return videoscateid; }
            set { videoscateid = value; }
        }
       

        private string title;
        public string Title 
        {
            get { return title; }
            set { title = value; }
        }

        private string describe;
        public string Description
        {
            get { return describe; }
            set { describe = value; }
        }
      //  private string fulldescribe;

 
        private string imagethumb;
        public string ImageThumb
        {
            get { return imagethumb; }
            set { imagethumb = value; }
        }

        private string imagelarge;
        public string ImageLarge
        {
            get { return imagelarge; }
            set { imagelarge = value; }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private DateTime postdate;
        public DateTime PostDate
        {
            get { return postdate; }
            set { postdate = value; }
        }



        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }



        private bool ishot;
        public bool Ishot
        {
            get { return ishot; }
            set { ishot = value; }
        }

        private int inview;
        public int Isview
        {
            get { return inview; }
            set { inview = value; }
        }
        private bool ishome;
        public bool Ishome
        {
            get { return ishome; }
            set { ishome = value; }
        }
        private bool isComment;
        public bool IsComment
        {
            get { return isComment; }
            set { isComment = value; }
        }

        private bool isApproval;
        public bool IsApproval
        {
            get { return isApproval; }
            set { isApproval = value; }
        }

        private DateTime approvalDate;
        public DateTime ApprovalDate
        {
            get { return approvalDate; }
            set { approvalDate = value; }
        }
        private int commentTotal;
        public int CommentTotal
        {
            get { return commentTotal; }
            set { commentTotal = value; }
        }
        private string createdUserName;
        public string CreatedUserName
        {
            get { return createdUserName; }
            set { createdUserName = value; }
        }

        private string approvalUserName;
        public string ApprovalUserName
        {
            get { return approvalUserName; }
            set { approvalUserName = value; }
        }

        private string videoUrl;
        public string VideosUrl
        {
            get { return videoUrl; }
            set { videoUrl = value; }
        }

        private string filename;
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }
        private bool videoType;
        public bool VideosType
        {
            get { return videoType; }
            set { videoType = value; }
        }

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
