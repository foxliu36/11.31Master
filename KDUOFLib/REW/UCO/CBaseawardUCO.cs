using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CBaseawardUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CBaseawardPO _CBaseawardPO = null;

        private CBaseawardPO CBaseawardPO
        {
            get
            {
                if (_CBaseawardPO == null)
                    _CBaseawardPO = new CBaseawardPO();
                return _CBaseawardPO;
            }
        }

        public DataTable QueryBaseawardDatas()
        {
            REWDS.TB_REW_BASEAWARD.Clear();
            this.CBaseawardPO.QueryDatas(REWDS.TB_REW_BASEAWARD);
            return REWDS.TB_REW_BASEAWARD;
        }
        public DataTable QueryBaseawardDatasByDocno(string docno)
        {
            DataTable dt = new DataTable();
            this.CBaseawardPO.QueryBaseawardDatasByDocno(dt, docno);
            return dt;
        }
        public DataTable QueryBaseawardDatasByQuery(string carcod,string sfx)
        {
            REWDS.TB_REW_BASEAWARD.Clear();
            this.CBaseawardPO.QueryBaseawardDatasByQuery(REWDS.TB_REW_BASEAWARD, carcod, sfx);
            return REWDS.TB_REW_BASEAWARD;
        }
        public DataTable QueryDocNoDatas()
        {
            REWDS.TB_REW_BASEAWARD.Clear();
            this.CBaseawardPO.QueryDocNoDatas(REWDS.TB_REW_BASEAWARD);
            return REWDS.TB_REW_BASEAWARD;
        }
        //20140225新增判斷年式
        public DataTable IsOverMonthData(string carcod, string carmodel, string sfx, string saleday,string p_yeartype)
        {
            REWDS.TB_REW_BASEAWARD.Clear();
            return this.CBaseawardPO.IsOverMonthData(carcod, carmodel, sfx, saleday, p_yeartype);
        }
        public void Update(DataRow row)
        {
            this.CBaseawardPO.Update(REWDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_BASEAWARD.Rows.Add(row);
            this.CBaseawardPO.Update(REWDS);
        }

        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CBaseawardPO.Update(REWDS);
        }
        public void Delete(string No)
        {
            this.CBaseawardPO.DeleteBySQL(No);
        }

        public bool IsRepeatData(string No)
        {
            return this.CBaseawardPO.IsRepeatData(No);
        }
        public void Insert(DataRow[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].RowState != DataRowState.Added)
                    REWDS.TB_REW_BASEAWARD.Rows.Add(rows[i]);
            }
            this.CBaseawardPO.Update(REWDS);
        }

        public DataRow NewRow()
        {
            return REWDS.TB_REW_BASEAWARD.NewRow();
        }

        public DataTable GetRepeatDatas(string CAR_CODE, string  CAR_MDL, string[] SFXs,DateTime BDATE,DateTime EDATE)
        {
            return this.CBaseawardPO.GetRepeatDatas(CAR_CODE,  CAR_MDL,  SFXs,BDATE, EDATE);
        }
    }
}
