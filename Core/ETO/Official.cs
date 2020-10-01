using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Official
    {
        public Official() 
        {
            //Constructor
        }

        private int officialid;
        public int OfficialID
        {
            set { officialid = value; }
            get { return officialid; }
        }

        private int cateofficialid;
        public int CateOfficialID
        {
            set { cateofficialid = value; }
            get { return cateofficialid; }
        }

        private string nocode;
        public string NoCode
        {
            set { nocode = value; }
            get { return nocode; }
        }

        private string officialname;
        public string OfficialName
        {
            set { officialname = value; }
            get { return officialname; }
        }

        private DateTime datepublic;
        public DateTime DatePublic
        {
            set { datepublic = value; }
            get { return datepublic; }
        }

        private string company;
        public string Company
        {
            set { company = value; }
            get { return company; }
        }

        private string classify;
        public string Classify
        {
            set { classify = value; }
            get { return classify; }
        }

        private string writer;
        public string Writer
        {
            set { writer = value; }
            get { return writer; }
        }

        private string quote;
        public string Quote
        {
            set { quote = value; }
            get { return quote; }
        }

        private string keyshort;
        public string KeyShort
        {
            set { keyshort = value; }
            get { return keyshort; }
        }

        private string attached;
        public string Attached
        {
            set { attached = value; }
            get { return attached; }
        }

        private bool status;
        public bool Status
        {
            set { status = value; }
            get { return status; }
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
        private DateTime createdDate;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
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

        private int groupCate;
        public int GroupCate
        {
            set { groupCate = value; }
            get { return groupCate; }
        }

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }

        private bool _isDelete;
        public bool isDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
    }
}
