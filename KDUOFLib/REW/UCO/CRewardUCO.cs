using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CRewardUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CRewardPO _CRewardPO = null;

        private CRewardPO CRewardPO
        {
            get
            {
                if (_CRewardPO == null)
                    _CRewardPO = new CRewardPO();
                return _CRewardPO;
            }
        }
        public DataRow NewRow()
        {
            return REWDS.TB_REW_REWARD.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CRewardPO.Update(REWDS);
        }
        public void UpdateByImport(string closemonth,string smid,double money)
        {
            this.CRewardPO.UpdateByImport(closemonth, smid, money);
        }
        public void UpdateByREW(string closemonth, string smid, double money)
        {
            this.CRewardPO.UpdateByREW(closemonth, smid, money);
        }
        
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CRewardPO.Update(REWDS);
        }
        public void DeleteBeforeDatas(string closemonth,string smid)
        {
            this.CRewardPO.DeleteBeforeDatas(closemonth, smid);
        }
        public void Delete(string id)
        {
            this.CRewardPO.Delete(id);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_REWARD.Rows.Add(row);
            this.CRewardPO.Update(REWDS);
            REWDS.TB_REW_REWARD.Clear();
        }


        public DataTable getCloseMonthDatas(string closemonth)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getCloseMonthDatas(dt, closemonth);
            return dt;
        }
        public DataTable getErrorCheckDatas(string closemonth)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getErrorCheckDatas(dt, closemonth);
            return dt;
        }
        public DataTable getCloseMonthDatasByImport(string closemonth,string smid)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getCloseMonthDatasByImport(dt, closemonth, smid);
            return dt;
        }
        public DataTable getDatasByRewReport(string closemonth, string brandid, string smid)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getDatasByRewReport(dt, closemonth, brandid, smid);
            return dt;
        }
        public DataTable getDatasByAccountReport(string closemonth, string closemonthE, string brandid, string smid)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getDatasByAccountReport(dt, closemonth, closemonthE, brandid, smid);
            return dt;
        }
        public DataTable getCloseMonthDatasByRew(string closemonth ,string smid)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getCloseMonthDatasByImport(dt, closemonth, smid);
            return dt;
        }
        public DataTable getCloseMonthDatasBySector(string closemonth, string groupid)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getCloseMonthDatasBySector(dt,groupid,closemonth);
            return dt;
        }
        public DataTable getCloseMonthDatasByBranch(string closemonth, string groupid)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getCloseMonthDatasByBranch(dt, groupid, closemonth);
            return dt;
        }


        public void CloseMonth(string closemonth, int is_close)
        {
            this.CRewardPO.CloseMonth(closemonth, is_close);
        }

        public void UpdateErrorDatas(string closemonth, string smid,double money)
        {
            this.CRewardPO.UpdateErrorDatas(closemonth, smid, money);
        }

        /// <summary>
        /// 已退車但做入實績
        /// </summary>
        /// <param name="closemonth">月結年分</param>
        /// <returns>Datas</returns>
        public DataTable getReadySetRewardButComebackCar(string closemonth)
        {
            DataTable dt = new DataTable();
            this.CRewardPO.getReadySetRewardButComebackCar(dt, closemonth);
            return dt;
        }

    }
}
