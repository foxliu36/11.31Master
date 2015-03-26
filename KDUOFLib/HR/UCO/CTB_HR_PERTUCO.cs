using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_PERTUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_PERTPO _CTB_HR_PERTPO = null;
        private CTB_HR_PERTPO CTB_HR_PERTPO
        {
            get
            {
                if (_CTB_HR_PERTPO == null)
                    _CTB_HR_PERTPO = new CTB_HR_PERTPO();
                return _CTB_HR_PERTPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_PERT.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CTB_HR_PERTPO.Update(HR);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_PERT.Rows.Add(row);
            this.CTB_HR_PERTPO.Update(HR);
        }
        public void Delete(string taskid)
        {
            this.CTB_HR_PERTPO.Delete(taskid);
        }

        public void UpdatebyGUID(DataRow row)
        {
            this.CTB_HR_PERTPO.UpdatebyGUID(row);
        }

        public DataTable getDatsBySMID(string p_SMID,string p_ASSESSTYPE, string p_YEAR)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_PERTPO.getDatsBySMID(l_dt, p_SMID,p_ASSESSTYPE, p_YEAR);
        }

        public DataTable getDatsByID(string p_siteCode, string TASK_ID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_PERTPO.getDatsByID(l_dt, p_siteCode, TASK_ID);
        }

        public DataTable check(string p_SMID, string p_type, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_PERTPO.check(l_dt, p_SMID, p_type, p_year);
        }

        public DataTable Query(string Bdate, string Edate, string p_smid, string p_GruopID,string p_GUID,string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_PERTPO.Query(l_dt, Bdate, Edate, p_smid, p_GruopID, p_GUID,p_type);
        }

    }
}
