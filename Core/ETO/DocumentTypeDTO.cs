using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePower.Core;

namespace ETO
{
    public class DocTypeDTO
    {
        #region "Private Members"
        int _typeID;
        string _typeName;
        bool _IsDelete;
        int _SortOrder;
        #endregion

        #region "Constructors"
        public DocTypeDTO()
        {
        }

        public DocTypeDTO(DocTypeBO objtypesBO)
        {
            _typeID = objtypesBO.Id;
            _typeName = objtypesBO.TypeName;
            _SortOrder = objtypesBO.SortOrder;
            _IsDelete = objtypesBO.IsDelete;
        }
        #endregion

        #region "Public Properties"
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }
        public int SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
        
        #endregion
    }
}

