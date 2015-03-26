using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KDUOFLib.REW.PO;

namespace KDUOFLib.REW.UCO
{
    public class CCaryearUCO
    {

        private REWDataSet REWDS = new REWDataSet();
        private CCaryearPO _CCaryearPO = null;
        private CCaryearPO CCaryearPO
        {
            get
            {
                if (_CCaryearPO == null)
                    _CCaryearPO = new CCaryearPO();
                return _CCaryearPO;
            }
        }


        public DataTable QueryCarmodelDatas()
        {
            REWDS.TB_REW_CARYEAR.Clear();
            this.CCaryearPO.QueryDatas(REWDS.TB_REW_CARYEAR);
            return REWDS.TB_REW_CARYEAR;
        }
        public DataTable QueryDatasBySearch(string carcode, string year)
        {
            REWDS.TB_REW_CARYEAR.Clear();
            this.CCaryearPO.QueryDatasBySearch(REWDS.TB_REW_CARYEAR, carcode, year);
            return REWDS.TB_REW_CARYEAR;
        }
        public DataTable QueryYearsByCarcod(string carcode)
        {
            REWDS.TB_REW_CARYEAR.Clear();
            this.CCaryearPO.QueryYearsByCarcod(REWDS.TB_REW_CARYEAR, carcode);
            return REWDS.TB_REW_CARYEAR;
        }

        public void Update(DataRow row)
        {
            this.CCaryearPO.Update(REWDS);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_CARYEAR.Rows.Add(row);
            this.CCaryearPO.Update(REWDS);
        }
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CCaryearPO.Update(REWDS);
        }

        public DataTable QuerySFXDatasByConditions(string CarCode, DateTime BDate, DateTime EDate)
        {
            return this.CCaryearPO.QuerySFXDatasByConditions(CarCode, BDate, EDate);
        }

        public void Insert(DataRow[] dataRow)
        {
            for (int i = 0; i < dataRow.Length; i++)
            {
                if (dataRow[i].RowState != DataRowState.Added)
                    REWDS.TB_REW_CARYEAR.Rows.Add(dataRow[i]);
            }
            CCaryearPO.Update(REWDS);
        }
    }
}
