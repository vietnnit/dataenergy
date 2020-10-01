<%@ WebHandler Language="C#" Class="ImageHandler" %>

 using System;
 using System.Drawing;
 using System.Drawing.Imaging;
 using System.IO;
 using System.Web;
 using System.Web.Caching;
 using System.Net;

public class ImageHandler : IHttpHandler
{
    public int _width;
    public int _height;
    public static string noImageUrl = @"images\no_photo.jpg";
    public string imageURL;

    
    public void ProcessRequest(HttpContext context)
    {
        Bitmap bitOutput;

        if (context.Cache[("ImageQueryURL-" + context.Request.QueryString.ToString())] != null)
        {
            bitOutput = (Bitmap)context.Cache[("ImageQueryURL-" + context.Request.QueryString.ToString())];
        }
        else
        {
            Bitmap bitInput = GetImage(context);

            bitInput = RotateFlipImage(context, bitInput);

            if (SetHeightWidth(context, bitInput))
            { bitOutput = ResizeImage(bitInput, _width, _height); }
            else { bitOutput = bitInput; }

            context.Response.ContentType = "image/jpeg";
            bitOutput.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //bitInput.s

            //Save Cache img
            string appPath = context.Server.MapPath(context.Request.ApplicationPath) + Path.DirectorySeparatorChar;

            if (String.IsNullOrEmpty(context.Request.QueryString["url"]))
            {
                appPath += noImageUrl;
            }
            else
            {
                if (System.IO.File.Exists((appPath + context.Request.QueryString["url"])))
                {
                    appPath += context.Request.QueryString["url"];
                }
                else
                {
                    appPath += noImageUrl;
                }
            }

            string imgPath = context.Server.MapPath(context.Request.ApplicationPath) + "/Upload/NewsImgCache/";  //Path.DirectorySeparatorChar;
            string strRealname = Path.GetFileNameWithoutExtension(appPath);
            string exts = Path.GetExtension(appPath);
            if (!System.IO.File.Exists(imgPath + strRealname + "_w" + _width + exts))
                bitOutput.Save(imgPath + strRealname + "_w" + _width + exts, System.Drawing.Imaging.ImageFormat.Jpeg);
            

            context.Cache.Insert(("ImageQueryURL-" + context.Request.QueryString.ToString()), bitOutput, new CacheDependency(imageURL), Cache.NoAbsoluteExpiration, TimeSpan.FromHours(8), System.Web.Caching.CacheItemPriority.BelowNormal, null);
            
        }

        context.Response.ContentType = "image/jpeg";
        bitOutput.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        return;        
    }
    

    /// <summary>
    /// Get the image requested via the query string. 
    /// </summary>
    /// <param name="context"></param>
    /// <returns>Return the requested image or the "no image" default if it does not exist.</returns>
    public Bitmap GetImage(HttpContext context)
    {
        if (context.Cache[("ImagePath-" + context.Request.QueryString["url"])] == null) 
        {
            //string appPath = context.Server.MapPath(context.Request.ApplicationPath) + Path.DirectorySeparatorChar;

            //if (String.IsNullOrEmpty(context.Request.QueryString["url"]))
            //{
            //    appPath += noImageUrl;
            //}
            //else
            //{
            //    if (System.IO.File.Exists((appPath + context.Request.QueryString["url"])))
            //    {
            //        appPath += context.Request.QueryString["url"];
            //    }
            //    else
            //    {
            //        appPath += noImageUrl;
            //    }
            //}

            //Step 2: Load data image from url;
            string url = "";
            url = context.Request.QueryString["url"];
            Stream mystream;

            HttpWebRequest wreq;
            HttpWebResponse wresp;

            wreq = (HttpWebRequest)WebRequest.Create(url);
            wreq.AllowWriteStreamBuffering = true;
            wreq.Timeout = 6000; // =6s //set timeout download images from server other

            wresp = (HttpWebResponse)wreq.GetResponse();

            System.Drawing.Bitmap bitOutput = null;
            if ((mystream = wresp.GetResponseStream()) != null)
            {
                bitOutput = new Bitmap(mystream);
            }
            

            //Bitmap bitOutput;
            //imageURL = appPath;

        
            //bitOutput = new Bitmap(appPath);
            
            context.Cache.Insert(("ImagePath-" + context.Request.QueryString["url"]), bitOutput, new CacheDependency(imageURL), Cache.NoAbsoluteExpiration, TimeSpan.FromHours(8), System.Web.Caching.CacheItemPriority.BelowNormal, null);
            return bitOutput;
        }
        else
        {
            return (Bitmap)context.Cache[("ImagePath-" + context.Request.QueryString["url"])];
        }
    }    
    

    /// <summary>
    /// Set the height and width of the handler class.
    /// </summary>
    /// <param name="context">The context to get the query string parameters, typically current context.</param>
    /// <param name="bitInput">The bitmap that determines the </param>
    /// <returns>True if image needs to be resized, false if original dimensions can be kept.</returns>
    public bool SetHeightWidth(HttpContext context, Bitmap bitInput)
    {
        double inputRatio = Convert.ToDouble(bitInput.Width) / Convert.ToDouble(bitInput.Height);
        
        if (!(String.IsNullOrEmpty(context.Request["w"])) && !(String.IsNullOrEmpty(context.Request["h"])))
        {
            _width = Int32.Parse(context.Request["w"]);
            _height = Int32.Parse(context.Request["h"]);
            return true;
        }
        else if (!(String.IsNullOrEmpty(context.Request["w"])))
        {
            _width = Int32.Parse(context.Request["w"]);
            _height = Convert.ToInt32( (_width / inputRatio));
            return true;
        }
        else if (!(String.IsNullOrEmpty(context.Request["h"])))
        {
            _height = Int32.Parse(context.Request["h"]);
            _width = Convert.ToInt32((_height * inputRatio));
            return true;
        }
        else
        {
            _height = bitInput.Height;
            _width = bitInput.Width;
            return false;
        }
    }

    /// <summary>
    /// Flip or rotate the bitmap according to the query string parameters.
    /// </summary>
    /// <param name="context">The context of the query string parameters.</param>
    /// <param name="bitInput">The bitmap to be flipped or rotated.</param>
    /// <returns>The bitmap after it has been flipped or rotated.</returns>
    public Bitmap RotateFlipImage(HttpContext context, Bitmap bitInput)
    {
        Bitmap bitOut = bitInput;
        
        if (String.IsNullOrEmpty(context.Request["RotateFlip"]))
        {
            return bitInput;
        }
        else if (context.Request["RotateFlip"] == "Rotate180flipnone")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }
        else if (context.Request["RotateFlip"] == "Rotate180flipx")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate180FlipX);
        }
        else if (context.Request["RotateFlip"] == "Rotate180flipxy")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate180FlipXY);
        }
        else if (context.Request["RotateFlip"] == "Rotate180flipy")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate180FlipY);
        }
        else if (context.Request["RotateFlip"] == "Rotate270flipnone")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }
        else if (context.Request["RotateFlip"] == "Rotate270flipx")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate270FlipX);
        }
        else if (context.Request["RotateFlip"] == "Rotate270FlipXY")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate270FlipXY);
        }
        else if (context.Request["RotateFlip"] == "Rotate270FlipY")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate270FlipY);
        }
        else if (context.Request["RotateFlip"] == "Rotate90FlipNone")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
        else if (context.Request["RotateFlip"] == "Rotate90FlipX")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate90FlipX);
        }
        else if (context.Request["RotateFlip"] == "Rotate90FlipXY")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate90FlipXY);
        }
        else if (context.Request["RotateFlip"] == "Rotate90FlipY")
        {
            bitOut.RotateFlip(RotateFlipType.Rotate90FlipY);
        }
        else if (context.Request["RotateFlip"] == "RotateNoneFlipX")
        {
            bitOut.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
        else if (context.Request["RotateFlip"] == "RotateNoneFlipXY")
        {
            bitOut.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        }
        else if (context.Request["RotateFlip"] == "RotateNoneFlipY")
        {
            bitOut.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }
        else { return bitInput; }

        return bitOut;
    }


    /// <summary>
    /// Resizes bitmap using high quality algorithms.
    /// </summary>
    /// <param name="originalBitmap"></param>
    /// <param name="newWidth">The width of the returned bitmap.</param>
    /// <param name="newHeight">The height of the returned bitmap.</param>
    /// <returns>Resized bitmap.</returns>
    public static Bitmap ResizeImage(Bitmap originalBitmap, int newWidth, int newHeight)
    {
        Bitmap inputBitmap = originalBitmap;
        Bitmap resizedBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

        Graphics g = Graphics.FromImage(resizedBitmap);
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        Rectangle rectangle = new Rectangle(0, 0, newWidth, newHeight);
        g.DrawImage(inputBitmap, rectangle, 0, 0, inputBitmap.Width, inputBitmap.Height, GraphicsUnit.Pixel);
        g.Dispose();

        return resizedBitmap;
    }


    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}