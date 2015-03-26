using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace KDUOFLib.PET.PO
{
    public class CPetcomPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        PETDataSetTableAdapters.TableAdapterManager _myTAM;

        public CPetcomPO()
        {
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_PETCOMTableAdapter = new PETDataSetTableAdapters.TB_PET_PETCOMTableAdapter();
            _myTAM.TB_PET_PETCOMTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }
        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_PET_PETCOM order by COM_NAME";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

    }
}
