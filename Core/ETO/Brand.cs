using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Brand
    {
        public Brand() 
        {
            //constructor
        }

        private int brandid;
        public int BrandID 
        {
            get { return brandid; }
            set { brandid = value; }
        }

        private string brandname;
        public string BrandName 
        {
            get { return brandname; }
            set { brandname = value; }
        }
        private string image;
        public string Image 
        {
            get { return image; }
            set { image = value; }
        }

        private string shortdescribe;
        public string ShortDescribe 
        {
            get { return shortdescribe; }
            set { shortdescribe = value; }
        }
        private string brandurl;
        public string BrandUrl 
        {
            get { return brandurl; }
            set { brandurl = value; }
        }
        private string language;
        public string Language 
        {
            get { return language; }
            set { language = value; }
        }
    }
}
