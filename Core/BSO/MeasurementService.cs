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
	public class MeasurementService
	{

MeasurementDao measurementDao = new MeasurementDao();
	public int Insert(Measurement obj)
	{
		MeasurementBO measurementBO = new MeasurementBO(obj);
		return measurementDao.Insert(measurementBO);
	}
	public Measurement Update(Measurement obj)
	{
		MeasurementBO measurementBO = new MeasurementBO(obj);
		measurementDao.Update(measurementBO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return measurementDao.Delete(_Id);
	}
	public Measurement FindByKey(int _Id)
	{
		return new Measurement(measurementDao.FindByKey(_Id));
	}
	public IList<Measurement> FindAll()
	{
		IList<Measurement> list = new List<Measurement>();
		IList<MeasurementBO> listBO = new List<MeasurementBO>();
		listBO = measurementDao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (MeasurementBO obj in listBO)
			list.Add(new Measurement(obj));
		 return list;
	}

	}
}
