using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CRewardDetailPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;
        public CRewardDetailPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_REWARDDETAILTableAdapter = new REWDataSetTableAdapters.TB_REW_REWARDDETAILTableAdapter();
            _myTAM.TB_REW_REWARDDETAILTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
        public void DeleteBeforeDatas(string closemonth, string smid)
        {
            string cmdTxt = @"delete from TB_REW_REWARDDETAIL where CLOSEMONTH ='" + closemonth + "' and SMID='" + smid + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void DeleteBeforeRewDatas(string closemonth, string smid,string orderno)
        {
            string cmdTxt = @"delete from TB_REW_REWARDDETAIL where CLOSEMONTH ='" + closemonth + "' and SMID='" + smid + "' and  ORDERNO ='" + orderno + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void Delete(string id)
        {
            string cmdTxt = @"delete from TB_REW_REWARDDETAIL where ID ='" + id + @"' ";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void  QueryBySmid(DataTable dt,string smid)
        {
            string cmdTxt = @"select * from TB_REW_REWARDDETAIL where SMID ='" + smid + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatas(DataTable dt, string smid)
        {
            string cmdTxt = @"select * from TB_REW_REWARDDETAIL where SMID ='" + smid + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
        public void QueryByOrderno(DataTable dt, string orderno)
        {
            string cmdTxt = @"select * from TB_REW_REWARDDETAIL where ORDERNO ='" + orderno + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryByInint(DataTable dt)
        {
            string cmdTxt = @"select top 2 * from TB_REW_REWARDDETAIL";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryBySearch(DataTable dt, string closeMonth,string smid,string memo)
        {
            string cmdTxt = @"select * from TB_REW_REWARDDETAIL where 1=1 ";

            if (!"".Equals(closeMonth))
            {
                cmdTxt += " and CLOSEMONTH = '" + closeMonth + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and SMID = '" + smid + "'";
            }
            if (!"".Equals(memo))
            {
                cmdTxt += " and MEMO like '" + memo + "%'";
            }
            cmdTxt += @" order by CLOSEMONTH,ORDERNO";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryByREW(DataTable dt, string closeMonth, string smid)
        {
            string cmdTxt = @"select * from TB_REW_REWARDDETAIL where TYPE='實績獎金' ";

            if (!"".Equals(closeMonth))
            {
                cmdTxt += " and CLOSEMONTH = '" + closeMonth + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and SMID = '" + smid + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryByREWUpdate(DataTable dt, string closeMonth, string smid)
        {
            string cmdTxt = @"select * from TB_REW_REWARDDETAIL where 1=1";

            if (!"".Equals(closeMonth))
            {
                cmdTxt += " and CLOSEMONTH = '" + closeMonth + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and SMID = '" + smid + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        /// <summary>
        /// 查詢所有明細檔(TB_REW_REWARDDETAIL)當月實績金額累計
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="closemonth"></param>
        public void getErrorCheckDatas(DataTable dt, string closemonth)
        {
            string cmdTxt = @"select SMID,amt = SUM(MONEY) ";
            cmdTxt += @" from TB_REW_REWARDDETAIL";
            cmdTxt += @" where SMID in";
            cmdTxt += @" (";
            cmdTxt += @" select SMID";
            cmdTxt += @" from dbo.TB_REW_REWARDDETAIL";
            cmdTxt += @" where CLOSEMONTH = '" + closemonth + "'";
            cmdTxt += @" group by SMID";
            cmdTxt += @" )";
            cmdTxt += @" and closemonth = '" + closemonth + "'";
            cmdTxt += @" and STATUS in (0,1,2)";//不記不判斷    
            cmdTxt += @" group by smid";
            cmdTxt += @" order by smid ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryByREWReport(DataTable dt, string closeMonth, string smid)
        {
            string cmdTxt = @"select u.NAME,o.ordpnm,o.CarCod,o.CarMdl,o.SFX,o.yeartype,o.EngNo,o.OrderDay,o.SaleDay,rd.*";
            cmdTxt += @" ,SUPPORT_TYPE = IsNull((case";
            cmdTxt += @" when (isnull(s.SUPPORT_TYPE,'')in ('5','1') ) then '一般'";
            cmdTxt += @" when (isnull(s.SUPPORT_TYPE,'')in ('2') ) then '僅核發'";
            cmdTxt += @" when (isnull(s.SUPPORT_TYPE,'')='' ) then ''";
            cmdTxt += @" end),0)";
            cmdTxt += @" from dbo.TB_REW_REWARDDETAIL rd";
            cmdTxt += @" left join TB_KD_ORDERS o on rd.ORDERNO = o.OrderNo";
            cmdTxt += @" inner join TB_EB_USER u on rd.SMID = u.ACCOUNT";
            cmdTxt += @" left join TB_REW_SPECIALSALE s on s.ORDERNO = rd.OrderNo ";
            cmdTxt += @" where 1=1";
            if (!"".Equals(closeMonth))
            {
                cmdTxt += " and rd.CLOSEMONTH = '" + closeMonth + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and rd.SMID = '" + smid + "'";
            }
            cmdTxt += @" order by rd.ORDERNO desc";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryByIMPORT(DataTable dt, string closeMonth, string smid, string memo)
        {
            string cmdTxt = @"select * from TB_REW_REWARDDETAIL where 1=1 and ORDERNO = '' ";

            if (!"".Equals(closeMonth))
            {
                cmdTxt += " and CLOSEMONTH = '" + closeMonth + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and SMID = '" + smid + "'";
            }
            if (!"".Equals(memo))
            {
                cmdTxt += " and MEMO like '" + memo + "%'";
            }
            cmdTxt += @" order by CLOSEMONTH,SMID";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
    }
}
