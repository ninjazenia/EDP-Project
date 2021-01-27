using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EDP_Project.ServiceReference1;

namespace EDP_Project
{
    public partial class AddAttractions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
     

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            bool validInput = true;
            string image = "";

            if (validInput)
            {
                if (FileUpload1.HasFile == true)
                {
                    image = "Images\\" + FileUpload1.FileName;
                }

                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                int result = client.CreateAttractions(tbID.Text, tbName.Text, tbDescription.Text, decimal.Parse(tbunitprice.Text), FileUpload1.FileName);
                if (result == 1)
                {
                    string saveimg = Server.MapPath(" ") + "\\" + image;
                    lbl_Result.Text = saveimg.ToString();
                    FileUpload1.SaveAs(saveimg);
                    lbMsg.Text = "Attraction Record Inserted Successfully!";
                }
                else
                    lbMsg.Text = "SQL Error. Insert Unsuccessful!";
            }
        }
    }
}