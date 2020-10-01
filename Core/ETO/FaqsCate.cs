using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class FaqsCate
    {
        #region "Private Members"
        int _FaqsCateID;

        int _FaqsCateParentID;
        string _FaqsCateName;
        int _FaqsCateOrder;
        string _Icon;
        string _Phone;
        string _Note;
        string _UserName;
        DateTime _Created;
        #endregion

        #region "Constructors"
        public FaqsCate()
        {
        }
        #endregion
        #region "Public Properties"
       

        public int FaqsCateID
        {
            get { return _FaqsCateID; }
            set { _FaqsCateID = value;  }
        }

        public int FaqsCateParentID
        {
            get { return _FaqsCateParentID; }
            set { _FaqsCateParentID = value;  }
        }

        public string FaqsCateName
        {
            get { return _FaqsCateName; }
            set { _FaqsCateName = value;  }
        }
        public int FaqsCateOrder
        {
            get { return _FaqsCateOrder; }
            set { _FaqsCateOrder = value;  }
        }

        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value;  }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value;  }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value;  }
        }

        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value;  }
        }

        #endregion
    }
}
