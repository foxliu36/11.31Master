using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_CLOCKTIMEPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_CLOCKTIMEPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_CLOCKTIMETableAdapter = new HRDataSetTableAdapters.TB_HR_CLOCKTIMETableAdapter();
            _myTAM.TB_HR_CLOCKTIMETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }
        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void QueryCLOCKTimeByDate(DataTable dt, DateTime p_BDate , DateTime p_EDate, string p_EmpNo)
        {
            string cmdTxt = @"select c.*,u.NAME,g.GROUP_NAME ";
            cmdTxt += @"from TB_HR_CLOCKTIME c";
            cmdTxt += @" left join TB_EB_USER u on c.EMPLOYEE_EIP = u.ACCOUNT";
            cmdTxt += @" left join dbo.TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID ";
            cmdTxt += @" left join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID ";
            cmdTxt += @" where c.EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
            cmdTxt += @" and  c.DATE_TIME  >= '" + p_BDate + @"' and  c.DATE_TIME <='" + p_EDate + "'";
            if (p_EmpNo != "")
            {
                cmdTxt += @" and EMPLOYEE_EIP = '" + p_EmpNo + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryCLOCKTimeByExportMIN(DataTable dt, DateTime p_BDate, DateTime p_EDate)
        {
            string cmdTxt = @" select EMPLOYEE_ID,EMPLOYEE_EIP,MIN(DATE_TIME) as DATE_TIME_MIN, '01'  as DATE_TIME_TYPE ";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
            cmdTxt += @" and  DATE_TIME  >= '" + p_BDate + @"' and  DATE_TIME <='" + p_EDate + "'";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryCLOCKTimeByExportMAX(DataTable dt, DateTime p_BDate, DateTime p_EDate)
        {
            string cmdTxt = @" select EMPLOYEE_ID,EMPLOYEE_EIP, MAX(DATE_TIME) as DATE_TIME_MAX ,'02'  as DATE_TIME_TYPE";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
            cmdTxt += @" and  DATE_TIME  >= '" + p_BDate + @"' and  DATE_TIME <='" + p_EDate + "'";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryVacation(DataTable dt, DateTime p_BDate, DateTime p_EDate)
        {
            //因為只會選擇當天所以日期都依樣 p_EDate就不需要用到
            string cmdTxt = @"select * from UOF.dbo.TB_HR_JOBTIME ";
            cmdTxt += @" where JOB_YEAR = " + p_BDate.Year + "";
            cmdTxt += @" and JOB_MONTH = " + p_BDate.Month + "";
            cmdTxt += @" and JOB_DAY = " + p_BDate.Day + "";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryByDays(DataTable dt, DateTime p_BDate, DateTime p_EDate, string p_EmpNo)
        {
            string cmdTxt = " select a.*,b.DATE_TIME_MAX ,g.GROUP_NAME, t.TITLE_NAME from ";
            cmdTxt += @" (select EMPLOYEE_ID,EMPLOYEE_EIP,MIN(DATE_TIME) as DATE_TIME_MIN ";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> ''  "; 
            if (!p_EmpNo.Equals(""))
            {
                cmdTxt += @" and EMPLOYEE_EIP = '" + p_EmpNo + "' ";
            }
            cmdTxt += @" and  DATE_TIME  >= '" + p_BDate + "' and DATE_TIME  <='" + p_EDate + "' ";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP ) a ";
            cmdTxt += @" join ";
            cmdTxt += @" (select EMPLOYEE_ID,EMPLOYEE_EIP,MAX(DATE_TIME) as DATE_TIME_MAX ";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '' ";
            if (!p_EmpNo.Equals(""))
            {
                cmdTxt += @" and EMPLOYEE_EIP = '" + p_EmpNo + "' ";
            }
            cmdTxt += @" and  DATE_TIME  >= '" + p_BDate + "' and DATE_TIME  <='" + p_EDate + "' ";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP) b ";
            cmdTxt += @" on a.EMPLOYEE_ID = b.EMPLOYEE_ID ";
            cmdTxt += @" join TB_EB_USER u on b.EMPLOYEE_EIP = u.ACCOUNT ";
            cmdTxt += @" join TB_EB_EMPL_DEP d on u.USER_GUID = d.USER_GUID ";
            cmdTxt += @" join TB_EB_GROUP g	on d.GROUP_ID = g.GROUP_ID ";
            cmdTxt += @" join TB_EB_JOB_TITLE t	on d.TITLE_ID = t.TITLE_ID ";
            cmdTxt += @"  ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
    }
}
