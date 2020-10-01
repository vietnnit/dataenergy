using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
    public class District
    {

        #region Constructor
        public District()
        { }

        public District(DistrictBO districtBO)
        {
            this.DistrictName = districtBO.DistrictName;
            this.DistrictCode = districtBO.DistrictCode;
            this.Id = districtBO.Id;
            this.SortOrder = districtBO.SortOrder;
            this.ProvinceId = districtBO.ProvinceId;
        }
        #endregion

        #region Private Variables
        private string _DistrictName;
        private string _DistrictCode;
        private int _Id;
        private int _SortOrder;
        private int _ProvinceId;
        private int _Total;
        #endregion

        #region Public Properties

        public string DistrictName
        {
            get { return _DistrictName; }
            set { _DistrictName = value; }
        }
        public string DistrictCode
        {
            get { return _DistrictCode; }
            set { _DistrictCode = value; }
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
        public int ProvinceId
        {
            get { return _ProvinceId; }
            set { _ProvinceId = value; }
        }

        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        #endregion Public Properties

    }
}
