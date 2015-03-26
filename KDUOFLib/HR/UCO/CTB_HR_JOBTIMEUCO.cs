using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_JOBTIMEUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_JOBTIMEPO _CTB_HR_JOBTIMEPO = null;
        private CTB_HR_JOBTIMEPO CTB_HR_JOBTIMEPO
        {
            get
            {
                if (_CTB_HR_JOBTIMEPO == null)
                    _CTB_HR_JOBTIMEPO = new CTB_HR_JOBTIMEPO();
                return _CTB_HR_JOBTIMEPO;
            }
        }
        public DataRow NewRow()
        {
            return HR.TB_HR_JOBTIME.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CTB_HR_JOBTIMEPO.Update(HR);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_JOBTIME.Rows.Add(row);
            this.CTB_HR_JOBTIMEPO.Update(HR);
        }
        public void Delete(string smid,string year,string month)
        {
            this._CTB_HR_JOBTIMEPO.Delete(smid, year, month);
        }

        public DataTable QueryJobTimeBySmid(string smid)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_JOBTIMEPO.QueryJobTimeBySmid(dt, smid);
            return dt;
        }
        public DataTable QueryJobTimeByCheck(string p_smid,string p_year,string p_month)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_JOBTIMEPO.QueryJobTimeByCheck(dt, p_smid, p_year, p_month);
            return dt;
        }
        public DataTable QueryJobTimeByCheck(string p_smid, string p_year, string p_month, string p_day)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_JOBTIMEPO.QueryJobTimeByCheck(dt, p_smid, p_year, p_month, p_day);
            return dt;
        }
        public DataTable QueryJobTimeByQuery(string p_smids, string p_year, string p_month)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_JOBTIMEPO.QueryJobTimeByQuery(dt, p_smids, p_year, p_month);
            return dt;
        }
        public DataTable QueryJobTimeByQueryByNoDatas(string p_smids, string p_year, string p_month)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_JOBTIMEPO.QueryJobTimeByQueryByNoDatas(dt, p_smids, p_year, p_month);
            return dt;
        }
        public DataTable QueryJobTimeByPrint(string p_smids, string p_year, string p_month, string p_day)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_JOBTIMEPO.QueryJobTimeByPrint(dt, p_smids, p_year, p_month, p_day);
            return dt;
        }

        public DataTable QueryJobTimeByAdmin(string p_year, string p_month, string p_type, string p_group, string p_smid)
        {
            DataTable dt = new DataTable();
            this.CTB_HR_JOBTIMEPO.QueryJobTimeByAdmin(dt, p_year, p_month, p_type, p_group, p_smid);
            return dt;
        }
        
    }
}
