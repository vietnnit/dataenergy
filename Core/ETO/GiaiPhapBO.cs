using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
    public class GiaiPhapBO : BaseEntity
    {

        #region Constructor
        public GiaiPhapBO()
        { }


        public GiaiPhapBO(GiaiPhap giaiphapDTO)
        {
            this.Id = giaiphapDTO.Id;
            this.TenGiaiPhap = giaiphapDTO.TenGiaiPhap;
            this.MoTa = giaiphapDTO.MoTa;
            this.EnterpriseId = giaiphapDTO.EnterpriseId;
            this.IsDelete = giaiphapDTO.IsDelete;
        }
        #endregion

        #region Private Variables
        private int _Id;
        private string _TenGiaiPhap;
        private string _MoTa;
        private int _EnterpriseId;
        private bool _IsDelete;
        #endregion

        #region Public Properties
        public override string TableName
        {
            get { return "DE_GiaiPhap"; }
            set { base.TableName = "DE_GiaiPhap"; }
        }

        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public override int Id
        {
            get { return _Id; }
            set { _Id = value; SetDirty("Id"); }
        }
        [FieldName("TenGiaiPhap", FieldAccessMode.ReadWrite, FieldType.String)]
        public string TenGiaiPhap
        {
            get { return _TenGiaiPhap; }
            set { _TenGiaiPhap = value; SetDirty("TenGiaiPhap"); }
        }
        [FieldName("MoTa", FieldAccessMode.ReadWrite, FieldType.String)]
        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; SetDirty("MoTa"); }
        }
        [FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int EnterpriseId
        {
            get { return _EnterpriseId; }
            set { _EnterpriseId = value; SetDirty("EnterpriseId"); }
        }
        [FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.Boolean)]
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; SetDirty("IsDelete"); }
        }
        #endregion

    }
}
