using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CQaUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CQaPO _CQaPO = null;
        private CQaPO CQaPO
        {
            get
            {
                if (_CQaPO == null)
                    _CQaPO = new CQaPO();
                return _CQaPO;
            }
        }
        ///未完成，請補PO的SQL
        public DataTable QueryQAByAdmin(string smid, string closemonth, string status)
        {
            REWDS.TB_REW_QA.Clear();
            this.CQaPO.QueryQAByAdmin(REWDS.TB_REW_QA, smid, closemonth, status);
            return REWDS.TB_REW_QA;
        }
        ///未完成，請補PO的SQL
        public DataTable QueryQABySmid(string smid, string closemonth, string status)
        {
            REWDS.TB_REW_QA.Clear();
            this.CQaPO.QueryQABySmid(REWDS.TB_REW_QA, smid, closemonth, status);
            return REWDS.TB_REW_QA;
        }

        public void Update(DataRow row)
        {
            CQaPO.Update(REWDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_QA.Rows.Add(row);
            CQaPO.Update(REWDS);
        }

        public DataTable ClearQA()
        {
            REWDS.TB_REW_QA.Clear();
            return REWDS.TB_REW_QA;
        }

        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            CQaPO.Update(REWDS);
        }
    }
}
