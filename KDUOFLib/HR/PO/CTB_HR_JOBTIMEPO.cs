using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_JOBTIMEPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_JOBTIMEPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_JOBTIMETableAdapter = new HRDataSetTableAdapters.TB_HR_JOBTIMETableAdapter();
            _myTAM.TB_HR_JOBTIMETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }


        public void Delete(string smid,string year,string month)
        {
            string cmdTxt = @"delete from TB_HR_JOBTIME where SMID='" + smid + "' and JOB_YEAR = '" + year + "' and JOB_MONTH = '" + month + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void QueryJobTimeBySmid(DataTable dt, string smid)
        {
            string cmdTxt = @"select * ";
            cmdTxt += @"from TB_HR_JOBTIME j ";
            cmdTxt += @"where  SMID ='" + smid + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryJobTimeByCheck(DataTable dt, string smid, string p_year, string p_month)
        {
            string cmdTxt = @"select * ";
            cmdTxt += @"from TB_HR_JOBTIME j ";
            cmdTxt += @"where  SMID ='" + smid + @"' ";
            cmdTxt += @"and  JOB_YEAR ='" + p_year + @"' ";
            cmdTxt += @"and  JOB_MONTH ='" + p_month + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void QueryJobTimeByCheck(DataTable dt, string smid, string p_year, string p_month, string p_day)
        {
            string cmdTxt = @"select * ";
            cmdTxt += @"from TB_HR_JOBTIME j ";
            cmdTxt += @"where  SMID ='" + smid + @"' ";
            cmdTxt += @"and  JOB_YEAR ='" + p_year + @"' ";
            cmdTxt += @"and  JOB_MONTH ='" + p_month + @"' ";
            cmdTxt += @"and  JOB_DAY ='" + p_day + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void QueryJobTimeByQuery(DataTable dt, string smids, string p_year, string p_month)
        {
            string cmdTxt = @"select j.*,u.*,g.GROUP_NAME  ";
            cmdTxt += @"from TB_HR_JOBTIME j ";
            cmdTxt += @" inner join dbo.TB_EB_USER u on j.SMID = u.ACCOUNT ";
            cmdTxt += @" inner join dbo.TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID ";
            cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID ";
            cmdTxt += @" where  SMID in (" + smids.Substring(0,smids.Length-1) + @") ";
            cmdTxt += @" and  JOB_YEAR ='" + p_year + @"' ";
            cmdTxt += @" and  JOB_MONTH ='" + p_month + @"' ";
            cmdTxt += @" order by SMID,JOB_YEAR,JOB_MONTH,JOB_DAY";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryJobTimeByQueryByNoDatas(DataTable dt, string smids, string p_year, string p_month)
        {
            string cmdTxt = @"select u.*,u.ACCOUNT as SMID,j.JOB_YEAR,j.JOB_MONTH,j.JOB_DAY,g.GROUP_NAME   ";
            cmdTxt += @" from TB_EB_USER u ";
            cmdTxt += @" left join TB_HR_JOBTIME j on j.SMID = u.ACCOUNT and j.JOB_YEAR ='" + p_year + "' and j.JOB_MONTH ='" + p_month + "'";
            cmdTxt += @" inner join dbo.TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID ";
            cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID ";
            cmdTxt += @" where  u.ACCOUNT in (" + smids.Substring(0, smids.Length - 1) + @") ";
            cmdTxt += @" and isnull(j.SMID,'') = ''";
            cmdTxt += @" order by u.ACCOUNT";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        

        public void QueryJobTimeByPrint(DataTable dt, string smid, string p_year, string p_month, string p_day)
        {
            string cmdTxt = @"select * ";
            cmdTxt += @"from TB_HR_JOBTIME j ";
            cmdTxt += @" inner join dbo.TB_EB_USER u on j.SMID = u.ACCOUNT ";
            cmdTxt += @" where  SMID = '" + smid + "'";
            cmdTxt += @" and  JOB_YEAR ='" + p_year + @"' ";
            cmdTxt += @" and  JOB_MONTH ='" + p_month + @"' ";
            cmdTxt += @" and  JOB_DAY ='" + p_day + @"' ";
            cmdTxt += @" order by SMID,JOB_YEAR,JOB_MONTH,JOB_DAY";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryJobTimeByAdmin(DataTable dt, string p_year, string p_month, string p_type, string p_group, string p_smid)
        {
            string cmdTxt = @"select j.*,u.name,g.GROUP_NAME,g.GROUP_ID ";
            cmdTxt += @" from TB_HR_JOBTIME j ";
            cmdTxt += @" inner join dbo.TB_EB_USER u on j.SMID = u.ACCOUNT ";
            cmdTxt += @" inner join dbo.TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID ";
            cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID ";
            cmdTxt += @" and  JOB_YEAR ='" + p_year + @"' ";
            cmdTxt += @" and  JOB_MONTH ='" + p_month + @"' ";
           
            if (!String.IsNullOrEmpty(p_smid))
            {
                cmdTxt += @" and  u.ACCOUNT ='" + p_smid + @"' ";
            }
            if (p_type.Equals("廠"))
            {
                if (!String.IsNullOrEmpty(p_group))
                {
                    cmdTxt += @" and  (g.PARENT_GROUP_ID = '" + p_group + "' or g.GROUP_ID = '" + p_group + "')";
                }
                else
                {

                    cmdTxt += @" and  g.GROUP_NAME like '%廠%'";
                }
            }
            else if (p_type.Equals("所"))
            {
                if (!String.IsNullOrEmpty(p_group))
                {
                    cmdTxt += @" and  (g.PARENT_GROUP_ID = '" + p_group + "' or g.GROUP_ID = '" + p_group + "')";
                }
                else
                {
                    cmdTxt += @" and  (g.GROUP_NAME like '%所%' or g.GROUP_NAME like '%課%')";
                }
            }
            else if (p_type.Equals("總管理處"))
            {
                cmdTxt += @" and  (g.GROUP_NAME  not like '%所%' and g.GROUP_NAME not like '%廠%' and g.GROUP_NAME not like '%課%')";
            }
            else
            {
                 cmdTxt += @" and  (g.PARENT_GROUP_ID = '" + p_group + "' or g.GROUP_ID = '" + p_group + "')";
            }
            cmdTxt += @" order by g.GROUP_NAME,SMID,JOB_YEAR,JOB_MONTH,JOB_DAY";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
    }
}
