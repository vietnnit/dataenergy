using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class HitCounter
    {
        public HitCounter() 
        {
            //contrustor
        }

        private long hitcounter;
        public long SiteHitCounter 
        {
            set { hitcounter = value; }
            get { return hitcounter; }
        }
    }
}
