using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePower.Core;
using ePower.Core.Entity;

namespace ETO
{
    public class OfficeRelateBO : BaseEntity
    {
        #region "Private Members"
        int _DocId;
        int _DocRelateId;
        #endregion

        #region "Constructors"
        public OfficeRelateBO()
        {
        }
        #endregion
        public OfficeRelateBO(OfficeRelateDTO objorganizationBO)
        {
            this.Id = objorganizationBO.Id;
            _DocId = objorganizationBO.DocId;
            _DocRelateId = objorganizationBO.DocRelateId;
        }
        #region "Public Properties"
        public override string TableName
        {
            get { return "tblOfficeRelate"; }
            set { base.TableName = "tblOfficeRelate"; }
        }

        [FieldName("DocId", FieldAccessMode.ReadWrite, FieldType.Int)]

        public int DocId
        {
            get { return _DocId; }
            set { _DocId = value; }
        }
        [FieldName("DocRelateId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int DocRelateId
        {
            get { return _DocRelateId; }
            set { _DocRelateId = value; }
        }
        #endregion
    }
}