using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Picture
    {
        public Picture() 
        {
            //constructor
        }

        private int pictureid;
        public int PictureID 
        {
            get { return pictureid; }
            set { pictureid = value; }
        }

        private int productid;
        public int ProductID
        {
            get { return productid; }
            set { productid = value; }
        }

        private string picturethumb;
        public string PictureThumb
        {
            get { return picturethumb; }
            set { picturethumb = value; }
        }

        private string picturelarge;
        public string PictureLarge
        {
            get { return picturelarge; }
            set { picturelarge = value; }
        }

        private int orders;
        public int Orders
        {
            get { return orders; }
            set { orders = value; }
        }
    }
}
