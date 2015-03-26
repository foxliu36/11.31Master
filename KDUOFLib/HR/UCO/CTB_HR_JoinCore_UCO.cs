using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_JoinCore_UCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_JoinCore_PO _CTB_HR_JoinCore_PO = null;

        private CTB_HR_JoinCore_PO CTB_HR_JoinCore_PO
        {
            get
            {
                if (_CTB_HR_JoinCore_PO == null)
                    _CTB_HR_JoinCore_PO = new CTB_HR_JoinCore_PO();
                return _CTB_HR_JoinCore_PO;
            }
        }

        public void updateDatas(DataTable p_dtImport)
        {
            
            this.CTB_HR_JoinCore_PO.insertData(p_dtImport);
        }

      public DataTable ifdouble(string p_ACCOUNT)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_JoinCore_PO.ifdouble(l_dt, p_ACCOUNT);
        }

      public string getTITLEIDbyTITLENAME(string p_TITLENAME)
      {
          return this.CTB_HR_JoinCore_PO.getTITLEIDbyTITLENAME(p_TITLENAME);
      }

      public string getFUNC_IDbyFUNC_NAME(string p_FUNC_NAME)
      {
          return this.CTB_HR_JoinCore_PO.getFUNC_IDbyFUNC_NAME(p_FUNC_NAME);
      }

    }
}
