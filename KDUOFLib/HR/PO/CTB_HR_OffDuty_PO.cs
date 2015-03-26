using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

/*** Design by fox***/
namespace KDUOFLib.HR.PO
{
    public class CTB_HR_OffDuty_PO : Fast.EB.Utility.Data.BasePersistentObject
    {
        
        HRDataSetTableAdapters.TableAdapterManager _myTAM = new HRDataSetTableAdapters.TableAdapterManager();

        public CTB_HR_OffDuty_PO() {
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            _myTAM.TB_HR_ResignationPaperTableAdapter = new HRDataSetTableAdapters.TB_HR_ResignationPaperTableAdapter();
            _myTAM.TB_HR_ResignationPaperTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public DataTable GetEmpData(string p_EmpNo) {
            try
            {

            
            DataTable dt = new DataTable();
            string cmd = " select * from TB_EB_USER u ";
            cmd += " join TB_EB_EMPL el on u.USER_GUID = el.USER_GUID ";
            cmd += " join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID ";
            cmd += " join TB_EB_JOB_TITLE j on j.TITLE_ID = d.TITLE_ID ";
            cmd += "  join TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID  ";
            cmd += " where u.ACCOUNT = '" + p_EmpNo + "' ";


            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmd);
            dt.Load(dr);   
            dr.Dispose();
            return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public DataTable GetOffDateLimit(string p_Date)
        {
            DataTable dt = new DataTable();

            string cmd = " SELECT * FROM [UOF].[dbo].[TB_WKF_OffHoliday] ";
            cmd += " where 1=1 ";
            cmd += " and HolidayDate = '" + p_Date + "' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmd);
            dt.Load(dr);
            dr.Dispose();
            return dt;
        }

        public DataTable CheckOffDuty(String p_EmpNo, string p_BDate, string p_EDate) {
            DataTable dt = new DataTable();

            string cmd = " select * from TB_HR_ResignationPaper ";
            cmd += " where 1=1 ";
            if (p_EmpNo != "")
            {
                cmd += " and EmpNo = '" + p_EmpNo + "' ";
            }
            if (p_BDate != "" && p_EDate != "")
            {
                cmd += " and OffDutyDate between'" + p_BDate + "' and '" + p_EDate + "' ";
            }


            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmd);
            dt.Load(dr);
            dr.Dispose();
            return dt;
        }

        public void Delete(string p_EMPNO) {
            StringBuilder sb = new StringBuilder();

            sb.Append(" DELETE FROM TB_HR_ResignationPaper ");
            sb.Append(" WHERE EmpNo = '" + p_EMPNO + "' ");

            this.m_db.ExecuteNonQuery(sb.ToString());
        }
    }
}
