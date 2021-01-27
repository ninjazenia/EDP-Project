<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="payment1.aspx.cs" Inherits="EDP_Project.payment" clientSecret%>
	
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>pay </h1>

    <form id="paymentform" runat="server" method="post" >
        <input type="text" id="name" value ="yes" />
        <asp:Label ID="Label2" runat="server" Text="Payment: $40"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		<div id ="card-element"> </div>
        <asp:Button ID="Button1" runat="server" Text="Pay" />

    </form>
    <script src="https://js.stripe.com/v3/"></script>

	<script>	
        document.addEventListener('DOMContentLoaded', function (e) {
            var stripe = Stripe('pk_test_51IAVthJ6RWPYSKZYYTelkoRgbUzSUnAX1VZSFA0E6rawA752a1orGzs2s9Cfz4vYUuUJs4sDj604ORfP6yRI7vSo00cByJcIqn')
            //setting up elements
            var elements = stripe.elements();
            var cardElement = elements.create('card');
            var client = "<%= clientSecret %>";
           
            cardElement.mount('#card-element');

            var nameinput = document.getElementById("name");
            //form
            var form = document.getElementById("paymentform");
            form.addEventListener("submit", function (e) {

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
                        form.submit();
                    }
                })
            })
        });
    </script>
</asp:Content>
