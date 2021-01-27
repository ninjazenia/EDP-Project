using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyDBService.Entity
{
    public class Attractions
    {
        public string _ID { get; set; }
        public string _Name { get; set; }
        public string _Desc { get; set; }
        public decimal _unitPrice { get; set; }
        public string _Image { get; set; }


        // Default constructor
        public Attractions()
        {

        }

        // Constructor that take in all data required to build a Product object
        public Attractions(string ID, string Name, string Desc,
                       decimal unitPrice, string Image)
        {
            _ID = ID;
            _Name = Name;
            _Desc = Desc;
            _unitPrice = unitPrice;
            _Image = Image;
        }

        // Constructor that take in all except product ID
        //public Attractions(string prodName, string prodDesc,
        /*               decimal unitPrice, string prodImage, int stockLevel)
                    : this(null, prodName, prodDesc, unitPrice, prodImage, stockLevel)
                {
                }

                // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
                public Attractions(string prodID)
                    : this(prodID, "", "", 0, "", 0)
                {
                }*/

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.




        //Below as the Class methods for some DB operations. 

        //public int ProductInsert()
        //{

        //}//end Insert

        //public int ProductDelete(decimal ID)
        //{

        //}//end Delete

        //public int ProductUpdate(string pId, string pName, decimal pUnitPrice)
        //{

        //}//end Update



        public int Insert()
        {

            // string msg = null;

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "INSERT INTO Attractions(Id,name,description,price,image) "
                + " values (@para_ID,@para_Name, @para_Desc, @para_unitPrice, @para_Image)";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@para_ID", _ID);
            sqlCmd.Parameters.AddWithValue("@para_Name", _Name);
            sqlCmd.Parameters.AddWithValue("@para_Desc", _Desc);
            sqlCmd.Parameters.AddWithValue("@para_unitPrice", _unitPrice);
            sqlCmd.Parameters.AddWithValue("@para_Image", _Image);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
        public Attractions GetAttractions(string ID)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Attractions where Id = @para_ID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@para_ID", ID);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Attractions emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string name = row["name"].ToString();
                string desc = row["desc"].ToString();
                string price = row["price"].ToString();
                decimal pay = Convert.ToDecimal(price);
                string image = row["image"].ToString();
                emp = new Attractions(ID, name, desc, pay, image);
            }
            return emp;
        }
        public List<Attractions> GetAttractionsAll()
        {


            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from Attractions";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            List<Attractions> empList = new List<Attractions>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string ID = row["Id"].ToString();
                string name = row["name"].ToString();
                string desc = row["description"].ToString();
                string price = row["price"].ToString();
                decimal pay = Convert.ToDecimal(price);
                string image = row["image"].ToString();
                Attractions obj = new Attractions(ID, name, desc, pay, image);
                empList.Add(obj);

            }
            return empList;
        }
    }
}
