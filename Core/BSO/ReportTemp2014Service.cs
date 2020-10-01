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
	public class ReportTemp2014Service
	{

ReportTemp2014Dao reporttemp2014Dao = new ReportTemp2014Dao();
	public int Insert(ReportTemp2014 obj)
	{
		ReportTemp2014BO reporttemp2014BO = new ReportTemp2014BO(obj);
		return reporttemp2014Dao.Insert(reporttemp2014BO);
	}
	public ReportTemp2014 Update(ReportTemp2014 obj)
	{
		ReportTemp2014BO reporttemp2014BO = new ReportTemp2014BO(obj);
		reporttemp2014Dao.Update(reporttemp2014BO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return reporttemp2014Dao.Delete(_Id);
	}
	public ReportTemp2014 FindByKey(int _Id)
	{
		return new ReportTemp2014(reporttemp2014Dao.FindByKey(_Id));
	}
	public IList<ReportTemp2014> FindAll()
	{
		IList<ReportTemp2014> list = new List<ReportTemp2014>();
		IList<ReportTemp2014BO> listBO = new List<ReportTemp2014BO>();
		listBO = reporttemp2014Dao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (ReportTemp2014BO obj in listBO)
			list.Add(new ReportTemp2014(obj));
		 return list;
	}

	}
}
