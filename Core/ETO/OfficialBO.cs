using System;
using System.Collections.Generic;
using System.Text;
using ePower.Core.Entity;

namespace ETO
{
    public class OfficialBO : BaseEntity
    {
        public OfficialBO()
        {
            //Constructor
        }
        public OfficialBO(OfficialDTO objBO)
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
            this.Id = objBO.OfficialID;
            this.PathFile = objBO.PathFile;
            this.DisscussionDate = objBO.DisscussionDate;
            this.GroupDoc = objBO.GroupDoc;
            this.NoteDoc = objBO.NoteDoc;

        }
        public override string TableName
        {
            get { return "tblOfficial"; }
            set { base.TableName = "tblOfficial"; }
        }

        //private int officialid;
        //[FieldName("ID", FieldAccessMode.ReadOnly)]
        //public int OfficialID
        //{
        //    set { officialid = value; }
        //    get { return officialid; SetDirty("OfficialID"); }
        //}

        private int cateofficialid;
        [FieldName("CateOfficialID", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int CateOfficialID
        {
            set { cateofficialid = value; }
            get { return cateofficialid; SetDirty("CateOfficialID"); }
        }

        private string nocode;
        [FieldName("NoCode", FieldAccessMode.ReadWrite, FieldType.String)]
        public string NoCode
        {
            set { nocode = value; }
            get { return nocode; SetDirty("NoCode"); }
        }

        private string officialname;
        [FieldName("OfficialName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string OfficialName
        {
            set { officialname = value; }
            get { return officialname; SetDirty("OfficialName"); }
        }

        private DateTime datepublic;
        [FieldName("DatePublic", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public DateTime DatePublic
        {
            set { datepublic = value; }
            get { return datepublic; SetDirty("DatePublic"); }
        }

        private string company;
        [FieldName("Company", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Company
        {
            set { company = value; }
            get { return company; SetDirty("Company"); }
        }

        private string classify;
        [FieldName("Classify", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Classify
        {
            set { classify = value; }
            get { return classify; SetDirty("Classify"); }
        }

        private string writer;
        [FieldName("Writer", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Writer
        {
            set { writer = value; }
            get { return writer; SetDirty("Writer"); }
        }

        private string quote;
        [FieldName("Quote", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Quote
        {
            set { quote = value; }
            get { return quote; SetDirty("Quote"); }
        }

        private string keyshort;
        [FieldName("KeyShort", FieldAccessMode.ReadWrite, FieldType.String)]
        public string KeyShort
        {
            set { keyshort = value; }
            get { return keyshort; SetDirty("KeyShort"); }
        }

        private string attached;
        [FieldName("Attached", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Attached
        {
            set { attached = value; }
            get { return attached; SetDirty("Attached"); }
        }

        private bool status;
        [FieldName("Status", FieldAccessMode.ReadWrite, FieldType.Boolean)]
        public bool Status
        {
            set { status = value; }
            get { return status; SetDirty("Status"); }
        }
        private bool isApproval;
        [FieldName("IsApproval", FieldAccessMode.ReadWrite, FieldType.Boolean)]
        public bool IsApproval
        {
            get { return isApproval; }
            set { isApproval = value; SetDirty("IsApproval"); }
        }

        private DateTime approvalDate;
        [FieldName("ApprovalDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public DateTime ApprovalDate
        {
            get { return approvalDate; }
            set { approvalDate = value; SetDirty("ApprovalDate"); }
        }
        private DateTime createdDate;
        [FieldName("createdDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; SetDirty("createdDate"); }
        }
        private string createdUserName;
        [FieldName("CreatedUserName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string CreatedUserName
        {
            get { return createdUserName; }
            set { createdUserName = value; SetDirty("CreatedUserName"); }
        }

        private string approvalUserName;
        [FieldName("ApprovalUserName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ApprovalUserName
        {
            get { return approvalUserName; }
            set { approvalUserName = value; SetDirty("ApprovalUserName"); }
        }

        private int groupCate;
        [FieldName("GroupCate", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int GroupCate
        {
            set { groupCate = value; }
            get { return groupCate; SetDirty("GroupCate"); }
        }

        private string _lang;
        [FieldName("Language", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Language
        {
            get { return _lang; }
            set { _lang = value; SetDirty("Language"); }
        }

        private bool _isDelete;
        [FieldName("isDelete", FieldAccessMode.ReadWrite, FieldType.Boolean)]
        public bool isDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; SetDirty("isDelete"); }
        }
        private int _DocTypeID;
        [FieldName("DocTypeID", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int DocTypeID
        {
            get { return _DocTypeID; }
            set { _DocTypeID = value; SetDirty("DocTypeID"); }
        }
        private int _OrgID;
        [FieldName("OrgID", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; SetDirty("OrgID"); }
        }
        private int _AreaID;
        [FieldName("AreaID", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; SetDirty("AreaID"); }
        }
        private DateTime _EffectDate;
        [FieldName("EffectDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public DateTime EffectDate
        {
            get { return _EffectDate; }
            set { _EffectDate = value; SetDirty("EffectDate"); }
        }
        private DateTime _ExpiredDate;
        [FieldName("ExpiredDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public DateTime ExpiredDate
        {
            get { return _ExpiredDate; }
            set { _ExpiredDate = value; SetDirty("ExpiredDate"); }
        }
        private DateTime _DisscussionDate;
        [FieldName("DisscussionDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public DateTime DisscussionDate
        {
            get { return _DisscussionDate; }
            set { _DisscussionDate = value; SetDirty("DisscussionDate"); }
        }

        private string _PathFile;
        [FieldName("PathFile", FieldAccessMode.ReadWrite, FieldType.String)]
        public string PathFile
        {
            get { return _PathFile; }
            set { _PathFile = value; SetDirty("PathFile"); }
        }

        private int _GroupDoc;
        [FieldName("GroupDoc", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int GroupDoc
        {
            get { return _GroupDoc; }
            set { _GroupDoc = value; SetDirty("GroupDoc"); }
        }
        private string _NoteDoc;
        [FieldName("NoteDoc", FieldAccessMode.ReadWrite, FieldType.String)]
        public string NoteDoc
        {
            get { return _NoteDoc; }
            set { _NoteDoc = value; SetDirty("NoteDoc"); }
        }

    }
}
