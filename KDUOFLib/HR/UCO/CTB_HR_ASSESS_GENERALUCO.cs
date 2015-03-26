using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_ASSESS_GENERALUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_ASSESS_GENERALPO _CTB_HR_ASSESS_GENERALPO = null;
        private CTB_HR_ASSESS_GENERALPO CTB_HR_ASSESS_GENERALPO
        {
            get
            {
                if (_CTB_HR_ASSESS_GENERALPO == null)
                    _CTB_HR_ASSESS_GENERALPO = new CTB_HR_ASSESS_GENERALPO();
                return _CTB_HR_ASSESS_GENERALPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_ASSESS_GENERAL.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CTB_HR_ASSESS_GENERALPO.Update(HR);
        }
        public void UpdateByTASKID(DataRow row)
        {
            this.CTB_HR_ASSESS_GENERALPO.UpdateByTASKID(row);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_ASSESS_GENERAL.Rows.Add(row);
            this.CTB_HR_ASSESS_GENERALPO.Update(HR);
        }
        public void DeletebyReject(string taskid)
        {
            this.CTB_HR_ASSESS_GENERALPO.DeletebyReject(taskid);
        }
        public void Delete(string taskid, string p_siteCode)
        {
            this.CTB_HR_ASSESS_GENERALPO.Delete(taskid, p_siteCode);
        }
        public DataTable getDatsByID(string taskid, string p_siteCode)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.getDatsByID(l_dt, taskid, p_siteCode);
        }

        public DataTable getDatabyBranch(string p_Branch, string p_ASSESS_TYPE, string p_year, string p_fromtype)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.getDatabyBranch(l_dt, p_Branch, p_ASSESS_TYPE, p_year, p_fromtype);
        }

        public DataTable getlast( string taskid)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.getlast(l_dt,taskid);
        }

        public DataTable if_ditto(string p_SMID, string p_type, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.if_ditto(l_dt, p_SMID, p_type,p_year);
        }

        public double AMOUNTbySeason(string p_GROUPID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.AMOUNTbySeason(l_dt, p_GROUPID);
        }

        public double AMOUNTbyYears(string p_GROUPID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.AMOUNTbyYears(l_dt, p_GROUPID);
        }

        public DataTable getdatail(string p_Bdate, string p_Edate, string p_smid, string p_GruopID, string p_GUID, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.getdatail(l_dt, p_Bdate, p_Edate, p_smid, p_GruopID, p_GUID, p_type);
        }

        public DataTable detail_dailog(string p_SITE_CODE, string p_GruopName, string p_ASSESS_TYPE, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_GENERALPO.detail_dailog(l_dt, p_SITE_CODE, p_GruopName, p_ASSESS_TYPE, p_year);
        }

    }
}
