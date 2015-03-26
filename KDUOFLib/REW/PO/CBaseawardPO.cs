using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CBaseawardPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;
        public CBaseawardPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_BASEAWARDTableAdapter = new REWDataSetTableAdapters.TB_REW_BASEAWARDTableAdapter();
            _myTAM.TB_REW_BASEAWARDTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_BASEAWARD order by CAR_CODE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDocNoDatas(DataTable dt)
        {
            string cmdTxt = @"select DOC_NO,BDATE,EDATE from TB_REW_BASEAWARD ";
            cmdTxt += @" group by DOC_NO,BDATE,EDATE";
            cmdTxt += @" order by BDATE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryBaseawardDatasByDocno(DataTable dt, string docno)
        {
            string cmdTxt = @"select * from TB_REW_BASEAWARD  where 1=1";

            if (!"".Equals(docno))
            {
                cmdTxt += @" and DOC_NO='" + docno + @"'";
            }
            cmdTxt += @" order by BDATE,CAR_CODE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryBaseawardDatasByQuery(DataTable dt, string carcod,string sfx)
        {
            string cmdTxt = @"select * from TB_REW_BASEAWARD  where 1=1";

            if (!"".Equals(carcod))
            {
                cmdTxt += @" and CAR_CODE='" + carcod + @"'";
            }
            if (!"".Equals(sfx))
            {
                cmdTxt += @" and CAR_SFX='" + sfx + @"'";
            }
            cmdTxt += @" order by BDATE,CAR_CODE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
      
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public bool IsRepeatData(string No)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select DOC_NO from TB_REW_BASEAWARD ";
            cmdTxt += @" Where DOC_NO='" + No + @"'";
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt.Rows.Count > 0 ? true : false;
        }

        public DataTable IsOverMonthData(string carcod, string carmodel, string sfx, string saleday, string p_yeartype)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select APPLY_NUM,APPLY_NUM_EMPTY,APPLY_NUM_25,APPLY_NUM_EMPTY_25,APPLY_NUM_GET,APPLY_NUM_EMPTY_GET,APPLY_NUM_IM,APPLY_NUM_EMPTY_IM,APPLY_NUM_TIC,APPLY_NUM_EMPTY_TIC,APPLY_NUM_25IM,APPLY_NUM_EMPTY_25IM,APPLY_NUM_25TIC,APPLY_NUM_EMPTY_25TIC,APPLY_NUM_RES,APPLY_NUM_EMPTY_RES from TB_REW_BASEAWARD ";
            cmdTxt += @" Where CAR_CODE='" + carcod + @"'";
            cmdTxt += @" and CAR_MDL='" + carmodel + @"'";
            cmdTxt += @" and CAR_YEAR='" + p_yeartype + @"'";
            cmdTxt += @" and CAR_SFX='" + sfx + @"'";
            cmdTxt += @" and ('" + saleday + "' >= BDATE  and '" + saleday + "' <= EDATE )";
            
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
        public void DeleteBySQL(string No)
        {
            string cmdTxt = @"delete from TB_REW_BASEAWARD ";
            cmdTxt += @" Where DOC_NO='" + No + @"'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable GetRepeatDatas(string CAR_CODE, string CAR_MDL, string[] SFXs, DateTime BDATE, DateTime EDATE)
        {
            string strSFX = "'"+SFXs[0]+"'";
            for (int i = 1; i < SFXs.Length; i++)
                strSFX += ", '" + SFXs[i] + "'";
            strSFX = "("+strSFX + ")";
            DataTable dt = new DataTable();
            string cmdTxt = @"select DISTINCT  CAR_SFX from dbo.TB_REW_BASEAWARD where CAR_CODE  = '" + CAR_CODE + @"'"
                + @" And CAR_MDL='" + CAR_MDL + "' "
                + @" And CAR_SFX in " + strSFX + " "
                + @" And (BDATE between '" + BDATE.ToString("yyyy/MM/dd") + "' And '" + EDATE.ToString("yyyy/MM/dd") + "'"
                + @" Or EDATE between '" + BDATE.ToString("yyyy/MM/dd") + "' And '" + EDATE.ToString("yyyy/MM/dd") + "')";

            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
    }
}
