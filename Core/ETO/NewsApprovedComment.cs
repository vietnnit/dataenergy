using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsApprovedComment
    {
        public NewsApprovedComment()
        {
            //constructor
        }

        private int approvedCommentNewsID;
        public int ApprovedCommentNewsID
        {
            get { return approvedCommentNewsID; }
            set { approvedCommentNewsID = value; }
        }

        private int Newsid;
        public int NewsID
        {
            get { return Newsid; }
            set { Newsid = value; }
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
 

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

 
    }
}
