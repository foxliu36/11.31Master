using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CRewardDetailUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CRewardDetailPO _RewardDetailPO = null;


        private CRewardDetailPO RewardDetailPO
        {
            get
            {
                if (_RewardDetailPO == null)
                    _RewardDetailPO = new CRewardDetailPO();
                return _RewardDetailPO;
            }
        }
        public DataRow NewRow()
        {
            return REWDS.TB_REW_REWARDDETAIL.NewRow();
        }

        public void Update(DataRow row)
        {
            this.RewardDetailPO.Update(REWDS);
        }
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.RewardDetailPO.Update(REWDS);
        }
        public void Delete(string id)
        {
            this.RewardDetailPO.Delete(id);
        }
        public void DeleteBeforeDatas(string closemonth, string smid)
        {
            this.RewardDetailPO.DeleteBeforeDatas(closemonth, smid);
        }
        public void DeleteBeforeRewDatas(string closemonth, string smid,string orderno)
        {
            this.RewardDetailPO.DeleteBeforeRewDatas(closemonth, smid, orderno);
        }
        
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_REWARDDETAIL.Rows.Add(row);
            this.RewardDetailPO.Update(REWDS);
        }

        public void Insert(DataRow[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].RowState != DataRowState.Added)
                    REWDS.TB_REW_REWARDDETAIL.Rows.Add(rows[i]);
            }
            this.RewardDetailPO.Update(REWDS);
        }

        public void AddRow(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_REWARDDETAIL.Rows.Add(row);
        }
        public DataTable QueryBySmid(string smid)
        {
            DataTable dt = new DataTable();
            this.RewardDetailPO.QueryBySmid(dt, smid);
            return dt;
        }
        public DataTable QueryDatas(string smid)
        {
            REWDS.TB_REW_REWARDDETAIL.Clear();
            this.RewardDetailPO.QueryDatas(REWDS.TB_REW_REWARDDETAIL, smid);
            return REWDS.TB_REW_REWARDDETAIL;
        }
        public DataTable QueryByOrderno(string orderno)
        {
            DataTable dt = new DataTable();
            this.RewardDetailPO.QueryByOrderno(dt, orderno);
            return dt;
        }
        public DataTable QueryBySearch(string closeMonth, string smid, string memo)
        {
            REWDS.TB_REW_REWARDDETAIL.Clear();
            this.RewardDetailPO.QueryBySearch(REWDS.TB_REW_REWARDDETAIL, closeMonth, smid, memo);
            return REWDS.TB_REW_REWARDDETAIL;
        }

        public DataTable QueryByREWReport(string closeMonth, string smid, string memo)
        {
            DataTable dt = new DataTable();
            this.RewardDetailPO.QueryByREWReport(dt, closeMonth, smid);
            return dt;
        }
        public DataTable getErrorCheckDatas(string closeMonth)
        {
            DataTable dt = new DataTable();
            this.RewardDetailPO.getErrorCheckDatas(dt, closeMonth);
            return dt;
        }
        
        public DataTable QueryByREW(string closeMonth, string smid)
        {
            DataTable dt = new DataTable();
            this.RewardDetailPO.QueryByREW(dt, closeMonth, smid);
            return dt;
        }
        public DataTable QueryByREWUpdate(string closeMonth, string smid)
        {
            DataTable dt = new DataTable();
            this.RewardDetailPO.QueryByREWUpdate(dt, closeMonth, smid);
            return dt;
        }
        
        public DataTable QueryByIMPORT(string closeMonth, string smid, string memo)
        {
            REWDS.TB_REW_REWARDDETAIL.Clear();
            this.RewardDetailPO.QueryByIMPORT(REWDS.TB_REW_REWARDDETAIL, closeMonth, smid, memo);
            return REWDS.TB_REW_REWARDDETAIL;
        }

        public DataTable setInitRewardDetail(DataTable dt)
        {
            DataTable dtinit = new DataTable();
            this.RewardDetailPO.QueryByInint(dtinit);
            double support_money = Convert.ToDouble(dt.Rows[0]["SUPPORT_MONEY"].ToString());
            double discount = Convert.ToDouble(dt.Rows[0]["DISCOUNT"].ToString());
            double subsieies_money = Convert.ToDouble(dt.Rows[0]["SUBSIDIES_MONEY"].ToString());
            double discount_money = Convert.ToDouble(dt.Rows[0]["DISCOUNT_MONEY"].ToString());
            int support_type = Convert.ToInt32(dt.Rows[0]["SUPPORT_TYPE"].ToString());
            string orderno = dt.Rows[0]["ORDERNO"].ToString();
            string smid = dt.Rows[0]["SMID"].ToString();

            dtinit.Rows[0]["ID"] = Guid.NewGuid();
            dtinit.Rows[0]["STATUS"] = 0;
            dtinit.Rows[0]["MONEY"] = support_money;
            dtinit.Rows[0]["MEMO"] = "支援";
            dtinit.Rows[0]["SMID"] = smid;
            dtinit.Rows[0]["ORDERNO"] = orderno;
            dtinit.Rows[0]["TYPE"] = "實績獎金";

            double douTotal = discount + (discount_money-subsieies_money);
            /*
             * (可折車價 - (交車表折讓金額+交車表補貼息金額)) < -1000 = 不計算
             * (可折車價 - (交車表折讓金額+交車表補貼息金額)) > -1000 = 計算(分類:應扣 備註:超折)
             * (可折車價 - (交車表折讓金額+交車表補貼息金額)) > 0 = 計算(分類:應加 備註:折讓獎金)
             * (可折車價 - (交車表折讓金額+交車表補貼息金額)) >= 10000 = 計算(分類:不計 備註:抵扣配件款(計算金額))
             */
            if (douTotal < 0)
            {
                if (douTotal < -999)
                {
                    dtinit.Rows[1]["ID"] = Guid.NewGuid();
                    dtinit.Rows[1]["STATUS"] = 1;

                    dtinit.Rows[1]["MONEY"] = douTotal;
                    dtinit.Rows[1]["MEMO"] = "超折";
                    dtinit.Rows[1]["SMID"] = smid;
                    dtinit.Rows[1]["ORDERNO"] = orderno;
                    dtinit.Rows[1]["TYPE"] = "實績獎金";
                }
                else
                {
                    dtinit.Rows[1]["ID"] = Guid.NewGuid();
                    dtinit.Rows[1]["STATUS"] = 1;

                    dtinit.Rows[1]["MONEY"] = 0;
                    dtinit.Rows[1]["MEMO"] = "超折(不足999)";
                    dtinit.Rows[1]["SMID"] = smid;
                    dtinit.Rows[1]["ORDERNO"] = orderno;
                    dtinit.Rows[1]["TYPE"] = "實績獎金";

                }
            }
            else
            {
                dtinit.Rows[1]["ID"] = Guid.NewGuid();
                dtinit.Rows[1]["SMID"] = smid;
                dtinit.Rows[1]["ORDERNO"] = orderno;
                dtinit.Rows[1]["TYPE"] = "實績獎金";
                if (douTotal < 10000)
                {
                    dtinit.Rows[1]["STATUS"] = 2;
                    dtinit.Rows[1]["MONEY"] = douTotal;
                    dtinit.Rows[1]["MEMO"] = "折讓獎金";
                }
                else
                {
                    dtinit.Rows[1]["STATUS"] = 3;
                    dtinit.Rows[1]["MONEY"] = 0;
                    dtinit.Rows[1]["MEMO"] = "抵扣配件款或蓋折讓單(" + douTotal + ")";
                }

            }
            return dtinit;
        }
    }
}
