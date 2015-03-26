using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class COrderUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private COrderPO _COrderPO = null;
        private COrderPO COrderPO
        {
            get
            {
                if (_COrderPO == null)
                    _COrderPO = new COrderPO();
                return _COrderPO;
            }
        }

        public DataTable QueryDatasByOrderno(string orderno)
        {
            REWDS.TB_KD_ORDERS.Clear();
            this.COrderPO.QueryDatasByOrderno(REWDS.TB_KD_ORDERS, orderno);
            return REWDS.TB_KD_ORDERS;
        }
        /// <summary>
        /// 判斷是否為合法訂單
        /// </summary>
        /// <param name="orderno">訂單號碼</param>
        /// <returns>True:合法 False:不合法</returns>
        public bool IsTrueOrderNO(string orderno)
        {
            DataTable dt = new DataTable();
            this.COrderPO.QueryDatasByOrderno(dt, orderno);

            if (dt.Rows.Count <= 0)
            {
                return false;
            }
            return true;
        }

        public DataTable QueryDatasByGuid(string guid)
        {
            DataTable dt = new DataTable();
            this.COrderPO.QueryDatasByGuid(dt, guid);
            return dt;
        }

        //20140804新增run獎金明細
        public DataTable RUNBonus(string BDate, string EDate)
        {
            DataTable dt = new DataTable();
            return this.COrderPO.RUNBonus(dt, BDate, EDate);
        }

        //20140806 新增員介車表單用
        public DataTable QueryDatabyStaffCar(string Orderno)
        {
            DataTable dt = new DataTable();
            return this.COrderPO.QueryDatabyStaffCar(dt, Orderno);
        }

    }
}
