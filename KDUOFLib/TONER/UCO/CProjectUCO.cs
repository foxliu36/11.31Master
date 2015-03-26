using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.TONER.PO;
using System.Data;

namespace KDUOFLib.TONER.UCO
{
    public class CProjectUCO
    {
        private TONERDataSet TONER = new TONERDataSet();
        private CProjectPO _CProjectPO = null;
        private CProjectPO CProjectPO
        {
            get
            {
                if (_CProjectPO == null)
                    _CProjectPO = new CProjectPO();
                return _CProjectPO;
            }
        }

        public DataRow NewRow()
        {
            return TONER.TB_TONER_PROJECT.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CProjectPO.Update(TONER);
        }

        public void UpdateByName(DataRow row)
        {
            this.CProjectPO.UpdateByName(row);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                TONER.TB_TONER_PROJECT.Rows.Add(row);
            this.CProjectPO.Update(TONER);
        }
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CProjectPO.Update(TONER);
        }

        public DataTable QueryDatasByProname(string p_strname)
        {
            DataTable dt = new DataTable();
            this.CProjectPO.selectbyProname(dt,p_strname);

            return dt;
        }

        public bool boolByname(string p_strname)
        {
            DataTable dt = new DataTable();
            bool l_cinf = this.CProjectPO.ConfirmbyProname(dt, p_strname);

            return l_cinf;
        }
    }
}
