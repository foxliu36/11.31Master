using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

/*** Design By Fox ***/
namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_OffDuty_UCO
    {
        private CTB_HR_OffDuty_PO _CTB_HR_OffDuty_PO = null;

        private HRDataSet HR = new HRDataSet();

        /// <summary>
        /// 取得PO
        /// </summary>
        public CTB_HR_OffDuty_PO CTB_HR_OffDuty_PO {
            get {
                if (_CTB_HR_OffDuty_PO == null)
                {
                    _CTB_HR_OffDuty_PO = new CTB_HR_OffDuty_PO();
                }
                return _CTB_HR_OffDuty_PO;
            }
            
        }

        public DataRow NewRow() {
            return HR.TB_HR_ResignationPaper.NewRow();
        }

        public DataTable GetEmpData(string p_EmpNo) {
            return CTB_HR_OffDuty_PO.GetEmpData(p_EmpNo);
        }

        public DataTable GetOffDateLimit(string p_Date) {
            return CTB_HR_OffDuty_PO.GetOffDateLimit(p_Date);
        }

        public void InsertData(DataRow p_dr) {
            if (p_dr.RowState != DataRowState.Added)
                HR.TB_HR_ResignationPaper.Rows.Add(p_dr);

            this.CTB_HR_OffDuty_PO.Update(HR);
        }

        public void DeleteData(string p_EmpNo) {
            this.CTB_HR_OffDuty_PO.Delete(p_EmpNo);
        }

        public DataTable CheckOffDuty(string p_EmpNo, string p_BDate, string p_EDate)
        {
            DataTable l_dt = new DataTable();
            return CTB_HR_OffDuty_PO.CheckOffDuty(p_EmpNo, p_BDate, p_EDate);
        }
    }
}
