using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ePower.Dao
{
    /// <summary>
    /// DbParameter
    /// </summary>
    public class DbParameter
    {
        private object _val;
		private string _paramterName;
		private bool _nText = false;
        private ParameterDirection _direction = ParameterDirection.Output;
		public DbParameter()
		{
		}
        public DbParameter(string parameterName, object val)
		{
			_paramterName = parameterName;
			_val = val;
		}
		/// <summary>
		/// Parameter name
		/// </summary>
		public string ParameterName
		{
			get
			{
				return _paramterName;
			}
			set
			{
				_paramterName  = value;
			}
		}
        /// <summary>
        /// Parameter Direction
        /// </summary>
        public ParameterDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }
		/// <summary>
		/// Parameter value
		/// </summary>
		public object Value
		{
			get
			{
				return _val;
			}
			set
			{
				_val  = value;
			}
		}
		/// <summary>
		/// Set parameter as Ntext or not
		/// </summary>
		public bool NText
		{
			get{return _nText;}
			set{_nText = value;}
		}
    }
}
