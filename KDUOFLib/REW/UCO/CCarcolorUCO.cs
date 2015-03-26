using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CCarcolorUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CCarcolorPO _CCarcolorPO = null;

        private CCarcolorPO CCarcolorPO
        {
            get
            {
                if (_CCarcolorPO == null)
                    _CCarcolorPO = new CCarcolorPO();
                return _CCarcolorPO;
            }
        }

        public DataTable QueryCarcolorDatas()
        {
            REWDS.TB_REW_CARCOLOR.Clear();
            this.CCarcolorPO.QueryDatas(REWDS.TB_REW_CARCOLOR);
            return REWDS.TB_REW_CARCOLOR;
        }
        public DataTable QueryCarcolorDatasByCarCod(string carcod)
        {
            REWDS.TB_REW_CARCOLOR.Clear();
            this.CCarcolorPO.QueryDatasByCarCod(REWDS.TB_REW_CARCOLOR, carcod);
            return REWDS.TB_REW_CARCOLOR;
        }
        public DataTable QueryCarcolorDatasByCheckDatas(string carcod,string colorid)
        {
            DataTable dt = new DataTable();
            this.CCarcolorPO.QueryCarcolorDatasByCheckDatas(dt, carcod, colorid);
            return dt;
        }
        public void Update(DataRow row)
        {
            this.CCarcolorPO.Update(REWDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_CARCOLOR.Rows.Add(row);
            this.CCarcolorPO.Update(REWDS);
        }

        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CCarcolorPO.Update(REWDS);
        }
    }
}
