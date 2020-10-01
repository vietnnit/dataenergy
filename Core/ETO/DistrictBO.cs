using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
    public class DistrictBO : BaseEntity
    {

        #region Constructor
        public DistrictBO()
        { }


        public DistrictBO(District districtDTO)
        {
            this.DistrictName = districtDTO.DistrictName;
            this.DistrictCode = districtDTO.DistrictCode;
            this.Id = districtDTO.Id;
            this.SortOrder = districtDTO.SortOrder;
            this.ProvinceId = districtDTO.ProvinceId;
        }
        #endregion

        #region Private Variables
        private string _DistrictName;
        private string _DistrictCode;
        private int _Id;
        private int _SortOrder;
        private int _ProvinceId;
        #endregion

        #region Public Properties
        public override string TableName
        {
            get { return "DE_District"; }
            set { base.TableName = "DE_District"; }
        }

        [FieldName("DistrictName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string DistrictName
        {
            get { return _DistrictName; }
            set { _DistrictName = value; SetDirty("DistrictName"); }
        }
        [FieldName("DistrictCode", FieldAccessMode.ReadWrite, FieldType.String)]
        public string DistrictCode
        {
            get { return _DistrictCode; }
            set { _DistrictCode = value; SetDirty("DistrictCode"); }
        }
        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public override int Id
        {
            get { return _Id; }
            set { _Id = value; SetDirty("Id"); }
        }
        [FieldName("SortOrder", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; SetDirty("SortOrder"); }
        }
        [FieldName("ProvinceId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ProvinceId
        {
            get { return _ProvinceId; }
            set { _ProvinceId = value; SetDirty("ProvinceId"); }
        }
        #endregion

    }
}
