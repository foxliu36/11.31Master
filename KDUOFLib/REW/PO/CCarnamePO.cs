using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CCarnamePO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;

        public CCarnamePO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_CARNAMETableAdapter = new REWDataSetTableAdapters.TB_REW_CARNAMETableAdapter();
            _myTAM.TB_REW_CARNAMETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }
        
        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_CARNAME order by CAR_TYPE_NAME";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryCarnameByCarcod(DataTable dt,string carcod)
        {
            string cmdTxt = @"select * from TB_REW_CARNAME where CAR_CODE ='" + carcod + "'";
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
