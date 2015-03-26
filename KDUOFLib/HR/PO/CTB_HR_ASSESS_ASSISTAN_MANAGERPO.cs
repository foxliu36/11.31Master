using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_ASSESS_ASSISTAN_MANAGERPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_ASSESS_ASSISTAN_MANAGERPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_ASSESS_ASSISTAN_MANAGERTableAdapter = new HRDataSetTableAdapters.TB_HR_ASSESS_ASSISTAN_MANAGERTableAdapter();
            _myTAM.TB_HR_ASSESS_ASSISTAN_MANAGERTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public void DeletebyReject(string taskid)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_ASSISTAN_MANAGER where TASK_ID='" + taskid +  "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void Delete(string taskid, string p_siteCode)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_ASSISTAN_MANAGER where TASK_ID='" + taskid + "' and SITE_CODE = '" + p_siteCode + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable getDatsByID(DataTable p_dt, string taskid, string p_siteCode)
        {
            string cmdTxt = @"select * from TB_HR_ASSESS_ASSISTAN_MANAGER where TASK_ID='" + taskid + "' and SITE_CODE = '" + p_siteCode + "'";
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
            string cmdTxt = @"UPDATE [TB_HR_ASSESS_ASSISTAN_MANAGER]";
            cmdTxt += @" SET [SMID] = '" + row["SMID"].ToString() + "'";
            cmdTxt += @" ,[SIGNER] ='" + row["SIGNER"].ToString() + "'";
            cmdTxt += @" ,[ASSESS_TYPE] ='" + row["ASSESS_TYPE"].ToString() + "'";
            cmdTxt += @" ,[KPI_Performance] =" + row["KPI_Performance"].ToString();
            cmdTxt += @" ,[KPI_Performance_Y] =" + row["KPI_Performance_Y"].ToString();
            cmdTxt += @" ,[KPI_Ploy] =" + row["KPI_Ploy"].ToString();
            cmdTxt += @" ,[KPI_Ploy_Y] =" + row["KPI_Ploy_Y"].ToString();
            cmdTxt += @" ,[KPI_Improve] =" + row["KPI_Improve"].ToString();
            cmdTxt += @" ,[KPI_Improve_Y] =" + row["KPI_Improve_Y"].ToString();
            cmdTxt += @" ,[Cooperation] =" + row["Cooperation"].ToString();
            cmdTxt += @" ,[Cooperation_Y] =" + row["Cooperation_Y"].ToString();
            cmdTxt += @" ,[Subordinate] =" + row["Subordinate"].ToString();
            cmdTxt += @" ,[Subordinate_Y] =" + row["Subordinate_Y"].ToString();
            cmdTxt += @" ,[Risk] =" + row["Risk"].ToString();
            cmdTxt += @" ,[Risk_Y] =" + row["Risk_Y"].ToString();
            cmdTxt += @" ,[Communication] =" + row["Communication"].ToString();
            cmdTxt += @" ,[Communication_Y] =" + row["Communication_Y"].ToString();
            cmdTxt += @" ,[Attitude] =" + row["Attitude"].ToString();
            cmdTxt += @" ,[Attitude_Y] =" + row["Attitude_Y"].ToString();
            cmdTxt += @" ,[Total] =" + row["Total"].ToString();
            cmdTxt += @" ,[Total_Y] =" + row["Total_Y"].ToString();
            cmdTxt += @" ,[RANK] ='" + row["RANK"].ToString() + "'";
            cmdTxt += @" ,[RANK_Y] ='" + row["RANK_Y"].ToString() + "'";
            cmdTxt += @" where TASK_ID = @TASK_ID";
            cmdTxt += @" and SITE_CODE = @SITE_CODE";
            this.m_db.AddParameter("@TASK_ID", row["TASK_ID"].ToString());
            this.m_db.AddParameter("@SITE_CODE", row["SITE_CODE"].ToString());
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable getDatabyBranch(DataTable p_dt, string p_Branch, string p_ASSESS_TYPE, string p_year,string p_fromtype)
        {
            string cmdTxt = @" select h.SIGNER,f_A=IsNull(sum(case when h.RANK ='A' then 1 end),0),";
            cmdTxt += @" f_B1=IsNull(sum(case when h.RANK ='B+' then 1 end),0),";
            cmdTxt += @" f_B=IsNull(sum(case when h.RANK ='B' then 1 end),0),";
            cmdTxt += @" f_B3=IsNull(sum(case when h.RANK ='B-' then 1 end),0),";
            cmdTxt += @" f_C1=IsNull(sum(case when h.RANK ='C+' then 1 end),0),";
            cmdTxt += @" f_C=IsNull(sum(case when h.RANK ='C' then 1 end),0),";
            cmdTxt += @" f_C3=IsNull(sum(case when h.RANK ='C-' then 1 end),0),";
            cmdTxt += @" f_D1=IsNull(sum(case when h.RANK ='D+' then 1 end),0),";
            cmdTxt += @" f_D=IsNull(sum(case when h.RANK ='D' then 1 end),0),";
            cmdTxt += @" f_D3=IsNull(sum(case when h.RANK ='D-' then 1 end),0),";
            cmdTxt += @" f_F=IsNull(sum(case when h.RANK ='F' then 1 end),0),";
            cmdTxt += @" f_AY=IsNull(sum(case when h.RANK_Y ='A' then 1 end),0),";
            cmdTxt += @" f_BY1=IsNull(sum(case when h.RANK_Y ='B+' then 1 end),0),";
            cmdTxt += @" f_BY=IsNull(sum(case when h.RANK_Y ='B' then 1 end),0),";
            cmdTxt += @" f_BY3=IsNull(sum(case when h.RANK_Y ='B-' then 1 end),0),";
            cmdTxt += @" f_CY1=IsNull(sum(case when h.RANK_Y ='C+' then 1 end),0),";
            cmdTxt += @" f_CY=IsNull(sum(case when h.RANK_Y ='C' then 1 end),0),";
            cmdTxt += @" f_CY3=IsNull(sum(case when h.RANK_Y ='C-' then 1 end),0),";
            cmdTxt += @" f_DY1=IsNull(sum(case when h.RANK_Y ='D+' then 1 end),0),";
            cmdTxt += @" f_DY=IsNull(sum(case when h.RANK_Y ='D' then 1 end),0),";
            cmdTxt += @" f_DY3=IsNull(sum(case when h.RANK_Y ='D-' then 1 end),0),";
            cmdTxt += @" f_FY=IsNull(sum(case when h.RANK_Y ='F' then 1 end),0),";
            cmdTxt += @" h.SITE_CODE,h.SITE_CODE+'/'+''+'/'+ g.GROUP_NAME+'/'+'" + p_fromtype + "' as keyword";
            cmdTxt += @" from TB_HR_ASSESS_ASSISTAN_MANAGER h";
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
            string cmdTxt = @" select * from dbo.TB_HR_ASSESS_ASSISTAN_MANAGER";
            cmdTxt += @" where TASK_ID = '" + taskid + "'";
            cmdTxt += @" order by SITE_CODE desc ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable if_ditto(DataTable p_dt, string p_SMID,string p_type,string p_year)
        {
            string cmdTxt = @" select * from TB_HR_ASSESS_ASSISTAN_MANAGER";
            cmdTxt += @" where SMID = '" + p_SMID + "'";
            cmdTxt += @" and ASSESS_TYPE='" + p_type + "'";
            cmdTxt += @" and substring(EDIT_DATE,1,4)= '" + p_year + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable getdatail(DataTable p_dt, string p_Bdate, string p_Edate, string p_smid, string p_GruopID, string p_GUID,string p_type)
        {
            string cmdTxt = @" select s.GUID,s.ASSESS_TYPE,s.SMID,u.NAME,t.TITLE_NAME,g.GROUP_NAME,s.RANK,s.RANK_Y,s.SITE_CODE,s.SIGNER";
            cmdTxt += @" from TB_HR_ASSESS_ASSISTAN_MANAGER s";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=s.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE t on t.TITLE_ID=e.TITLE_ID";
            cmdTxt += @" where e.ORDERS = 0";
            cmdTxt += @" and s.EDIT_DATE between '" + p_Bdate + "' and '" + p_Edate + "'";
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
            string cmdTxt = @" select g.GROUP_NAME,NAME,a.SMID,t.TITLE_NAME,a.RANK,a.RANK_Y";
            cmdTxt += @" from TB_HR_ASSESS_ASSISTAN_MANAGER a";
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
