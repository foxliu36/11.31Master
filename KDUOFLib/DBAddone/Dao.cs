using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HMI
{
    public class Dao
    {
        //第一：連結SQL資料庫
        SqlConnection con = new SqlConnection();

        SqlDataAdapter sda = new SqlDataAdapter();

        public Dao() {
            con.ConnectionString = "Data Source = 172.26.100.8;Initial Catalog=KDGAS;User ID=sa;Password=hp1020.;";
        }

        public Dao(string p_CString) 
        {
            con.ConnectionString = p_CString;
        }
        //查詢
        public DataTable Query(string command) {

            try {
                DataSet ds = new DataSet();
                con.Open();
                string sqlstr = command;
                        
                sda.SelectCommand = new SqlCommand(sqlstr, con);

                sda.Fill(ds);
                con.Close();
                return ds.Tables[0];
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        //修改(新刪修)
        public void ExcuteNonQuery(string command) {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection.Open();
                cmd.CommandText = command;

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
