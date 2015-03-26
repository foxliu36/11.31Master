using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CSpecialCntPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;

        public CSpecialCntPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_SPECIALCNTTableAdapter = new REWDataSetTableAdapters.TB_REW_SPECIALCNTTableAdapter();
            _myTAM.TB_REW_SPECIALCNTTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }

        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_SPECIALCNT order by BDATE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByDate(DataTable dt, DateTime l_BDate, DateTime l_EDate)
        {
            string cmdTxt = @"select * from TB_REW_SPECIALCNT ";
            cmdTxt += @"where BDATE >= '" + l_BDate + "' and EDATE <= '" + l_EDate +"'";
            cmdTxt += @" order by BRANCH";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByBranch(DataTable dt, string p_branch,DateTime p_saleday)
        {
            string cmdTxt = @"select * from TB_REW_SPECIALCNT ";
            cmdTxt += @" where BRANCH ='" + p_branch + "'";
            cmdTxt += @" and '" + p_saleday + "' >= BDATE and '" + p_saleday + "' <= EDATE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void DeleteBySQL(string No)
        {
            string cmdTxt = @"delete from TB_REW_SPECIALCNT ";
            cmdTxt += @" Where ID='" + No + @"'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        //2015/03/02 需給室新增需求，送單超過7天，可支援金額改為1000

        public string QueryDate(DataTable p_dt,string p_orderno)
        {
            string cmdTxt = @"select SaleDay from TB_KD_ORDERS ";
            cmdTxt += @" where OrderNo='" + p_orderno + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();

            List<DataRow> l_list = new List<DataRow>();
            foreach(DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            
            string l_date = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_date = l_list[0][0].ToString();
            }
            return l_date;
        }

    }
}
