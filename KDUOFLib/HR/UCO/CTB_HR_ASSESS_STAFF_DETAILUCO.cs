using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_ASSESS_STAFF_DETAILUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_ASSESS_STAFF_DETAILPO _CTB_HR_ASSESS_STAFF_DETAILPO = null;
        private CTB_HR_ASSESS_STAFF_DETAILPO CTB_HR_ASSESS_STAFF_DETAILPO
        {
            get
            {
                if (_CTB_HR_ASSESS_STAFF_DETAILPO == null)
                    _CTB_HR_ASSESS_STAFF_DETAILPO = new CTB_HR_ASSESS_STAFF_DETAILPO();
                return _CTB_HR_ASSESS_STAFF_DETAILPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_ASSESS_STAFFDETAIL.NewRow();
        }

        public void updateGUID(string p_GUID, string p_SMID, string p_type, string p_year)
        {
            this.CTB_HR_ASSESS_STAFF_DETAILPO.updateGUID(p_GUID,p_SMID,p_type,p_year);
        }

        public void Update(DataRow row)
        {
            this.CTB_HR_ASSESS_STAFF_DETAILPO.Update(HR);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_ASSESS_STAFFDETAIL.Rows.Add(row);
            this.CTB_HR_ASSESS_STAFF_DETAILPO.Update(HR);
        }
        public void DeletebyReject(string p_GUID)
        {
            this.CTB_HR_ASSESS_STAFF_DETAILPO.DeletebyReject(p_GUID);
        }
        public void Delete(string p_DEL_GUID, string p_GUID)
        {
            this.CTB_HR_ASSESS_STAFF_DETAILPO.Delete(p_DEL_GUID, p_GUID);
        }

        public DataTable getDatsByID(string taskid, string p_siteCode)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_DETAILPO.getDatsByID(l_dt, taskid, p_siteCode);
        }

        public DataTable if_ditto(string p_SMID, string p_type, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_STAFF_DETAILPO.if_ditto(l_dt, p_SMID, p_type, p_year);
        }

        public void DeletebySMID(string p_SMID, string p_type, string p_year)
        {
            this.CTB_HR_ASSESS_STAFF_DETAILPO.DeletebySMID(p_SMID, p_type,p_year);
        }

    }
}
