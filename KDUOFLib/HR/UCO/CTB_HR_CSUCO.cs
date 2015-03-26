using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_CSUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_CSPO _CTB_HR_CSPO = null;
        private CTB_HR_CSPO CTB_HR_CSPO
        {
            get
            {
                if (_CTB_HR_CSPO == null)
                    _CTB_HR_CSPO = new CTB_HR_CSPO();
                return _CTB_HR_CSPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_CS.NewRow();
        }

        public string getDatsByID(string p_SMID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_CSPO.getDatsByID(l_dt, p_SMID);
        }

    }
}
