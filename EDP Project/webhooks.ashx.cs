using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Stripe;

namespace EDP_Project
{
    /// <summary>
    /// Summary description for webhooks
    /// </summary>
    public class webhooks : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var endpointSecret = "whsec_K3lU5YpmMluiFskTy0hhEplPp8QDA16t";
            var json = new StreamReader(context.Request.InputStream).ReadToEnd();
            var signature = context.Request.Headers["Stripe-Signature"];
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    signature,
                    endpointSecret
                );
                switch (stripeEvent.Type)
                {
                    case Events.PaymentIntentSucceeded:
                        var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                        Console.WriteLine($"Payment succeeded {paymentIntent.Id} for ${paymentIntent.Amount}");
                        break;

                    default:
                        Console.WriteLine($"Got event {stripeEvent.Type}");
                        break;
                }

            }
            catch (StripeException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}