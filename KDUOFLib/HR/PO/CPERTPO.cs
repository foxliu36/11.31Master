using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CPERTPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;

        public CPERTPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_PERTTableAdapter = new HRDataSetTableAdapters.TB_HR_PERTTableAdapter();
            _myTAM.TB_HR_PERTTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public void Delete(string GUID)
        {
            string cmdTxt = @"delete from TB_HR_PERT where GUID='" + GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }




    }
}
