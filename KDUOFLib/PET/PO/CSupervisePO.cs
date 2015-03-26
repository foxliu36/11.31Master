using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.PET.PO
{
    public class CSupervisePO : Fast.EB.Utility.Data.BasePersistentObject
    {
        PETDataSetTableAdapters.TableAdapterManager _myTAM;

        public CSupervisePO()
        {
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_SUPERVISETableAdapter = new PETDataSetTableAdapters.TB_PET_SUPERVISETableAdapter();
            _myTAM.TB_PET_SUPERVISETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }
        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_PET_SUPERVISE order by ID";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QuerySuperviseDatasByID(DataTable dt,string  id)
        {
            string cmdTxt = @"select * from TB_PET_SUPERVISE where ID = '" + id + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
        public void Update(PETDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
    }
}
