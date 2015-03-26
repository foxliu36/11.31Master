using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_ASSESS_STAFF_UCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_ASSESS_STAFF_PO _CTB_HR_ASSESS_STAFF_PO = null;
        private CTB_HR_ASSESS_STAFF_PO CTB_HR_ASSESS_STAFF_PO
        {
            get
            {
                if (_CTB_HR_ASSESS_STAFF_PO == null)
                    _CTB_HR_ASSESS_STAFF_PO = new CTB_HR_ASSESS_STAFF_PO();
                return _CTB_HR_ASSESS_STAFF_PO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_ASSESS_STAFF.NewRow();
        }

        public void Update(DataRow row)
        {
            this.CTB_HR_ASSESS_STAFF_PO.Update(HR);
        }

        public void UpdateByTASKID(DataRow row)
        {
            this.CTB_HR_ASSESS_STAFF_PO.UpdateByTASKID(row);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_ASSESS_STAFF.Rows.Add(row);
            this.CTB_HR_ASSESS_STAFF_PO.Update(HR);
        }
        public void DeletebyReject(string taskid)
        {
            this.CTB_HR_ASSESS_STAFF_PO.DeletebyReject(taskid);
        }
        public void Delete(string taskid, string p_siteCode)
        {
            this.CTB_HR_ASSESS_STAFF_PO.Delete(taskid, p_siteCode);
        }

        public DataTable getDatsByID(string taskid, string p_siteCode)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_PO.getDatsByID(l_dt, taskid, p_siteCode);
        }

        public DataTable getDatabyBranch(string p_Branch, string p_ASSESS_TYPE, string p_year, string p_fromtype)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_PO.getDatabyBranch(l_dt, p_Branch, p_ASSESS_TYPE, p_year, p_fromtype);
        }

        public DataTable getlast(string taskid)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_PO.getlast(l_dt, taskid);
        }

        public DataTable if_ditto(string p_SMID, string p_type, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_PO.if_ditto(l_dt, p_SMID, p_type, p_year);
        }

        public DataTable getdatail(string p_Bdate, string p_Edate, string p_smid, string p_GruopID, string p_GUID, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_PO.getdatail(l_dt, p_Bdate, p_Edate, p_smid, p_GruopID, p_GUID, p_type);
        }

        public DataTable detail_dailog(string p_SITE_CODE, string p_GruopName, string p_ASSESS_TYPE, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_PO.detail_dailog(l_dt, p_SITE_CODE, p_GruopName, p_ASSESS_TYPE, p_year);
        }

    }
}
