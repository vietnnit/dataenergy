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
	public class GroupFuelService
	{

GroupFuelDao groupfuelDao = new GroupFuelDao();
	public int Insert(GroupFuel obj)
	{
		GroupFuelBO groupfuelBO = new GroupFuelBO(obj);
		return groupfuelDao.Insert(groupfuelBO);
	}
	public GroupFuel Update(GroupFuel obj)
	{
		GroupFuelBO groupfuelBO = new GroupFuelBO(obj);
		groupfuelDao.Update(groupfuelBO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return groupfuelDao.Delete(_Id);
	}
	public GroupFuel FindByKey(int _Id)
	{
		return new GroupFuel(groupfuelDao.FindByKey(_Id));
	}
	public IList<GroupFuel> FindAll()
	{
		IList<GroupFuel> list = new List<GroupFuel>();
		IList<GroupFuelBO> listBO = new List<GroupFuelBO>();
		listBO = groupfuelDao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (GroupFuelBO obj in listBO)
			list.Add(new GroupFuel(obj));
		 return list;
	}

	}
}
