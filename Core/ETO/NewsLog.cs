using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsLog
    {
        private int newsLogid;
        public int NewsLogID
        {
            get { return newsLogid; }
            set { newsLogid = value; }
        }

        private int newsGroupid;
        public int NewsGroupID
        {
            get { return newsGroupid; }
            set { newsGroupid = value; }
        }

        private int catenewsid;
        public int CateNewsID
        {
            get { return catenewsid; }
            set { catenewsid = value; }
        }

        private int parentnewsid;
        public int ParentNewsID
        {
            get { return parentnewsid; }
            set { parentnewsid = value; }
        }

        private int groupCate;
        public int GroupCate
        {
            get { return groupCate; }
            set { groupCate = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string shortdescribe;
        public string ShortDescribe
        {
            get { return shortdescribe; }
            set { shortdescribe = value; }
        }
        private string fulldescribe;

        public string FullDescribe
        {
            get { return fulldescribe; }
            set { fulldescribe = value; }
        }

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

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
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

        private int relationtotal;
        public int RelationTotal
        {
            get { return relationtotal; }
            set { relationtotal = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private string language;
        public string Language
        {
            get { return language; }
            set { language = value; }
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

        private bool typeNews;
        public bool TypeNews
        {
            get { return typeNews; }
            set { typeNews = value; }
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

        private string _slug;
        public string Slug
        {
            get { return _slug; }
            set { _slug = value; }
        }

        private string _keyword;
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        private string _tags;
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        private string _shortTitle;
        public string ShortTitle
        {
            get { return _shortTitle; }
            set { _shortTitle = value; }
        }

        private bool _isUrl;
        public bool isUrl
        {
            get { return _isUrl; }
            set { _isUrl = value; }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private bool _isDelete;
        public bool isDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        private DateTime modifyDate;
        public DateTime ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
        }
       
        private string modifyUserName;
        public string ModifyUserName
        {
            get { return modifyUserName; }
            set { modifyUserName = value; }
        }

        private int version;
        public int Version
        {
            get { return version; }
            set { version = value; }
        }
    }
}
