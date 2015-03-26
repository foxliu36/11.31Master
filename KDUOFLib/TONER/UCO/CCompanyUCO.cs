using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.TONER.PO;
using System.Data;

namespace KDUOFLib.TONER.UCO
{
    public class CCompanyUCO
    {
        private TONERDataSet TONER = new TONERDataSet();
        private CCompanyPO _CCompanyPO = null;
        private CCompanyPO CCompanyPO
        {
            get
            {
                if (_CCompanyPO == null)
                    _CCompanyPO = new CCompanyPO();
                return _CCompanyPO;
            }
        }

        public DataRow NewRow()
        {
            return TONER.TB_TONER_COMPANY.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CCompanyPO.Update(TONER);
        }

        public void UpdateByName(DataRow row)
        {
            this.CCompanyPO.UpdateByName(row);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                TONER.TB_TONER_COMPANY.Rows.Add(row);
            this.CCompanyPO.Update(TONER);
        }
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CCompanyPO.Update(TONER);
        }

        public DataTable QueryDatasByname(string p_strname)
        {
            DataTable dt = new DataTable();
            this.CCompanyPO.selectbyname(dt, p_strname);

            return dt;
        }

        public bool boolByname(string p_strname)
        {
            DataTable dt = new DataTable();
            bool l_cinf= this.CCompanyPO.Confirmbyname(dt, p_strname);

            return l_cinf;
        }

    }
}
