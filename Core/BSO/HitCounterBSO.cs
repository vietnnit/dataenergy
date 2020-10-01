using System;
using System.Collections.Generic;
using System.Text;
using ETO;
using DAO;
namespace BSO
{
    public class HitCounterBSO
    {
        public HitCounterBSO() 
        {
            //contrustor
        }

        #region UpdateHitCounter
        public void UpdateHitCounter(long hitcounter) 
        {
            HitCounterDAO hitcounterDAO = new HitCounterDAO();
            hitcounterDAO.UpdateHitCounter(hitcounter);
        }
        #endregion

        #region GetHitCounter
        public long GetHitCounter() 
        {
            HitCounterDAO hitcounterDAO = new HitCounterDAO();
            HitCounter hitcounter =  hitcounterDAO.GetHitCounter();
            return hitcounter.SiteHitCounter;
        }
        #endregion
    }
}
