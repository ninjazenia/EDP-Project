<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="EDP_assignment.payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="https://js.stripe.com/v3/"></script>
	<script>	
        document.addEventListener('DOMContentLoaded', function (e) {
            var stripe = Stripe('pk_test_51IAVthJ6RWPYSKZYYTelkoRgbUzSUnAX1VZSFA0E6rawA752a1orGzs2s9Cfz4vYUuUJs4sDj604ORfP6yRI7vSo00cByJcIqn')
            //setting up elements
            var elements = stripe.elements();
            var cardElement = elements.create('card');
            cardElement.mount('#card-element');
            var client = "<%= clientSecret %>";

            var nameinput = document.getElementById("name");
            //form
            var form = document.getElementById("paymentform");
            form.addEventListener("submit", function (e){
                e.preventDefault();
                //token payment
                stripe.confirmCardPayment(
                    client,
                    {
                        payment_method: {
                            card: cardElement,
                            billing_details: {
                                name: "yes"
                            }
                        }
                    }
                ).then(function (result) {
                    if (result.error) {
                        alert(result.error.message);
                    } else {
                        console.log("successful payment");
                        document.getElementById("p1").innerHTML = "payment confirmed";
                        form.submit();
                        
                    }
                })
            })
        });
    </script>

 
</head>
<body>
    <h1>Payment Form </h1>
    
    <form id="paymentform" runat="server" method="post" >
        <p id ="p1"> Price: $40</p>
        <input type="text" id="name" value ="yes" />

		<div id ="card-element"> </div>
        <asp:Button ID="Button1" runat="server" Text="Pay" />

    </form>
</body>
</html>
