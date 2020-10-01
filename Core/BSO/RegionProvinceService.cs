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
	public class RegionProvinceService
	{

RegionProvinceDao regionprovinceDao = new RegionProvinceDao();
	public int Insert(RegionProvince obj)
	{
		RegionProvinceBO regionprovinceBO = new RegionProvinceBO(obj);
		return regionprovinceDao.Insert(regionprovinceBO);
	}
	public RegionProvince Update(RegionProvince obj)
	{
		RegionProvinceBO regionprovinceBO = new RegionProvinceBO(obj);
		regionprovinceDao.Update(regionprovinceBO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return regionprovinceDao.Delete(_Id);
	}
	public RegionProvince FindByKey(int _Id)
	{
		return new RegionProvince(regionprovinceDao.FindByKey(_Id));
	}
	public IList<RegionProvince> FindAll()
	{
		IList<RegionProvince> list = new List<RegionProvince>();
		IList<RegionProvinceBO> listBO = new List<RegionProvinceBO>();
		listBO = regionprovinceDao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (RegionProvinceBO obj in listBO)
			list.Add(new RegionProvince(obj));
		 return list;
	}

	}
}
