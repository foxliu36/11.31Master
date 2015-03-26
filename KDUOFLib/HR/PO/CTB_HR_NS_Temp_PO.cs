using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_NS_Temp_PO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_NS_Temp_PO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_NS_tempTableAdapter = new HRDataSetTableAdapters.TB_HR_NS_tempTableAdapter();
            _myTAM.TB_HR_NS_tempTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }


        public void DeletebyNS_GUID(string p_NS_GUID)
        {
            string cmdTxt = @"delete from TB_HR_NS_temp ";
            cmdTxt += @" where ISNULL(NS_GUID,'') = '" + p_NS_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable getData(DataTable p_dt, string p_NS_GUID)
        {
            string cmdTxt = @"select * from TB_HR_NS_temp ";
            //if (!"".Equals(p_NS_GUID))
            //{
            cmdTxt += @" where ISNULL(NS_GUID,'') = '" + p_NS_GUID + "'";
            //}
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public string getUS_GUIDbyACCOUNT(DataTable p_dt,string p_ACCOUNT)
        {
            string cmdTxt = @"select USER_GUID from TB_EB_USER ";
            cmdTxt += @" where ACCOUNT='" + p_ACCOUNT + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_US_GUID = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_US_GUID +=  l_list[i][0].ToString() ;
            }

            return l_US_GUID;
        }

        public void updateGUIDbyDate(string p_NS_GUID, string p_GUID)
        {
            string cmdTxt = @"update TB_HR_NS_temp set NS_GUID ='" + p_NS_GUID + "'";
            cmdTxt += @" where GUID = '" + p_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public string getNS_GUID(DataTable p_dt)
        {
            string cmdTxt = @"select NS_GUID from TB_HR_NS_temp order by NS_GUID desc ";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_NS_GUID = "";
            l_NS_GUID = l_list[0][0].ToString();


            return l_NS_GUID;
        }

    }
}
