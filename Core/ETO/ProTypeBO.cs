using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace PR.Domain
{
    public class ProTypeBO : BaseEntity
    {

        #region Constructor
        public ProTypeBO()
        { }


        public ProTypeBO(ProType protypeDTO)
        {
            this.Id = protypeDTO.Id;
            this.ProjectId = protypeDTO.ProjectId;
            this.TypeId = protypeDTO.TypeId;
        }
        #endregion

        #region Private Variables
        private int _Id;
        private int _ProjectId;
        private int _TypeId;
        #endregion

        #region Public Properties
        public override string TableName
        {
            get { return "Pr_ProType"; }
            set { base.TableName = "Pr_ProType"; }
        }

        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public override int Id
        {
            get { return _Id; }
            set { _Id = value; SetDirty("Id"); }
        }
        [FieldName("ProjectId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ProjectId
        {
            get { return _ProjectId; }
            set { _ProjectId = value; SetDirty("ProjectId"); }
        }
        [FieldName("TypeId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int TypeId
        {
            get { return _TypeId; }
            set { _TypeId = value; SetDirty("TypeId"); }
        }
        #endregion

    }
}
