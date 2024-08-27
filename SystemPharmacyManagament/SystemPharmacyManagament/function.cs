using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SystemPharmacyManagament
{
    class function
    {
        protected  SqlConnection getConnection()
        {
            //step 1
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NGUYEN NHAT HUYNH\OneDrive\Tài liệu\pharmacy.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source = Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\NGUYEN NHAT HUYNH\\OneDrive\\Tài liệu\\pharmacy.mdf;Integrated Security=True;Connect Timeout=30";
            //return con;


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DUY\Documents\duy.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFilename =C:\Users\NGUYEN NHAT HUYNH\OneDrive\Tài liệu\pharmacy.mdf; Integrated Security=True;Connect Timeout = 30");
            return con;
        }

        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query, String msg)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
