using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_STAFF_CARUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_STAFF_CARPO _CTB_HR_STAFF_CARPO = null;
        private CTB_HR_STAFF_CARPO CTB_HR_STAFF_CARPO
        {
            get
            {
                if (_CTB_HR_STAFF_CARPO == null)
                    _CTB_HR_STAFF_CARPO = new CTB_HR_STAFF_CARPO();
                return _CTB_HR_STAFF_CARPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_STAFF_CAR.NewRow();
        }

        public string getDatsByID(string p_SMID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_STAFF_CARPO.getDatsByID(l_dt, p_SMID);
        }


    }
}
