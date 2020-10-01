using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;
using ePower.DE.Dao;

namespace ePower.DE.Service
{
	public class TOEService
	{

TOEDao toeDao = new TOEDao();
	public int Insert(TOE obj)
	{
		TOEBO toeBO = new TOEBO(obj);
		return toeDao.Insert(toeBO);
	}
	public TOE Update(TOE obj)
	{
		TOEBO toeBO = new TOEBO(obj);
		toeDao.Update(toeBO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return toeDao.Delete(_Id);
	}
	public TOE FindByKey(int _Id)
	{
		return new TOE(toeDao.FindByKey(_Id));
	}
	public IList<TOE> FindAll()
	{
		IList<TOE> list = new List<TOE>();
		IList<TOEBO> listBO = new List<TOEBO>();
		listBO = toeDao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (TOEBO obj in listBO)
			list.Add(new TOE(obj));
		 return list;
	}

	}
}
