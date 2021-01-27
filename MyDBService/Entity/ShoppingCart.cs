using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDBService.Entity
{
    public class ShoppingCart
    {
        public string _ItemID { get; set; }
        public string _ItemName { get; set; }
        public string _ItemDesc { get; set; }
        public decimal _ItemPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public ShoppingCart()
        {

        }

        public ShoppingCart(string ID, string Name, string Desc,
                       decimal unitPrice)
        {
            _ItemID = ID;
            _ItemName = Name;
            _ItemDesc = Desc;
            _ItemPrice = unitPrice;
            TotalPrice = TotalPrice();

        }
        public decimal TotalPrice()
        {
            return _ItemPrice * Quantity; 
        }


        public int Insert()
        {

            // string msg = null;

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "INSERT INTO ShoppingCart(Id,name,description,price) "
                + " values (@para_ID,@para_Name, @para_Desc, @para_unitPrice";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@para_ID", _ItemID);
            sqlCmd.Parameters.AddWithValue("@para_Name", _ItemName);
            sqlCmd.Parameters.AddWithValue("@para_Desc", _ItemDesc);
            sqlCmd.Parameters.AddWithValue("@para_unitPrice", _ItemPrice);
            

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
        public ShoppingCart GetCartItems(string ID)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from ShoppingCart where Id = @para_ID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@para_ID", ID);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            ShoppingCart emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string name = row["name"].ToString();
                string desc = row["desc"].ToString();
                string price = row["price"].ToString();
                decimal pay = Convert.ToDecimal(price);
                emp = new ShoppingCart(ID, name, desc, pay);
            }
            return emp;
        }
        public List<ShoppingCart> GetAllCartItems()
        {


            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from ShoppingCart";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            List<ShoppingCart> empList = new List<ShoppingCart>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string ID = row["Id"].ToString();
                string name = row["name"].ToString();
                string desc = row["description"].ToString();
                string price = row["price"].ToString();
                decimal pay = Convert.ToDecimal(price);
                ShoppingCart obj = new ShoppingCart(ID, name, desc, pay);
                empList.Add(obj);

            }
            return empList;
        }


    }
}
