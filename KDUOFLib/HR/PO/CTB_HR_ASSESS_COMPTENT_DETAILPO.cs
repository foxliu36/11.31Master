using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_ASSESS_COMPTENT_DETAILPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        
        HRDataSetTableAdapters.TableAdapterManager _myTAM;

        public CTB_HR_ASSESS_COMPTENT_DETAILPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_ASSESS_COMPTENT_DETAILTableAdapter = new HRDataSetTableAdapters.TB_HR_ASSESS_COMPTENT_DETAILTableAdapter();
            _myTAM.TB_HR_ASSESS_COMPTENT_DETAILTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void DeletebyReject(string taskid)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_COMPTENT_DETAIL where TASK_ID='" + taskid +"'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void Delete(string taskid, string p_siteCode)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_COMPTENT_DETAIL where TASK_ID='" + taskid + "' and SITE_CODE = '" + p_siteCode + "'";  
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public DataTable getDatsByID(DataTable p_dt, string taskid, string p_siteCode)
        {
            string cmdTxt = @"select * from TB_HR_ASSESS_COMPTENT_DETAIL where TASK_ID='" + taskid + "' and SITE_CODE = '" + p_siteCode + "'";         
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void UpdateByTASKID(DataRow row)
        {
            string cmdTxt = @"UPDATE [TB_HR_ASSESS_COMPTENT_DETAIL]";
            cmdTxt += @" SET [SMID] = '" + row["SMID"].ToString() + "'";
            cmdTxt += @" ,[SIGNER] ='" + row["SIGNER"].ToString() + "'";
            cmdTxt += @" ,[ASSESS_TYPE] ='" + row["ASSESS_TYPE"].ToString() + "'";
            cmdTxt += @" ,[KPI_Performance] =" + row["KPI_Performance"].ToString();
            cmdTxt += @" ,[KPI_Ploy] =" + row["KPI_Ploy"].ToString();
            cmdTxt += @" ,[KPI_Improve] =" + row["KPI_Improve"].ToString();
            cmdTxt += @" ,[Communication] =" + row["Communication"].ToString();
            cmdTxt += @" ,[Attitude] =" + row["Attitude"].ToString();
            cmdTxt += @" ,[Cooperation] =" + row["Cooperation"].ToString();
            cmdTxt += @" ,[Subordinate] =" + row["Subordinate"].ToString();
            cmdTxt += @" ,[Risk] =" + row["Risk"].ToString();
            cmdTxt += @" ,[CS] =" + row["CS"].ToString();
            cmdTxt += @" ,[Total] =" + row["Total"].ToString();
            cmdTxt += @" ,[RANK_Y] ='" + row["RANK_Y"].ToString() + "'";
            cmdTxt += @" where TASK_ID = @TASK_ID";
            cmdTxt += @" and SITE_CODE = @SITE_CODE";
            this.m_db.AddParameter("@TASK_ID", row["TASK_ID"].ToString());
            this.m_db.AddParameter("@SITE_CODE", row["SITE_CODE"].ToString());
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable getDatabyBranch(DataTable p_dt, string p_Branch, string p_ASSESS_TYPE, string p_year, string p_fromtype)
        {
            string cmdTxt = @" select h.SIGNER,f_A=IsNull(sum(case when h.RANK_Y ='A' then 1 end),0),";
            cmdTxt += @" f_B1=IsNull(sum(case when h.RANK_Y ='B+' then 1 end),0),";
            cmdTxt += @" f_B=IsNull(sum(case when h.RANK_Y ='B' then 1 end),0),";
            cmdTxt += @" f_B3=IsNull(sum(case when h.RANK_Y ='B-' then 1 end),0),";
            cmdTxt += @" f_C1=IsNull(sum(case when h.RANK_Y ='C+' then 1 end),0),";
            cmdTxt += @" f_C=IsNull(sum(case when h.RANK_Y ='C' then 1 end),0),";
            cmdTxt += @" f_C3=IsNull(sum(case when h.RANK_Y ='C-' then 1 end),0),";
            cmdTxt += @" f_D1=IsNull(sum(case when h.RANK_Y ='D+' then 1 end),0),";
            cmdTxt += @" f_D=IsNull(sum(case when h.RANK_Y ='D' then 1 end),0),";
            cmdTxt += @" f_D3=IsNull(sum(case when h.RANK_Y ='D-' then 1 end),0),";
            cmdTxt += @" f_F=IsNull(sum(case when h.RANK_Y ='F' then 1 end),0),";
            cmdTxt += @" h.SITE_CODE,h.SITE_CODE+'/'+''+'/'+ g.GROUP_NAME+'/'+'" + p_fromtype + "' as keyword";
            cmdTxt += @" from TB_HR_ASSESS_COMPTENT_DETAIL h";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = h.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where g.GROUP_ID in( ";
            cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
            cmdTxt += @" and e.ORDERS = 0 ";
            cmdTxt += @" and ASSESS_TYPE='" + p_ASSESS_TYPE + "'";
            cmdTxt += @" and SUBSTRING(EDIT_DATE,1,4)='" + p_year + "'";
            cmdTxt += @" group by h.SIGNER,h.SITE_CODE,g.GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable getlast(DataTable p_dt, string taskid)
        {
            string cmdTxt = @" select * from dbo.TB_HR_ASSESS_COMPTENT_DETAIL";
            cmdTxt += @" where TASK_ID = '" + taskid + "'";
            cmdTxt += @" order by SITE_CODE desc ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable if_ditto(DataTable p_dt, string p_SMID, string p_type, string p_year)
        {
            string cmdTxt = @" select * from TB_HR_ASSESS_COMPTENT_DETAIL";
            cmdTxt += @" where SMID = '" + p_SMID + "'";
            cmdTxt += @" and ASSESS_TYPE='" + p_type + "'";
            cmdTxt += @" and substring(EDIT_DATE,1,4)= '" + p_year + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable getdatail(DataTable p_dt, string p_smid, string p_GruopID, string p_GUID,string p_type)
        {
            string cmdTxt = @" select s.GUID,s.ASSESS_TYPE,s.SMID,u.NAME,t.TITLE_NAME,g.GROUP_NAME,s.RANK_Y,s.SITE_CODE,s.SIGNER";
            cmdTxt += @" from TB_HR_ASSESS_COMPTENT_DETAIL  s";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=s.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE t on t.TITLE_ID=e.TITLE_ID";
            cmdTxt += @" where e.ORDERS = 0";
            if (!String.IsNullOrEmpty(p_smid))
            {
                cmdTxt += @" and s.SMID='" + p_smid + "'";
            }
            if (!String.IsNullOrEmpty(p_GruopID))
            {
                cmdTxt += @" and g.GROUP_ID in(" + p_GruopID.Substring(0, p_GruopID.Length - 1) + ")";
            }
            if (!String.IsNullOrEmpty(p_GUID))
            {
                cmdTxt += @" and s.GUID='" + p_GUID + "'";
            }
            if (!String.IsNullOrEmpty(p_type))
            {
                cmdTxt += @" and s.ASSESS_TYPE='" + p_type + "'";
            }
            cmdTxt += @" order by s.SMID";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        #region 明細
        public DataTable detail_dailog(DataTable p_dt, string p_SITE_CODE, string p_GruopName, string p_ASSESS_TYPE, string p_year)
        {
            string cmdTxt = @" select g.GROUP_NAME,NAME,a.SMID,t.TITLE_NAME ,a.RANK_Y";
            cmdTxt += @" from TB_HR_ASSESS_COMPTENT_DETAIL a";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=a.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE t on t.TITLE_ID=e.TITLE_ID";
            cmdTxt += @" where e.ORDERS = 0 ";
            cmdTxt += @" and GROUP_NAME ='" + p_GruopName + "'";
            cmdTxt += @" and SITE_CODE ='" + p_SITE_CODE + "'";
            cmdTxt += @" and ASSESS_TYPE='" + p_ASSESS_TYPE + "'";
            cmdTxt += @" and SUBSTRING(EDIT_DATE,1,4)='" + p_year + "'";
            cmdTxt += @" order by ACCOUNT";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        #endregion

    }
}
