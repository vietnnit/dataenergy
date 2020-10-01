using System;
using System.Collections.Generic;
using System.Text;


namespace ETO
{
    public class OfficialDTO
    {
        public OfficialDTO()
        {
            //Constructor
        }
        public OfficialDTO(OfficialBO objBO)
        {
            this._AreaID = objBO.AreaID;
            this._DocTypeID = objBO.DocTypeID;
            this._EffectDate = objBO.EffectDate;
            this._ExpiredDate = objBO.ExpiredDate;
            this._isDelete = objBO.isDelete;
            this._lang = objBO.Language;
            this._OrgID = objBO.OrgID;
            this.approvalDate = objBO.ApprovalDate;
            this.approvalUserName = objBO.ApprovalUserName;
            this.attached = objBO.Attached;
            this.cateofficialid = objBO.CateOfficialID;
            this.classify = objBO.Classify;
            this.company = objBO.Company;
            this.createdDate = objBO.CreatedDate;
            this.createdUserName = objBO.CreatedUserName;
            this.datepublic = objBO.DatePublic;
            this.groupCate = objBO.GroupCate;
            this.isApproval = objBO.IsApproval;
            this.keyshort = objBO.KeyShort;
            this.nocode = objBO.NoCode;
            this.officialname = objBO.OfficialName;
            this.quote = objBO.Quote;
            this.status = objBO.Status;
            this.writer = objBO.Writer;
            this.officialid = objBO.Id;
            this.PathFile = objBO.PathFile;
            this.DisscussionDate = objBO.DisscussionDate;
            this.GroupDoc = objBO.GroupDoc;
            this.NoteDoc = objBO.NoteDoc;
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
        private int _DocTypeID;
        public int DocTypeID
        {
            get { return _DocTypeID; }
            set { _DocTypeID = value; }
        }
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private int _AreaID;
        public int AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; }
        }
        private DateTime _EffectDate;

        public DateTime EffectDate
        {
            get { return _EffectDate; }
            set { _EffectDate = value; }
        }
        private DateTime _ExpiredDate;

        public DateTime ExpiredDate
        {
            get { return _ExpiredDate; }
            set { _ExpiredDate = value; }
        }
        private DateTime _DisscussionDate;

        public DateTime DisscussionDate
        {
            get { return _DisscussionDate; }
            set { _DisscussionDate = value; }
        }

        private string _PathFile;
        public string PathFile
        {
            get { return _PathFile; }
            set { _PathFile = value; }
        }
        private int _GroupDoc;
        public int GroupDoc
        {
            get { return _GroupDoc; }
            set { _GroupDoc = value; }
        }
        private string _NoteDoc;
        public string NoteDoc
        {
            get { return _NoteDoc; }
            set { _NoteDoc = value; }
        }
        

    }
}
