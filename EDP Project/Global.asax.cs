using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;
using Stripe;

namespace EDP_Project
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StripeConfiguration.ApiKey = "sk_test_51IAVthJ6RWPYSKZYut1oaWsFKMKUQmZMAZmGaeSx2lNsLM0Z2Wiqp4jNxXh7VYg128OznjhB0Dc5ekEpsuZqO1SR00Rt4BaH4C";
        }
    }
}