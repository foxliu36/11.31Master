using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CRewardPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;
        public CRewardPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_REWARDTableAdapter = new REWDataSetTableAdapters.TB_REW_REWARDTableAdapter();
            _myTAM.TB_REW_REWARDTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
        public void UpdateByImport(string closemonth, string smid, double money)
        {
            string cmdTxt = @"update TB_REW_REWARD set MONTH_MONEY =" + money;
            cmdTxt += @" where CLOSEMONTH ='" + closemonth + @"' and SMID = '" + smid + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void UpdateByREW(string closemonth, string smid, double money)
        {
            string cmdTxt = @"update TB_REW_REWARD set MONTH_MONEY =" + money;
            cmdTxt += @" where CLOSEMONTH ='" + closemonth + @"' and SMID = '" + smid + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void Delete(string id)
        {
            string cmdTxt = @"delete from TB_REW_REWARDDETAIL where ID ='" + id + @"' ";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void DeleteBeforeDatas(string closemonth, string smid)
        {
            string cmdTxt = @"delete from TB_REW_REWARD where CLOSEMONTH ='" + closemonth + "' and SMID='" + smid + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        /// <summary>
        /// 查詢所有主檔(TB_REW_REWARD)當月實績金額
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="closemonth"></param>
        public void getErrorCheckDatas(DataTable dt, string closemonth)
        {
            string cmdTxt = @"select * from TB_REW_REWARD ";
            cmdTxt += @" where SMID in";
            cmdTxt += @" (";
            cmdTxt += @" select SMID";
            cmdTxt += @" from dbo.TB_REW_REWARDDETAIL";
            cmdTxt += @" where CLOSEMONTH = '" + closemonth + "' ";
            cmdTxt += @" group by SMID";
            cmdTxt += @" )";
            cmdTxt += @" and closemonth = '" + closemonth + "'";
            cmdTxt += @" order by smid";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void getCloseMonthDatas(DataTable dt,string closemonth)
        {
            string cmdTxt = @"select CLOSEMONTH,IT_MONEY = sum(IT_MONEY),MONTH_MONEY = sum(MONTH_MONEY),IS_CLOSE = sum(IS_CLOSE) ";
            cmdTxt += @" from dbo.TB_REW_REWARD";
            cmdTxt += @" where CLOSEMONTH ='" + closemonth + "'";
            cmdTxt += @" group by CLOSEMONTH";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void getCloseMonthDatasByImport(DataTable dt, string closemonth, string smid)
        {
            string cmdTxt = @"select *";
            cmdTxt += @" from dbo.TB_REW_REWARD";
            cmdTxt += @" where CLOSEMONTH ='" + closemonth + "'";
            cmdTxt += @" and SMID ='" + smid + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void getDatasByRewReport(DataTable dt, string closemonth, string brandid, string smid)
        {
            string cmdTxt = @"select r.*,u.NAME,g.PARENT_GROUP_ID,g.GROUP_NAME";
            cmdTxt += @" from dbo.TB_REW_REWARD r";
            cmdTxt += @" inner join TB_EB_USER u on r.SMID = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" where 1=1";
            if (!"".Equals(closemonth))
            {
                cmdTxt += @" and r.CLOSEMONTH ='" + closemonth + "'";

            }
            if (!"".Equals(brandid))
            {
                cmdTxt += @" and g.PARENT_GROUP_ID ='" + brandid + "'";

            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and r.SMID ='" + smid + "'";

            }
            cmdTxt += @" order by g.GROUP_NAME";
           
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void getDatasByAccountReport(DataTable dt, string closemonth, string closemonthE, string brandid, string smid)
        {
            string cmdTxt = @"select r.CLOSEMONTH,g.GROUP_NAME,r.SMID,u.NAME,total = (r.IT_MONEY + r.MONTH_MONEY),";

            cmdTxt += @" car = (select yescnt = IsNull(sum(case when (IsNull(a.ORDERNO,'') <> '') then 1 end),0)";
            cmdTxt += @"    from ";
            cmdTxt += @"    (";
            cmdTxt += @"        select ORDERNO from TB_REW_REWARDDETAIL where SMID = r.SMID and CLOSEMONTH = '" + closemonth + "' and ORDERNO <> '' group by ORDERNO";
            cmdTxt += @"    ) a";
            cmdTxt += @" )";
            
            cmdTxt += @" from dbo.TB_REW_REWARD r";
            cmdTxt += @" inner join TB_EB_USER u on r.SMID = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" inner join TB_REW_REWARDDETAIL rd on rd.SMID = r.SMID and rd.CLOSEMONTH = r.CLOSEMONTH and rd.ORDERNO <> ''";
            cmdTxt += @" where 1=1";
            if (!"".Equals(closemonth))
            {
                cmdTxt += @" and rd.CLOSEMONTH between '" + closemonth + "' and '" + closemonthE + "'";

            }
            if (!"".Equals(brandid))
            {
                cmdTxt += @" and g.PARENT_GROUP_ID ='" + brandid + "'";

            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and r.SMID ='" + smid + "'";

            }
            cmdTxt += @" group by r.CLOSEMONTH,g.GROUP_NAME,r.SMID,u.NAME,r.IT_MONEY,r.MONTH_MONEY";
            cmdTxt += @" order by r.CLOSEMONTH,g.GROUP_NAME";
           
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
        public void getCloseMonthDatasByRew(DataTable dt, string closemonth, string smid)
        {
            string cmdTxt = @"select *";
            cmdTxt += @" from dbo.TB_REW_REWARD";
            cmdTxt += @" where CLOSEMONTH ='" + closemonth + "'";
            cmdTxt += @" and SMID ='" + smid + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
        public void getCloseMonthDatasBySector(DataTable dt, string groupid, string closemonth)
        {
            string cmdTxt = @"select r.*";
            cmdTxt += @" from dbo.TB_REW_REWARD r";
            cmdTxt += @" inner join TB_EB_USER u on r.SMID = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
            cmdTxt += @" where g.GROUP_ID = '" + groupid + "'";
            cmdTxt += @" and r.CLOSEMONTH ='" + closemonth + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void getCloseMonthDatasByBranch(DataTable dt, string groupid, string closemonth)
        {
            string cmdTxt = @"select r.*";
            cmdTxt += @" from dbo.TB_REW_REWARD r";
            cmdTxt += @" inner join TB_EB_USER u on r.SMID = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
            cmdTxt += @" where g.PARENT_GROUP_ID = '" + groupid + "'";
            cmdTxt += @" and r.CLOSEMONTH ='" + closemonth + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void CloseMonth(string closemonth,int is_close)
        {
            string cmdTxt = @" update dbo.TB_REW_REWARD set IS_CLOSE = " + is_close;
            cmdTxt += @" where CLOSEMONTH ='" + closemonth + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void UpdateErrorDatas(string closemonth, string smid, double money)
        {
            string cmdTxt = @" update TB_REW_REWARD set MONTH_MONEY=" + money;
            cmdTxt += @" where CLOSEMONTH= '" + closemonth + "' ";
            cmdTxt += @" and SMID = '" + smid + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        
        public void getReadySetRewardButComebackCar(DataTable dt, string closemonth)
        {
            string cmdTxt = @"select o.OrderNo,u.ACCOUNT,u.NAME";
            cmdTxt += @" from TB_KD_ORDERS o";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = o.SMId";
            cmdTxt += @" where o.OrderNo in";
            cmdTxt += @" (";
            cmdTxt += @"  select rd.ORDERNO";
            cmdTxt += @"  from TB_REW_REWARD r";
            cmdTxt += @"  inner join TB_REW_REWARDDETAIL rd on rd.CLOSEMONTH = r.CLOSEMONTH";
            cmdTxt += @"  where r.CLOSEMONTH = '" + closemonth + "'";
            cmdTxt += @"  group by rd.ORDERNO";
            cmdTxt += @" )";
            cmdTxt += @"  and o.Status in ('0','1','2')";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }     
        
    }
}
