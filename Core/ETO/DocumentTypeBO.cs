using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePower.Core;
using ePower.Core.Entity;

namespace ETO
{
    public class DocTypeBO : BaseEntity
    {
        #region "Private Members"

        string _typeName;
        bool _IsDelete;
        int _SortOrder;
        #endregion

        #region "Constructors"
        public DocTypeBO()
        {
        }
        #endregion
        public DocTypeBO(DocTypeDTO objtypesBO)
        {
            this.Id = objtypesBO.TypeID;
            _typeName = objtypesBO.TypeName;
            _IsDelete = objtypesBO.IsDelete;
            _SortOrder = objtypesBO.SortOrder;
        }
        #region "Public Properties"
        public override string TableName
        {
            get { return "tblDocumentType"; }
            set { base.TableName = "tblDocumentType"; }
        }


        [FieldName("TypeName", FieldAccessMode.ReadWrite)]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; SetDirty("TypeName"); }
        }
        [FieldName("IsDelete", FieldAccessMode.ReadWrite)]
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }
        [FieldName("SortOrder", FieldAccessMode.ReadWrite)]
        public int SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
        #endregion
    }
}

