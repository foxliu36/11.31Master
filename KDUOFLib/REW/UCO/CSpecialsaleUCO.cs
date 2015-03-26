using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;
using System.Collections;

namespace KDUOFLib.REW.UCO
{
    public class CSpecialsaleUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CSpecialsalePO _CSpecialsalePO = null;
        private CSpecialsalePO CSpecialsalePO
        {
            get
            {
                if (_CSpecialsalePO == null)
                    _CSpecialsalePO = new CSpecialsalePO();
                return _CSpecialsalePO;
            }
        }
        public DataTable QueryCSpecialsaleDatas()
        {
            REWDS.TB_REW_SPECIALSALE.Clear();
            this.CSpecialsalePO.QueryDatas(REWDS.TB_REW_SPECIALSALE);
            return REWDS.TB_REW_SPECIALSALE;
        }
        public DataTable QueryCSpecialsaleDatas(string oderno)
        {
            REWDS.TB_REW_SPECIALSALE.Clear();
            this.CSpecialsalePO.QueryDatasByOrderno(REWDS.TB_REW_SPECIALSALE, oderno);
            return REWDS.TB_REW_SPECIALSALE;
        }
        public DataTable QueryDatasByOrderno(string oderno)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByOrderno(dt, oderno);
            return dt;
        }
        public DataTable QueryDatasByQuery(string BDate, string EDate, string orderno, string status, string smid)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByQuery(dt, BDate, EDate, orderno, status, smid);
            return dt;
        }
        public DataTable QueryDatasByJOBQuery(string BDate, string EDate, string orderno, string status, string groupid,string smid)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByJOBQuery(dt, BDate, EDate, orderno, status, groupid, smid);
            return dt;
        }
        public DataTable QueryDatasByJOBQueryNoDoc(string BDate, string EDate, string orderno, string status, string groupid, string smid)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByJOBQueryNoDoc(dt, BDate, EDate, orderno, status, groupid, smid);
            return dt;
        }
        public DataTable QueryDatasByJOBQueryYESDoc(string BDate, string EDate, string orderno, string status, string groupid, string smid)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByJOBQueryYESDoc(dt, BDate, EDate, orderno, status, groupid, smid);
            return dt;
        }
        
        public DataTable QueryDatasByAdminQuery(string BDate, string EDate, string orderno, string status, string branchid, string smid)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByAdminQuery(dt, BDate, EDate, orderno, status, branchid, smid);
            return dt;
        }
        public DataTable QueryDatasByAdminQuery1(string BDate, string EDate, string orderno, string status, string branchid, string smid, string insurance, string bigtype, string specialtype, string carcod, string supprotmoney, string supprottype)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByAdminQuery1(dt, BDate, EDate, orderno, status, branchid, smid, insurance, bigtype, specialtype, carcod, supprotmoney, supprottype);
            return dt;
        }
        public DataTable QueryDatasByAdminQuery1NoDoc(string BDate, string EDate, string orderno, string status, string branchid, string smid, string insurance, string bigtype, string specialtype, string carcod, string p_supportMoney, string supprottype)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByAdminQuery1NoDoc(dt, BDate, EDate, orderno, status, branchid, smid, insurance, bigtype, specialtype, carcod, p_supportMoney, supprottype);
            return dt;
        }
        public DataTable QueryDatasByAdminQuery1YESDoc(string BDate, string EDate, string orderno, string status, string branchid, string smid, string insurance, string bigtype, string specialtype, string carcod, string p_supportMoney, string supprottype)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByAdminQuery1YESDoc(dt, BDate, EDate, orderno, status, branchid, smid, insurance, bigtype, specialtype, carcod, p_supportMoney, supprottype);
            return dt;
        }

        public DataTable QueryDatasByCarQuery(string BDate, string EDate, string orderno, string branchid, string smid, string signuser)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByCarQuery(dt, BDate, EDate, orderno, branchid, smid, signuser);
            return dt;
        }
        public DataTable QueryDatasByCarSingQuery(string BDate, string EDate, string orderno, string smid, string groupid)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByCarSingQuery(dt, BDate, EDate, orderno, smid, groupid);
            return dt;
        }
        
        public DataTable QuerySignerName(string taskid)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QuerySignerName(dt, taskid);
            return dt;
        }
        public DataTable QueryDatasByNTSQuery(string BDate, string EDate, string orderno, string status, string branchid, string smid, string engo)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasByNTSQuery(dt, BDate, EDate, orderno, status, branchid, smid, engo);
            return dt;
        }
        public DataRow NewRow()
        {
            return REWDS.TB_REW_SPECIALSALE.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CSpecialsalePO.Update(REWDS);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_SPECIALSALE.Rows.Add(row);
            this.CSpecialsalePO.Update(REWDS);
        }
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CSpecialsalePO.Update(REWDS);
        }
        public void Delete(string orderno)
        {
            this.CSpecialsalePO.Delete(orderno);
        }
        public DataTable QueryDatasBySPECIALSALE(string BDate, string EDate, string orderno, string status)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasBySPECIALSALE(dt, BDate, EDate, orderno, status);
            return dt;
        }

        
        public DataTable QuerySALEDOCSpecialsaleDataByOrderno(string Orderno)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasBySPECIALSALE(dt, Orderno);
            return dt;
        }
        public DataTable QueryDatasBySPECIALSALEByNTS(string Orderno)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasBySPECIALSALEByNTS(dt, Orderno);
            return dt;
        }
        
        public DataTable QueryDatasBySaleDoc(string Orderno)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryDatasBySaleDoc(dt, Orderno);
            return dt;
        }

        /// <summary>
        /// 新增轄區販賣報表 20120522
        /// </summary>
        /// <param name="BDate">販賣起始日</param>
        /// <param name="EDate">販賣結束日</param>
        /// <param name="branchid">據點</param>
        /// <param name="al">據點所屬區域</param>
        public DataTable QueryLocationRewCount(string BranchId, string BDate, string EDate,ArrayList al)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryLocationRewCount(dt, BranchId, BDate, EDate, al);
            return dt;
        }

        /// <summary>
        /// 新增轄區販賣報表明細 20120522
        /// </summary>
        /// <param name="BDate">販賣起始日</param>
        /// <param name="EDate">販賣結束日</param>
        /// <param name="branchid">據點</param>
        /// <param name="al">據點所屬區域</param>
        public DataTable QueryLocationRewCountDetail(string BranchId, string BDate, string EDate)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QueryLocationRewCountDetail(dt, BranchId, BDate, EDate);
            return dt;
        }


        /// <summary>
        /// 新增受訂日&販賣日報表總計
        /// </summary>
        /// <param name="BDate">販賣OR受訂起始日</param>
        /// <param name="EDate">販賣OR受訂結束日</param>
        /// <param name="type">販賣OR受訂</param>
        public DataTable QuerySaleOROrederCnt(string BDate, string EDate, string Type)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QuerySaleOROrederCnt(dt, BDate, EDate, Type);
            return dt;
        }

        /// <summary>
        /// 新增受訂日&販賣日報表明細
        /// </summary>
        /// <param name="BDate">販賣OR受訂起始日</param>
        /// <param name="EDate">販賣OR受訂結束日</param>
        /// <param name="type">販賣OR受訂</param>
        public DataTable QuerySaleOROrederDet(string BDate, string EDate, string Type)
        {
            DataTable dt = new DataTable();
            this.CSpecialsalePO.QuerySaleOROrederDet(dt, BDate, EDate, Type);
            return dt;
        }
    }
}
