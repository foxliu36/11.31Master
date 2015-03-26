using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CSpecialCntUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CSpecialCntPO _CSpecialCntPO = null;
        private CSpecialCntPO CSpecialCntPO
        {
            get
            {
                if (_CSpecialCntPO == null)
                    _CSpecialCntPO = new CSpecialCntPO();
                return _CSpecialCntPO;
            }
        }

        public void Update(DataRow row)
        {
            CSpecialCntPO.Update(REWDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_SPECIALCNT.Rows.Add(row);
            CSpecialCntPO.Update(REWDS);
        }
        public DataTable QueryDatas()
        {
            REWDS.TB_REW_SPECIALCNT.Clear();
            CSpecialCntPO.QueryDatas(REWDS.TB_REW_SPECIALCNT);
            return REWDS.TB_REW_SPECIALCNT;
        }
        public DataTable QueryDatasByDate(DateTime l_BDate, DateTime l_EDate)
        {
            REWDS.TB_REW_SPECIALCNT.Clear();
            CSpecialCntPO.QueryDatasByDate(REWDS.TB_REW_SPECIALCNT, l_BDate, l_EDate);
            return REWDS.TB_REW_SPECIALCNT;
        }
        public DataTable QueryDatasByBranch(string p_branch, DateTime p_saleday)
        {
            REWDS.TB_REW_SPECIALCNT.Clear();
            CSpecialCntPO.QueryDatasByBranch(REWDS.TB_REW_SPECIALCNT, p_branch, p_saleday);
            return REWDS.TB_REW_SPECIALCNT;
        }

        public void Delete(string No)
        {
            this.CSpecialCntPO.DeleteBySQL(No);
        }

        public string QueryDate(string p_orderno)
        {
            DataTable l_dt = new DataTable();
            return this.CSpecialCntPO.QueryDate(l_dt, p_orderno);
        }
    }
}
