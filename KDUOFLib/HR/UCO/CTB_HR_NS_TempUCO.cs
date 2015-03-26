using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_NS_TempUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_NS_Temp_PO _CTB_HR_NS_Temp_PO = null;
        private CTB_HR_NS_Temp_PO CTB_HR_NS_Temp_PO
        {
            get
            {
                if (_CTB_HR_NS_Temp_PO == null)
                    _CTB_HR_NS_Temp_PO = new CTB_HR_NS_Temp_PO();
                return _CTB_HR_NS_Temp_PO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_NS_temp.NewRow();
        }

        public void Update(DataRow row)
        {
            this.CTB_HR_NS_Temp_PO.Update(HR);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_NS_temp.Rows.Add(row);
            this.CTB_HR_NS_Temp_PO.Update(HR);
        }

        public void DeletebyNS_GUID(string p_NS_GUID)
        {
            this.CTB_HR_NS_Temp_PO.DeletebyNS_GUID(p_NS_GUID);
        }

        public DataTable getData(string p_NS_GUID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_NS_Temp_PO.getData(l_dt, p_NS_GUID);
        }

        public string getUS_GUIDbyACCOUNT(string p_ACCOUNT)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_NS_Temp_PO.getUS_GUIDbyACCOUNT(l_dt, p_ACCOUNT);
        }

        public void updateGUIDbyDate(string p_GUID, string p_Date)
        {
            this.CTB_HR_NS_Temp_PO.updateGUIDbyDate( p_GUID, p_Date);
        }

        public string getNS_GUID()
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_NS_Temp_PO.getNS_GUID(l_dt);
        }

    }
}
