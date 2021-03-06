using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
    public class ProductBO : BaseEntity
    {

        #region Constructor
        public ProductBO()
        { }


        public ProductBO(Product productDTO)
        {
            this.Id = productDTO.Id;
            this.ProductName = productDTO.ProductName;
            this.Measurement = productDTO.Measurement;
            this.Quantity = productDTO.Quantity;
            this.YearStart = productDTO.YearStart;
            this.YearEnd = productDTO.YearEnd;
            this.Note = productDTO.Note;
            this.EnterpriseId = productDTO.EnterpriseId;
            this.IsProduct = productDTO.IsProduct;
            this.FuelId = productDTO.FuelId;
            this.ProductOrder = productDTO.ProductOrder;
            this.MeasurementId = productDTO.MeasurementId;
            this.NhietTriThap = productDTO.NhietTriThap;
            this.GroupFuel = productDTO.GroupFuel;
            this.ProductType13 = productDTO.ProductType13;
        }
        #endregion

        #region Private Variables
        private int _Id;
        private string _ProductName;
        private string _Measurement;
        private decimal _Quantity;
        private int _YearStart;
        private int _YearEnd;
        private string _Note;
        private int _EnterpriseId;
        private bool _IsProduct;
        private int _FuelId;
        private int _ProductOrder;
        private int _MeasurementId;
        private decimal _NhietTriThap;
        private int _GroupFuel;
        private string _ProductType13;
        #endregion

        #region Public Properties
        public override string TableName
        {
            get { return "DE_Product"; }
            set { base.TableName = "DE_Product"; }
        }

        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public override int Id
        {
            get { return _Id; }
            set { _Id = value; SetDirty("Id"); }
        }
        [FieldName("ProductName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; SetDirty("ProductName"); }
        }
        [FieldName("Measurement", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Measurement
        {
            get { return _Measurement; }
            set { _Measurement = value; SetDirty("Measurement"); }
        }
        [FieldName("Quantity", FieldAccessMode.ReadWrite, FieldType.String)]
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; SetDirty("Quantity"); }
        }
        [FieldName("YearStart", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int YearStart
        {
            get { return _YearStart; }
            set { _YearStart = value; SetDirty("YearStart"); }
        }
        [FieldName("YearEnd", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int YearEnd
        {
            get { return _YearEnd; }
            set { _YearEnd = value; SetDirty("YearEnd"); }
        }
        [FieldName("Note", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; SetDirty("Note"); }
        }
        [FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int EnterpriseId
        {
            get { return _EnterpriseId; }
            set { _EnterpriseId = value; SetDirty("EnterpriseId"); }
        }
        [FieldName("IsProduct", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsProduct
        {
            get { return _IsProduct; }
            set { _IsProduct = value; SetDirty("IsProduct"); }
        }
        [FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int FuelId
        {
            get { return _FuelId; }
            set { _FuelId = value; SetDirty("FuelId"); }
        }

        [FieldName("MeasurementId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int MeasurementId
        {
            get { return _MeasurementId; }
            set { _MeasurementId = value; SetDirty("MeasurementId"); }
        }

        [FieldName("ProductOrder", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ProductOrder
        {
            get { return _ProductOrder; }
            set { _ProductOrder = value; SetDirty("ProductOrder"); }
        }

        [FieldName("NhietTriThap", FieldAccessMode.ReadWrite, FieldType.String)]
        public decimal NhietTriThap
        {
            get { return _NhietTriThap; }
            set { _NhietTriThap = value; SetDirty("NhietTriThap"); }
        }
        [FieldName("GroupFuel", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int GroupFuel
        {
            get { return _GroupFuel; }
            set { _GroupFuel = value; SetDirty("GroupFuel"); }
        } 
        [FieldName("ProductType13", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ProductType13
        {
            get { return _ProductType13; }
            set { _ProductType13 = value; SetDirty("ProductType13"); }
        }
        #endregion

    }
}
