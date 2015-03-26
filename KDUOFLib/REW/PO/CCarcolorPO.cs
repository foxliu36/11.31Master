using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CCarcolorPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;

        public CCarcolorPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_CARCOLORTableAdapter = new REWDataSetTableAdapters.TB_REW_CARCOLORTableAdapter();
            _myTAM.TB_REW_CARCOLORTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_CARCOLOR order by CAR_CODE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByCarCod(DataTable dt, string carcod)
        {
            string cmdTxt = @"select * from TB_REW_CARCOLOR where CAR_CODE ='" + carcod + @"' order by CAR_CODE ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryCarcolorDatasByCheckDatas(DataTable dt, string carcod, string colorid)
        {
            string cmdTxt = @"select * from TB_REW_CARCOLOR";
            cmdTxt += @" where CAR_CODE ='" + carcod + "'";
            cmdTxt += @" and CAR_COLOR_ID ='" + colorid + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
    }
}
