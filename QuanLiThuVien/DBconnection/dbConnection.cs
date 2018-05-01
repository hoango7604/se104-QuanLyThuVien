using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;




namespace DBconnection
{
    public class dbConnection
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn; 


        public dbConnection () {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStr"]);


            }

        public SqlConnection  openConnection ()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)

            {
                conn.Open(); 
            }

            return conn; 
        
        }


        public DataTable excuteNonQuery(string query ,SqlParameter [] parm )
        {
           DataTable datatable=  new DataTable(); 
               datatable=null; 
            SqlCommand comm= new SqlCommand ();

            comm.Connection = openConnection();
            comm.CommandText = query;
            comm.Parameters.AddRange(parm);
            comm.ExecuteNonQuery(); 


            myAdapter.SelectCommand = comm;
            myAdapter.Fill(datatable); 


          


            return datatable  ; 

        }

    }
}
