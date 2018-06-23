using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace dbConnection

{
    public class dbconnection
    {  

        private SqlDataAdapter myAdapter;
        private SqlConnection conn;


        public dbconnection ()
        { 
            myAdapter = new SqlDataAdapter();
           // string str = ConfigurationManager.AppSettings("ConnectionStr");
            conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=THUVIEN;Integrated Security=True");
            
        }

        public SqlConnection  openConnection ()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)

            {
                conn.Open(); 
            }

            return conn; 
        
        }
        public void closeConnection ()
        {
            if (conn.State == ConnectionState.Open )

            {
                conn.Close(); 
            }

            
        
        }


        public DataTable excuteNonQuery(string query ,SqlParameter [] parm )
        {
           DataTable datatable=  new DataTable(); 
           //    datatable=null; 
            SqlCommand comm= new SqlCommand ();

            comm.Connection = openConnection();
            comm.CommandText = query;
            comm.Parameters.AddRange(parm);

            comm.ExecuteNonQuery(); 


            myAdapter.SelectCommand = comm;
         
            myAdapter.Fill(datatable);
            return datatable  ; 

        }

        public void excuteNonQuery2(string query, SqlParameter[] parm)
        {
            DataTable datatable = new DataTable();
            //    datatable=null; 
            SqlCommand comm = new SqlCommand();

            comm.Connection = openConnection();
            comm.CommandText = query;
            comm.Parameters.AddRange(parm);

            comm.ExecuteNonQuery();

        }

    }
}
 