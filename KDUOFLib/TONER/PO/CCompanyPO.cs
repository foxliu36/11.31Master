using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.TONER.PO
{
    public class CCompanyPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        TONERDataSetTableAdapters.TableAdapterManager _myTAM;

        public CCompanyPO()
        {
            _myTAM = new TONERDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = TONERDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_TONER_COMPANYTableAdapter = new TONERDataSetTableAdapters.TB_TONER_COMPANYTableAdapter();
            _myTAM.TB_TONER_COMPANYTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void Update(TONERDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        //public void delectByName(DataRow row)
        //{
        //    string cmdTxt = @"delete from [TB_TONER_COMPANY]";
        //    cmdTxt += @" where [f_companyid] = '" + row["f_companyid"].ToString() + "'";
        //    this.m_db.AddParameter("@f_companyid", row["f_companyid"].ToString());
        //    this.m_db.ExecuteNonQuery(cmdTxt);
        //}

        public void UpdateByName(DataRow row)
        {
            string cmdTxt = @"UPDATE [TB_TONER_COMPANY]";
            cmdTxt += @" SET [f_companyid] = '" + row["f_companyid"].ToString() + "'";
            cmdTxt += @" ,[f_syscode] ='" + row["f_syscode"].ToString() + "'";
            cmdTxt += @" where f_companyno = @f_companyno";
            this.m_db.AddParameter("@f_companyno", row["f_companyno"].ToString());
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void selectbyname(DataTable dt, string p_name)
        {
            string cmdTxt = @"select *";
            cmdTxt += @" from TB_TONER_COMPANY";
            cmdTxt += @" where 1=1";
            if (!"".Equals(p_name))
            {
                cmdTxt += @" and f_companyid = '" + p_name + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public bool Confirmbyname(DataTable dt, string p_name)
        {
            string cmdTxt = @"select *";
            cmdTxt += @" from TB_TONER_COMPANY";
            cmdTxt += @" where 1=1";
            if (!"".Equals(p_name))
            {
                cmdTxt += @" and f_companyid = '" + p_name + "'";
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
