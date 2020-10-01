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
	public class RegionService
	{

RegionDao regionDao = new RegionDao();
	public int Insert(Region obj)
	{
		RegionBO regionBO = new RegionBO(obj);
		return regionDao.Insert(regionBO);
	}
	public Region Update(Region obj)
	{
		RegionBO regionBO = new RegionBO(obj);
		regionDao.Update(regionBO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return regionDao.Delete(_Id);
	}
	public Region FindByKey(int _Id)
	{
		return new Region(regionDao.FindByKey(_Id));
	}
	public IList<Region> FindAll()
	{
		IList<Region> list = new List<Region>();
		IList<RegionBO> listBO = new List<RegionBO>();
		listBO = regionDao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (RegionBO obj in listBO)
			list.Add(new Region(obj));
		 return list;
	}

	}
}
