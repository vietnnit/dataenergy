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
	public class TOEYearService
	{

TOEYearDao toeyearDao = new TOEYearDao();
	public int Insert(TOEYear obj)
	{
		TOEYearBO toeyearBO = new TOEYearBO(obj);
		return toeyearDao.Insert(toeyearBO);
	}
	public TOEYear Update(TOEYear obj)
	{
		TOEYearBO toeyearBO = new TOEYearBO(obj);
		toeyearDao.Update(toeyearBO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return toeyearDao.Delete(_Id);
	}
	public TOEYear FindByKey(int _Id)
	{
		return new TOEYear(toeyearDao.FindByKey(_Id));
	}
	public IList<TOEYear> FindAll()
	{
		IList<TOEYear> list = new List<TOEYear>();
		IList<TOEYearBO> listBO = new List<TOEYearBO>();
		listBO = toeyearDao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (TOEYearBO obj in listBO)
			list.Add(new TOEYear(obj));
		 return list;
	}

	}
}
