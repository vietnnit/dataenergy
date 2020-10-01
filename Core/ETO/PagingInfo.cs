using System;

namespace ETO
{
	/// <summary>
	/// Represents a class to paging a list of result objects.
	/// </summary>
	public class PagingInfo
	{
		#region "fields"
		private long _pageSize=50;
		private long _currentPage;
		private long _rowsCount;
		// instance of PagingInfo that no paging
		private static PagingInfo _noPaging = new PagingInfo(0, 0);
		#endregion

		#region "properties"
		/// <summary>
		/// Number of objects per page.
		/// </summary>
		public long PageSize
		{
			get { return this._pageSize; }
		}

		/// <summary>
		/// Current page index.
		/// </summary>
		public long CurrentPage
		{
			get { return this._currentPage; }
		}

		/// <summary>
		/// Number of total rows.
		/// </summary>
		public long RowsCount
		{
			get { return this._rowsCount; }
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException("RowsCount");
				this._rowsCount = value;
			}
		}

		/// <summary>
		/// Number of total pages.
		/// </summary>
		public long PagesCount
		{
			get { return (long) Math.Ceiling((double) this._rowsCount / (double) this._pageSize); }
		}

		/// <summary>
		/// No paging.
		/// </summary>
		public static PagingInfo All
		{
			get { return _noPaging; }
		}
		#endregion

		/// <summary>
		/// Initialize a new instance of PagingInfo class.
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="currentPage"></param>
		public PagingInfo(long pageSize, long currentPage)
		{
            //this._pageSize = pageSize;
            this._currentPage = currentPage;
		}
        public PagingInfo(long pageSize, long currentPage,bool _size)
        {
            if (_size)
            {
                this._pageSize = pageSize;
            }
            this._currentPage = currentPage;
        }
		/// <summary>
		/// Returns a <b>string</b> that represents the current PagingInfo object.
		/// </summary>
		/// <returns>A <b>string</b> that represents the current PagingInfo object.</returns>
		public override string ToString()
		{
			return string.Format("PagingInfo [PageSize={0}, CurrentPage={1}, RowsCount={2}]",
				this._pageSize, this._currentPage, this._rowsCount);
		}
	}
}
