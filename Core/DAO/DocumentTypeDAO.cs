using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePower.Core;
using ePower.Dao;
using ETO;

namespace DAO
{
    public class DocTypeDao : EntityDao<DocTypeBO>
    {
        #region "Function Common"
        public IList<DocTypeBO> FindAll()
        {
            IList<DocTypeBO> list;
            try
            {
                list = base.FindAll();

            }
            catch (Exception ex)
            {
                return null;
            }
            return list;
        }

       
        #endregion
    }
}

