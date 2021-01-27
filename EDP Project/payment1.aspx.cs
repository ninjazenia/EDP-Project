using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Project
{
    public partial class payment : System.Web.UI.Page
    {
        public string clientSecret = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = 4000,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>
                    {
                        "card",
                    },
                };
                var service = new PaymentIntentService();
                var paymentIntent = service.Create(options);
                clientSecret = paymentIntent.ClientSecret;

            }
            else;
            {

            }



            //  continue your regular Page_load() processing...
        }
    }
}