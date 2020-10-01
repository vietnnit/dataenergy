<%@ Application Language="C#" %>

<script runat="server">

    
    void Application_Start(object sender, EventArgs e)
    {
        log4net.Config.XmlConfigurator.Configure();
        //long SiteHitCounter = 100;
        //long CurrentUsers = 10;

        //WebHitCounter webhitcounter = new WebHitCounter();
        //SiteHitCounter = webhitcounter.GetHitCounter();

        //Application["SiteHitCounter"] = SiteHitCounter;
        //Application["CurrentUsers"] = CurrentUsers;

    }

    void Application_End(object sender, EventArgs e)
    {
        //WebHitCounter webhitcounter = new WebHitCounter();
        //webhitcounter.UpdateHitCounter((int)Application["SiteHitCounter"]);

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        Session.Timeout = 10;
        //Application.Lock();
        //Application["SiteHitCounter"] = Convert.ToInt32(Application["SiteHitCounter"]) + 1;
        //Application["CurrentUsers"] = Convert.ToInt32(Application["CurrentUsers"]) + 1;
        //Application.UnLock();

        //WebHitCounter webhitcounter = new WebHitCounter();
        //webhitcounter.UpdateHitCounter(Convert.ToInt32(Application["SiteHitCounter"]));

        //long SiteHitCounter = 100;

        //WebHitCounter webhitcounter = new WebHitCounter();
        //SiteHitCounter = webhitcounter.GetHitCounter();

        //webhitcounter.UpdateHitCounter(SiteHitCounter + 1);

    }

    void Session_End(object sender, EventArgs e)
    {

        //Application.Lock();

        //Application["CurrentUsers"] = Convert.ToInt32(Application["CurrentUsers"]) - 1;

        //Application.UnLock();
    }
       
</script>
