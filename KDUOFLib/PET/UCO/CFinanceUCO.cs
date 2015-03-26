using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.PET.PO;
using System.Data;

namespace KDUOFLib.PET.UCO
{
    public class CFinanceUCO
    {
        private PETDataSet PETDS = new PETDataSet();
        private CFinancePO _CFinancePO = null;
        private CFinancePO CFinancePO
        {
            get
            {
                if (_CFinancePO == null)
                    _CFinancePO = new CFinancePO();
                return _CFinancePO;
            }
        }
        public DataTable QueryFinanceData(string ORDERNO)
        {
            PETDS.TB_PET_FINANCE.Clear();
            if (string.IsNullOrEmpty(ORDERNO))
            {
                return PETDS.TB_PET_FINANCE;
            }
            CFinancePO.QueryDatas(ORDERNO, PETDS.TB_PET_FINANCE);
            return PETDS.TB_PET_FINANCE;
        }
        public void Insert(DataTable dt)
        {
            if (PETDS.TB_PET_FINANCE != dt)
                throw new Exception("並非DATASET裡面的TABLE，無法使用此函式！");
            CFinancePO.Update(PETDS);
        }

        #region Print
        public DataTable QueryDatasByPrint(string orderno)
        {
            DataTable dt = new DataTable();
            CFinancePO.QueryDatasByPrint(orderno,dt);
            return dt;
        }
        public DataTable QueryDatasByCrytalPrint(string id)
        {
            DataTable dt = new DataTable();
            CFinancePO.QueryDatasByCrytalPrint(id, dt);
            return dt;
        }
        
        #endregion  
    }
}
