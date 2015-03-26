using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_ASSESS_GENERALPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_ASSESS_GENERALPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_ASSESS_GENERALTableAdapter = new HRDataSetTableAdapters.TB_HR_ASSESS_GENERALTableAdapter();
            _myTAM.TB_HR_ASSESS_GENERALTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }
        public void DeletebyReject(string taskid)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_GENERAL where TASK_ID='" + taskid + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void Delete(string taskid, string p_siteCode)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_GENERAL where TASK_ID='" + taskid + "' and SITE_CODE = '" + p_siteCode + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public DataTable getDatsByID(DataTable p_dt, string taskid, string p_siteCode)
        {
            string cmdTxt = @"select * from TB_HR_ASSESS_GENERAL where TASK_ID='" + taskid + "' and SITE_CODE = '" + p_siteCode + "'";
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
            string cmdTxt = @"UPDATE [TB_HR_ASSESS_GENERAL]";
            cmdTxt += @" SET [SMID] = '" + row["SMID"].ToString() + "'";
            cmdTxt += @" ,[SIGNER] ='" + row["SIGNER"].ToString() + "'";
            cmdTxt += @" ,[ASSESS_TYPE] ='" + row["ASSESS_TYPE"].ToString() + "'";
            cmdTxt += @" ,[EFFICIENCY_Y] =" + row["EFFICIENCY_Y"].ToString();
            cmdTxt += @" ,[PERFORMANCE] =" + row["PERFORMANCE"].ToString();
            cmdTxt += @" ,[PERFORMANCE_Y] =" + row["PERFORMANCE_Y"].ToString();
            cmdTxt += @" ,[ATTITUDE] =" + row["ATTITUDE"].ToString();
            cmdTxt += @" ,[ATTITUDE_Y] =" + row["ATTITUDE_Y"].ToString();
            cmdTxt += @" ,[PROVISION] =" + row["PROVISION"].ToString();
            cmdTxt += @" ,[PROVISION_Y] =" + row["PROVISION_Y"].ToString();
            cmdTxt += @" ,[SPIRIT] =" + row["SPIRIT"].ToString();
            cmdTxt += @" ,[SPIRIT_Y] =" + row["SPIRIT_Y"].ToString();
            cmdTxt += @" ,[TIDY] =" + row["TIDY"].ToString();
            cmdTxt += @" ,[TIDY_Y] =" + row["TIDY_Y"].ToString();
            cmdTxt += @" ,[COORDINATION] =" + row["COORDINATION"].ToString();
            cmdTxt += @" ,[COORDINATION_Y] =" + row["COORDINATION_Y"].ToString();
            cmdTxt += @" ,[SPECIALTY] =" + row["SPECIALTY"].ToString();
            cmdTxt += @" ,[SPECIALTY_Y] =" + row["SPECIALTY_Y"].ToString();
            cmdTxt += @" ,[REACTION] =" + row["REACTION"].ToString();
            cmdTxt += @" ,[REACTION_Y] =" + row["REACTION_Y"].ToString();
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

        public DataTable getDatabyBranch(DataTable p_dt, string p_Branch, string p_ASSESS_TYPE, string p_year, string p_fromtype)
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
            cmdTxt += @" from TB_HR_ASSESS_GENERAL h";
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
            string cmdTxt = @" select * from dbo.TB_HR_ASSESS_GENERAL";
            cmdTxt += @" where TASK_ID = '" + taskid + "'";
            cmdTxt += @" order by SITE_CODE desc ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable if_ditto(DataTable p_dt, string p_SMID, string p_type, string p_year)
        {
            string cmdTxt = @" select * from TB_HR_ASSESS_GENERAL";
            cmdTxt += @" where SMID = '" + p_SMID + "'";
            cmdTxt += @" and ASSESS_TYPE='" + p_type + "'";
            cmdTxt += @" and substring(EDIT_DATE,1,4)= '" + p_year + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public double AMOUNTbySeason(DataTable p_dt, string p_GROUPID)
        {
            string cmdTxt = @" select Season = IsNull(sum(case when h.RANK='B' or h.RANK='A'then 1 end),0)";
            cmdTxt += @" from TB_HR_ASSESS_GENERAL h";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = h.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where g.GROUP_ID='" + p_GROUPID + "'";
            cmdTxt += @" and h.SITE_CODE='S2'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }

            double l_int人數 = Convert.ToInt32(l_list[0][0].ToString());

            return l_int人數;
        }

        public double AMOUNTbyYears(DataTable p_dt, string p_GROUPID)
        {
            string cmdTxt = @" select Years = IsNull(sum(case when h.RANK_Y='B' or h.RANK_Y='A'then 1 end),0)";
            cmdTxt += @" from TB_HR_ASSESS_GENERAL h";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = h.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where g.GROUP_ID='" + p_GROUPID + "'";
            cmdTxt += @" and h.SITE_CODE='S2'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            double l_int人數 = Convert.ToInt32(l_list[0][0].ToString());
            return l_int人數;
        }

        public DataTable getdatail(DataTable p_dt, string p_Bdate, string p_Edate, string p_smid, string p_GruopID, string p_GUID, string p_type)
        {
            string cmdTxt = @" select s.GUID,s.ASSESS_TYPE,s.SMID,u.NAME,t.TITLE_NAME,g.GROUP_NAME,s.RANK,s.RANK_Y,s.SITE_CODE,s.SIGNER";
            cmdTxt += @" from TB_HR_ASSESS_GENERAL s";
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
            cmdTxt += @" from TB_HR_ASSESS_GENERAL a";
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
