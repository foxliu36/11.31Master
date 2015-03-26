using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_CLOCKTIMEUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_CLOCKTIMEPO _CTB_HR_CLOCKTIMEPO = null;
        private CTB_HR_CLOCKTIMEPO CTB_HR_CLOCKTIMEPO
        {
            get
            {
                if (_CTB_HR_CLOCKTIMEPO == null)
                    _CTB_HR_CLOCKTIMEPO = new CTB_HR_CLOCKTIMEPO();
                return _CTB_HR_CLOCKTIMEPO;
            }
        }
        public DataRow NewRow()
        {
            return HR.TB_HR_CLOCKTIME.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CTB_HR_CLOCKTIMEPO.Update(HR);
        }

        public DataTable QueryCLOCKTimeByDate(DateTime p_BDate, DateTime p_EDate, string p_EmpNo)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_CLOCKTIMEPO.QueryCLOCKTimeByDate(dt, p_BDate, p_EDate, p_EmpNo);
            return dt;
        }
        public DataTable QueryCLOCKTimeByExportMIN(DateTime p_BDate, DateTime p_EDate)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_CLOCKTIMEPO.QueryCLOCKTimeByExportMIN(dt, p_BDate, p_EDate);
            return dt;
        }
        public DataTable QueryCLOCKTimeByExportMAX(DateTime p_BDate, DateTime p_EDate)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_CLOCKTIMEPO.QueryCLOCKTimeByExportMAX(dt, p_BDate, p_EDate);
            return dt;
        }
        public DataTable QueryVacation(DateTime p_BDate, DateTime p_EDate)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_CLOCKTIMEPO.QueryVacation(dt, p_BDate, p_EDate);
            return dt;
        }
        public DataTable QueryClockTimeByDays(DateTime p_BDate, DateTime p_EDate, string EmpNo)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_CLOCKTIMEPO.QueryByDays(dt, p_BDate, p_EDate, EmpNo);
            return dt;
        }
    }
}
