using System;
using System.Collections.Generic;
using System.Text;
using ETO;
using DAO;
namespace BSO
{
    public class ConfigBSO
    {
        public ConfigBSO() 
        {
            //contrustor
        }

        #region GetAllConfig
        public Config GetAllConfig(string language) 
        {
            ConfigDAO configDAO = new ConfigDAO();
            return configDAO.GetAllConfig(language);
        }
        #endregion

        #region UpdateConfig
        public void UpdateConfig(Config config) 
        {
            ConfigDAO configDAO = new ConfigDAO();
            configDAO.UpdateConfig(config);
        }
        #endregion
    }
}
