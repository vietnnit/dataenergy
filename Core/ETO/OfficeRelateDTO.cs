using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePower.Core;
using ePower.Core.Entity;

namespace ETO
{
    public class OfficeRelateDTO
    {
        #region "Private Members"
        int _Id;
        int _DocId;
        int _DocRelateId;       
        #endregion

        #region "Constructors"
        public OfficeRelateDTO()
        {
        }

        public OfficeRelateDTO(OfficeRelateBO objorganizationBO)
        {
            _Id = objorganizationBO.Id;
            _DocId = objorganizationBO.DocId;
            _DocRelateId = objorganizationBO.DocRelateId;
        }
        #endregion

        #region "Public Properties"
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int DocId
        {
            get { return _DocId; }
            set { _DocId = value; }
        }
        public int DocRelateId
        {
            get { return _DocRelateId; }
            set { _DocRelateId = value; }
        }
        #endregion
    }
}

