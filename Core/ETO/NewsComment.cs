using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsComment
    {
        public NewsComment()
        {
            //constructor
        }

        private int commentNewsID;
        public int CommentNewsID
        {
            get { return commentNewsID; }
            set { commentNewsID = value; }
        }

        private int Newsid;
        public int NewsID
        {
            get { return Newsid; }
            set { Newsid = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private bool actived;
        public bool Actived
        {
            get { return actived; }
            set { actived = value; }
        }

        private DateTime dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
        private int groupCate;
        public int GroupCate
        {
            get { return groupCate; }
            set { groupCate = value; }
        }

        private string approvalUserName;
        public string ApprovalUserName
        {
            get { return approvalUserName; }
            set { approvalUserName = value; }
        }

        private DateTime approvalDate;
        public DateTime ApprovalDate
        {
            get { return approvalDate; }
            set { approvalDate = value; }
        }

    }
}
