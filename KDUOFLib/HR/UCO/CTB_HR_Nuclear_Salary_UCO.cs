using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_Nuclear_Salary_UCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_Nuclear_Salary_PO _CTB_HR_Nuclear_Salary_PO = null;
        private CTB_HR_Nuclear_Salary_PO CTB_HR_Nuclear_Salary_PO
        {
            get
            {
                if (_CTB_HR_Nuclear_Salary_PO == null)
                    _CTB_HR_Nuclear_Salary_PO = new CTB_HR_Nuclear_Salary_PO();
                return _CTB_HR_Nuclear_Salary_PO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_Nuclear_Salary.NewRow();
        }

        public void Update(DataRow row)
        {
            this.CTB_HR_Nuclear_Salary_PO.Update(HR);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_Nuclear_Salary.Rows.Add(row);
            this.CTB_HR_Nuclear_Salary_PO.Update(HR);
        }

        public void Delete(string p_taskid)
        {
            this.CTB_HR_Nuclear_Salary_PO.Delete(p_taskid);
        }

        public DataTable getUSER_GUIDbyACCOUNT(string p_ACCOUNT)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_Nuclear_Salary_PO.getUSER_GUIDbyACCOUNT(l_dt, p_ACCOUNT);
        }

        public DataTable getData(string p_USER_GUID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_Nuclear_Salary_PO.getData(l_dt, p_USER_GUID);
        }

        public DataTable getDetailbyDate(string p_BDate, string p_EDate)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_Nuclear_Salary_PO.getDetailbyDate(l_dt, p_BDate, p_EDate);

        }

        public DataTable getDetailbySMID(string p_smid, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_Nuclear_Salary_PO.getDetailbySMID(l_dt, p_smid, p_type);
        }

        public DataTable getAllDetailbySMID(string p_smid, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_Nuclear_Salary_PO.getAllDetailbySMID(l_dt, p_smid, p_type);

        }

        public DataTable getDetailbyGroup_Name(string p_Group_Name)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_Nuclear_Salary_PO.getDetailbyGroup_Name(l_dt, p_Group_Name);

        }

        public DataTable getDetailbyTITLE_NAME(string p_TITLE_NAME)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_Nuclear_Salary_PO.getDetailbyTITLE_NAME(l_dt, p_TITLE_NAME);

        }

    }
}
