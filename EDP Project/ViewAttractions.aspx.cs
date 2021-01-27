using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EDP_Project.ServiceReference1;

namespace EDP_Project
{
    public partial class ViewAttractions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }
        private void RefreshGridView()
        {
            List<Attractions> aList = new List<Attractions>();

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            //List<Attractions> eList = new List<Attr    ons>((IEnumerable<Attractions>)client.SelectAttractionsAll());

            aList = client.SelectAttractionsAll()?.ToList<Attractions>();
            //List<Attractions> a = new List<Attractions>();
            if (aList != null)
            {
                gvAttractions.Visible = true;
                gvAttractions.DataSource = aList;
                gvAttractions.DataBind();
            }
            else
            {
                gvAttractions.Visible = false;
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAttractions.aspx");
        }
        protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row.
            GridViewRow row = gvAttractions.SelectedRow;

            // Get Product ID from the selected row, which is the 
            // first row, i.e. index 0.
            string prodID = row.Cells[0].Text;

            // Redirect to next page, with the Product Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("payment.aspx" );

        }
        protected void Buy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("Buy") == 0 )
            {
                Response.Redirect("payment.aspx");
            }
        }
    }
}