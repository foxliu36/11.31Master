using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CCarnameUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CCarnamePO _CCarnamePO = null;
        private CCarnamePO CCarnamePO
        {
            get
            {
                if (_CCarnamePO == null)
                    _CCarnamePO = new CCarnamePO();
                return _CCarnamePO;
            }
        }

        public DataTable QueryCarnameDatas()
        {
            REWDS.TB_REW_CARNAME.Clear();
            CCarnamePO.QueryDatas(REWDS.TB_REW_CARNAME);
            return REWDS.TB_REW_CARNAME;
        }
        public bool QueryCarnameByCarcod(string carcod)
        {
            DataTable dt = new DataTable();
            CCarnamePO.QueryCarnameByCarcod(dt, carcod);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void Update(DataRow row)
        {
            CCarnamePO.Update(REWDS);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_CARNAME.Rows.Add(row);
            CCarnamePO.Update(REWDS);
        }
    }
}
