using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
    public class Product
    {

        #region Constructor
        public Product()
        { }

        public Product(ProductBO productBO)
        {
            this.Id = productBO.Id;
            this.ProductName = productBO.ProductName;
            this.Measurement = productBO.Measurement;
            this.Quantity = productBO.Quantity;
            this.YearStart = productBO.YearStart;
            this.YearEnd = productBO.YearEnd;
            this.Note = productBO.Note;
            this.EnterpriseId = productBO.EnterpriseId;
            this.IsProduct = productBO.IsProduct;
            this.FuelId = productBO.FuelId;
            this.ProductOrder = productBO.ProductOrder;
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
        private int _Total;
        private int _FuelId;
        private int _ProductOrder;
        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public string Measurement
        {
            get { return _Measurement; }
            set { _Measurement = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public int YearStart
        {
            get { return _YearStart; }
            set { _YearStart = value; }
        }
        public int YearEnd
        {
            get { return _YearEnd; }
            set { _YearEnd = value; }
        }
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        public int EnterpriseId
        {
            get { return _EnterpriseId; }
            set { _EnterpriseId = value; }
        }
        public bool IsProduct
        {
            get { return _IsProduct; }
            set { _IsProduct = value; }
        }

        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public int FuelId
        {
            get { return _FuelId; }
            set { _FuelId = value; }
        }
        public int ProductOrder
        {
            get { return _ProductOrder; }
            set { _ProductOrder = value; }
        }

        #endregion Public Properties

    }
}
