using System;
using System.Collections.Generic;
using System.Text;

namespace KDUOFLib.TONER.PO
{
    public class COrderdetailPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        TONERDataSetTableAdapters.TableAdapterManager _myTAM;

        public COrderdetailPO()
        {
            _myTAM = new TONERDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = TONERDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_TONER_ORDERDETAILTableAdapter = new TONERDataSetTableAdapters.TB_TONER_ORDERDETAILTableAdapter();
            _myTAM.TB_TONER_ORDERDETAILTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void Delete(string orderno)
        {
            string cmdTxt = @"delete from TB_TONER_ORDERDETAIL where f_orderno='" + orderno + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void Update(TONERDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
    }
}
