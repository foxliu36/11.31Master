using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.TONER.PO
{
    public class CProjectPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        TONERDataSetTableAdapters.TableAdapterManager _myTAM;

        public CProjectPO()
        {
            _myTAM = new TONERDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = TONERDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_TONER_PROJECTTableAdapter = new TONERDataSetTableAdapters.TB_TONER_PROJECTTableAdapter();
            _myTAM.TB_TONER_PROJECTTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void Update(TONERDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void UpdateByName(DataRow row)
        {
            string cmdTxt = @"UPDATE [TB_TONER_PROJECT]";
            cmdTxt += @" SET [f_price] = " + row["f_price"].ToString();
            cmdTxt += @" ,[f_proname] ='" + row["f_proname"].ToString() + "'";
            cmdTxt += @" ,[f_companyid] ='" + row["f_companyid"].ToString() + "'";
            cmdTxt += @" ,[f_editday] ='" + row["f_editday"].ToString() + "'";
            cmdTxt += @" ,[f_memo] ='" + row["f_memo"].ToString() + "'";
            cmdTxt += @" where f_prono = @f_prono";
            this.m_db.AddParameter("@f_prono", row["f_prono"].ToString());
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void selectbyProname(DataTable dt, string p_name)
        {
            string cmdTxt = @"select *";
            cmdTxt += @" from TB_TONER_PROJECT";
            cmdTxt += @" where 1=1";
            if (!"".Equals(p_name))
            {
                cmdTxt += @" and f_proname = '" + p_name + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public bool ConfirmbyProname(DataTable dt, string p_name)
        {
            string cmdTxt = @"select *";
            cmdTxt += @" from TB_TONER_PROJECT";
            cmdTxt += @" where 1=1";
            if (!"".Equals(p_name))
            {
                cmdTxt += @" and f_proname = '" + p_name + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

    }
}
