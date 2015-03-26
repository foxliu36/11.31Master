using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CSaleDocPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;

        public CSaleDocPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_SALEDOCTableAdapter = new REWDataSetTableAdapters.TB_REW_SALEDOCTableAdapter();
            _myTAM.TB_REW_SALEDOCTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void DeleteByOrderno(string Orderno)
        {
            string cmdTxt = @"delete from TB_REW_SALEDOC where ORDERNO='" + Orderno + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void QuerySALEDOCSpecialsaleDataByOrderno(DataTable dt, string Orderno)
        {
            string cmdTxt = @"select * from TB_REW_SALEDOC where ORDERNO='" + Orderno + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void UpdateByAfterReward(string Orderno,int status)
        {
            string cmdTxt = @"update TB_REW_SALEDOC set STATUS = " + status + "";
            cmdTxt += " where ORDERNO='" + Orderno + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        
        public void QuerySALEDOCByREWARDDialog(DataTable dt, string Orderno)
        {
            string cmdTxt = @"select s.ORDERNO,s.INVOICE_MONEY,s.STATUS,o.BranchId,o.EngNo,o.SMId,o.SectorId,o.OrderDay,o.SaleDay,sp.SUPPORT_TYPE,";
            cmdTxt += @" cm.CAR_PRICE,b.BASEAWARD,s.DISCOUNT_MONEY,s.SUBSIDIES_MONEY,sp.DISCOUNT,sp.SUPPORT_MONEY,sp.SPECIAL_MONEY";
            cmdTxt += @" ,BIG_TYPE = IsNull((case when (isnull(sp.BIG_TYPE,'')= '0' ) then '無' ";
            cmdTxt += @" when (isnull(sp.BIG_TYPE,'')= '1' ) then '計程車' ";
            cmdTxt += @" when (isnull(sp.BIG_TYPE,'')= '2' ) then '租賃車(一般)' ";
            cmdTxt += @" when (isnull(sp.BIG_TYPE,'')= '3' ) then '租賃車(和運)' 	";
            cmdTxt += @" end),0) ";
            cmdTxt += @" ,SPECIAL_TYPE = IsNull((case when (isnull(sp.SPECIAL_TYPE,'')= '0' ) then '空車' ";
            cmdTxt += @" when (isnull(sp.SPECIAL_TYPE,'')= '1' ) then '精裝' ";
            cmdTxt += @" end),0),sp.M_APPLY_NUM,sp.APPLY_NUM ";

            cmdTxt += @" from TB_REW_SALEDOC s ";
            cmdTxt += @" inner join TB_REW_SPECIALSALE sp on sp.ORDERNO = s.ORDERNO";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" inner join TB_REW_CARMODEL cm on cm.CAR_MDL = o.CarMdl and cm.CAR_SFX = o.SFX and cm.CAR_CODE= o.CarCod";
            //cmdTxt += @" inner join TB_REW_BASEAWARD b on b.CAR_MDL = o.CarMdl and b.CAR_SFX = o.SFX and b.CAR_CODE= o.CarCod and b.CAR_YEAR = o.yeartype";
            cmdTxt += @" inner join TB_REW_BASEAWARD b on b.CAR_MDL = o.CarMdl and b.CAR_SFX = o.SFX and b.CAR_CODE= o.CarCod  ";
            cmdTxt += @" where s.ORDERNO = '" + Orderno + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QuerySALEDOCByREWAdmin(DataTable dt, string saledBdate, string saledEdate, string orderno, string branchId, string status, string saleBDay, string saleEDay, string smid, string insurance, string bigtype, string specialtype,string carcod)
        {
            string cmdTxt = @"select s.*,o.SaleDay,o.BranchId,sp.TASK_ID,sp.CREATOR as CREATOR1,o.EngNo";
            cmdTxt += @" ,STATUS_Type = IsNull((case";
            cmdTxt += @" when (isnull(s.STATUS,'')= '0' ) then '未做入實績'";
            cmdTxt += @" when (isnull(s.STATUS,'')= '1' ) then '已做入實績'";
            cmdTxt += @" end),0),u.NAME";
            cmdTxt += @" from dbo.TB_REW_SALEDOC s";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" left join TB_REW_SPECIALSALE sp on sp.ORDERNO = s.ORDERNO";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" where 1=1 ";

            if (!"".Equals(carcod))
            {
                cmdTxt += @" and o.CarCod = '" + carcod + "'";
            }

            if (!"".Equals(saledBdate))
            {
                cmdTxt += @" and o.SaleDay between '" + saledBdate + "' and '" + saledEdate + "'";
            }
            if (!"".Equals(branchId))
            {
                cmdTxt += @" and o.BranchId = '" + branchId + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += @" and s.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += @" and s.STATUS = '" + status + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and o.SMId  = '" + smid + "'";
            }
            if (!"".Equals(insurance))
            {
                cmdTxt += @" and sp.INSURANCE_TYPE = '" + insurance + "'";
            }
            if (!"".Equals(bigtype))
            {
                cmdTxt += @" and sp.BIG_TYPE = '" + bigtype + "'";
            }
            if (!"".Equals(specialtype))
            {
                cmdTxt += @" and sp.SPECIAL_TYPE = '" + specialtype + "'";
            }
            cmdTxt += @" order by o.BranchId,sp.CREATOR";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
   
        }
    }
}
